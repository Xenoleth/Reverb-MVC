using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Contracts;
using Reverb.Data.Models;

namespace Reverb.Services.UnitTests.GenreServiceTests
{
    [TestClass]
    public class Update_Should
    {
        [TestMethod]
        public void CallSaveChangesOnce()
        {
            // Arrange
            var repository = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            var sut = new GenreService(repository.Object, context.Object);

            context.Setup(x => x.SaveChanges());

            // Act
            sut.Update(new Genre());

            // Assert
            context.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void CallSongRepoUpdateOnce()
        {
            // Arrange
            var repository = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();
            var genre = new Genre();

            var sut = new GenreService(repository.Object, context.Object);

            repository.Setup(x => x.Update(It.IsAny<Genre>()));

            // Act
            sut.Update(genre);

            // Assert
            repository.Verify(x => x.Update(genre), Times.Once);
        }
    }
}
