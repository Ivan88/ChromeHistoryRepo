using Community.CsharpSqlite.SQLiteClient;
using System;
using System.Collections.Generic;
using System.IO;

namespace ChromeHistoryReader
{
	public class HistoryDataProvider
	{
		private const string sqlCommandText = "select * from urls order by last_visit_time desc";
		private const string deleteCommandText = "delete from 'urls' where id = @id";

		public IEnumerable<HistoryRecord> GetHistoryRecords()
		{
			var result = new List<HistoryRecord>();
			var chromeHistoryFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Google\Chrome\User Data\Default\History";

			if (File.Exists(chromeHistoryFile))
			{
				using (var conn = new SqliteConnection("Version=3,uri=file:" + chromeHistoryFile))
				{
					conn.Open();
					using (var command = new SqliteCommand(sqlCommandText, conn))
					{
						using (var reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								var historyItem = new HistoryRecord
								{
									Id = (int)reader["id"],
									Title = (String)reader["title"],
									Url = (String)reader["url"]
								};
								// Chrome stores time elapsed since Jan 1, 1601 (UTC format) in microseconds
								var utcMicroSeconds = Convert.ToInt64(reader["last_visit_time"]);

								// Windows file time UTC is in nanoseconds, so multiplying by 10
								var gmtTime = DateTime.FromFileTimeUtc(10 * utcMicroSeconds);

								// Converting to local time
								var localTime = TimeZoneInfo.ConvertTimeFromUtc(gmtTime, TimeZoneInfo.Local);
								historyItem.VisitedDate = localTime;

								result.Add(historyItem);
							}
						}
					}
				}
			}

			return result;
		}

		public void DeleteHistoryItem(int id)
		{
			var chromeHistoryFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Google\Chrome\User Data\Default\History";

			if (File.Exists(chromeHistoryFile))
			{
				using (var conn = new SqliteConnection("Version=3,uri=file:" + chromeHistoryFile))
				{
					conn.Open();
					var text = deleteCommandText + id.ToString() + ";";
					using (var command = new SqliteCommand())
					{
						var trans = conn.BeginTransaction();
						command.Connection = conn;
						command.CommandText = deleteCommandText;
						command.Parameters.Add(new SqliteParameter("@id", id));
						command.ExecuteNonQuery();
						trans.Commit();
					}
					conn.Close();
				}
			}
		}
	}
}
