using System.Collections.ObjectModel;
using NSubstitute;
using NUnit.Framework;
using X10D.Collections;

namespace X10D.Tests.Collections;

internal partial class CollectionTests
{
    [TestFixture]
    public class ClearAndDisposeAllAsyncTests
    {
        [Test]
        public async Task ClearAndDisposeAllAsync_ShouldClearAndDisposeAllItems_WhenCalledWithValidList()
        {
            var substitute1 = Substitute.For<IAsyncDisposable>();
            var substitute2 = Substitute.For<IAsyncDisposable>();
            var substitute3 = Substitute.For<IAsyncDisposable>();
            var list = new List<IAsyncDisposable> {substitute1, substitute2, substitute3};

            await list.ClearAndDisposeAllAsync().ConfigureAwait(false);

            await substitute1.Received(1).DisposeAsync();
            await substitute2.Received(1).DisposeAsync();
            await substitute3.Received(1).DisposeAsync();

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
            var substitute = Substitute.For<IAsyncDisposable>();
            var list = new ReadOnlyCollection<IAsyncDisposable>(new List<IAsyncDisposable> {substitute});

            Assert.ThrowsAsync<InvalidOperationException>(list.ClearAndDisposeAllAsync);
        }
    }
}
