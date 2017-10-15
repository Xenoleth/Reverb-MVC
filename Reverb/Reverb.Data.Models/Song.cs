using Reverb.Data.Models.Abstracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reverb.Data.Models
{
    public class Song : BaseModel
    {
        private ICollection<Genre> genres;
        private ICollection<User> favoritedBy;

        public Song()
        {
            this.genres = new HashSet<Genre>();
            this.favoritedBy = new HashSet<User>();
        }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Title { get; set; }

        public virtual Album Album { get; set; }

        public virtual Artist Artist { get; set; }

        public int? Duration { get; set; }

        public virtual ICollection<Genre> Genres
        {
            get
            {
                return this.genres;
            }

            set
            {
                this.genres = value;
            }
        }

        [Column(TypeName = "ntext")]
        public string Lyrics { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        public string VideoUrl { get; set; }

        public virtual ICollection<User> FavoritedBy
        {
            get
            {
                return this.favoritedBy;
            }

            set
            {
                this.favoritedBy = value;
            }
        }
    }
}
