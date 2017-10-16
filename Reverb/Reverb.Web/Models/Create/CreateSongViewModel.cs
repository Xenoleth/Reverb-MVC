using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reverb.Web.Models.Create
{
    public class CreateSongViewModel
    {
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
        public int? Duration { get; set; }

        [Required]
        public ICollection<string> Genres { get; set; }

        [Required]
        [MaxLength(10000)]
        public string Lyrics { get; set; }

        [Required]
        [MaxLength(10000)]
        public string VideoUrl { get; set; }

        public ICollection<string> AllAlbums { get; set; }

        public ICollection<string> AllArtists { get; set; }

        public ICollection<string> AllGenres { get; set; }

    }
}