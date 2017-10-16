using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Services.Contracts;
using Reverb.Web.Controllers;
using Reverb.Web.Models.Song;
using System;
using System.Collections.Generic;

namespace Reverb.Web.UnitTests.SongControllerTests
{
    [TestClass]
    public class HttpPost_EditSong_Should
    {
        [TestMethod]
        public void CallSongModifyServiceMethodUpdateSongOnce_WhenInvoked()
        {
            // Arrange
            var songService = new Mock<ISongService>();
            var userService = new Mock<IUserService>();
            var artistService = new Mock<IArtistService>();
            var albumService = new Mock<IAlbumService>();
            var genreService = new Mock<IGenreService>();
            var songModifyService = new Mock<ISongModifyService>();

            songModifyService.Setup(x => x.UpdateSong(
                It.IsAny<Guid>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<int?>(),
                It.IsAny<ICollection<string>>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()));

            var sut = new SongController(
                songService.Object,
                userService.Object,
                artistService.Object,
                albumService.Object,
                genreService.Object,
                songModifyService.Object);

            var model = new SongViewModel()
            {
                Id = Guid.NewGuid(),
                Title = "Title",
                Artist = "Artist",
                Album = "Album",
                Duration = 5,
                Genres = new List<string>()
                {
                    "Genre"
                },
                Lyrics = "Lyrics",
                VideoUrl = "VideoUrl",
                CoverUrl = "CoverUrl"
            };  

            // Act
            sut.EditSong(model);

            // Assert
            songModifyService.Verify(x => x.UpdateSong(
                It.IsAny<Guid>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<int?>(),
                It.IsAny<ICollection<string>>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()), Times.Once);
        }
    }
}
