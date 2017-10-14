﻿using Reverb.Services.Contracts;
using Reverb.Web.Models.Song;
using System.Linq;
using System.Web.Mvc;

namespace Reverb.Web.Controllers
{
    public class SongController : Controller
    {
        private readonly ISongService songService;

        public SongController(ISongService songService)
        {
            this.songService = songService;
        }

        // GET: Song
        public ActionResult Library()
        {
            var songs = this.songService
                .GetSongs()
                .Select(x => new SongViewModel
                {
                    Title = x.Title,
                    Artist = x.Artist.Name,
                    Album = x.Album.Title,
                    Lyrics = x.Lyrics
                })
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
                 Title = x.Title,
                 Artist = x.Artist.Name,
                 Album = x.Album.Title,
                 Lyrics = x.Lyrics
             })
             .ToList();


            return View("Library", data);
        }
    }
}