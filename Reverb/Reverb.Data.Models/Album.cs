using Reverb.Data.Models.Abstracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reverb.Data.Models
{
    public class Album : BaseModel
    {
        private ICollection<Song> songs;

        public Album()
        {
            this.songs = new HashSet<Song>();
        }

        [Required]
        public string Title { get; set; }

        public virtual Artist Artist { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        public string CoverUrl { get; set; }

        public virtual ICollection<Song> Songs
        {
            get
            {
                return this.songs;
            }

            set
            {
                this.songs = value;
            }
        }
    }
}
