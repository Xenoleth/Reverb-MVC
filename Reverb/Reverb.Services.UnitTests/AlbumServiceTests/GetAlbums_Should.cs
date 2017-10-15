using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Contracts;
using Reverb.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Reverb.Services.UnitTests.AlbumServiceTests
{

    [TestClass]
    public class GetAlbums_Should
    {
        [TestMethod]
        public void CallPropertyAllInContextWrapper()
        {
            // Arrange
            var repository = new Mock<IEfContextWrapper<Album>>();
            var context = new Mock<ISaveContext>();

            var sut = new AlbumService(repository.Object, context.Object);

            repository.Setup(x => x.All);

            // Act
            sut.GetAlbums();

            // Assert
            repository.Verify(x => x.All, Times.Once);
        }

        [TestMethod]
        public void ReturnCorrectSongObjects()
        {
            // Arrange
            const string albumTitle = "Title";

            var repository = new Mock<IEfContextWrapper<Album>>();
            var context = new Mock<ISaveContext>();

            var sut = new AlbumService(repository.Object, context.Object);

            var albumCollection = new List<Album>()
            {
                new Album()
                {
                    Title = albumTitle
                }
            };

            repository.Setup(x => x.All).Returns(() => albumCollection.AsQueryable());

            // Act
            var result = sut.GetAlbums().ToList();

            // Assert
            Assert.AreEqual(albumCollection[0].Title, result[0].Title);
        }
    }
}
