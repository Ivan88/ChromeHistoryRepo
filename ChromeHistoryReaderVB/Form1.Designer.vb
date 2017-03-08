<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()

        Me.button1 = New Button()
        Me.tableLayoutPanel1 = New TableLayoutPanel()
        Me.dataGridView1 = New DataGridView()
        Me.tableLayoutPanel1.SuspendLayout()
        DirectCast(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        ' 
        ' button1
        ' 
        Me.button1.Location = New System.Drawing.Point(3, 3)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 0
        Me.button1.Text = "Get History"
        Me.button1.UseVisualStyleBackColor = True
        AddHandler Me.button1.Click, AddressOf Me.button1_Click
        ' 
        ' tableLayoutPanel1
        ' 
        Me.tableLayoutPanel1.Anchor = (((((AnchorStyles.Top Or AnchorStyles.Bottom) Or AnchorStyles.Left) Or AnchorStyles.Right)))
        Me.tableLayoutPanel1.ColumnCount = 1
        Me.tableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        Me.tableLayoutPanel1.Controls.Add(Me.button1, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.dataGridView1, 0, 1)
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 2
        Me.tableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 35.0F))
        Me.tableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 95.0F))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(1131, 572)
        Me.tableLayoutPanel1.TabIndex = 1
        ' 
        ' dataGridView1
        ' 
        Me.dataGridView1.Anchor = (((((AnchorStyles.Top Or AnchorStyles.Bottom) Or AnchorStyles.Left) Or AnchorStyles.Right)))
        Me.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Location = New System.Drawing.Point(3, 38)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.Size = New System.Drawing.Size(1125, 531)
        Me.dataGridView1.TabIndex = 1
        Me.dataGridView1.Columns.Add("Id", "Id")
        Me.dataGridView1.Columns(0).[ReadOnly] = True
        Me.dataGridView1.Columns(0).Visible = False
        Me.dataGridView1.Columns(0).DataPropertyName = "Id"
        Me.dataGridView1.Columns.Add("Url", "Url")
        Me.dataGridView1.Columns(1).[ReadOnly] = True
        Me.dataGridView1.Columns(1).DataPropertyName = "Url"
        Me.dataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dataGridView1.Columns(1).FillWeight = 40
        Me.dataGridView1.Columns.Add("Title", "Title")
        Me.dataGridView1.Columns(2).[ReadOnly] = True
        Me.dataGridView1.Columns(2).DataPropertyName = "Title"
        Me.dataGridView1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dataGridView1.Columns(2).FillWeight = 30
        Me.dataGridView1.Columns.Add("VisitDate", "Visited Date")
        Me.dataGridView1.Columns(3).[ReadOnly] = True
        Me.dataGridView1.Columns(3).DataPropertyName = "VisitedDate"
        Me.dataGridView1.Columns(3).Width = 120
        Me.dataGridView1.Columns.Add("VisitCount", "Visit Count")
        Me.dataGridView1.Columns(4).[ReadOnly] = True
        Me.dataGridView1.Columns(4).DataPropertyName = "VisitCount"
        Me.dataGridView1.Columns(4).Width = 120
        Me.dataGridView1.Columns.Add("TypedCount", "Typed Count")
        Me.dataGridView1.Columns(5).[ReadOnly] = True
        Me.dataGridView1.Columns(5).DataPropertyName = "TypedCount"
        Me.dataGridView1.Columns(5).Width = 120

        AddHandler Me.dataGridView1.MouseDown, AddressOf dataGridView1_MouseDown
        Me.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        Me.dataGridView1.ContextMenu = New ContextMenu()
        Me.dataGridView1.ContextMenu.MenuItems.Add(New MenuItem("Delete"))
        AddHandler Me.dataGridView1.ContextMenu.MenuItems(0).Click, AddressOf MenuItem_Click
        ' 
        ' Form1
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1155, 596)
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.Name = "Form1"
        Me.Text = "Google Chrome History Viewer"
        Me.tableLayoutPanel1.ResumeLayout(False)
        DirectCast(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

End Class
