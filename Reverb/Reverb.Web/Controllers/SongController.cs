using Reverb.Services.Contracts;
using Reverb.Web.Models.Song;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Reverb.Web.Controllers
{
    public class SongController : Controller
    {
        private readonly ISongService songService;
        private readonly IUserService userService;

        public SongController(ISongService songService, IUserService userService)
        {
            this.songService = songService;
            this.userService = userService;
        }

        // GET: Song
        public ActionResult Library()
        {
            var songs = this.songService
                .GetSongs()
                .Select(x => new SongViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Artist = x.Artist.Name,
                    Album = x.Album.Title,
                    Lyrics = x.Lyrics,
                    Users = x.FavoritedBy.Select(u => u.Email)
                })
                .OrderBy(x => x.Title)
                .ToList();

            return View(songs);
        }

        [HttpPost]
        public ActionResult SearchSong(SongSearchViewModel songRequest)
        {
            var songs = this.songService
                .GetSongs();

            switch (songRequest.SearchBy)
            {
                case "Title":
                    songs = songs.Where(x => x.Title.Contains(songRequest.SearchTerm));
                    break;
                case "Album":
                    songs = songs.Where(x => x.Album.Title.Contains(songRequest.SearchTerm));
                    break;
                case "Artist":
                    songs = songs.Where(x => x.Artist.Name.Contains(songRequest.SearchTerm));
                    break;
            }

            if (songRequest.IsDescending)
            {
                songs = songs.OrderByDescending(x => x.Artist.Name)
                    .OrderByDescending(x => x.Album.Title)
                    .OrderByDescending(x => x.Title);
            }
            else
            {
                songs = songs.OrderBy(x => x.Artist.Name)
                    .OrderBy(x => x.Album.Title)
                    .OrderBy(x => x.Title);
            }

            var data = songs
             .Select(x => new SongViewModel
             {
                 Id = x.Id,
                 Title = x.Title,
                 Artist = x.Artist.Name,
                 Album = x.Album.Title,
                 Lyrics = x.Lyrics,
                 Users = x.FavoritedBy.Select(u => u.Email)
             })
             .ToList();


            return View("Library", data);
        }

        [HttpPost]
        public ActionResult AddToFavorites(Guid songId)
        {
            var song = this.songService
                .GetSongs()
                .Where(x => x.Id == songId)
                .SingleOrDefault();

            this.userService.AddFavoriteSong(song, User.Identity.Name);

            return this.RedirectToAction("Library");
        }

        [HttpPost]
        public ActionResult RemoveFromFavorites(Guid songId)
        {
            var song = this.songService
                .GetSongs()
                .Where(x => x.Id == songId)
                .SingleOrDefault();

            this.userService.RemoveFavoriteSong(song, User.Identity.Name);

            return this.RedirectToAction("Library");
        }

        [HttpGet]
        public ActionResult EditSong(Guid songId)
        {
            var song = this.songService
                .GetSongs()
                .Where(x => x.Id == songId)
                .Select(x => new SongViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Artist = x.Artist.Name,
                    Album = x.Album.Title,
                    Lyrics = x.Lyrics,
                    Users = x.FavoritedBy.Select(u => u.Email)
                })
                .SingleOrDefault();

            return View(song);
        }

        [HttpPost]
        public ActionResult EditSong(SongViewModel songModel)
        {
            var song = this.songService
                .GetSongs()
                .Where(x => x.Id == songModel.Id)
                .SingleOrDefault();

            // TODO: Decide if here or in service
            song.Title = songModel.Title;
            // TODO: Change the rest of the song parameters

            this.songService.Update(song);

            return this.RedirectToAction("Library");
        }
    }
}