﻿using Bytes2you.Validation;
using Reverb.Services.Contracts;
using Reverb.Web.Models.Create;
using System.Linq;
using System.Web.Mvc;

namespace Reverb.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CreateController : Controller
    {
        private const string Watch = "watch?v=";
        private const string Embed = "embed/";
        private const string CreationChoiceAction = "CreationChoice";

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
        [ValidateAntiForgeryToken]
        public ActionResult CreateArtist(CreateArtistViewModel artist)
        {
            this.createService.CreateArtist(artist.Name);

            return RedirectToAction(CreationChoiceAction);
        }

        [HttpGet]
        public ActionResult CreateGenre()
        {
            var model = new CreateGenreViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGenre(CreateGenreViewModel genre)
        {
            this.createService.CreateGenre(genre.Name);

            return RedirectToAction(CreationChoiceAction);
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
        [ValidateAntiForgeryToken]
        public ActionResult CreateAlbum(CreateAlbumViewModel album)
        {
            this.createService.CreateAlbum(album.Title, album.Artist, album.CoverUrl);

            return RedirectToAction(CreationChoiceAction);
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
        [ValidateAntiForgeryToken]
        public ActionResult CreateSong(CreateSongViewModel song)
        {
            if (song.VideoUrl.Contains(Watch))
            {
                song.VideoUrl = song.VideoUrl.Replace(Watch, Embed);
            }

            this.createService.CreateSong(song.Title, song.Artist, song.Album, song.Duration, song.Genres, song.Lyrics, song.VideoUrl);

            return RedirectToAction(CreationChoiceAction);
        }
    }
}