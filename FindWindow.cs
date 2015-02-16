using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FooBorf
{
	public partial class FindWindow : Form
	{
		private MainForm main;

		public FindWindow()
		{
			InitializeComponent();
		}
		public FindWindow(MainForm main)
		{
			this.main = main;
			InitializeComponent();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			results.Items.Clear();
			int id = main.tabControl1.SelectedIndex;
			PlayList p = null;
			if (id == 0)
				p = main.queuePlayList;
			else
				p = main.playlists[id - 1];

			string[] filters = searchTerms.Text.ToLower().Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);

			foreach (ListViewItem it in p.listview.Items)
			{
				PlayListItem pi = (PlayListItem) it.Tag;
				bool ok = true;
				foreach (string filter in filters)
				{
					if (!pi.file.ToLower().Contains(filter))
					{
						ok = false;
						break;
					}
				}
				if (ok)
				{
					ListViewItem listviewItem = (ListViewItem) it.Clone();
					listviewItem.SubItems.RemoveAt(0);
					listviewItem.SubItems.RemoveAt(0);
					listviewItem.SubItems.RemoveAt(2);
					listviewItem.Tag = it;
					results.Items.Add(listviewItem);
				}
			}
			if (results.Items.Count > 0)
				results.Items[0].Selected = true;
			results.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
		}

		private void results_DoubleClick(object sender, EventArgs e)
		{
			if (results.Items.Count > 0)
			{
				ListViewItem item = ((ListViewItem) results.SelectedItems[0].Tag);

				main.activateItem(item);

			}
			Close();
		}

		private void searchTerms_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				results_DoubleClick(sender, e);
			}
			if (e.KeyCode == Keys.Down)
			{
				results.Focus();
				SendKeys.Send(e.KeyCode.ToString());
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private void results_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
				results_DoubleClick(sender, e);
		}
	}
}
