using System.Collections.Generic;

namespace Reverb.Web.Models.Create
{
    public class CreateAlbumViewModel
    {
        public string Title { get; set; }

        public string Artist { get; set; }

        public string CoverUrl { get; set; }

        public ICollection<string> AllArtists { get; set; }

    }
}