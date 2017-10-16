using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Contracts;
using Reverb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Reverb.Services.UnitTests.SongModifyServiceTests
{
    [TestClass]
    public class DeleteSong_Should
    {
        [TestMethod]
        public void CallSongRepoAllPropertyOnce_WhenInvoked()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            var id = Guid.NewGuid();
            var songTitle = "Song Title";
            var songCollection = new List<Song>()
            {
                new Song()
                {
                    Title = songTitle,
                    Id = id
                }
            };

            songRepo.Setup(x => x.All).Returns(() => songCollection.AsQueryable());

            var sut = new SongModifyService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                context.Object);

            // Act
            sut.DeleteSong(id);

            // Assert
            songRepo.Verify(x => x.All, Times.Once);
        }

        [TestMethod]
        public void CallSongRepoDeleteMethodOnce_WhenInvoked()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            var id = Guid.NewGuid();
            var songTitle = "Song Title";
            var songCollection = new List<Song>()
            {
                new Song()
                {
                    Title = songTitle,
                    Id = id
                }
            };

            songRepo.Setup(x => x.All).Returns(() => songCollection.AsQueryable());
            songRepo.Setup(x => x.Delete(It.IsAny<Song>()));

            var sut = new SongModifyService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                context.Object);

            // Act
            sut.DeleteSong(id);

            // Assert
            songRepo.Verify(x => x.Delete(songCollection.FirstOrDefault()), Times.Once);
        }

        [TestMethod]
        public void CallContextSaveChangesOnce_WhenInvoked()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            var id = Guid.NewGuid();
            var songTitle = "Song Title";
            var songCollection = new List<Song>()
            {
                new Song()
                {
                    Title = songTitle,
                    Id = id
                }
            };

            songRepo.Setup(x => x.All).Returns(() => songCollection.AsQueryable());
            songRepo.Setup(x => x.Delete(It.IsAny<Song>()));
            context.Setup(x => x.SaveChanges());

            var sut = new SongModifyService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                context.Object);

            // Act
            sut.DeleteSong(id);

            // Assert
            context.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
