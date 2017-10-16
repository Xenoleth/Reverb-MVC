using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reverb.Web.Models.Create
{
    public class CreateArtistViewModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}