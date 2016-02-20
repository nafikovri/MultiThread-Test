namespace MultiThread_Test
{
	partial class Form1
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.label_threadsInQueue_static = new System.Windows.Forms.Label();
			this.label_threadsInQueue = new System.Windows.Forms.Label();
			this.button_CreateNewThread = new System.Windows.Forms.Button();
			this.button_InterruptThread = new System.Windows.Forms.Button();
			this.button_CreateSubthread = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(12, 12);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(336, 26);
			this.progressBar.TabIndex = 0;
			// 
			// label_threadsInQueue_static
			// 
			this.label_threadsInQueue_static.AutoSize = true;
			this.label_threadsInQueue_static.Location = new System.Drawing.Point(13, 45);
			this.label_threadsInQueue_static.Name = "label_threadsInQueue_static";
			this.label_threadsInQueue_static.Size = new System.Drawing.Size(106, 13);
			this.label_threadsInQueue_static.TabIndex = 1;
			this.label_threadsInQueue_static.Text = "Потоков в очереди:";
			// 
			// label_threadsInQueue
			// 
			this.label_threadsInQueue.AutoSize = true;
			this.label_threadsInQueue.Location = new System.Drawing.Point(126, 45);
			this.label_threadsInQueue.Name = "label_threadsInQueue";
			this.label_threadsInQueue.Size = new System.Drawing.Size(13, 13);
			this.label_threadsInQueue.TabIndex = 2;
			this.label_threadsInQueue.Text = "0";
			// 
			// button_CreateNewThread
			// 
			this.button_CreateNewThread.Location = new System.Drawing.Point(12, 70);
			this.button_CreateNewThread.Name = "button_CreateNewThread";
			this.button_CreateNewThread.Size = new System.Drawing.Size(201, 23);
			this.button_CreateNewThread.TabIndex = 3;
			this.button_CreateNewThread.Text = "Создать новый поток";
			this.button_CreateNewThread.UseVisualStyleBackColor = true;
			this.button_CreateNewThread.Click += new System.EventHandler(this.button_CreateNewThread_Click);
			// 
			// button_InterruptThread
			// 
			this.button_InterruptThread.Location = new System.Drawing.Point(219, 70);
			this.button_InterruptThread.Name = "button_InterruptThread";
			this.button_InterruptThread.Size = new System.Drawing.Size(129, 23);
			this.button_InterruptThread.TabIndex = 3;
			this.button_InterruptThread.Text = "Завершить текущий";
			this.button_InterruptThread.UseVisualStyleBackColor = true;
			this.button_InterruptThread.Click += new System.EventHandler(this.button_InterruptThread_Click);
			// 
			// button_CreateSubthread
			// 
			this.button_CreateSubthread.Location = new System.Drawing.Point(12, 99);
			this.button_CreateSubthread.Name = "button_CreateSubthread";
			this.button_CreateSubthread.Size = new System.Drawing.Size(201, 23);
			this.button_CreateSubthread.TabIndex = 3;
			this.button_CreateSubthread.Text = "Создать новый подпоток в текущем";
			this.button_CreateSubthread.UseVisualStyleBackColor = true;
			this.button_CreateSubthread.Click += new System.EventHandler(this.button_CreateSubthread_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(360, 132);
			this.Controls.Add(this.button_InterruptThread);
			this.Controls.Add(this.button_CreateSubthread);
			this.Controls.Add(this.button_CreateNewThread);
			this.Controls.Add(this.label_threadsInQueue);
			this.Controls.Add(this.label_threadsInQueue_static);
			this.Controls.Add(this.progressBar);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label label_threadsInQueue_static;
		private System.Windows.Forms.Label label_threadsInQueue;
		private System.Windows.Forms.Button button_CreateNewThread;
		private System.Windows.Forms.Button button_InterruptThread;
		private System.Windows.Forms.Button button_CreateSubthread;
	}
}

