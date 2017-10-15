using Bytes2you.Validation;
using Reverb.Services.Contracts;
using Reverb.Web.Models.Create;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Reverb.Web.Controllers
{
    public class CreateController : Controller
    {
        private readonly ICreationService createService;
        private readonly IArtistService artistService;
        private readonly IAlbumService albumService;
        private readonly IGenreService genreService;

        public CreateController(
            ICreationService createService, 
            IArtistService artistService,
            IAlbumService albumService,
            IGenreService genreService)
        {
            Guard.WhenArgument(createService, "createService").IsNull().Throw();
            Guard.WhenArgument(artistService, "artistService").IsNull().Throw();
            Guard.WhenArgument(albumService, "albumService").IsNull().Throw();
            Guard.WhenArgument(genreService, "genreService").IsNull().Throw();

            this.createService = createService;
            this.artistService = artistService;
            this.albumService = albumService;
            this.genreService = genreService;
        }

        [HttpGet]
        public ActionResult CreationChoice()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateArtist()
        {
            var model = new CreateArtistViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateArtist(CreateArtistViewModel artist)
        {
            this.createService.CreateArtist(artist.Name);

            return RedirectToAction("CreationChoice");
        }

        [HttpGet]
        public ActionResult CreateGenre()
        {
            var model = new CreateGenreViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateGenre(CreateGenreViewModel genre)
        {
            this.createService.CreateGenre(genre.Name);

            return RedirectToAction("CreationChoice");
        }

        [HttpGet]
        public ActionResult CreateAlbum()
        {  
            var artistNames = this.artistService
                .GetArtists()
                .Select(x => x.Name)
                .OrderBy(x => x)
                .ToList();

            var model = new CreateAlbumViewModel()
            {
                AllArtists = artistNames
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateAlbum(CreateAlbumViewModel album)
        {
            this.createService.CreateAlbum(album.Title, album.Artist);

            return RedirectToAction("CreationChoice");
        }

        [HttpGet]
        public ActionResult CreateSong()
        {
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

            var model = new CreateSongViewModel()
            {
                AllArtists = artistNames,
                AllAlbums = albumNames,
                AllGenres = genreNames
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateSong(CreateSongViewModel song)
        {
            this.createService.CreateSong(song.Title, song.Artist, song.Album, song.Duration, song.Genres, song.Lyrics);

            return RedirectToAction("CreationChoice");
        }
    }
}