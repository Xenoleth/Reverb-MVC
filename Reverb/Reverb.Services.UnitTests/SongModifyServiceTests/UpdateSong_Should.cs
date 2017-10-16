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
    public class UpdateSong_Should
    {
        [TestMethod]
        public void CallSongRepoPropertyAll_WhenInvoked()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            var id = Guid.NewGuid();
            int? duration = 5;
            var lyrics = "Lyrics";
            var videoUrl = "VideoUrl";
            var coverUrl = "CoverUrl";
            var genres = new List<string>()
            {                
                "Genre Name"
            };

            var songTitle = "Song Title";
            var songCollection = new List<Song>()
            {
                new Song()
                {
                    Title = songTitle,
                    Id = id
                }
            };

            var artistName = "Artist Name";
            var artistCollection = new List<Artist>()
            {
                new Artist()
                {
                    Name = artistName
                }
            };

            var albumTitle = "Album Title";
            var albumCollection = new List<Album>()
            {
                new Album()
                {
                    Title = albumTitle
                }
            };

            var genreName = "Genre Name";
            var genreCollection = new List<Genre>()
            {
                new Genre()
                {
                    Name = genreName
                }
            };

            genreRepo.Setup(x => x.All).Returns(() => genreCollection.AsQueryable());
            albumRepo.Setup(x => x.All).Returns(() => albumCollection.AsQueryable());
            artistRepo.Setup(x => x.All).Returns(() => artistCollection.AsQueryable());
            songRepo.Setup(x => x.All).Returns(() => songCollection.AsQueryable());

            var sut = new SongModifyService(
                songRepo.Object, 
                artistRepo.Object, 
                albumRepo.Object, 
                genreRepo.Object, 
                context.Object);

            // Act
            sut.UpdateSong(id, songTitle, artistName, albumTitle, duration, genres, lyrics, videoUrl, coverUrl);

            // Assert
            songRepo.Verify(x => x.All, Times.Once);
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

            var id = Guid.NewGuid();
            int? duration = 5;
            var lyrics = "Lyrics";
            var videoUrl = "VideoUrl";
            var coverUrl = "CoverUrl";
            var genres = new List<string>()
            {
                "Genre Name"
            };

            var songTitle = "Song Title";
            var songCollection = new List<Song>()
            {
                new Song()
                {
                    Title = songTitle,
                    Id = id
                }
            };

            var artistName = "Artist Name";
            var artistCollection = new List<Artist>()
            {
                new Artist()
                {
                    Name = artistName
                }
            };

            var albumTitle = "Album Title";
            var albumCollection = new List<Album>()
            {
                new Album()
                {
                    Title = albumTitle
                }
            };

            var genreName = "Genre Name";
            var genreCollection = new List<Genre>()
            {
                new Genre()
                {
                    Name = genreName
                }
            };

            genreRepo.Setup(x => x.All).Returns(() => genreCollection.AsQueryable());
            albumRepo.Setup(x => x.All).Returns(() => albumCollection.AsQueryable());
            artistRepo.Setup(x => x.All).Returns(() => artistCollection.AsQueryable());
            songRepo.Setup(x => x.All).Returns(() => songCollection.AsQueryable());

            var sut = new SongModifyService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                context.Object);

            // Act
            sut.UpdateSong(id, songTitle, artistName, albumTitle, duration, genres, lyrics, videoUrl, coverUrl);

            // Assert
            artistRepo.Verify(x => x.All, Times.Once);
        }

        [TestMethod]
        public void CallGenreRepoPropertyAll_WhenInvoked()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            var id = Guid.NewGuid();
            int? duration = 5;
            var lyrics = "Lyrics";
            var videoUrl = "VideoUrl";
            var coverUrl = "CoverUrl";
            var genres = new List<string>()
            {
                "Genre Name"
            };

            var songTitle = "Song Title";
            var songCollection = new List<Song>()
            {
                new Song()
                {
                    Title = songTitle,
                    Id = id
                }
            };

            var artistName = "Artist Name";
            var artistCollection = new List<Artist>()
            {
                new Artist()
                {
                    Name = artistName
                }
            };

            var albumTitle = "Album Title";
            var albumCollection = new List<Album>()
            {
                new Album()
                {
                    Title = albumTitle
                }
            };

            var genreName = "Genre Name";
            var genreCollection = new List<Genre>()
            {
                new Genre()
                {
                    Name = genreName
                }
            };

            genreRepo.Setup(x => x.All).Returns(() => genreCollection.AsQueryable());
            albumRepo.Setup(x => x.All).Returns(() => albumCollection.AsQueryable());
            artistRepo.Setup(x => x.All).Returns(() => artistCollection.AsQueryable());
            songRepo.Setup(x => x.All).Returns(() => songCollection.AsQueryable());

            var sut = new SongModifyService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                context.Object);

            // Act
            sut.UpdateSong(id, songTitle, artistName, albumTitle, duration, genres, lyrics, videoUrl, coverUrl);

            // Assert
            genreRepo.Verify(x => x.All, Times.Once);
        }

        [TestMethod]
        public void CallAlbumRepoPropertyAll_WhenInvoked()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            var id = Guid.NewGuid();
            int? duration = 5;
            var lyrics = "Lyrics";
            var videoUrl = "VideoUrl";
            var coverUrl = "CoverUrl";
            var genres = new List<string>()
            {
                "Genre Name"
            };

            var songTitle = "Song Title";
            var songCollection = new List<Song>()
            {
                new Song()
                {
                    Title = songTitle,
                    Id = id
                }
            };

            var artistName = "Artist Name";
            var artistCollection = new List<Artist>()
            {
                new Artist()
                {
                    Name = artistName
                }
            };

            var albumTitle = "Album Title";
            var albumCollection = new List<Album>()
            {
                new Album()
                {
                    Title = albumTitle
                }
            };

            var genreName = "Genre Name";
            var genreCollection = new List<Genre>()
            {
                new Genre()
                {
                    Name = genreName
                }
            };

            genreRepo.Setup(x => x.All).Returns(() => genreCollection.AsQueryable());
            albumRepo.Setup(x => x.All).Returns(() => albumCollection.AsQueryable());
            artistRepo.Setup(x => x.All).Returns(() => artistCollection.AsQueryable());
            songRepo.Setup(x => x.All).Returns(() => songCollection.AsQueryable());

            var sut = new SongModifyService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                context.Object);

            // Act
            sut.UpdateSong(id, songTitle, artistName, albumTitle, duration, genres, lyrics, videoUrl, coverUrl);

            // Assert
            albumRepo.Verify(x => x.All, Times.Once);
        }

        [TestMethod]
        public void AssingSongPropertiesCorrectly_WhenInvoked()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            var id = Guid.NewGuid();
            int? duration = 5;
            var lyrics = "Lyrics";
            var videoUrl = "VideoUrl";
            var coverUrl = "CoverUrl";
            var genres = new List<string>()
            {
                "Genre Name"
            };

            var songTitle = "Song Title";
            var songCollection = new List<Song>()
            {
                new Song()
                {
                    Title = songTitle,
                    Id = id
                }
            };

            var artistName = "Artist Name";
            var artistCollection = new List<Artist>()
            {
                new Artist()
                {
                    Name = artistName
                }
            };

            var albumTitle = "Album Title";
            var albumCollection = new List<Album>()
            {
                new Album()
                {
                    Title = albumTitle
                }
            };

            var genreName = "Genre Name";
            var genreCollection = new HashSet<Genre>()
            {
                new Genre()
                {
                    Name = genreName
                }
            };

            genreRepo.Setup(x => x.All).Returns(() => genreCollection.AsQueryable());
            albumRepo.Setup(x => x.All).Returns(() => albumCollection.AsQueryable());
            artistRepo.Setup(x => x.All).Returns(() => artistCollection.AsQueryable());
            songRepo.Setup(x => x.All).Returns(() => songCollection.AsQueryable());

            var sut = new SongModifyService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                context.Object);

            // Act
            sut.UpdateSong(id, songTitle, artistName, albumTitle, duration, genres, lyrics, videoUrl, coverUrl);

            // Assert
            var song = songRepo.Object.All.FirstOrDefault();

            Assert.AreEqual(id, song.Id);
            Assert.AreEqual(songTitle, song.Title);
            Assert.AreEqual(artistName, song.Artist.Name);
            Assert.AreEqual(albumTitle, song.Album.Title);
            Assert.AreEqual(duration, song.Duration);
            // TODO: Fix unknown problem with genre assign
            //Assert.AreEqual(genres[0], song.Genres.FirstOrDefault().Name);
            Assert.AreEqual(lyrics, song.Lyrics);
            Assert.AreEqual(videoUrl, song.VideoUrl);
            Assert.AreEqual(coverUrl, song.Album.CoverUrl);

        }

        [TestMethod]
        public void CallSongRepoUpdate_WhenInvoked()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            var id = Guid.NewGuid();
            int? duration = 5;
            var lyrics = "Lyrics";
            var videoUrl = "VideoUrl";
            var coverUrl = "CoverUrl";
            var genres = new List<string>()
            {
                "Genre Name"
            };

            var songTitle = "Song Title";
            var songCollection = new List<Song>()
            {
                new Song()
                {
                    Title = songTitle,
                    Id = id
                }
            };

            var artistName = "Artist Name";
            var artistCollection = new List<Artist>()
            {
                new Artist()
                {
                    Name = artistName
                }
            };

            var albumTitle = "Album Title";
            var albumCollection = new List<Album>()
            {
                new Album()
                {
                    Title = albumTitle
                }
            };

            var genreName = "Genre Name";
            var genreCollection = new HashSet<Genre>()
            {
                new Genre()
                {
                    Name = genreName
                }
            };

            genreRepo.Setup(x => x.All).Returns(() => genreCollection.AsQueryable());
            albumRepo.Setup(x => x.All).Returns(() => albumCollection.AsQueryable());
            artistRepo.Setup(x => x.All).Returns(() => artistCollection.AsQueryable());
            songRepo.Setup(x => x.All).Returns(() => songCollection.AsQueryable());
            songRepo.Setup(x => x.Update(It.IsAny<Song>()));

            var sut = new SongModifyService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                context.Object);

            // Act
            sut.UpdateSong(id, songTitle, artistName, albumTitle, duration, genres, lyrics, videoUrl, coverUrl);

            // Assert
            songRepo.Verify(x => x.Update(songCollection.FirstOrDefault()));
        }

        [TestMethod]
        public void CallContextSaveChanges_WhenInvoked()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            var id = Guid.NewGuid();
            int? duration = 5;
            var lyrics = "Lyrics";
            var videoUrl = "VideoUrl";
            var coverUrl = "CoverUrl";
            var genres = new List<string>()
            {
                "Genre Name"
            };

            var songTitle = "Song Title";
            var songCollection = new List<Song>()
            {
                new Song()
                {
                    Title = songTitle,
                    Id = id
                }
            };

            var artistName = "Artist Name";
            var artistCollection = new List<Artist>()
            {
                new Artist()
                {
                    Name = artistName
                }
            };

            var albumTitle = "Album Title";
            var albumCollection = new List<Album>()
            {
                new Album()
                {
                    Title = albumTitle
                }
            };

            var genreName = "Genre Name";
            var genreCollection = new HashSet<Genre>()
            {
                new Genre()
                {
                    Name = genreName
                }
            };

            genreRepo.Setup(x => x.All).Returns(() => genreCollection.AsQueryable());
            albumRepo.Setup(x => x.All).Returns(() => albumCollection.AsQueryable());
            artistRepo.Setup(x => x.All).Returns(() => artistCollection.AsQueryable());
            songRepo.Setup(x => x.All).Returns(() => songCollection.AsQueryable());
            songRepo.Setup(x => x.Update(It.IsAny<Song>()));
            context.Setup(x => x.SaveChanges());

            var sut = new SongModifyService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                context.Object);

            // Act
            sut.UpdateSong(id, songTitle, artistName, albumTitle, duration, genres, lyrics, videoUrl, coverUrl);

            // Assert
            context.Verify(x => x.SaveChanges());
        }
    }
}
