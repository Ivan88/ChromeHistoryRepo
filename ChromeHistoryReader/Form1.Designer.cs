﻿using System.Windows.Forms;
namespace ChromeHistoryReader
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();

			this.button1 = new Button();
			this.tableLayoutPanel1 = new TableLayoutPanel();
			this.dataGridView1 = new DataGridView();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(3, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Get History";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 95F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1131, 572);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(3, 38);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(1125, 531);
			this.dataGridView1.TabIndex = 1;
			this.dataGridView1.Columns.Add("Id", "Id");
			this.dataGridView1.Columns[0].ReadOnly = true;
			this.dataGridView1.Columns[0].Visible = false;
			this.dataGridView1.Columns[0].DataPropertyName = "Id";
			this.dataGridView1.Columns.Add("Url", "Url");
			this.dataGridView1.Columns[1].ReadOnly = true;
			this.dataGridView1.Columns[1].DataPropertyName = "Url";
			this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridView1.Columns[1].FillWeight = 40;
			this.dataGridView1.Columns.Add("Title", "Title");
			this.dataGridView1.Columns[2].ReadOnly = true;
			this.dataGridView1.Columns[2].DataPropertyName = "Title";
			this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridView1.Columns[2].FillWeight = 30;
			this.dataGridView1.Columns.Add("VisitDate", "Visited Date");
			this.dataGridView1.Columns[3].ReadOnly = true;
			this.dataGridView1.Columns[3].DataPropertyName = "VisitedDate";
			this.dataGridView1.Columns[3].Width = 120;
			this.dataGridView1.Columns.Add("VisitCount", "Visit Count");
			this.dataGridView1.Columns[4].ReadOnly = true;
			this.dataGridView1.Columns[4].DataPropertyName = "VisitCount";
			this.dataGridView1.Columns[4].Width = 120;
			this.dataGridView1.Columns.Add("TypedCount", "Typed Count");
			this.dataGridView1.Columns[5].ReadOnly = true;
			this.dataGridView1.Columns[5].DataPropertyName = "TypedCount";
			this.dataGridView1.Columns[5].Width = 120;

			this.dataGridView1.MouseDown += dataGridView1_MouseDown;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			this.dataGridView1.ContextMenu = new ContextMenu();
			this.dataGridView1.ContextMenu.MenuItems.Add(new MenuItem("Delete"));
			this.dataGridView1.ContextMenu.MenuItems[0].Click += MenuItem_Click;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1155, 596);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Form1";
			this.Text = "Google Chrome History Viewer";
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
		}

		#endregion

		private Button button1;
		private TableLayoutPanel tableLayoutPanel1;
		private DataGridView dataGridView1;
	}
}

