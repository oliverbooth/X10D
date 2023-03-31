using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using X10D.Collections;

namespace X10D.Tests.Collections;

public partial class CollectionTests
{
    [TestClass]
    public class ClearAndDisposeAllAsyncTests
    {
        [TestMethod]
        public async Task ClearAndDisposeAllAsync_ShouldClearAndDisposeAllItems_WhenCalledWithValidList()
        {
            var mock1 = new Mock<IAsyncDisposable>();
            var mock2 = new Mock<IAsyncDisposable>();
            var mock3 = new Mock<IAsyncDisposable>();
            var list = new List<IAsyncDisposable> {mock1.Object, mock2.Object, mock3.Object};

            await list.ClearAndDisposeAllAsync().ConfigureAwait(false);

            mock1.Verify(i => i.DisposeAsync(), Times.Once);
            mock2.Verify(i => i.DisposeAsync(), Times.Once);
            mock3.Verify(i => i.DisposeAsync(), Times.Once);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public async Task ClearAndDisposeAllAsync_ShouldThrowArgumentNullException_WhenCalledWithNullList()
        {
            List<IAsyncDisposable>? list = null;
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(list!.ClearAndDisposeAllAsync).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task ClearAndDisposeAllAsync_ShouldThrowInvalidOperationException_WhenCalledWithReadOnlyList()
        {
            var mock = new Mock<IAsyncDisposable>();
            var list = new ReadOnlyCollection<IAsyncDisposable>(new List<IAsyncDisposable> {mock.Object});

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(list.ClearAndDisposeAllAsync).ConfigureAwait(false);
        }
    }
}
