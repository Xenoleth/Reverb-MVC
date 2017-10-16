using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Models;
using Reverb.Services.Contracts;
using Reverb.Web.Controllers;
using Reverb.Web.Models.Song;
using System.Collections.Generic;
using System.Linq;

namespace Reverb.Web.UnitTests.SongControllerTests
{
    [TestClass]
    public class SearchSong_Should
    {
        [TestMethod]
        public void CallSongServiceMethodGetSongsOnce_WhenInvoked()
        {
            // Arrange
            var songService = new Mock<ISongService>();
            var userService = new Mock<IUserService>();
            var artistService = new Mock<IArtistService>();
            var albumService = new Mock<IAlbumService>();
            var genreService = new Mock<IGenreService>();
            var songModifyService = new Mock<ISongModifyService>();

            var songCollection = new List<Song>()
            {
                new Song()
                {
                    Title = "Song Title",
                    Album = new Album() {
                        Title = "Album Title"
                    },
                    Artist = new Artist() {
                        Name = "Artist Name"
                    },
                    Duration = 5,
                    Genres = new List<Genre>() {
                        new Genre()
                        {
                            Name = "Genre Name"
                        }
                    },
                    Lyrics = "Some Lyrics",
                    VideoUrl = "VideoUrl"

                }
            };

            songService.Setup(x => x.GetSongs()).Returns(() => songCollection.AsQueryable());

            var sut = new SongController(
                songService.Object,
                userService.Object,
                artistService.Object,
                albumService.Object,
                genreService.Object,
                songModifyService.Object);

            var model = new SongSearchViewModel();

            // Act
            sut.SearchSong(model);

            // Assert
            songService.Verify(x => x.GetSongs());
        }

        //[TestMethod]
        //public void ReturnRequestedSong_WhenInvoked()
        //{
        //    // Arrange
        //    var songService = new Mock<ISongService>();
        //    var userService = new Mock<IUserService>();
        //    var artistService = new Mock<IArtistService>();
        //    var albumService = new Mock<IAlbumService>();
        //    var genreService = new Mock<IGenreService>();
        //    var songModifyService = new Mock<ISongModifyService>();

        //    var songCollection = new List<Song>()
        //    {
        //        new Song()
        //        {
        //            Title = "Song Title",
        //            Album = new Album() {
        //                Title = "Album Title"
        //            },
        //            Artist = new Artist() {
        //                Name = "Artist Name"
        //            },
        //            Duration = 5,
        //            Genres = new List<Genre>() {
        //                new Genre()
        //                {
        //                    Name = "Genre Name"
        //                }
        //            },
        //            Lyrics = "Some Lyrics",
        //            VideoUrl = "VideoUrl"

        //        }
        //    };

        //    songService.Setup(x => x.GetSongs()).Returns(() => songCollection.AsQueryable());

        //    var sut = new SongController(
        //        songService.Object,
        //        userService.Object,
        //        artistService.Object,
        //        albumService.Object,
        //        genreService.Object,
        //        songModifyService.Object);

        //    var model = new SongSearchViewModel()
        //    {
        //        SearchBy = "Title",
        //        SearchTerm = "Song Title"
        //    };

        //    // Act
        //    var result = sut.SearchSong(model);
        //}
    }
}
