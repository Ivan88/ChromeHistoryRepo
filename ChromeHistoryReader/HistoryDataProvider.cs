using Community.CsharpSqlite.SQLiteClient;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;

namespace ChromeHistoryReader
{
	public class HistoryDataProvider
	{
		#region Chrome history methods

		private const string sqlCommandText = "select * from urls order by last_visit_time desc";
		private const string deleteCommandText = "delete from 'urls' where id = @id";

		public Task<BindingList<HistoryRecord>> GetChromeHistoryRecords()
		{
			return Task.Run<BindingList<HistoryRecord>>(() =>
			{
				var result = new BindingList<HistoryRecord>();
				var filePath = GetChromeHistoryFilePath();

				try
				{
					using (var conn = new SqliteConnection("Version=3,uri=file:" + filePath))
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
										Url = (String)reader["url"],
										VisitCount = (int)reader["visit_count"],
										TypedCount = (int)reader["typed_count"]
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
				catch (SqliteException)
				{
					NotificationSender.ShowMessage("Cannot access the file with Chrome history, please close Google Chrome browser.");
				}
				catch (Exception)
				{
					NotificationSender.ShowMessage("An unexpected error appeared.");
				}
				return result;
			});
		}

		public bool DeleteChromeHistoryItem(int id)
		{
			var filePath = GetChromeHistoryFilePath();

			try
			{
				using (var conn = new SqliteConnection("Version=3,uri=file:" + filePath))
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
				}
				return true;
			}
			catch
			{
				NotificationSender.ShowMessage("A history item deletion was not successful.");
				return false;
			}
		}

		private string GetChromeHistoryFilePath()
		{
			var chromeHistoryFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Google\Chrome\User Data\Default\History";

			if (!File.Exists(chromeHistoryFile))
			{
				throw new Exception("Chrome history was not found on your computer. It seems like you did not install Google Chrome browser.");
			}

			return chromeHistoryFile;
		}

		#endregion
	}
}
