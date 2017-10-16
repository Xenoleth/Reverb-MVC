using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Models;
using Reverb.Services.Contracts;
using Reverb.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverb.Web.UnitTests.SongControllerTests
{
    [TestClass]
    public class HttpGet_EditSong_Should
    {
        [TestMethod]
        public void CallArtistServiceMethodGetArtistsOnce_WhenInvoked()
        {
            // Arrange
            var songService = new Mock<ISongService>();
            var userService = new Mock<IUserService>();
            var artistService = new Mock<IArtistService>();
            var albumService = new Mock<IAlbumService>();
            var genreService = new Mock<IGenreService>();
            var songModifyService = new Mock<ISongModifyService>();

            var id = Guid.NewGuid();
            var artist = new Artist()
            {
                Name = "Artist Name"
            };

            var songCollection = new List<Song>()
            {
                new Song()
                {
                    Id = id,
                    Title = "Song Title",
                    Album = new Album() {
                        Title = "Album Title"
                    },
                    Artist = artist,
                    Duration = 5,
                    Genres = new List<Genre>() {
                        new Genre()
                        {
                            Name = "Genre Name"
                        }
                    },
                    Lyrics = "Some Lyrics",
                    VideoUrl = "VideoUrl"

                }
            };

            var artistCollection = new List<Artist>()
            {
                artist
            };

            artistService.Setup(x => x.GetArtists()).Returns(() => artistCollection.AsQueryable());
            songService.Setup(x => x.GetSongs()).Returns(() => songCollection.AsQueryable());
            userService.Setup(x => x.AddFavoriteSong(It.IsAny<Song>(), It.IsAny<string>()));

            var sut = new SongController(
                songService.Object,
                userService.Object,
                artistService.Object,
                albumService.Object,
                genreService.Object,
                songModifyService.Object);

            // Act
            sut.EditSong(id);

            // Assert
            artistService.Verify(x => x.GetArtists(), Times.Once);
        }

        [TestMethod]
        public void CallAlbumServiceMethodGetAlbumsOnce_WhenInvoked()
        {
            // Arrange
            var songService = new Mock<ISongService>();
            var userService = new Mock<IUserService>();
            var artistService = new Mock<IArtistService>();
            var albumService = new Mock<IAlbumService>();
            var genreService = new Mock<IGenreService>();
            var songModifyService = new Mock<ISongModifyService>();

            var id = Guid.NewGuid();
            var artist = new Artist()
            {
                Name = "Artist Name"
            };
            var album = new Album()
            {
                Title = "Album Title"
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
                    Genres = new List<Genre>() {
                        new Genre()
                        {
                            Name = "Genre Name"
                        }
                    },
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

            albumService.Setup(x => x.GetAlbums()).Returns(() => albumCollection.AsQueryable());
            artistService.Setup(x => x.GetArtists()).Returns(() => artistCollection.AsQueryable());
            songService.Setup(x => x.GetSongs()).Returns(() => songCollection.AsQueryable());
            userService.Setup(x => x.AddFavoriteSong(It.IsAny<Song>(), It.IsAny<string>()));

            var sut = new SongController(
                songService.Object,
                userService.Object,
                artistService.Object,
                albumService.Object,
                genreService.Object,
                songModifyService.Object);

            // Act
            sut.EditSong(id);

            // Assert
            albumService.Verify(x => x.GetAlbums(), Times.Once);
        }

        [TestMethod]
        public void CallGenreServiceMethodGetGenresOnce_WhenInvoked()
        {
            // Arrange
            var songService = new Mock<ISongService>();
            var userService = new Mock<IUserService>();
            var artistService = new Mock<IArtistService>();
            var albumService = new Mock<IAlbumService>();
            var genreService = new Mock<IGenreService>();
            var songModifyService = new Mock<ISongModifyService>();

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
            songService.Setup(x => x.GetSongs()).Returns(() => songCollection.AsQueryable());
            userService.Setup(x => x.AddFavoriteSong(It.IsAny<Song>(), It.IsAny<string>()));

            var sut = new SongController(
                songService.Object,
                userService.Object,
                artistService.Object,
                albumService.Object,
                genreService.Object,
                songModifyService.Object);

            // Act
            sut.EditSong(id);

            // Assert
            genreService.Verify(x => x.GetGenres(), Times.Once);
        }

        [TestMethod]
        public void CallSongServiceMethodGetSongsOnce_WhenInvoked()
        {
            // Arrange
            var songService = new Mock<ISongService>();
            var userService = new Mock<IUserService>();
            var artistService = new Mock<IArtistService>();
            var albumService = new Mock<IAlbumService>();
            var genreService = new Mock<IGenreService>();
            var songModifyService = new Mock<ISongModifyService>();

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
            songService.Setup(x => x.GetSongs()).Returns(() => songCollection.AsQueryable());
            userService.Setup(x => x.AddFavoriteSong(It.IsAny<Song>(), It.IsAny<string>()));

            var sut = new SongController(
                songService.Object,
                userService.Object,
                artistService.Object,
                albumService.Object,
                genreService.Object,
                songModifyService.Object);

            // Act
            sut.EditSong(id);

            // Assert
            songService.Verify(x => x.GetSongs(), Times.Once);
        }
    }
}
