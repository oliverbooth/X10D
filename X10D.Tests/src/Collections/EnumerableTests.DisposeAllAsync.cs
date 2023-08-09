using NSubstitute;
using NUnit.Framework;
using X10D.Collections;

namespace X10D.Tests.Collections;

public partial class EnumerableTests
{
    [TestFixture]
    public class DisposeAllAsyncTests
    {
        [Test]
        public async Task DisposeAllAsync_ShouldDisposeAllItems_WhenCalledWithValidList()
        {
            var substitute1 = Substitute.For<IAsyncDisposable>();
            var substitute2 = Substitute.For<IAsyncDisposable>();
            var substitute3 = Substitute.For<IAsyncDisposable>();
            var list = new List<IAsyncDisposable> { substitute1, substitute2, null!, substitute3 };

            await list.DisposeAllAsync().ConfigureAwait(false);

            await substitute1.Received(1).DisposeAsync();
            await substitute2.Received(1).DisposeAsync();
            await substitute3.Received(1).DisposeAsync();
        }

        [Test]
        public void DisposeAllAsync_ShouldThrowArgumentNullException_WhenCalledWithNullList()
        {
            List<IAsyncDisposable> list = null!;
            Assert.ThrowsAsync<ArgumentNullException>(() => list.DisposeAllAsync());
        }
    }
}
