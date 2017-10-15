using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Contracts;
using Reverb.Data.Models;
using System.Collections.Generic;
using System.Linq;


namespace Reverb.Services.UnitTests.GenreServiceTests
{
    [TestClass]
    public class GetGenres_Should
    {
        [TestMethod]
        public void CallPropertyAllInContextWrapper()
        {
            // Arrange
            var repository = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            var sut = new GenreService(repository.Object, context.Object);

            repository.Setup(x => x.All);

            // Act
            sut.GetGenres();

            // Assert
            repository.Verify(x => x.All, Times.Once);
        }

        [TestMethod]
        public void ReturnCorrectSongObjects()
        {
            // Arrange
            const string genreName = "Name";

            var repository = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            var sut = new GenreService(repository.Object, context.Object);

            var genreCollection = new List<Genre>()
            {
                new Genre()
                {
                    Name = genreName
                }
            };

            repository.Setup(x => x.All).Returns(() => genreCollection.AsQueryable());

            // Act
            var result = sut.GetGenres().ToList();

            // Assert
            Assert.AreEqual(genreCollection[0].Name, result[0].Name);
        }
    }
}
