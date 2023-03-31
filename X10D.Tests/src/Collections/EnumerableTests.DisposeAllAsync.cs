using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using X10D.Collections;

namespace X10D.Tests.Collections;

public partial class EnumerableTests
{
    [TestClass]
    public class DisposeAllAsyncTests
    {
        [TestMethod]
        public async Task DisposeAllAsync_ShouldDisposeAllItems_WhenCalledWithValidList()
        {
            var mock1 = new Mock<IAsyncDisposable>();
            var mock2 = new Mock<IAsyncDisposable>();
            var mock3 = new Mock<IAsyncDisposable>();
            var list = new List<IAsyncDisposable> {mock1.Object, mock2.Object, null!, mock3.Object};

            await list.DisposeAllAsync().ConfigureAwait(false);

            mock1.Verify(i => i.DisposeAsync(), Times.Once);
            mock2.Verify(i => i.DisposeAsync(), Times.Once);
            mock3.Verify(i => i.DisposeAsync(), Times.Once);
        }

        [TestMethod]
        public async Task DisposeAllAsync_ShouldThrowArgumentNullException_WhenCalledWithNullList()
        {
            List<IAsyncDisposable>? list = null;
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => list!.DisposeAllAsync()).ConfigureAwait(false);
        }
    }
}
