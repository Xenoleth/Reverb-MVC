using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Contracts;
using Reverb.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Reverb.Services.UnitTests.UserServiceTests
{
    [TestClass]
    public class GetUsers_Should
    {
        [TestMethod]
        public void CallPropertyAllInContextWrapper()
        {
            // Arrange
            var repository = new Mock<IEfContextWrapper<User>>();
            var context = new Mock<ISaveContext>();

            var sut = new UserService(repository.Object, context.Object);

            repository.Setup(x => x.All);

            // Act
            sut.GetUsers();

            // Assert
            repository.Verify(x => x.All, Times.Once);
        }

        [TestMethod]
        public void ReturnCorrectSongObjects()
        {
            // Arrange
            const string userName = "Name";

            var repository = new Mock<IEfContextWrapper<User>>();
            var context = new Mock<ISaveContext>();

            var sut = new UserService(repository.Object, context.Object);

            var userCollection = new List<User>()
            {
                new User()
                {
                    UserName = userName
                }
            };

            repository.Setup(x => x.All).Returns(() => userCollection.AsQueryable());

            // Act
            var result = sut.GetUsers().ToList();

            // Assert
            Assert.AreEqual(userCollection[0].UserName, result[0].UserName);
        }
    }
}
