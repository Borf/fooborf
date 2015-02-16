using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FooBorf
{
	public class PlayList
	{
		public List<PlayListItem> items = new List<PlayListItem>();

		public string name;
		public TabPage tab;
		public ListView listview;

		public PlayList(string value, MainForm mainForm)
		{
			if (value == null || mainForm == null)
				return;
			this.name = value;

			tab = new System.Windows.Forms.TabPage();
			tab.Name = value;
			tab.Text = value;


			ColumnHeader playingIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			ColumnHeader Track = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			ColumnHeader Artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			ColumnHeader Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			ColumnHeader Album = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			ColumnHeader Filename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			playingIndex.Text = "";
			playingIndex.Width = 14;

			Track.Text = "Track";
			Artist.Text = "Artist";
			Title.Text = "Title";
			Album.Text = "Album";
			Filename.Text = "Filename";

			

			this.listview = new ListView();
			this.listview.AllowColumnReorder = true;
			this.listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            playingIndex,
            Track,
            Artist,
            Title,
            Album,
            Filename});
			this.listview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listview.FullRowSelect = true;
			this.listview.Location = new System.Drawing.Point(3, 3);
			this.listview.Name = "queue";
			this.listview.ShowGroups = false;
			this.listview.Size = new System.Drawing.Size(1048, 540);
			this.listview.SmallImageList = mainForm.treeList;
			this.listview.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listview.TabIndex = 0;
			this.listview.UseCompatibleStateImageBehavior = false;
			this.listview.HideSelection = false;
			this.listview.View = System.Windows.Forms.View.Details;


			this.listview.DoubleClick += (sender, args) =>
			{
				if(listview.SelectedItems.Count > 0)
					mainForm.activateItem(listview.SelectedItems[0]);
			};

			this.tab.Controls.Add(listview);
		}

	}
}