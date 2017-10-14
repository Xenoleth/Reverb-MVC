using System;

namespace Reverb.Web.Models.Song
{
    public class SongViewModel
    {
        public Guid? Id { get; set; }

        public string Title { get; set; }

        public string Album { get; set; }

        public string Artist { get; set; }

        public string Lyrics { get; set; }
    }
}