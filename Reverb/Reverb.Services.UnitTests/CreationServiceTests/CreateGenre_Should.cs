using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Contracts;
using Reverb.Data.Models;

namespace Reverb.Services.UnitTests.CreationServiceTests
{
    [TestClass]
    public class CreateGenre_Should
    {
        [TestMethod]
        public void CallArtistRepoMethodAddOnce_WhenInvoked()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            genreRepo.Setup(x => x.Add(It.IsAny<Genre>()));

            var genreName = "Name";

            var sut = new CreationService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                context.Object);

            // Act
            sut.CreateGenre(genreName);

            // Assert
            genreRepo.Verify(x => x.Add(It.IsAny<Genre>()), Times.Once);
        }

        [TestMethod]
        public void CallContextSaveChangesOnce_WhenInvoked()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            genreRepo.Setup(x => x.Add(It.IsAny<Genre>()));
            context.Setup(x => x.SaveChanges());

            var genreName = "Name";

            var sut = new CreationService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                context.Object);

            // Act
            sut.CreateGenre(genreName);

            // Assert
            context.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
