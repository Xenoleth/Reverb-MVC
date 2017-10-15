using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Contracts;
using Reverb.Data.Models;
using System;


namespace Reverb.Services.UnitTests.GenreServiceTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowWhenContextWrapperIsNotPassedAsParameter()
        {
            // Arrange
            var context = new Mock<ISaveContext>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new GenreService(null, context.Object));
        }

        [TestMethod]
        public void ThrowWhenSaveContextIsNotPassedAsParameter()
        {
            // Arrange
            var repository = new Mock<IEfContextWrapper<Genre>>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new GenreService(repository.Object, null));
        }
    }
}
