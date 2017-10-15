using System.Collections.Generic;

namespace Reverb.Web.Models.Create
{
    public class CreateSongViewModel
    {
        public string Title { get; set; }

        public string Album { get; set; }

        public string Artist { get; set; }

        public int? Duration { get; set; }

        public ICollection<string> Genres { get; set; }

        public string Lyrics { get; set; }

        public ICollection<string> AllAlbums { get; set; }

        public ICollection<string> AllArtists { get; set; }

        public ICollection<string> AllGenres { get; set; }

    }
}