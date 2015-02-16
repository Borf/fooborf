namespace FooBorf
{
	partial class FindWindow
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
			this.searchTerms = new System.Windows.Forms.TextBox();
			this.results = new System.Windows.Forms.ListView();
			this.Artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.File = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// searchTerms
			// 
			this.searchTerms.Dock = System.Windows.Forms.DockStyle.Top;
			this.searchTerms.Location = new System.Drawing.Point(0, 0);
			this.searchTerms.Name = "searchTerms";
			this.searchTerms.Size = new System.Drawing.Size(1262, 20);
			this.searchTerms.TabIndex = 0;
			this.searchTerms.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			this.searchTerms.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTerms_KeyDown);
			// 
			// results
			// 
			this.results.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Artist,
            this.Title,
            this.File});
			this.results.Dock = System.Windows.Forms.DockStyle.Fill;
			this.results.FullRowSelect = true;
			this.results.GridLines = true;
			this.results.HideSelection = false;
			this.results.Location = new System.Drawing.Point(0, 20);
			this.results.Name = "results";
			this.results.ShowGroups = false;
			this.results.Size = new System.Drawing.Size(1262, 532);
			this.results.TabIndex = 1;
			this.results.UseCompatibleStateImageBehavior = false;
			this.results.View = System.Windows.Forms.View.Details;
			this.results.DoubleClick += new System.EventHandler(this.results_DoubleClick);
			this.results.KeyDown += new System.Windows.Forms.KeyEventHandler(this.results_KeyDown);
			// 
			// Artist
			// 
			this.Artist.Text = "Artist";
			// 
			// Title
			// 
			this.Title.Text = "Title";
			// 
			// File
			// 
			this.File.Text = "File";
			// 
			// FindWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1262, 552);
			this.Controls.Add(this.results);
			this.Controls.Add(this.searchTerms);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "FindWindow";
			this.Text = "Find";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox searchTerms;
		private System.Windows.Forms.ListView results;
		private System.Windows.Forms.ColumnHeader Artist;
		private System.Windows.Forms.ColumnHeader Title;
		private System.Windows.Forms.ColumnHeader File;
	}
}