Public Class NotificationSender
    Public Shared Sub ShowMessage(message As String)
        If Not [String].IsNullOrEmpty(message) Then
            MessageBox.Show(message, "An error!")
        End If
    End Sub
End Class
