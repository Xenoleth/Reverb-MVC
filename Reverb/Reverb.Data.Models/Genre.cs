﻿using Reverb.Data.Models.Abstracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reverb.Data.Models
{
    public class Genre : BaseModel
    {
        private ICollection<Song> songs;

        public Genre()
        {
            this.songs = new HashSet<Song>();
        }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

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
