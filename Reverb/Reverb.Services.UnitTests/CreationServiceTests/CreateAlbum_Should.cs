using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Contracts;
using Reverb.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Reverb.Services.UnitTests.CreationServiceTests
{
    [TestClass]
    public class CreateAlbum_Should
    {
        [TestMethod]
        public void CallCreateArtist_IfArtistRepoDoesNotFindArtistWithGivenName()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            var title = "Title";
            var artistName = "Artist Name";
            var coverUrl = "CoverUrl";

            var artistCollection = new List<Artist>()
            {
                new Artist()
                {
                    Name = "Some Name"
                }
            };

            artistRepo.Setup(x => x.All).Returns(() => artistCollection.AsQueryable());
            artistRepo.Setup(x => x.Add(It.IsAny<Artist>()));

            var sut = new CreationService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                context.Object);

            // Act
            sut.CreateAlbum(title, artistName, coverUrl);

            // Assert
            artistRepo.Verify(x => x.Add(It.IsAny<Artist>()), Times.Once);
        }

        [TestMethod]
        public void CallArtistRepoPropertyAll_WhenInvoked()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            var title = "Title";
            var artistName = "Artist Name";
            var coverUrl = "CoverUrl";

            var artistCollection = new List<Artist>()
            {
                new Artist()
                {
                    Name = artistName
                }
            };

            artistRepo.Setup(x => x.All).Returns(() => artistCollection.AsQueryable());
            artistRepo.Setup(x => x.Add(It.IsAny<Artist>()));

            var sut = new CreationService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                context.Object);

            // Act
            sut.CreateAlbum(title, artistName, coverUrl);

            // Assert
            artistRepo.Verify(x => x.All, Times.Exactly(2));
        }

        [TestMethod]
        public void CallAlbumsRepoMethodAddOnce_WhenInvoked()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            var title = "Title";
            var artistName = "Artist Name";
            var coverUrl = "CoverUrl";

            var artistCollection = new List<Artist>()
            {
                new Artist()
                {
                    Name = artistName
                }
            };

            artistRepo.Setup(x => x.All).Returns(() => artistCollection.AsQueryable());
            artistRepo.Setup(x => x.Add(It.IsAny<Artist>()));
            albumRepo.Setup(x => x.Add(It.IsAny<Album>()));

            var sut = new CreationService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                context.Object);

            // Act
            sut.CreateAlbum(title, artistName, coverUrl);

            // Assert
            albumRepo.Verify(x => x.Add(It.IsAny<Album>()), Times.Once);
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

            var title = "Title";
            var artistName = "Artist Name";
            var coverUrl = "CoverUrl";

            var artistCollection = new List<Artist>()
            {
                new Artist()
                {
                    Name = artistName
                }
            };

            artistRepo.Setup(x => x.All).Returns(() => artistCollection.AsQueryable());
            artistRepo.Setup(x => x.Add(It.IsAny<Artist>()));
            albumRepo.Setup(x => x.Add(It.IsAny<Album>()));
            context.Setup(x => x.SaveChanges());

            var sut = new CreationService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                context.Object);

            // Act
            sut.CreateAlbum(title, artistName, coverUrl);

            // Assert
            context.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
