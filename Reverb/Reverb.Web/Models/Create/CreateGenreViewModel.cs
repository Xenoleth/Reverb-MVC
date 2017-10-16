using System.ComponentModel.DataAnnotations;

namespace Reverb.Web.Models.Create
{
    public class CreateGenreViewModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}