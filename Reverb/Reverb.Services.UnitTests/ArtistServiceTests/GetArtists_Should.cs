using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Contracts;
using Reverb.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Reverb.Services.UnitTests.ArtistServiceTests
{
    [TestClass]
    public class GetArtists_Should
    {
        [TestMethod]
        public void CallPropertyAllInContextWrapper()
        {
            // Arrange
            var repository = new Mock<IEfContextWrapper<Artist>>();
            var context = new Mock<ISaveContext>();

            var sut = new ArtistService(repository.Object, context.Object);

            repository.Setup(x => x.All);

            // Act
            sut.GetArtists();

            // Assert
            repository.Verify(x => x.All, Times.Once);
        }

        [TestMethod]
        public void ReturnCorrectSongObjects()
        {
            // Arrange
            const string artistName = "Name";

            var repository = new Mock<IEfContextWrapper<Artist>>();
            var context = new Mock<ISaveContext>();

            var sut = new ArtistService(repository.Object, context.Object);

            var artistCollection = new List<Artist>()
            {
                new Artist()
                {
                    Name = artistName
                }
            };

            repository.Setup(x => x.All).Returns(() => artistCollection.AsQueryable());

            // Act
            var result = sut.GetArtists().ToList();

            // Assert
            Assert.AreEqual(artistCollection[0].Name, result[0].Name);
        }
    }
}
