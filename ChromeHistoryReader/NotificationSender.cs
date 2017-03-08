using System;
using System.Windows.Forms;

namespace ChromeHistoryReader
{
	public static class NotificationSender
	{
		public static void ShowMessage(string message)
		{
			if (!String.IsNullOrEmpty(message))
			{
				MessageBox.Show(message, "An error!");
			}
		}
	}
}
