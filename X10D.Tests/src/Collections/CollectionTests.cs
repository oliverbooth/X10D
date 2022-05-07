using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestClass]
public class CollectionTests
{
    [TestMethod]
    public void ClearAndDisposeAll_ShouldDispose_GivenCollection()
    {
        var collection = new List<Disposable> {new(), new(), new()};
        var copy = new List<Disposable>(collection);

        collection.ClearAndDisposeAll();

        Assert.IsTrue(copy.All(x => x.IsDisposed));
        Assert.AreEqual(0, collection.Count);
    }

    [TestMethod]
    public async Task ClearAndDisposeAllAsync_ShouldDispose_GivenCollection()
    {
        var collection = new List<Disposable> {new(), new(), new()};
        var copy = new List<Disposable>(collection);

        await collection.ClearAndDisposeAllAsync();

        Assert.IsTrue(copy.All(x => x.IsDisposed));
        Assert.AreEqual(0, collection.Count);
    }

    [TestMethod]
    public void ClearAndDisposeAll_ShouldThrow_GivenNull()
    {
        List<Disposable>? collection = null;
        Assert.ThrowsException<ArgumentNullException>(() => collection!.ClearAndDisposeAll());
    }

    [TestMethod]
    public void ClearAndDisposeAllAsync_ShouldThrow_GivenNull()
    {
        List<Disposable>? collection = null;
        Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await collection!.ClearAndDisposeAllAsync());
    }

    [TestMethod]
    public void ClearAndDisposeAll_ShouldThrow_GivenReadOnlyCollection()
    {
        var collection = new List<Disposable>().AsReadOnly();
        Assert.ThrowsException<InvalidOperationException>(() => collection.ClearAndDisposeAll());
    }

    [TestMethod]
    public void ClearAndDisposeAllAsync_ShouldThrow_GivenReadOnlyCollection()
    {
        var collection = new List<Disposable>().AsReadOnly();
        Assert.ThrowsExceptionAsync<InvalidOperationException>(async () => await collection.ClearAndDisposeAllAsync());
    }

    private class Disposable : IDisposable, IAsyncDisposable
    {
        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            Assert.IsTrue(IsDisposed = true);
        }

#pragma warning disable CS1998
        public async ValueTask DisposeAsync()
#pragma warning restore CS1998
        {
            Assert.IsTrue(IsDisposed = true);
        }
    }
}
