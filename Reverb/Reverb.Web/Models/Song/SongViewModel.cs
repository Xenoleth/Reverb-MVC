using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reverb.Web.Models.Song
{
    public class SongViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Album { get; set; }

        [Required]
        [MaxLength(200)]
        public string Artist { get; set; }

        [Required]
        [MaxLength(10000)]
        public string Lyrics { get; set; }

        [Required]
        [MaxLength(10000)]
        public string VideoUrl { get; set; }

        public string CoverUrl { get; set; }

        [Required]
        public int? Duration { get; set; }

        [Required]
        public ICollection<string> Genres { get; set; }
        
        public IEnumerable<string> Users { get; set; }

        public IEnumerable<string> AllAlbums { get; set; }

        public IEnumerable<string> AllArtists { get; set; }

        public IEnumerable<string> AllGenres { get; set; }
    }
}