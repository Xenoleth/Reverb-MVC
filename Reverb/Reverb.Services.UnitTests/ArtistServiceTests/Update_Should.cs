using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Contracts;
using Reverb.Data.Models;


namespace Reverb.Services.UnitTests.ArtistServiceTests
{
    [TestClass]
    public class Update_Should
    {
        [TestMethod]
        public void CallSaveChangesOnce()
        {
            // Arrange
            var repository = new Mock<IEfContextWrapper<Artist>>();
            var context = new Mock<ISaveContext>();

            var sut = new ArtistService(repository.Object, context.Object);

            context.Setup(x => x.SaveChanges());

            // Act
            sut.Update(new Artist());

            // Assert
            context.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void CallSongRepoUpdateOnce()
        {
            // Arrange
            var repository = new Mock<IEfContextWrapper<Artist>>();
            var context = new Mock<ISaveContext>();
            var artist = new Artist();

            var sut = new ArtistService(repository.Object, context.Object);

            repository.Setup(x => x.Update(It.IsAny<Artist>()));

            // Act
            sut.Update(artist);

            // Assert
            repository.Verify(x => x.Update(artist), Times.Once);
        }
    }
}
