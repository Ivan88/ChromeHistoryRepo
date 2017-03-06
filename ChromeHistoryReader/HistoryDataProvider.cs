using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeHistoryReader
{
	public class HistoryDataProvider
	{
		public IEnumerable<HistoryRecord> GetHistoryRecords()
		{
			return Enumerable.Empty<HistoryRecord>();
		}
	}
}
