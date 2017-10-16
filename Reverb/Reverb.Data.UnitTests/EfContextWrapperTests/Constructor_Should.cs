using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reverb.Data.Models;
using Reverb.Data.Repositories;
using System;

namespace Reverb.Data.UnitTests.EfContextWrapperTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void Thorw_WhenContextIsNotSupplied()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new EfContextWrapper<Artist>(null));
        }
    }
}
