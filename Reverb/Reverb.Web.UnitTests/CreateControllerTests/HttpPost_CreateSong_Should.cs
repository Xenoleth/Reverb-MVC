using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Services.Contracts;
using Reverb.Web.Controllers;
using Reverb.Web.Models.Create;
using System.Collections.Generic;

namespace Reverb.Web.UnitTests.CreateControllerTests
{
    [TestClass]
    public class HttpPost_CreateSong_Should
    {
        [TestMethod]
        public void CallCreateServiceMethodCreateSong_WhenInvoked()
        {
            // Arrange
            var createService = new Mock<ICreationService>();
            var artistService = new Mock<IArtistService>();
            var albumService = new Mock<IAlbumService>();
            var genreService = new Mock<IGenreService>();

            createService.Setup(x => x.CreateSong(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<int?>(),
                It.IsAny<ICollection<string>>(),
                It.IsAny<string>(),
                It.IsAny<string>()));

            var sut = new CreateController(
                createService.Object,
                artistService.Object,
                albumService.Object,
                genreService.Object);

            var model = new CreateSongViewModel()
            {
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
            };

            // Act
            sut.CreateSong(model);

            // Assert
            createService.Verify(x => x.CreateSong(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<int?>(),
                It.IsAny<ICollection<string>>(),
                It.IsAny<string>(),
                It.IsAny<string>()), Times.Once);
        }
    }
}
