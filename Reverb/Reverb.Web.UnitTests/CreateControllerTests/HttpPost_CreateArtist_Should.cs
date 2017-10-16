using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Services.Contracts;
using Reverb.Web.Controllers;
using Reverb.Web.Models.Create;

namespace Reverb.Web.UnitTests.CreateControllerTests
{
    [TestClass]
    public class HttpPost_CreateArtist_Should
    {
        [TestMethod]
        public void CallCreateServiceMethodCreateArtistOnce_WhenInvoked()
        {
            // Arrange
            var createService = new Mock<ICreationService>();
            var artistService = new Mock<IArtistService>();
            var albumService = new Mock<IAlbumService>();
            var genreService = new Mock<IGenreService>();

            createService.Setup(x => x.CreateArtist(It.IsAny<string>()));

            var sut = new CreateController(
                createService.Object,
                artistService.Object,
                albumService.Object,
                genreService.Object);

            var model = new CreateArtistViewModel()
            {
                Name = "Artist Name"
            };

            // Act
            sut.CreateArtist(model);

            // Assert
            createService.Verify(x => x.CreateArtist(It.IsAny<string>()), Times.Once);
        }
    }
}
