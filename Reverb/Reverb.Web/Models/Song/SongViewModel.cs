﻿using System;
using System.Collections.Generic;

namespace Reverb.Web.Models.Song
{
    public class SongViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Album { get; set; }

        public string Artist { get; set; }

        public string Lyrics { get; set; }

        public string VideoUrl { get; set; }

        public string CoverUrl { get; set; }

        public int? Duration { get; set; }

        public ICollection<string> Genres { get; set; }
        
        public IEnumerable<string> Users { get; set; }

        public IEnumerable<string> AllAlbums { get; set; }

        public IEnumerable<string> AllArtists { get; set; }

        public IEnumerable<string> AllGenres { get; set; }
    }
}