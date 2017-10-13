using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Contracts;
using Reverb.Data.Models;

namespace Reverb.Services.UnitTests.SongServiceTests
{
    [TestClass]
    public class Update_Should
    {
        [TestMethod]
        public void CallSaveChangesOnce()
        {
            // Arrange
            var repository = new Mock<IEfContextWrapper<Song>>();
            var context = new Mock<ISaveContext>();

            var sut = new SongService(repository.Object, context.Object);

            context.Setup(x => x.SaveChanges());

            // Act
            sut.Update(new Song());

            // Assert
            context.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void CallSongRepoUpdateOnce()
        {
            // Arrange
            var repository = new Mock<IEfContextWrapper<Song>>();
            var context = new Mock<ISaveContext>();
            var song = new Song();

            var sut = new SongService(repository.Object, context.Object);

            repository.Setup(x => x.Update(It.IsAny<Song>()));

            // Act
            sut.Update(song);

            // Assert
            repository.Verify(x => x.Update(song), Times.Once);
        }
    }
}
