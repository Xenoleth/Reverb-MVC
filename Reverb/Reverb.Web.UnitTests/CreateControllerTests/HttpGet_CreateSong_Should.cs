using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Models;
using Reverb.Services.Contracts;
using Reverb.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverb.Web.UnitTests.CreateControllerTests
{
    [TestClass]
    public class HttpGet_CreateSong_Should
    {
        [TestMethod]
        public void CallArtistServiceGetArtistsOnce_WhenInvoked()
        {
            // Arrange
            var createService = new Mock<ICreationService>();
            var artistService = new Mock<IArtistService>();
            var albumService = new Mock<IAlbumService>();
            var genreService = new Mock<IGenreService>();

            var id = Guid.NewGuid();
            var artist = new Artist()
            {
                Name = "Artist Name"
            };
            var album = new Album()
            {
                Title = "Album Title"
            };
            var genre = new Genre()
            {
                Name = "Genre Name"
            };
            var genres = new List<Genre>() {
                new Genre()
                {
                    Name = "Genre Name"
                }
            };

            var songCollection = new List<Song>()
            {
                new Song()
                {
                    Id = id,
                    Title = "Song Title",
                    Album = album,
                    Artist = artist,
                    Duration = 5,
                    Genres = genres,
                    Lyrics = "Some Lyrics",
                    VideoUrl = "VideoUrl"

                }
            };

            var artistCollection = new List<Artist>()
            {
                artist
            };

            var albumCollection = new List<Album>()
            {
                album
            };

            var genreCollection = new List<Genre>()
            {
                genre
            };

            genreService.Setup(x => x.GetGenres()).Returns(() => genreCollection.AsQueryable());
            albumService.Setup(x => x.GetAlbums()).Returns(() => albumCollection.AsQueryable());
            artistService.Setup(x => x.GetArtists()).Returns(() => artistCollection.AsQueryable());

            var sut = new CreateController(
                createService.Object,
                artistService.Object,
                albumService.Object,
                genreService.Object);

            // Act
            sut.CreateSong();

            // Assert
            artistService.Verify(x => x.GetArtists(), Times.Once);
        }

        [TestMethod]
        public void CallAlbumServiceGetAlbumsOnce_WhenInvoked()
        {
            // Arrange
            var createService = new Mock<ICreationService>();
            var artistService = new Mock<IArtistService>();
            var albumService = new Mock<IAlbumService>();
            var genreService = new Mock<IGenreService>();

            var id = Guid.NewGuid();
            var artist = new Artist()
            {
                Name = "Artist Name"
            };
            var album = new Album()
            {
                Title = "Album Title"
            };
            var genre = new Genre()
            {
                Name = "Genre Name"
            };
            var genres = new List<Genre>() {
                new Genre()
                {
                    Name = "Genre Name"
                }
            };

            var songCollection = new List<Song>()
            {
                new Song()
                {
                    Id = id,
                    Title = "Song Title",
                    Album = album,
                    Artist = artist,
                    Duration = 5,
                    Genres = genres,
                    Lyrics = "Some Lyrics",
                    VideoUrl = "VideoUrl"

                }
            };

            var artistCollection = new List<Artist>()
            {
                artist
            };

            var albumCollection = new List<Album>()
            {
                album
            };

            var genreCollection = new List<Genre>()
            {
                genre
            };

            genreService.Setup(x => x.GetGenres()).Returns(() => genreCollection.AsQueryable());
            albumService.Setup(x => x.GetAlbums()).Returns(() => albumCollection.AsQueryable());
            artistService.Setup(x => x.GetArtists()).Returns(() => artistCollection.AsQueryable());

            var sut = new CreateController(
                createService.Object,
                artistService.Object,
                albumService.Object,
                genreService.Object);

            // Act
            sut.CreateSong();

            // Assert
            albumService.Verify(x => x.GetAlbums(), Times.Once);
        }

        [TestMethod]
        public void CallGenreServiceGetGenresOnce_WhenInvoked()
        {
            // Arrange
            var createService = new Mock<ICreationService>();
            var artistService = new Mock<IArtistService>();
            var albumService = new Mock<IAlbumService>();
            var genreService = new Mock<IGenreService>();

            var id = Guid.NewGuid();
            var artist = new Artist()
            {
                Name = "Artist Name"
            };
            var album = new Album()
            {
                Title = "Album Title"
            };
            var genre = new Genre()
            {
                Name = "Genre Name"
            };
            var genres = new List<Genre>() {
                new Genre()
                {
                    Name = "Genre Name"
                }
            };

            var songCollection = new List<Song>()
            {
                new Song()
                {
                    Id = id,
                    Title = "Song Title",
                    Album = album,
                    Artist = artist,
                    Duration = 5,
                    Genres = genres,
                    Lyrics = "Some Lyrics",
                    VideoUrl = "VideoUrl"

                }
            };

            var artistCollection = new List<Artist>()
            {
                artist
            };

            var albumCollection = new List<Album>()
            {
                album
            };

            var genreCollection = new List<Genre>()
            {
                genre
            };

            genreService.Setup(x => x.GetGenres()).Returns(() => genreCollection.AsQueryable());
            albumService.Setup(x => x.GetAlbums()).Returns(() => albumCollection.AsQueryable());
            artistService.Setup(x => x.GetArtists()).Returns(() => artistCollection.AsQueryable());

            var sut = new CreateController(
                createService.Object,
                artistService.Object,
                albumService.Object,
                genreService.Object);

            // Act
            sut.CreateSong();

            // Assert
            genreService.Verify(x => x.GetGenres(), Times.Once);
        }
    }
}
