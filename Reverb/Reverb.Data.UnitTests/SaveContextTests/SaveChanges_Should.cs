using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reverb.Data.Contracts;
using Reverb.Data.SaveChanges;

namespace Reverb.Data.UnitTests.SaveContextTests
{
    [TestClass]
    public class SaveChanges_Should
    {
        [TestMethod]
        public void CallContextSaveChangesOnce_WhenInvoked()
        {
            // Arrange
            var context = new Mock<IReverbDbContext>();

            context.Setup(x => x.SaveChanges());

            var sut = new SaveContext(context.Object);

            // Act
            sut.SaveChanges();

            // Assert
            context.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
