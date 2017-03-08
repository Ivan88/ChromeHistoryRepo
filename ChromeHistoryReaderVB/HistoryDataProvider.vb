Imports System.ComponentModel
Imports System.IO
Imports Community.CsharpSqlite.SQLiteClient

Public Class HistoryDataProvider
    Private Const sqlCommandText As String = "select * from urls order by last_visit_time desc"
    Private Const deleteCommandText As String = "delete from 'urls' where id = @id"

    Public Function GetHistoryRecords() As Task(Of BindingList(Of HistoryRecord))
        Return Task.Run(Of BindingList(Of HistoryRecord))(Function()
                                                              Dim result = New BindingList(Of HistoryRecord)()
                                                              Dim filePath = GetHistoryFilePath()

                                                              Try
                                                                  Using conn = New SqliteConnection(Convert.ToString("Version=3,uri=file:") & filePath)
                                                                      conn.Open()
                                                                      Using command = New SqliteCommand(sqlCommandText, conn)
                                                                          Using reader = command.ExecuteReader()
                                                                              While reader.Read()
                                                                                  Dim historyItem = New HistoryRecord()
                                                                                  historyItem.Id = CInt(reader("id"))
                                                                                  historyItem.Title = DirectCast(reader("title"), [String])
                                                                                  historyItem.Url = DirectCast(reader("url"), [String])
                                                                                  historyItem.VisitCount = CInt(reader("visit_count"))
                                                                                  historyItem.TypedCount = CInt(reader("typed_count"))

                                                                                  ' Chrome stores time elapsed since Jan 1, 1601 (UTC format) in microseconds
                                                                                  Dim utcMicroSeconds = Convert.ToInt64(reader("last_visit_time"))

                                                                                  ' Windows file time UTC is in nanoseconds, so multiplying by 10
                                                                                  Dim gmtTime = DateTime.FromFileTimeUtc(10 * utcMicroSeconds)

                                                                                  ' Converting to local time
                                                                                  Dim localTime = TimeZoneInfo.ConvertTimeFromUtc(gmtTime, TimeZoneInfo.Local)
                                                                                  historyItem.VisitedDate = localTime

                                                                                  result.Add(historyItem)
                                                                              End While
                                                                          End Using
                                                                      End Using
                                                                  End Using
                                                              Catch generatedExceptionName As SqliteException
                                                                  NotificationSender.ShowMessage("Cannot access the file with Chrome history, please close Google Chrome browser.")
                                                              Catch generatedExceptionName As Exception
                                                                  NotificationSender.ShowMessage("An unexpected error appeared.")
                                                              End Try
                                                              Return result

                                                          End Function)
    End Function

    Public Function DeleteHistoryItem(id As Integer) As Boolean
        Dim filePath = GetHistoryFilePath()

        Try
            Using conn = New SqliteConnection(Convert.ToString("Version=3,uri=file:") & filePath)
                conn.Open()
                Dim text = (deleteCommandText & id.ToString()) + ";"
                Using command = New SqliteCommand()
                    Dim trans = conn.BeginTransaction()
                    command.Connection = conn
                    command.CommandText = deleteCommandText
                    command.Parameters.Add(New SqliteParameter("@id", id))
                    command.ExecuteNonQuery()
                    trans.Commit()
                End Using
            End Using
            Return True
        Catch
            NotificationSender.ShowMessage("A history item deletion was not successful.")
            Return False
        End Try
    End Function

    Private Function GetHistoryFilePath() As String
        Dim chromeHistoryFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\Google\Chrome\User Data\Default\History"

        If Not File.Exists(chromeHistoryFile) Then
            Throw New Exception("Chrome history was not found on your computer. It seems like you did not install Google Chrome browser.")
        End If

        Return chromeHistoryFile
    End Function
End Class
