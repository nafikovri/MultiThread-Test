using System;
using System.Threading;
using System.Windows.Forms;

namespace MultiThread_Test
{
	public partial class Form1 : Form
	{
		private int _countThreads;

		private Thread _mainThread;
		private Thread _currentThread;

		private bool _closing = false;
		private readonly bool _shouldBeClosedIfNoThreads = false;

		private readonly object _counterLocker = new object();
		private readonly object _currentThreadLocker = new object();
		private readonly Semaphore _semaphoreForProgressBar = new Semaphore(1, 1);
		private readonly SemaphoreSlim _semaphoreForCounter = new SemaphoreSlim(0);

		private readonly int _countModalForms;

		#region Constructors

		public Form1(int countModalForms)
		{
			_countModalForms = countModalForms;
			_countThreads = 0;

			InitializeComponent();
		}

		public Form1(int countModalForms, int countThreads) : this(countModalForms)
		{
			_countThreads = countThreads;
			_shouldBeClosedIfNoThreads = true;

			for (int i = 0; i < _countThreads; i++)
			{
				_semaphoreForCounter.Release();
			}

			base.Text = "Form1 (модальная)";
			label_threadsInQueue.Text = _countThreads.ToString();
		}

		#endregion

		#region Form Events

		private void Form1_Shown(object sender, EventArgs e) {}

		private void Form1_Load(object sender, EventArgs e)
		{
			if (_countModalForms == 0)
				button_CreateSubthread.Enabled = false;

			_mainThread = new Thread(ControlThread);
			_mainThread.Start();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			_closing = true;

			if (_countThreads != 0)
			{
				e.Cancel = true;
			}
			else
			{
				if (_mainThread != null)
					_mainThread.Abort();
			}
		}

		#endregion

		#region Button Events

		private void button_CreateNewThread_Click(object sender, EventArgs e)
		{
			_semaphoreForCounter.Release();

			lock (_counterLocker)
			{
				_countThreads++;
				label_threadsInQueue.Text = _countThreads.ToString();
			}
		}

		private void button_InterruptThread_Click(object sender, EventArgs e)
		{
			_semaphoreForProgressBar.WaitOne();

			lock (_currentThreadLocker)
			{
				if (_currentThread != null)
					_currentThread.Abort();
			}

			_semaphoreForProgressBar.Release();
		}

		private void button_CreateSubthread_Click(object sender, EventArgs e)
		{
			_semaphoreForProgressBar.WaitOne();

			var modalForm = new Form1(_countModalForms - 1, 1);
			modalForm.ShowDialog();

			_semaphoreForProgressBar.Release();
		}

		#endregion


		private void ControlThread()
		{
			while (true)
			{
				// снимает нагрузку с ЦП (в отличие от проверки счетчика потоков)
				_semaphoreForCounter.Wait();

				StartThreadAndWait(FillProgressBar);

				lock (_currentThreadLocker)
				{
					_currentThread = null;
				}

				lock (_counterLocker)
				{
					_countThreads--;
					SetLabelThreadsText(_countThreads.ToString());
				}

				if (_countThreads == 0 &&
					(_closing || _shouldBeClosedIfNoThreads))
					break;
			}

			this.BeginInvoke(new Action(this.Close));
		}

		private void StartThreadAndWait(ThreadStart threadStart)
		{
			lock (_currentThreadLocker)
			{
				// создает новый поток
				_currentThread = new Thread(threadStart);
				_currentThread.Start();
			}

			// обеспечивает выполнение по очереди
			_currentThread.Join();
		}

		/// <summary>
		/// Задача, заполняющая прогресс-бар. Выполняется не менее 10 секунд.
		/// </summary>
		private void FillProgressBar()
		{
			SetProgressBarValue(0);

			for (int i = 1; i <= 100; i++)
			{
				_semaphoreForProgressBar.WaitOne();
				Thread.Sleep(100);
				_semaphoreForProgressBar.Release();

				SetProgressBarValue(i);
			}
		}


		private void SetProgressBarValue(int value)
		{
			if (progressBar != null && !progressBar.Disposing)
				progressBar.BeginInvoke(new Action(() => progressBar.Value = value));
		}

		private void SetLabelThreadsText(string text)
		{
			if (label_threadsInQueue != null && !label_threadsInQueue.Disposing)
				label_threadsInQueue.BeginInvoke(new Action(() => label_threadsInQueue.Text = text));
		}
	}
}