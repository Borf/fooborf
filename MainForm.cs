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



		private void MainForm_Load(object sender, EventArgs e)
		{
			client = new TcpClient("borf.info", 6600);
			stream = client.GetStream();
			commands.Add("init");
			Write("lsinfo /\n");
			Write("listplaylists\n");
			Write("playlistinfo\n");
			Write("currentsong\n");
			stream.BeginRead(buffer, 0, 1024, onRead, null);
		}


		void onRead(IAsyncResult ar)
		{
			int rc = stream.EndRead(ar);
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
								Text = response[4].Substring(8) + " - " + response[8].Substring(7) + " - [ FooBorf ]";
								for(int i = 0; i < response.Count; i++)
									if(response[i].Length > 5)
										if(response[i].Substring(0, 5) == "Pos: ")
											pos = int.Parse(response[i].Substring(5));
							}

							foreach (ListViewItem item in playList.Items)
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
						String[] row = new string[6];

						Invoke(() =>
						{
							bool first = true;
							PlayListItem playlistItem = new PlayListItem();
							for (int i = 0; i < response.Count; i++)
							{
								String type = response[i].Substring(0, response[i].IndexOf(": "));
								String value = response[i].Substring(response[i].IndexOf(": ") + 2);
								playlistItem.set(type, value);
								if (type == "file")
									row[5] = value;
								if (type == "Artist")
									row[2] = value;
								if (type == "Title")
									row[3] = value;
								if (type == "Track")
									row[1] = value;
								if (type == "Album")
									row[4] = value;

								if (type == "file" && first)
									first = false;
								else if (type == "file" && !first)
								{
									var item = new ListViewItem(row);
									item.Tag = playlistItem;
									playList.Items.Add(item);
									playlistItem = new PlayListItem();
								}
							}
							playList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
						});
					}

					if(command == "listplaylists")
					{
						Console.WriteLine("Playlists!");
					}

					if (command == "previous" || command == "next")
					{
						Write("currentsong\n");
					}

					response.Clear();
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





		void Write(string s)
		{
			commands.AddRange(s.Split(new Char [] { '\n' }, StringSplitOptions.RemoveEmptyEntries));

			Console.WriteLine("SENDING " + s.Trim());
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			stream.Write(bytes, 0, bytes.Length);
		}
		public void Invoke(Action action)
		{
			Invoke((Delegate)action);
		}

		private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			Write("lsinfo \"" + e.Node.Tag.ToString().Substring(1) + "\"\n");
		}


	}





}
