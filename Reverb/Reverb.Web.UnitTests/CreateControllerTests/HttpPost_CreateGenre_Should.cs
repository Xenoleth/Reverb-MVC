using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Services.Contracts;
using Reverb.Web.Controllers;
using Reverb.Web.Models.Create;

namespace Reverb.Web.UnitTests.CreateControllerTests
{
    [TestClass]
    public class HttpPost_CreateGenre_Should
    {
        [TestMethod]
        public void CallCreateServiceMethodCreateGenreOnce_WhenInvoked()
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

            var model = new CreateGenreViewModel()
            {
                Name = "Genre Name"
            };

            // Act
            sut.CreateGenre(model);

            // Assert
            createService.Verify(x => x.CreateGenre(It.IsAny<string>()), Times.Once);
        }
    }
}
