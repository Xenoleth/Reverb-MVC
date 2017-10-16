using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Services.Contracts;
using Reverb.Web.Controllers;
using Reverb.Web.Models.Create;

namespace Reverb.Web.UnitTests.CreateControllerTests
{
    [TestClass]
    public class HttpPost_CreateAlbum_Should
    {
        [TestMethod]
        public void CallCreateServiceMethodCreateAlbumOnce_WhenInvoked()
        {
            // Arrange
            var createService = new Mock<ICreationService>();
            var artistService = new Mock<IArtistService>();
            var albumService = new Mock<IAlbumService>();
            var genreService = new Mock<IGenreService>();

            createService.Setup(x => x.CreateGenre(It.IsAny<string>()));

            var sut = new CreateController(
                createService.Object,
                artistService.Object,
                albumService.Object,
                genreService.Object);

            var model = new CreateAlbumViewModel()
            {
                Title = "Album Name",
                Artist = "Artist Name",
                CoverUrl = "CoverUrl"
            };

            // Act
            sut.CreateAlbum(model);

            // Assert
            createService.Verify(x => x.CreateAlbum(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
