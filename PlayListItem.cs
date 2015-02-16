using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			else if (type == "Last-Modified" || type == "Disc" || type == "AlbumArtist" || type == "Composer" || type == "Performer" || type == "ArtistSort" || type == "MUSICBRAINZ_ARTISTID" || type == "MUSICBRAINZ_ALBUMID" || type == "MUSICBRAINZ_TRACKID" || type == "AlbumArtistSort")
				;
			else
				Console.WriteLine("Unknown value: " + type + " => " + value);
		}
		public override String ToString()
		{
			return file;
		}
	}

}
