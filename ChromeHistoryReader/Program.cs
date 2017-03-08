using System;
using System.Windows.Forms;

namespace ChromeHistoryReader
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.ThreadException += Application_ThreadException;
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1(new HistoryDataProvider()));
		}

		private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			if (e != null &&
				e.Exception != null &&
				!String.IsNullOrEmpty(e.Exception.Message))
			{
				NotificationSender.ShowMessage(e.Exception.Message);
			}
		}
	}
}
