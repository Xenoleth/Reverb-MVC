using Bytes2you.Validation;
using Reverb.Data.Contracts;
using Reverb.Data.Models;
using Reverb.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverb.Services
{
    public class SongModifyService : ISongModifyService
    {
        private readonly IEfContextWrapper<Song> songsRepo;
        private readonly IEfContextWrapper<Artist> artistsRepo;
        private readonly IEfContextWrapper<Album> albumsRepo;
        private readonly IEfContextWrapper<Genre> genresRepo;
        private readonly ISaveContext context;

        public SongModifyService(
            IEfContextWrapper<Song> songsRepo,
            IEfContextWrapper<Artist> artistsRepo,
            IEfContextWrapper<Album> albumsRepo,
            IEfContextWrapper<Genre> genresRepo,
            ISaveContext context)
        {
            Guard.WhenArgument(songsRepo, "songRepo").IsNull().Throw();
            Guard.WhenArgument(artistsRepo, "artistsRepo").IsNull().Throw();
            Guard.WhenArgument(albumsRepo, "albumsRepo").IsNull().Throw();
            Guard.WhenArgument(genresRepo, "genresRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.songsRepo = songsRepo;
            this.artistsRepo = artistsRepo;
            this.albumsRepo = albumsRepo;
            this.genresRepo = genresRepo;
            this.context = context;
        }

        public void UpdateSong(Guid id, string title, string artistName, string albumName, int? duration, ICollection<string> selectedGenres, string lyrics, string videoUrl, string coverUrl)
        {
            var song = this.songsRepo
                .All
                .Where(x => x.Id == id)
                .FirstOrDefault();

            var artist = this.artistsRepo
                .All
                .Where(x => x.Name == artistName)
                .FirstOrDefault();

            var genres = new HashSet<Genre>();

            this.genresRepo
                .All
                .Where(x => selectedGenres.Contains(x.Name))
                .Select(x => genres.Add(x));

            var album = this.albumsRepo
                .All
                .Where(x => x.Title == albumName)
                .FirstOrDefault();

            album.CoverUrl = coverUrl;

            song.Title = title;
            song.Artist = artist;
            song.Album = album;
            song.Genres = genres;
            song.Duration = duration;
            song.Lyrics = lyrics;
            song.VideoUrl = videoUrl;

            this.songsRepo.Update(song);

            this.context.SaveChanges();
        }

        public void DeleteSong(Guid id)
        {
            var song = this.songsRepo
                .All
                .Where(x => x.Id == id)
                .FirstOrDefault();

            this.songsRepo.Delete(song);

            this.context.SaveChanges();
        }
    }
}
