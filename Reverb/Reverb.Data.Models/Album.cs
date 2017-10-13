using Reverb.Data.Models.Abstracts;
using System.Collections.Generic;

namespace Reverb.Data.Models
{
    public class Album : BaseModel
    {
        private ICollection<Song> songs;

        public Album()
        {
            this.songs = new HashSet<Song>();
        }

        public string Title { get; set; }

        public virtual Artist Artist { get; set; }

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
