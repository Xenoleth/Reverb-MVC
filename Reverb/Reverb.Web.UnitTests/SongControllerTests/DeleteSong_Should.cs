using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Services.Contracts;
using Reverb.Web.Controllers;
using System;

namespace Reverb.Web.UnitTests.SongControllerTests
{
    [TestClass]
    public class DeleteSong_Should
    {
        [TestMethod]
        public void CallSongModifyServiceMethodDeleteSong_WhenInvoked()
        {
            // Arrange
            var songService = new Mock<ISongService>();
            var userService = new Mock<IUserService>();
            var artistService = new Mock<IArtistService>();
            var albumService = new Mock<IAlbumService>();
            var genreService = new Mock<IGenreService>();
            var songModifyService = new Mock<ISongModifyService>();

            songModifyService.Setup(x => x.DeleteSong(It.IsAny<Guid>()));

            var id = Guid.NewGuid();

            var sut = new SongController(
                songService.Object,
                userService.Object,
                artistService.Object,
                albumService.Object,
                genreService.Object,
                songModifyService.Object);

            // Act
            sut.DeleteSong(id);

            // Assert
            songModifyService.Verify(x => x.DeleteSong(It.IsAny<Guid>()), Times.Once);
        }
    }
}
