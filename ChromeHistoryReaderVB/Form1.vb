Partial Class Form1

    Private button1 As Button
    Private tableLayoutPanel1 As TableLayoutPanel
    Private dataGridView1 As DataGridView

    Private _dataProvider As HistoryDataProvider
    Private _source As BindingSource

    Public Sub New(dataProvider As HistoryDataProvider)
        Me._dataProvider = dataProvider
        _source = New BindingSource()
        InitializeComponent()
        Me.dataGridView1.DataSource = _source
    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs)
        RefreshContent()
    End Sub

    Private Sub dataGridView1_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hti = dataGridView1.HitTest(e.X, e.Y)
            dataGridView1.ClearSelection()
            If dataGridView1.Rows.Count > 0 AndAlso hti.RowIndex >= 0 Then
                dataGridView1.Rows(hti.RowIndex).Selected = True

                Me.dataGridView1.ContextMenu.Show(dataGridView1, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As EventArgs)
        Dim rowToDelete = Me.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected)
        Dim item = DirectCast(dataGridView1.Rows(rowToDelete).DataBoundItem, HistoryRecord)

        If item IsNot Nothing Then
            Dim rowWasDeleted = _dataProvider.DeleteHistoryItem(item.Id)
            If rowWasDeleted Then
                _source.RemoveAt(rowToDelete)
            End If
        End If
        Me.dataGridView1.ClearSelection()
    End Sub

    Private Async Sub RefreshContent()
        Dim records = Await _dataProvider.GetHistoryRecords()
        _source.DataSource = records
        Me.dataGridView1.ClearSelection()
    End Sub
End Class
