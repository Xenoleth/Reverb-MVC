﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Contracts;
using Reverb.Data.Models;
using System;

namespace Reverb.Services.UnitTests.CreationServiceTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void Thorw_WhenSongRepoIsNotSupplied()
        {
            // Arrange
            //var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreationService(
                null,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                context.Object));
        }

        [TestMethod]
        public void Thorw_WhenArtistRepoIsNotSupplied()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            //var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreationService(
                songRepo.Object,
                null,
                albumRepo.Object,
                genreRepo.Object,
                context.Object));
        }

        [TestMethod]
        public void Thorw_WhenAlbumRepoIsNotSupplied()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            //var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreationService(
                null,
                artistRepo.Object,
                null,
                genreRepo.Object,
                context.Object));
        }

        [TestMethod]
        public void Thorw_WhenGenreRepoIsNotSupplied()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            //var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            var context = new Mock<ISaveContext>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreationService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                null,
                context.Object));
        }

        [TestMethod]
        public void Thorw_WhenContextIsNotSupplied()
        {
            // Arrange
            var songRepo = new Mock<IEfContextWrapper<Song>>();
            var artistRepo = new Mock<IEfContextWrapper<Artist>>();
            var albumRepo = new Mock<IEfContextWrapper<Album>>();
            var genreRepo = new Mock<IEfContextWrapper<Genre>>();
            //var context = new Mock<ISaveContext>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreationService(
                songRepo.Object,
                artistRepo.Object,
                albumRepo.Object,
                genreRepo.Object,
                null));
        }
    }
}
