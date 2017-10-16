using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reverb.Data.SaveChanges;
using System;

namespace Reverb.Data.UnitTests.SaveContextTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void Throw_WhenNoContextIsSupplied()
        {            
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new SaveContext(null));
        }
    }
}
