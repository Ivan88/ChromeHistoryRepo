using System;

namespace ChromeHistoryReader
{
	public class HistoryRecord
	{
		public int Id { get; set; }
		public string Url { get; set; }
		public string Title { get; set; }
		public DateTime VisitedDate { get; set; }
		public int VisitCount { get; set; }
		public int TypedCount { get; set; }
	}
}
