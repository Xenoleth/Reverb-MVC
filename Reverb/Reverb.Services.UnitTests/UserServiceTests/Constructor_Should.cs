using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Contracts;
using Reverb.Data.Models;
using System;

namespace Reverb.Services.UnitTests.UserServiceTests
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
            Assert.ThrowsException<ArgumentNullException>(() => new UserService(null, context.Object));
        }

        [TestMethod]
        public void ThrowWhenSaveContextIsNotPassedAsParameter()
        {
            // Arrange
            var repository = new Mock<IEfContextWrapper<User>>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UserService(repository.Object, null));
        }
    }
}
