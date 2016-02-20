using System;
using System.Windows.Forms;

namespace MultiThread_Test
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			const int countModalForms = 5;
			Application.Run(new Form1(countModalForms));
		}
	}
}
