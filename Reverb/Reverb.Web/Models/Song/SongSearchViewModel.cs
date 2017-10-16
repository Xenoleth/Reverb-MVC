namespace Reverb.Web.Models.Song
{
    public class SongSearchViewModel
    {
        public string SearchTerm { get; set; }

        public string SearchBy { get; set; }

        public string OrderBy { get; set; }

        public bool IsDescending { get; set; }

        public bool OnlyFavorites { get; set; }
    }
}