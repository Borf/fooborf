using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FooBorf
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private TcpClient client;
		private NetworkStream stream;
		private byte[] buffer = new byte[1024];
		private string data;
		private List<String> response = new List<string>(); 
		private List<String> commands = new List<string>();
		public List<PlayList> playlists = new List<PlayList>();
		public PlayList activePlaylist = null;
		public PlayList queuePlayList = null;
		public string newSong = "";


		private void MainForm_Load(object sender, EventArgs e)
		{
			Hooker.callback += (Keys key) =>
			{
				if(key == Keys.MediaNextTrack)
					Write("next\n");
				else if (key == Keys.MediaPreviousTrack)
					Write("previous\n");
				else if (key == Keys.MediaPlayPause)
					Write("pause\n");

			};

			Connect();
			Write("lsinfo /\n");
			Write("listplaylists\n");
			Write("playlistinfo\n");
			Write("currentsong\n");
		}


		void onRead(IAsyncResult ar)
		{
			int rc = -1;
			try
			{
				rc = stream.EndRead(ar);
			}
			catch (IOException)
			{
				client.Close();
				Connect();
				Write("currentsong\n");
				return;
			}
			if (rc <= 0 || !client.Connected)
			{
				client.Close();
				Connect();
				Write("currentsong\n");
				return;
			}
			data += Encoding.UTF8.GetString(buffer, 0, rc);
			while (data.Contains("\n"))
			{
				string line = data.Substring(0, data.IndexOf("\n"));
				data = data.Substring(data.IndexOf("\n") + 1);
				if(line != "OK")
					response.Add(line);
				string cmd = line;
				if (cmd.Contains(" "))
					cmd = cmd.Substring(0, cmd.IndexOf(" "));
				if (cmd == "ACK")
				{
					Console.WriteLine("Error: " + line);
					response.Clear();
				}
				if (cmd == "OK")
				{
					Console.Out.WriteLine("OK");
					string command = commands[0];
					commands.RemoveAt(0);

					string commandcmd = command;
					if (commandcmd.Contains(" "))
						commandcmd = commandcmd.Substring(0, commandcmd.IndexOf(" "));


					if (command == "currentsong")
					{
						Invoke(() =>
						{
							int pos = -1;
							if (response.Count == 0)
								Text = "Nothing Playing - [ FooBorf ]";
							else
							{
								PlayListItem playlistItem = new PlayListItem();
								for (int i = 0; i < response.Count; i++)
								{
									String type = response[i].Substring(0, response[i].IndexOf(": "));
									String value = response[i].Substring(response[i].IndexOf(": ") + 2);
									playlistItem.set(type, value);
								}

								if ((playlistItem.artist != "" || playlistItem.title != "") && (playlistItem.artist != null || playlistItem.title != null))
									Text = playlistItem.artist  + " - " + playlistItem.title + " - [ FooBorf ]";
								else
									Text = playlistItem.file.Substring(playlistItem.file.LastIndexOf("/")+1) + " - [ FooBorf ]";
								pos = playlistItem.pos;
							}

							foreach (ListViewItem item in queue.Items)
							{
								if (((PlayListItem) item.Tag).pos == pos)
								{
									item.ImageIndex = 1;
									item.EnsureVisible();
								}
								else
									item.ImageIndex = -1;
							}


						});
					}

					if (commandcmd == "lsinfo")
					{
						Invoke(() =>
						{
							if (command.Substring(7) == "/")
							{
								for (int i = 0; i < response.Count; i+=2)
								{
									if (response[i].Substring(0, 11) == "directory: ")
									{
										TreeNode node = new TreeNode(response[i].Substring(11));
										node.Tag = "D" + node.Text;
										node.Nodes.Add(new TreeNode("...") {Tag = "dummy"});
										treeView1.Nodes.Add(node);
									}
								}
							}
							else
							{
								string dir = command.Substring(7).Trim(new char[] { '"' });
								var dirs = dir.Split(new char[] {'/'});
								TreeNodeCollection n = treeView1.Nodes;
								for (int i = 0; i < dirs.Length; i++)
								{
									for (int ii = 0; ii < n.Count; ii++)
									{
										if (n[ii].Text == dirs[i])
										{
											n = n[ii].Nodes;
											break;
										}
									}


								}
								n.Clear();
								for (int i = 0; i < response.Count; i++)
								{
									if (response[i].Length < 5)
										continue;
									if (response[i].Substring(0, 6) == "file: ")
									{
										TreeNode node = new TreeNode(response[i].Substring(11));
										node.Tag = "F" + node.Text;
										node.ImageIndex = 1;
										node.SelectedImageIndex = 1;
										node.Text = node.Text.Substring(node.Text.LastIndexOf('/') + 1);
										n.Add(node);
									}


									if (response[i].Length < 11)
										continue;
									if (response[i].Substring(0, 11) == "directory: ")
									{
										TreeNode node = new TreeNode(response[i].Substring(11));
										node.ImageIndex = 0;
										node.Tag = "D" + node.Text;
										node.Text = node.Text.Substring(node.Text.LastIndexOf('/') + 1);
										node.Nodes.Add(new TreeNode("...") { Tag = "dummy" });
										n.Add(node);
									}
								}





							}
						});
					}

					if (command == "playlistinfo")
					{

						bool first = true;
						PlayListItem playlistItem = new PlayListItem();
						List<ListViewItem> rows = new List<ListViewItem>();
						queuePlayList = new PlayList(null, null);
						queuePlayList.listview = queue;

						for (int i = 0; i < response.Count; i++)
						{
							String type = response[i].Substring(0, response[i].IndexOf(": "));
							String value = response[i].Substring(response[i].IndexOf(": ") + 2);
							if (type == "file" && first)
								first = false;
							else if (type == "file" && !first)
							{
								var item = new ListViewItem(new string[]
								{
									null,
									playlistItem.number,
									playlistItem.artist,
									playlistItem.title,
									playlistItem.album,
									playlistItem.file,
								}) {Tag = playlistItem};
								rows.Add(item);
								queuePlayList.items.Add(playlistItem);
								playlistItem = new PlayListItem();
							}
							playlistItem.set(type, value);

		
						}
						var item_ = new ListViewItem(new string[]
								{
									null,
									playlistItem.number,
									playlistItem.artist,
									playlistItem.title,
									playlistItem.album,
									playlistItem.file,
								}) { Tag = playlistItem };
						rows.Add(item_);
						queuePlayList.items.Add(playlistItem);
						Invoke(() =>
						{
							queue.Items.Clear();
							queue.Items.AddRange(rows.ToArray());
							queue.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
						});
						checkPlaylist();
					}

					if(command == "listplaylists")
					{
						Invoke(() =>
						{
							for (int i = 0; i < response.Count; i++)
							{
								String type = response[i].Substring(0, response[i].IndexOf(": "));
								String value = response[i].Substring(response[i].IndexOf(": ") + 2);
								if (type == "playlist")
								{
									PlayList playlist = new PlayList(value, this);
									this.tabControl1.Controls.Add(playlist.tab);
									playlists.Add(playlist);
									Write("listplaylistinfo " + value + "\n");
								}

							}

						});
					}
					if (commandcmd == "listplaylistinfo")
					{
						string name = command.Substring(17);
						PlayList playlist = null;
						foreach(PlayList p in playlists)
							if (p.name == name)
								playlist = p;
						if(playlist == null)
							Console.WriteLine("UHOH, playlist not found");


						bool first = true;

						PlayListItem playlistItem = new PlayListItem();
						List<ListViewItem> rows = new List<ListViewItem>();

						for (int i = 0; i < response.Count; i++)
						{
							String type = response[i].Substring(0, response[i].IndexOf(": "));
							String value = response[i].Substring(response[i].IndexOf(": ") + 2);

							if (type == "file" && first)
								first = false;
							else if (type == "file" && !first)
							{
								var item = new ListViewItem(new string[]
								{
									null, 
									playlistItem.number, 
									playlistItem.artist,
									playlistItem.title,
									playlistItem.album,
									playlistItem.file
								}) {Tag = playlistItem};
								rows.Add(item);
								playlist.items.Add(playlistItem);
								playlistItem = new PlayListItem();
							}
							playlistItem.set(type, value);
						}
						var item_ = new ListViewItem(new string[]
								{
									null, 
									playlistItem.number, 
									playlistItem.artist,
									playlistItem.title,
									playlistItem.album,
									playlistItem.file
								}) { Tag = playlistItem };
						rows.Add(item_);
						playlist.items.Add(playlistItem);
						playlistItem = new PlayListItem();

		
						Invoke(() =>
						{
							playlist.listview.Items.Clear();
							playlist.listview.Items.AddRange(rows.ToArray());
							playlist.listview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
						});
						checkPlaylist();

					}

					if (command == "previous" || command == "next")
					{
						Write("currentsong\n");
					}

					response.Clear();
				}

			}


			if (newSong != "")
			{
				foreach(PlayListItem it in queuePlayList.items)
					if (it.file == newSong)
					{
						Write("play " + it.pos + "\n");
						newSong = "";
					}
			}



			stream.BeginRead(buffer, 0, 1024, onRead, null);
		}

		private void btnPrev_Click(object sender, EventArgs e)
		{
			Write("previous\n");
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			Write("next\n");
		}

		private void btnPlayPause_Click(object sender, EventArgs e)
		{
			Write("pause\n");
		}


		public void Write(string s)
		{
			if (!client.Connected)
			{
				Connect();
			}
			commands.AddRange(s.Split(new Char [] { '\n' }, StringSplitOptions.RemoveEmptyEntries));

			Console.WriteLine("SENDING " + s.Trim());
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			stream.Write(bytes, 0, bytes.Length);
		}

		private void Connect()
		{
			Console.Write("Connecting...");
			client = new TcpClient("borf.info", 6600);
			stream = client.GetStream();
			commands.Add("init");
			stream.BeginRead(buffer, 0, 1024, onRead, null);
			Console.WriteLine("connected...");
		}

		public void Invoke(Action action)
		{
			Invoke((Delegate)action);
		}

		private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			Write("lsinfo \"" + e.Node.Tag.ToString().Substring(1) + "\"\n");
		}

		private void playList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (queue.SelectedItems.Count > 0)
			{
				activateItem(queue.SelectedItems[0]);
			}
		}

		private void pingTimer_Tick(object sender, EventArgs e)
		{
			Write("ping\n");
		}


		void checkPlaylist()
		{
			if (activePlaylist != null)
				Invoke(() => activePlaylist.tab.Text = activePlaylist.name);
			activePlaylist = null;
			foreach (PlayList p in playlists)
			{
				int match = 0;
				int match2 = 0;
				foreach (PlayListItem item in queuePlayList.items)
				{
					if (p.items.Any(it => it.file == item.file))
						match++;
					//else if (queuePlayList.items.Any(it => it.file == item.file) && match > 0)
					//	Console.WriteLine(":(:(");
					//else if(match > 0)
					//	Console.WriteLine(":(");
				}
				foreach (PlayListItem item in p.items)
				{
					if (queuePlayList.items.Any(it => it.file == item.file))
						match2++;
				}
				if (match == match2 && (match == queuePlayList.items.Count || (match > queuePlayList.items.Count/2 && queuePlayList.items.Count == p.items.Count)))
				{
					activePlaylist = p;
					Invoke(() => p.tab.Text = "*" + p.name + "*");
					Console.WriteLine("Active playlist is " + p.name);
					
				}
			}
		}

		private void queue_ItemDrag(object sender, ItemDragEventArgs e)
		{
			queue.DoDragDrop(queue.SelectedItems, DragDropEffects.Move | DragDropEffects.Copy);
		}

		private void queue_DragEnter(object sender, DragEventArgs e)
		{
			int len = e.Data.GetFormats().Length - 1;
			int i;
			for (i = 0; i <= len; i++)
			{
				if (e.Data.GetFormats()[i].Equals("System.Windows.Forms.ListView+SelectedListViewItemCollection"))
				{
					//The data from the drag source is moved to the target.	
					if((e.KeyState & 8) == 8) //ctrl
						e.Effect = DragDropEffects.Copy;
					else
						e.Effect = DragDropEffects.Move;
				}
			}
		}

		private void queue_DragDrop(object sender, DragEventArgs e)
		{
			//Return if the items are not selected in the ListView control.
			if (queue.SelectedItems.Count == 0)
			{
				return;
			}
			//Returns the location of the mouse pointer in the ListView control.
			Point cp = queue.PointToClient(new Point(e.X, e.Y));
			//Obtain the item that is located at the specified location of the mouse pointer.
			ListViewItem dragToItem = queue.GetItemAt(cp.X, cp.Y);
			if (dragToItem == null)
			{
				return;
			}
			//Obtain the index of the item at the mouse pointer.
			int dragIndex = dragToItem.Index;
			ListViewItem[] sel = new ListViewItem[queue.SelectedItems.Count];
			for (int i = 0; i <= queue.SelectedItems.Count - 1; i++)
			{
				sel[i] = queue.SelectedItems[i];
			}
			for (int i = 0; i < sel.GetLength(0); i++)
			{
				//Obtain the ListViewItem to be dragged to the target location.
				ListViewItem dragItem = sel[i];
				int itemIndex = dragIndex;
				if (itemIndex == dragItem.Index)
				{
					return;
				}
				if (dragItem.Index < itemIndex)
					itemIndex++;
				else
					itemIndex = dragIndex + i;
				//Insert the item at the mouse pointer.
				ListViewItem insertItem = (ListViewItem)dragItem.Clone();
				queue.Items.Insert(itemIndex, insertItem);
				//Removes the item from the initial location while 
				//the item is moved to the new location.
				queue.Items.Remove(dragItem);
			}
		}

		private void tabControl1_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		}

		private void tabControl1_DragDrop(object sender, DragEventArgs e)
		{
			Console.WriteLine("COPY");
		}

		private void findToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FindWindow w = new FindWindow(this);
			w.ShowDialog(this);

		}

		internal void activateItem(ListViewItem item)
		{
			int id = tabControl1.SelectedIndex;
			PlayList p = null;
			if (id == 0)
			{
				Write("play " + ((PlayListItem) item.Tag).pos + "\n");
				Write("currentsong\n");
			}
			else
			{
				p = playlists[id - 1];
	
				if (activePlaylist != p)
				{
					Write("clear\n");
					Write("load " + p.name + "\n");
					Write("playlistinfo\n");
				}

				newSong = ((PlayListItem)item.Tag).file;
				Write("currentsong\n");
			}



		}
	}
}
