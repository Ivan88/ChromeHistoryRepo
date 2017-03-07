using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChromeHistoryReader
{
	public class HistoryRecord : INotifyPropertyChanged
	{
		public int Id { get; set; }
		public string Url { get; set; }
		public string Title { get; set; }
		public DateTime VisitedDate { get; set; }
		public int VisitCount { get; set; }
		public int TypedCount { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
