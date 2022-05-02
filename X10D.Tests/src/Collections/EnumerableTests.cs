using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestClass]
public class EnumerableTests
{
    [TestMethod]
    public void DisposeAll_ShouldDispose_GivenCollection()
    {
        var collection = new List<Disposable> {new(), new(), new()};
        collection.DisposeAll();
        Assert.IsTrue(collection.All(x => x.IsDisposed));
    }

    [TestMethod]
    public async Task DisposeAllAsync_ShouldDispose_GivenCollection()
    {
        var collection = new List<Disposable> {new(), new(), new()};
        await collection.DisposeAllAsync();
        Assert.IsTrue(collection.All(x => x.IsDisposed));
    }

    [TestMethod]
    public void DisposeAll_ShouldThrow_GivenNull()
    {
        List<Disposable>? collection = null;
        Assert.ThrowsException<ArgumentNullException>(() => collection!.DisposeAll());
    }

    [TestMethod]
    public async Task DisposeAllAsync_ShouldThrow_GivenNull()
    {
        List<Disposable>? collection = null;
        await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await collection!.DisposeAllAsync());
    }

    [TestMethod]
    public void For_ShouldTransform_GivenTransformationDelegate()
    {
        var oneToTen = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        var multipliedByIndex = new[] {0, 2, 6, 12, 20, 30, 42, 56, 72, 90};

        IEnumerable<DummyClass> source = oneToTen.Select(i => new DummyClass {Value = i}).ToArray();
        IEnumerable<int> values = source.Select(o => o.Value);
        CollectionAssert.AreEqual(oneToTen, values.ToArray());

        source.For((i, o) => o.Value *= i);
        values = source.Select(o => o.Value);
        CollectionAssert.AreEqual(multipliedByIndex, values.ToArray());
    }

    [TestMethod]
    public void For_ShouldThrow_GivenNullSource()
    {
        IEnumerable<object>? source = null;
        Assert.ThrowsException<ArgumentNullException>(() => source!.For((_, _) => { }));
    }

    [TestMethod]
    public void For_ShouldThrow_GivenNullAction()
    {
        IEnumerable<object> source = ArraySegment<object>.Empty;
        Assert.ThrowsException<ArgumentNullException>(() => source.For(null!));
    }

    [TestMethod]
    public void ForEach_ShouldTransform_GivenTransformationDelegate()
    {
        var oneToTen = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        var oneToTenDoubled = new[] {2, 4, 6, 8, 10, 12, 14, 16, 18, 20};

        IEnumerable<DummyClass> source = oneToTen.Select(i => new DummyClass {Value = i}).ToArray();
        IEnumerable<int> values = source.Select(o => o.Value);
        CollectionAssert.AreEqual(oneToTen, values.ToArray());

        source.ForEach(o => o.Value *= 2);
        values = source.Select(o => o.Value);
        CollectionAssert.AreEqual(oneToTenDoubled, values.ToArray());
    }

    [TestMethod]
    public void ForEach_ShouldThrow_GivenNullSource()
    {
        IEnumerable<object>? source = null;
        Assert.ThrowsException<ArgumentNullException>(() => source!.ForEach(_ => { }));
    }

    [TestMethod]
    public void ForEach_ShouldThrow_GivenNullAction()
    {
        IEnumerable<object> source = ArraySegment<object>.Empty;
        Assert.ThrowsException<ArgumentNullException>(() => source.ForEach(null!));
    }

    [TestMethod]
    public void Shuffled_ShouldThrow_GivenNull()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((List<int>?)null)!.Shuffled());
    }

    [TestMethod]
    public void Shuffled_ShouldReorder_GivenNotNull()
    {
        int[] array = Enumerable.Range(1, 52).ToArray(); // 52! chance of being shuffled to the same order
        int[] shuffled = array[..];

        CollectionAssert.AreEqual(array, shuffled);

        shuffled = array.Shuffled().ToArray();
        CollectionAssert.AreNotEqual(array, shuffled);
    }

    private class DummyClass
    {
        public int Value { get; set; }
    }

    private class Disposable : IDisposable, IAsyncDisposable
    {
        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            Assert.IsTrue(IsDisposed = true);
        }

        public ValueTask DisposeAsync()
        {
            Assert.IsTrue(IsDisposed = true);
            return ValueTask.CompletedTask;
        }
    }
}
