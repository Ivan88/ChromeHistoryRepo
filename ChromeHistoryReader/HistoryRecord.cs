﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeHistoryReader
{
	public class HistoryRecord
	{
		public int Id { get; set; }
		public string Url { get; set; }
		public string Title { get; set; }
		public DateTime VisitedDate { get; set; }
		public int VisitedCount { get; set; }
		public int TypedCount { get; set; }
	}
}
