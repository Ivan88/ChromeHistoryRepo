using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				ContextMenu m = new ContextMenu();
				m.MenuItems.Add(new MenuItem("Delete"));

				int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;
			}
		}

		private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				var hti = dataGridView1.HitTest(e.X, e.Y);
				dataGridView1.ClearSelection();
				if (dataGridView1.Rows.Count > 0 && hti.RowIndex >= 0)
				{
					dataGridView1.Rows[hti.RowIndex].Selected = true;

					this.ContextMenu.Show(dataGridView1, new Point(e.X, e.Y));
				}
			}
		}

		private void Form1_Click(object sender, System.EventArgs e)
		{
			var rowToDelete = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
			var item = (HistoryRecord)dataGridView1.Rows[rowToDelete].DataBoundItem;
			var rowWasDeleted = _dataProvider.DeleteHistoryItem(item.Id);
			if (rowWasDeleted)
			{
				_source.RemoveAt(rowToDelete);
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
