using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
