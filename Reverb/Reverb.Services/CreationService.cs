using Bytes2you.Validation;
using Reverb.Data.Contracts;
using Reverb.Data.Models;
using Reverb.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverb.Services
{
    public class CreationService : ICreationService
    {
        private readonly IEfContextWrapper<Song> songsRepo;
        private readonly IEfContextWrapper<Artist> artistsRepo;
        private readonly IEfContextWrapper<Album> albumsRepo;
        private readonly IEfContextWrapper<Genre> genresRepo;
        private readonly ISaveContext context;
        
        public CreationService(
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

        public void CreateArtist(string name)
        {
            Guard.WhenArgument(name, "name").IsNull().Throw();

            var artist = new Artist()
            {
                Name = name
            };

            this.artistsRepo.Add(artist);

            this.context.SaveChanges();
        }

        public void CreateGenre(string name)
        {
            Guard.WhenArgument(name, "name").IsNull().Throw();

            var genre = new Genre()
            {
                Name = name
            };

            this.genresRepo.Add(genre);

            this.context.SaveChanges();
        }

        public void CreateAlbum(string title, string artistName, string coverUrl)
        {
            Guard.WhenArgument(title, "title").IsNull().Throw();
            Guard.WhenArgument(artistName, "artistName").IsNull().Throw();
            Guard.WhenArgument(coverUrl, "coverUrl").IsNull().Throw();

            if (!this.artistsRepo.All.Any(x => x.Name == artistName))
            {
                this.CreateArtist(artistName);
            }

            var artist = this.artistsRepo
                .All
                .Where(x => x.Name == artistName)
                .FirstOrDefault();

            var album = new Album()
            {
                Title = title,
                Artist = artist,
                CoverUrl = coverUrl
            };

            this.albumsRepo.Add(album);

            this.context.SaveChanges();
        }

        public void CreateSong(string title, string artistName, string albumName, int? duration, ICollection<string> selectedGenres, string lyrics, string videoUrl)
        {
            Guard.WhenArgument(title, "title").IsNull().Throw();
            Guard.WhenArgument(artistName, "artistName").IsNull().Throw();
            Guard.WhenArgument(albumName, "albumName").IsNull().Throw();
            Guard.WhenArgument(duration, "duration").IsNull().Throw();
            Guard.WhenArgument(selectedGenres, "selectedGenres").IsNull().Throw();
            Guard.WhenArgument(lyrics, "lyrics").IsNull().Throw();
            Guard.WhenArgument(videoUrl, "videoUrl").IsNull().Throw();

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

            var song = new Song()
            {
                Title = title,
                Artist = artist,
                Album = album,
                Duration = duration,
                Genres = genres,
                Lyrics = lyrics,
                VideoUrl = videoUrl
            };

            this.songsRepo.Add(song);

            this.context.SaveChanges();
        }
    }
}
