using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThread_Test
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button_CreateNewThread_Click(object sender, EventArgs e)
		{

		}

		private void button_InterruptThread_Click(object sender, EventArgs e)
		{

		}

		private void button_CreateSubthread_Click(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// Задача, заполняющая прогресс-бар. Выполняется не менее 10 секунд.
		/// </summary>
		private void ThreadStart()
		{
			progressBar.Value = 0;

			for (int i = 1; i <= 100; i++)
			{
				Thread.Sleep(100);
				progressBar.Value = i;
			}
		}
	}
}
