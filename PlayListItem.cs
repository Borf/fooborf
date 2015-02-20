using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FooBorf
{
	public class PlayListItem
	{
		public String number;
		public String file;
		public String title;
		public String artist;
		public String album;
		public string genre;
		public int pos;
		public int id;
		public int time;
		public string date;
		public byte prio = 0;

		public void set(string type, string value)
		{
			if (type == "Artist")
				artist = value;
			else if (type == "file")
				file = value;
			else if (type == "Title")
				title = value;
			else if (type == "Track")
				number = value;
			else if (type == "Album")
				album = value;
			else if (type == "Genre")
				genre = value;
			else if (type == "Pos")
				pos = int.Parse(value);
			else if (type == "Id")
				id = int.Parse(value);
			else if (type == "Time")
				time = int.Parse(value);
			else if (type == "Date")
				date = value;
			else if (type == "Prio")
				prio = byte.Parse(value);
			else if (type == "Last-Modified" || type == "Disc" || type == "AlbumArtist" || type == "Composer" || type == "Performer" || type == "ArtistSort" || type == "MUSICBRAINZ_ARTISTID" || type == "MUSICBRAINZ_ALBUMID" || type == "MUSICBRAINZ_TRACKID" || type == "AlbumArtistSort")
				;
			else
				Console.WriteLine("Unknown value: " + type + " => " + value);
		}
		public override String ToString()
		{
			return file;
		}

		internal void set(PlayListItem i)
		{
			number = i.number;
			file = i.file;
			title = i.title;
			artist = i.artist;
			album = i.album;
			genre = i.genre;
			pos = i.pos;
			id = i.id;
			time = i.time;
			date = i.date;
			prio = i.prio;
		}

		public ListViewItem listViewItem()
		{
			var item = new ListViewItem(new string[]
								{
									null,
									number,
									artist + " - " + album,
									title,
									file,
								}) { Tag = this };
			return item;
		}

	}

}
