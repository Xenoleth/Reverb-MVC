using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Contracts;
using Reverb.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Reverb.Services.UnitTests.CreationServiceTests
{
    [TestClass]
    public class CreateSong_Should
    {
        [TestMethod]
        public void CallArtistRepoPropertyAllOnce_WhenInvoked()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            var title = "Title";
            var artistName = "Artist Name";
            var albumName = "Album Name";
            int? duration = 5;
            var lyrics = "Lyrics";
            var videoUrl = "VideUrl";
            var selectedGenres = new List<string>()
            {
                "Genre Name"
            };

            var artistCollection = new List<Artist>()
            {
                new Artist()
                {
                    Name = artistName
                }
            };

            artistRepo.Setup(x => x.All).Returns(() => artistCollection.AsQueryable());

            var sut = new CreationService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                context.Object);
            
            // Act
            sut.CreateSong(title, artistName, albumName, duration, selectedGenres, lyrics, videoUrl);

            // Assert
            artistRepo.Verify(x => x.All, Times.Once);
        }

        [TestMethod]
        public void CallGenresRepoPropertyAllOnce_WhenInvoked()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            var genreName = "Genre Name";
            var title = "Title";
            var artistName = "Artist Name";
            var albumName = "Album Name";
            int? duration = 5;
            var lyrics = "Lyrics";
            var videoUrl = "VideUrl";
            var selectedGenres = new List<string>()
            {
                genreName
            };

            var artistCollection = new List<Artist>()
            {
                new Artist()
                {
                    Name = artistName
                }
            };

            var genreCollection = new List<Genre>()
            {
                new Genre()
                {
                    Name = genreName
                }
            };

            var albumCollection = new List<Album>()
            {
                new Album()
                {
                    Title = albumName
                }
            };

            genreRepo.Setup(x => x.All).Returns(() => genreCollection.AsQueryable());
            albumRepo.Setup(x => x.All).Returns(() => albumCollection.AsQueryable());
            artistRepo.Setup(x => x.All).Returns(() => artistCollection.AsQueryable());
            context.Setup(x => x.SaveChanges());
            
            var sut = new CreationService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                context.Object);

            // Act
            sut.CreateSong(title, artistName, albumName, duration, selectedGenres, lyrics, videoUrl);

            // Assert
            genreRepo.Verify(x => x.All, Times.Once);
        }

        [TestMethod]
        public void CallAlbumsRepoPropertyAllOnce_WhenInvoked()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            var genreName = "Genre Name";
            var title = "Title";
            var artistName = "Artist Name";
            var albumName = "Album Name";
            int? duration = 5;
            var lyrics = "Lyrics";
            var videoUrl = "VideUrl";
            var selectedGenres = new List<string>()
            {
                genreName
            };

            var artistCollection = new List<Artist>()
            {
                new Artist()
                {
                    Name = artistName
                }
            };

            var genreCollection = new List<Genre>()
            {
                new Genre()
                {
                    Name = genreName
                }
            };

            var albumCollection = new List<Album>()
            {
                new Album()
                {
                    Title = albumName
                }
            };

            genreRepo.Setup(x => x.All).Returns(() => genreCollection.AsQueryable());
            albumRepo.Setup(x => x.All).Returns(() => albumCollection.AsQueryable());
            artistRepo.Setup(x => x.All).Returns(() => artistCollection.AsQueryable());
            context.Setup(x => x.SaveChanges());

            var sut = new CreationService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                context.Object);

            // Act
            sut.CreateSong(title, artistName, albumName, duration, selectedGenres, lyrics, videoUrl);

            // Assert
            albumRepo.Verify(x => x.All, Times.Once);
        }

        [TestMethod]
        public void CallSongsRepoMethodAddOnce_WhenInvoked()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            var genreName = "Genre Name";
            var title = "Title";
            var artistName = "Artist Name";
            var albumName = "Album Name";
            int? duration = 5;
            var lyrics = "Lyrics";
            var videoUrl = "VideUrl";
            var selectedGenres = new List<string>()
            {
                genreName
            };

            var artistCollection = new List<Artist>()
            {
                new Artist()
                {
                    Name = artistName
                }
            };

            var genreCollection = new List<Genre>()
            {
                new Genre()
                {
                    Name = genreName
                }
            };

            var albumCollection = new List<Album>()
            {
                new Album()
                {
                    Title = albumName
                }
            };

            songRepo.Setup(x => x.Add(It.IsAny<Song>()));
            genreRepo.Setup(x => x.All).Returns(() => genreCollection.AsQueryable());
            albumRepo.Setup(x => x.All).Returns(() => albumCollection.AsQueryable());
            artistRepo.Setup(x => x.All).Returns(() => artistCollection.AsQueryable());
            context.Setup(x => x.SaveChanges());

            var sut = new CreationService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                context.Object);

            // Act
            sut.CreateSong(title, artistName, albumName, duration, selectedGenres, lyrics, videoUrl);

            // Assert
            songRepo.Verify(x => x.Add(It.IsAny<Song>()), Times.Once);
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

            var genreName = "Genre Name";
            var title = "Title";
            var artistName = "Artist Name";
            var albumName = "Album Name";
            int? duration = 5;
            var lyrics = "Lyrics";
            var videoUrl = "VideUrl";
            var selectedGenres = new List<string>()
            {
                genreName
            };

            var artistCollection = new List<Artist>()
            {
                new Artist()
                {
                    Name = artistName
                }
            };

            var genreCollection = new List<Genre>()
            {
                new Genre()
                {
                    Name = genreName
                }
            };

            var albumCollection = new List<Album>()
            {
                new Album()
                {
                    Title = albumName
                }
            };

            songRepo.Setup(x => x.Add(It.IsAny<Song>()));
            genreRepo.Setup(x => x.All).Returns(() => genreCollection.AsQueryable());
            albumRepo.Setup(x => x.All).Returns(() => albumCollection.AsQueryable());
            artistRepo.Setup(x => x.All).Returns(() => artistCollection.AsQueryable());
            context.Setup(x => x.SaveChanges());

            var sut = new CreationService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                context.Object);

            // Act
            sut.CreateSong(title, artistName, albumName, duration, selectedGenres, lyrics, videoUrl);

            // Assert
            context.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
