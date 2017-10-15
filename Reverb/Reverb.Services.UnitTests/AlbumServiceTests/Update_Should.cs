using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Contracts;
using Reverb.Data.Models;

namespace Reverb.Services.UnitTests.AlbumServiceTests
{
    [TestClass]
    public class Update_Should
    {
        [TestMethod]
        public void CallSaveChangesOnce()
        {
            // Arrange
            var repository = new Mock<IEfContextWrapper<Album>>();
            var context = new Mock<ISaveContext>();

            var sut = new AlbumService(repository.Object, context.Object);

            context.Setup(x => x.SaveChanges());

            // Act
            sut.Update(new Album());

            // Assert
            context.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void CallSongRepoUpdateOnce()
        {
            // Arrange
            var repository = new Mock<IEfContextWrapper<Album>>();
            var context = new Mock<ISaveContext>();
            var album = new Album();

            var sut = new AlbumService(repository.Object, context.Object);

            repository.Setup(x => x.Update(It.IsAny<Album>()));

            // Act
            sut.Update(album);

            // Assert
            repository.Verify(x => x.Update(album), Times.Once);
        }
    }
}
