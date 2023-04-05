using System.Collections.ObjectModel;
using Moq;
using NUnit.Framework;
using X10D.Collections;

namespace X10D.Tests.Collections;

public partial class CollectionTests
{
    [TestFixture]
    public class ClearAndDisposeAllAsyncTests
    {
        [Test]
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
            Assert.That(list, Is.Empty);
        }

        [Test]
        public void ClearAndDisposeAllAsync_ShouldThrowArgumentNullException_WhenCalledWithNullList()
        {
            List<IAsyncDisposable>? list = null;
            Assert.ThrowsAsync<ArgumentNullException>(list!.ClearAndDisposeAllAsync);
        }

        [Test]
        public void ClearAndDisposeAllAsync_ShouldThrowInvalidOperationException_WhenCalledWithReadOnlyList()
        {
            var mock = new Mock<IAsyncDisposable>();
            var list = new ReadOnlyCollection<IAsyncDisposable>(new List<IAsyncDisposable> {mock.Object});

            Assert.ThrowsAsync<InvalidOperationException>(list.ClearAndDisposeAllAsync);
        }
    }
}
