using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Models;
using Reverb.Services.Contracts;
using Reverb.Web.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace Reverb.Web.UnitTests.CreateControllerTests
{
    [TestClass]
    public class HttpGet_CreateAlbum_Should
    {
        [TestMethod]
        public void CallArtistServiceMethodGetArtists_WhenInvoked()
        {
            // Arrange
            var createService = new Mock<ICreationService>();
            var artistService = new Mock<IArtistService>();
            var albumService = new Mock<IAlbumService>();
            var genreService = new Mock<IGenreService>();

            var artist = new Artist()
            {
                Name = "Artist Name"
            };

            var artistCollection = new List<Artist>()
            {
                artist
            };

            artistService.Setup(x => x.GetArtists()).Returns(() => artistCollection.AsQueryable());

            var sut = new CreateController(
                createService.Object,
                artistService.Object,
                albumService.Object,
                genreService.Object);

            // Act
            sut.CreateAlbum();

            // Assert
            artistService.Verify(x => x.GetArtists(), Times.Once);
        }
    }
}
