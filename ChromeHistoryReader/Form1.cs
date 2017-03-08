using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChromeHistoryReader
{
	public partial class Form1 : Form
	{
		private HistoryDataProvider _dataProvider;
		private BindingSource _source;

		public Form1(HistoryDataProvider dataProvider)
		{
			this._dataProvider = dataProvider;
			_source = new BindingSource();
			InitializeComponent();
			this.dataGridView1.DataSource = _source;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			RefreshContent();
		}

		private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				var hti = dataGridView1.HitTest(e.X, e.Y);
				dataGridView1.ClearSelection();
				if (dataGridView1.Rows.Count > 0 && hti.RowIndex >= 0)
				{
					dataGridView1.Rows[hti.RowIndex].Selected = true;

					this.dataGridView1.ContextMenu.Show(dataGridView1, new Point(e.X, e.Y));
				}
			}
		}

		private void MenuItem_Click(object sender, EventArgs e)
		{
			var rowToDelete = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
			var item = (HistoryRecord)dataGridView1.Rows[rowToDelete].DataBoundItem;

			if (item != null)
			{
				var rowWasDeleted = _dataProvider.DeleteHistoryItem(item.Id);
				if (rowWasDeleted)
				{
					_source.RemoveAt(rowToDelete);
				}
			}
			this.dataGridView1.ClearSelection();
		}

		private async void RefreshContent()
		{
			var records = await _dataProvider.GetHistoryRecords();
			_source.DataSource = records;
			this.dataGridView1.ClearSelection();
		}
	}
}
