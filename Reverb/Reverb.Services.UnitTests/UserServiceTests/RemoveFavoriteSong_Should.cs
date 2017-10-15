using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Contracts;
using Reverb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverb.Services.UnitTests.UserServiceTests
{
    [TestClass]
    public class RemoveFavoriteSong_Should
    {
        [TestMethod]
        public void Throw_WhenNullSongIsPassed()
        {
            // Arrange
            var repository = new Mock<IEfContextWrapper<User>>();
            var context = new Mock<ISaveContext>();

            var email = "email";

            var sut = new UserService(repository.Object, context.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => sut.RemoveFavoriteSong(null, email));
        }

        [TestMethod]
        public void Throw_WhenNullEmailIsPassed()
        {
            // Arrange
            var repository = new Mock<IEfContextWrapper<User>>();
            var context = new Mock<ISaveContext>();

            var song = new Song();

            var sut = new UserService(repository.Object, context.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => sut.RemoveFavoriteSong(song, null));
        }

        [TestMethod]
        public void CallUsersRepoPropertyAllOnce_WhenInvoked()
        {
            // Arrange
            var repository = new Mock<IEfContextWrapper<User>>();
            var context = new Mock<ISaveContext>();

            var email = "email";
            var song = new Song();

            var userCollection = new List<User>()
            {
                new User()
                {
                    Email = email,
                    FavoriteSongs = new HashSet<Song>()
                }
            };

            repository.Setup(x => x.All).Returns(() => userCollection.AsQueryable());

            var sut = new UserService(repository.Object, context.Object);

            // Act
            sut.RemoveFavoriteSong(song, email);

            // Assert
            repository.Verify(x => x.All, Times.Once);
        }

        [TestMethod]
        public void RemoveSongFromUserFavoriteSongs_WhenInvoked()
        {
            // Arrange
            var repository = new Mock<IEfContextWrapper<User>>();
            var context = new Mock<ISaveContext>();

            var email = "email";
            var song = new Song();

            var userCollection = new List<User>()
            {
                new User()
                {
                    Email = email,
                    FavoriteSongs = new HashSet<Song>()
                }
            };

            userCollection[0].FavoriteSongs.Add(song);

            repository.Setup(x => x.All).Returns(() => userCollection.AsQueryable());

            var sut = new UserService(repository.Object, context.Object);

            // Act
            sut.RemoveFavoriteSong(song, email);

            // Assert
            var item = repository.Object.All.Where(x => x.Email == email).SingleOrDefault().FavoriteSongs.FirstOrDefault();
            Assert.IsTrue(item == null);
        }

        [TestMethod]
        public void CallContextSaveChanges_WhenInvoked()
        {
            // Arrange
            var repository = new Mock<IEfContextWrapper<User>>();
            var context = new Mock<ISaveContext>();

            var email = "email";
            var song = new Song();

            var userCollection = new List<User>()
            {
                new User()
                {
                    Email = email,
                    FavoriteSongs = new HashSet<Song>()
                }
            };

            repository.Setup(x => x.All).Returns(() => userCollection.AsQueryable());
            context.Setup(x => x.SaveChanges());

            var sut = new UserService(repository.Object, context.Object);

            // Act
            sut.RemoveFavoriteSong(song, email);

            // Assert
            context.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
