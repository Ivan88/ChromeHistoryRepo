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

		public Form1(HistoryDataProvider dataProvider)
		{
			this._dataProvider = dataProvider;
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var records = _dataProvider.GetHistoryRecords().ToArray();
			dataGridView1.DataSource = records;
		}

		private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				ContextMenu m = new ContextMenu();
				m.MenuItems.Add(new MenuItem("Delete"));

				int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

				if (currentMouseOverRow >= 0)
				{
					m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
				}

				//m.Show(dataGridView1, new Point(e.X, e.Y));

			}
		}
	}
}
