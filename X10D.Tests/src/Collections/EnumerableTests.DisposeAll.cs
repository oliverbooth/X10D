using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using X10D.Collections;

namespace X10D.Tests.Collections;

public partial class EnumerableTests
{
    [TestClass]
    public class DisposeAllTests
    {
        [TestMethod]
        public void DisposeAll_ShouldDisposeAllItems_WhenCalledWithValidList()
        {
            var mock1 = new Mock<IDisposable>();
            var mock2 = new Mock<IDisposable>();
            var mock3 = new Mock<IDisposable>();
            var list = new List<IDisposable> {mock1.Object, mock2.Object, null!, mock3.Object};

            list.DisposeAll();

            mock1.Verify(i => i.Dispose(), Times.Once);
            mock2.Verify(i => i.Dispose(), Times.Once);
            mock3.Verify(i => i.Dispose(), Times.Once);
        }

        [TestMethod]
        public void DisposeAll_ShouldThrowArgumentNullException_WhenCalledWithNullList()
        {
            List<IDisposable>? list = null;
            Assert.ThrowsException<ArgumentNullException>(() => list!.DisposeAll());
        }
    }
}
