using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Contracts;
using Reverb.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Reverb.Services.UnitTests.SongServiceTests
{
    [TestClass]
    public class GetSongs_Should
    {
        [TestMethod]
        public void CallPropertyAllInContextWrapper()
        {
            // Arrange
            var repository = new Mock<IEfContextWrapper<Song>>();
            var context = new Mock<ISaveContext>();

            var sut = new SongService(repository.Object, context.Object);

            repository.Setup(x => x.All);

            // Act
            sut.GetSongs();

            // Assert
            repository.Verify(x => x.All, Times.Once);
        }

        [TestMethod]
        public void ReturnCorrectSongObjects()
        {
            // Arrange
            const string songTitle = "Title";

            var repository = new Mock<IEfContextWrapper<Song>>();
            var context = new Mock<ISaveContext>();

            var sut = new SongService(repository.Object, context.Object);

            var songCollection = new List<Song>()
            {
                new Song()
                {
                    Title = songTitle
                } 
            };

            repository.Setup(x => x.All).Returns(() => songCollection.AsQueryable());

            // Act
            var result = sut.GetSongs().ToList();

            // Assert
            Assert.AreEqual(songCollection[0].Title, result[0].Title);
        }        
    }
}
