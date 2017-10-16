using Bytes2you.Validation;
using Reverb.Services.Contracts;
using Reverb.Web.Models.Song;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Reverb.Web.Controllers
{
    public class SongController : Controller
    {
        private const string Watch = "watch?v=";
        private const string Embed = "embed/";
        private const string LibraryAction = "Library";
        private const string LibraryView = "Library";
        private const string SongDetailsView = "SongDetails";

        private readonly ISongService songService;
        private readonly IUserService userService;
        private readonly IArtistService artistService;
        private readonly IAlbumService albumService;
        private readonly IGenreService genreService;
        private readonly ISongModifyService songModifyService;

        public SongController(
            ISongService songService, 
            IUserService userService,
            IArtistService artistService,
            IAlbumService albumService,
            IGenreService genreService,
            ISongModifyService songModifyService)
        {
            Guard.WhenArgument(songService, "songService").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(artistService, "artistService").IsNull().Throw();
            Guard.WhenArgument(albumService, "albumService").IsNull().Throw();
            Guard.WhenArgument(genreService, "genreService").IsNull().Throw();
            Guard.WhenArgument(songModifyService, "songModifyService").IsNull().Throw();

            this.songService = songService;
            this.userService = userService;
            this.artistService = artistService;
            this.albumService = albumService;
            this.genreService = genreService;
            this.songModifyService = songModifyService;
        }

        [HttpGet]
        [AllowAnonymous]
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
                    Duration = x.Duration,
                    Genres = x.Genres.Select(g => g.Name).ToList(),
                    Lyrics = x.Lyrics,
                    VideoUrl = x.VideoUrl,
                    CoverUrl = x.Album.CoverUrl,
                    Users = x.FavoritedBy.Select(u => u.Email)
                })
                .OrderBy(x => x.Title)
                .ToList();

            return View(songs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchSong(SongSearchViewModel songRequest)
        {
            var songs = this.songService
                .GetSongs();

            if (songRequest.OnlyFavorites)
            {
                songs = songs.Where(x => x.FavoritedBy.Select(u => u.UserName).Contains(User.Identity.Name));
            }

            if (!String.IsNullOrEmpty(songRequest.SearchTerm))
            {
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
            }

            if (songRequest.IsDescending)
            {
                switch (songRequest.OrderBy)
                {
                    case "Title":
                        songs = songs.OrderByDescending(x => x.Title);
                        break;
                    case "Album":
                        songs = songs.OrderByDescending(x => x.Album.Title);
                        break;
                    case "Artist":
                        songs = songs.OrderByDescending(x => x.Artist.Name);
                        break;
                }
            }
            else
            {
                switch (songRequest.OrderBy)
                {
                    case "Title":
                        songs = songs.OrderBy(x => x.Title);
                        break;
                    case "Album":
                        songs = songs.OrderBy(x => x.Album.Title);
                        break;
                    case "Artist":
                        songs = songs.OrderBy(x => x.Artist.Name);
                        break;
                }
            }

            var data = songs
             .Select(x => new SongViewModel
             {
                 Id = x.Id,
                 Title = x.Title,
                 Artist = x.Artist.Name,
                 Album = x.Album.Title,
                 Duration = x.Duration,
                 Genres = x.Genres.Select(g => g.Name).ToList(),
                 Lyrics = x.Lyrics,
                 VideoUrl = x.VideoUrl,
                 CoverUrl = x.Album.CoverUrl,
                 Users = x.FavoritedBy.Select(u => u.Email)
             })
             .ToList();


            return View(LibraryView, data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToFavorites(Guid songId)
        {
            var song = this.songService
                .GetSongs()
                .Where(x => x.Id == songId)
                .SingleOrDefault();

            this.userService.AddFavoriteSong(song, User.Identity.Name);

            return this.RedirectToAction(LibraryAction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveFromFavorites(Guid songId)
        {
            var song = this.songService
                .GetSongs()
                .Where(x => x.Id == songId)
                .SingleOrDefault();

            this.userService.RemoveFavoriteSong(song, User.Identity.Name);

            return this.RedirectToAction(LibraryAction);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditSong(Guid songId = new Guid())
        {
            if (songId == Guid.Empty)
            {
                RedirectToAction(LibraryAction);
            }
            
            var artistNames = this.artistService
                .GetArtists()
                .Select(x => x.Name)
                .OrderBy(x => x)
                .ToList();

            var albumNames = this.albumService
                .GetAlbums()
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            var genreNames = this.genreService
                .GetGenres()
                .Select(x => x.Name)
                .OrderBy(x => x)
                .ToList();

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
                    Duration = x.Duration,
                    Genres = x.Genres.Select(g => g.Name).ToList(),
                    VideoUrl = x.VideoUrl,
                    CoverUrl = x.Album.CoverUrl,
                    Users = x.FavoritedBy.Select(u => u.Email),
                    AllArtists = artistNames,
                    AllAlbums = albumNames,
                    AllGenres = genreNames
                })
                .SingleOrDefault();

            return View(song);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult EditSong(SongViewModel song)
        {
            if (song.VideoUrl.Contains(Watch))
            {
                song.VideoUrl = song.VideoUrl.Replace(Watch, Embed);
            }

            this.songModifyService.UpdateSong(
                song.Id,
                song.Title,
                song.Artist,
                song.Album,
                song.Duration,
                song.Genres,
                song.Lyrics,
                song.VideoUrl,
                song.CoverUrl
                );

            return this.RedirectToAction(LibraryAction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteSong(Guid songId)
        {
            this.songModifyService.DeleteSong(songId);

            return RedirectToAction(LibraryAction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(Guid songId)
        {
            var song = this.songService
                .GetSongs()
                .Where(x => x.Id == songId)
                .Select(x => new SongViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Artist = x.Artist.Name,
                    Album = x.Album.Title,
                    Duration = x.Duration,
                    Genres = x.Genres.Select(g => g.Name).ToList(),
                    Lyrics = x.Lyrics,
                    VideoUrl = x.VideoUrl,
                    CoverUrl = x.Album.CoverUrl,
                    Users = x.FavoritedBy.Select(u => u.Email)
                })
                .FirstOrDefault();

            return View(SongDetailsView, song);
        }
    }
}