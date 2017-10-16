using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Models;
using Reverb.Services.Contracts;
using Reverb.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Reverb.Web.UnitTests.SongControllerTests
{
    [TestClass]
    public class RemoveFromFavorites_Should
    {
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

            var songCollection = new List<Song>()
            {
                new Song()
                {
                    Id = id,
                    Title = "Song Title",
                    Album = new Album() {
                        Title = "Album Title"
                    },
                    Artist = new Artist() {
                        Name = "Artist Name"
                    },
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

            songService.Setup(x => x.GetSongs()).Returns(() => songCollection.AsQueryable());
            userService.Setup(x => x.AddFavoriteSong(It.IsAny<Song>(), It.IsAny<string>()));

            var sut = new SongController(
                songService.Object,
                userService.Object,
                artistService.Object,
                albumService.Object,
                genreService.Object,
                songModifyService.Object);

            var userName = "userName";
            var context = new Mock<ControllerContext>();
            context.SetupGet(x => x.HttpContext.User.Identity.Name).Returns(() => userName);

            sut.ControllerContext = context.Object;

            // Act
            sut.RemoveFromFavorites(id);

            // Assert
            songService.Verify(x => x.GetSongs(), Times.Once);
        }

        [TestMethod]
        public void CallUserServiceMethodAddFavoriteSongOnce_WhenInvoked()
        {
            // Arrange
            var songService = new Mock<ISongService>();
            var userService = new Mock<IUserService>();
            var artistService = new Mock<IArtistService>();
            var albumService = new Mock<IAlbumService>();
            var genreService = new Mock<IGenreService>();
            var songModifyService = new Mock<ISongModifyService>();

            var id = Guid.NewGuid();

            var songCollection = new List<Song>()
            {
                new Song()
                {
                    Id = id,
                    Title = "Song Title",
                    Album = new Album() {
                        Title = "Album Title"
                    },
                    Artist = new Artist() {
                        Name = "Artist Name"
                    },
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

            songService.Setup(x => x.GetSongs()).Returns(() => songCollection.AsQueryable());
            userService.Setup(x => x.AddFavoriteSong(It.IsAny<Song>(), It.IsAny<string>()));

            var sut = new SongController(
                songService.Object,
                userService.Object,
                artistService.Object,
                albumService.Object,
                genreService.Object,
                songModifyService.Object);

            var userName = "userName";
            var context = new Mock<ControllerContext>();
            context.SetupGet(x => x.HttpContext.User.Identity.Name).Returns(() => userName);

            sut.ControllerContext = context.Object;

            // Act
            sut.RemoveFromFavorites(id);

            // Assert
            userService.Verify(x => x.RemoveFavoriteSong(It.IsAny<Song>(), It.IsAny<string>()), Times.Once);
        }

    }
}
