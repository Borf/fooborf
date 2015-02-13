namespace FooBorf
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.playbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.libraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnPrev = new System.Windows.Forms.ToolStripButton();
			this.btnPlayPause = new System.Windows.Forms.ToolStripButton();
			this.btnStop = new System.Windows.Forms.ToolStripButton();
			this.btnNext = new System.Windows.Forms.ToolStripButton();
			this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.AlbumListTabstrip = new System.Windows.Forms.TabControl();
			this.tabAlbumTree = new System.Windows.Forms.TabPage();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.treeList = new System.Windows.Forms.ImageList(this.components);
			this.tabAlbumList = new System.Windows.Forms.TabPage();
			this.tabAlbumTags = new System.Windows.Forms.TabPage();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabQueue = new System.Windows.Forms.TabPage();
			this.playList = new System.Windows.Forms.ListView();
			this.Track = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Album = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Filename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.playingIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.AlbumListTabstrip.SuspendLayout();
			this.tabAlbumTree.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabQueue.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.playbackToolStripMenuItem,
            this.libraryToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1285, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// playbackToolStripMenuItem
			// 
			this.playbackToolStripMenuItem.Name = "playbackToolStripMenuItem";
			this.playbackToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.playbackToolStripMenuItem.Text = "Playback";
			// 
			// libraryToolStripMenuItem
			// 
			this.libraryToolStripMenuItem.Name = "libraryToolStripMenuItem";
			this.libraryToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
			this.libraryToolStripMenuItem.Text = "Library";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrev,
            this.btnPlayPause,
            this.btnStop,
            this.btnNext,
            this.toolStripComboBox1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1285, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnPrev
			// 
			this.btnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
			this.btnPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPrev.Name = "btnPrev";
			this.btnPrev.Size = new System.Drawing.Size(23, 22);
			this.btnPrev.Text = "toolStripButton1";
			this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
			// 
			// btnPlayPause
			// 
			this.btnPlayPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPlayPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayPause.Image")));
			this.btnPlayPause.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPlayPause.Name = "btnPlayPause";
			this.btnPlayPause.Size = new System.Drawing.Size(23, 22);
			this.btnPlayPause.Text = "toolStripButton2";
			this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
			// 
			// btnStop
			// 
			this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
			this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(23, 22);
			this.btnStop.Text = "toolStripButton3";
			// 
			// btnNext
			// 
			this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
			this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(23, 22);
			this.btnNext.Text = "toolStripButton4";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// toolStripComboBox1
			// 
			this.toolStripComboBox1.Name = "toolStripComboBox1";
			this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 49);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.AlbumListTabstrip);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
			this.splitContainer1.Size = new System.Drawing.Size(1285, 572);
			this.splitContainer1.SplitterDistance = 219;
			this.splitContainer1.TabIndex = 2;
			// 
			// AlbumListTabstrip
			// 
			this.AlbumListTabstrip.Controls.Add(this.tabAlbumTree);
			this.AlbumListTabstrip.Controls.Add(this.tabAlbumList);
			this.AlbumListTabstrip.Controls.Add(this.tabAlbumTags);
			this.AlbumListTabstrip.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AlbumListTabstrip.Location = new System.Drawing.Point(0, 0);
			this.AlbumListTabstrip.Name = "AlbumListTabstrip";
			this.AlbumListTabstrip.SelectedIndex = 0;
			this.AlbumListTabstrip.Size = new System.Drawing.Size(219, 572);
			this.AlbumListTabstrip.TabIndex = 1;
			// 
			// tabAlbumTree
			// 
			this.tabAlbumTree.Controls.Add(this.treeView1);
			this.tabAlbumTree.Location = new System.Drawing.Point(4, 22);
			this.tabAlbumTree.Name = "tabAlbumTree";
			this.tabAlbumTree.Padding = new System.Windows.Forms.Padding(3);
			this.tabAlbumTree.Size = new System.Drawing.Size(211, 546);
			this.tabAlbumTree.TabIndex = 0;
			this.tabAlbumTree.Text = "Treeview";
			this.tabAlbumTree.UseVisualStyleBackColor = true;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.ImageIndex = 0;
			this.treeView1.ImageList = this.treeList;
			this.treeView1.Location = new System.Drawing.Point(3, 3);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = 0;
			this.treeView1.Size = new System.Drawing.Size(205, 540);
			this.treeView1.TabIndex = 0;
			this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
			// 
			// treeList
			// 
			this.treeList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeList.ImageStream")));
			this.treeList.TransparentColor = System.Drawing.Color.Transparent;
			this.treeList.Images.SetKeyName(0, "folder.png");
			this.treeList.Images.SetKeyName(1, "song.png");
			// 
			// tabAlbumList
			// 
			this.tabAlbumList.Location = new System.Drawing.Point(4, 22);
			this.tabAlbumList.Name = "tabAlbumList";
			this.tabAlbumList.Padding = new System.Windows.Forms.Padding(3);
			this.tabAlbumList.Size = new System.Drawing.Size(211, 546);
			this.tabAlbumList.TabIndex = 1;
			this.tabAlbumList.Text = "Explorer View";
			this.tabAlbumList.UseVisualStyleBackColor = true;
			// 
			// tabAlbumTags
			// 
			this.tabAlbumTags.Location = new System.Drawing.Point(4, 22);
			this.tabAlbumTags.Name = "tabAlbumTags";
			this.tabAlbumTags.Padding = new System.Windows.Forms.Padding(3);
			this.tabAlbumTags.Size = new System.Drawing.Size(211, 546);
			this.tabAlbumTags.TabIndex = 2;
			this.tabAlbumTags.Text = "Tag view";
			this.tabAlbumTags.UseVisualStyleBackColor = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabQueue);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1062, 572);
			this.tabControl1.TabIndex = 0;
			// 
			// tabQueue
			// 
			this.tabQueue.Controls.Add(this.playList);
			this.tabQueue.Location = new System.Drawing.Point(4, 22);
			this.tabQueue.Name = "tabQueue";
			this.tabQueue.Padding = new System.Windows.Forms.Padding(3);
			this.tabQueue.Size = new System.Drawing.Size(1054, 546);
			this.tabQueue.TabIndex = 0;
			this.tabQueue.Text = "Queue";
			this.tabQueue.UseVisualStyleBackColor = true;
			// 
			// playList
			// 
			this.playList.AllowColumnReorder = true;
			this.playList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.playingIndex,
            this.Track,
            this.Artist,
            this.Title,
            this.Album,
            this.Filename});
			this.playList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.playList.FullRowSelect = true;
			this.playList.Location = new System.Drawing.Point(3, 3);
			this.playList.Name = "playList";
			this.playList.ShowGroups = false;
			this.playList.Size = new System.Drawing.Size(1048, 540);
			this.playList.SmallImageList = this.treeList;
			this.playList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.playList.TabIndex = 0;
			this.playList.UseCompatibleStateImageBehavior = false;
			this.playList.View = System.Windows.Forms.View.Details;
			// 
			// Track
			// 
			this.Track.Text = "Track";
			// 
			// Artist
			// 
			this.Artist.Text = "Artist";
			// 
			// Title
			// 
			this.Title.Text = "Title";
			// 
			// Album
			// 
			this.Album.Text = "Album";
			// 
			// Filename
			// 
			this.Filename.Text = "Filename";
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1054, 546);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Mei\'s squeekings";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// playingIndex
			// 
			this.playingIndex.Text = "";
			this.playingIndex.Width = 14;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1285, 621);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Fooborf";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.AlbumListTabstrip.ResumeLayout(false);
			this.tabAlbumTree.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabQueue.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem playbackToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem libraryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnPrev;
		private System.Windows.Forms.ToolStripButton btnPlayPause;
		private System.Windows.Forms.ToolStripButton btnStop;
		private System.Windows.Forms.ToolStripButton btnNext;
		private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabQueue;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabControl AlbumListTabstrip;
		private System.Windows.Forms.TabPage tabAlbumTree;
		private System.Windows.Forms.TabPage tabAlbumList;
		private System.Windows.Forms.TabPage tabAlbumTags;
		private System.Windows.Forms.ImageList treeList;
		private System.Windows.Forms.ListView playList;
		private System.Windows.Forms.ColumnHeader Track;
		private System.Windows.Forms.ColumnHeader Artist;
		private System.Windows.Forms.ColumnHeader Title;
		private System.Windows.Forms.ColumnHeader Album;
		private System.Windows.Forms.ColumnHeader Filename;
		private System.Windows.Forms.ColumnHeader playingIndex;
		
	}
}

