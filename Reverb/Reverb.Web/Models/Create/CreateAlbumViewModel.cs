using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reverb.Web.Models.Create
{
    public class CreateAlbumViewModel
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Artist { get; set; }

        [Required]
        [MaxLength(10000)]
        public string CoverUrl { get; set; }

        public ICollection<string> AllArtists { get; set; }

    }
}