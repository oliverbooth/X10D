using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;
using X10D.Core;

namespace X10D.Tests.Collections;

[TestClass]
public class EnumerableTests
{
    [TestMethod]
    public void CountWhereNot_ShouldReturnCorrectCount_GivenSequence()
    {
        var enumerable = new[] {2, 4, 6, 7, 8, 9, 10};
        int count = enumerable.CountWhereNot(x => x % 2 == 0);
        Assert.AreEqual(2, count);
    }

    [TestMethod]
    public void CountWhereNot_ShouldThrowArgumentNullException_GivenNullSource()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((IEnumerable<int>?)null)!.CountWhereNot(x => x % 2 == 0));
    }

    [TestMethod]
    public void CountWhereNot_ShouldThrowOverflowException_GivenLargeSource()
    {
        IEnumerable<byte> GetValues()
        {
            while (true)
            {
                yield return 1;
            }

            // ReSharper disable once IteratorNeverReturns
        }

        Assert.ThrowsException<OverflowException>(() => GetValues().CountWhereNot(x => x % 2 == 0));
    }

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
    public void FirstWhereNot_ShouldReturnCorrectElements_GivenSequence()
    {
        var enumerable = new[] {2, 4, 6, 7, 8, 9, 10};
        int result = enumerable.FirstWhereNot(x => x % 2 == 0);
        Assert.AreEqual(7, result);
    }

    [TestMethod]
    public void FirstWhereNot_ShouldThrowArgumentNullException_GivenNullSource()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((IEnumerable<int>?)null)!.FirstWhereNot(x => x % 2 == 0));
    }

    [TestMethod]
    public void FirstWhereNot_ShouldThrowArgumentNullException_GivenNullPredicate()
    {
        Assert.ThrowsException<ArgumentNullException>(() => Array.Empty<int>().FirstWhereNotOrDefault(null!));
    }

    [TestMethod]
    public void FirstWhereNot_ShouldThrowInvalidOperationException_GivenEmptySource()
    {
        Assert.ThrowsException<InvalidOperationException>(() => Array.Empty<int>().FirstWhereNot(x => x % 2 == 0));
    }

    [TestMethod]
    public void FirstWhereNot_ShouldThrowInvalidOperationException_GivenSourceWithNoMatchingElements()
    {
        Assert.ThrowsException<InvalidOperationException>(() => 2.AsArrayValue().FirstWhereNot(x => x % 2 == 0));
    }

    [TestMethod]
    public void FirstWhereNotOrDefault_ShouldReturnCorrectElements_GivenSequence()
    {
        var enumerable = new[] {2, 4, 6, 7, 8, 9, 10};
        int result = enumerable.FirstWhereNotOrDefault(x => x % 2 == 0);
        Assert.AreEqual(7, result);
    }

    [TestMethod]
    public void FirstWhereNotOrDefault_ShouldThrowArgumentNullException_GivenNullSource()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((IEnumerable<int>?)null)!.FirstWhereNotOrDefault(x => x % 2 == 0));
    }

    [TestMethod]
    public void FirstWhereNotOrDefault_ShouldThrowArgumentNullException_GivenNullPredicate()
    {
        Assert.ThrowsException<ArgumentNullException>(() => Array.Empty<int>().FirstWhereNotOrDefault(null!));
    }

    [TestMethod]
    public void FirstWhereNotOrDefault_ShouldReturnDefault_GivenEmptySource()
    {
        int result = Array.Empty<int>().FirstWhereNotOrDefault(x => x % 2 == 0);
        Assert.AreEqual(default, result);
    }

    [TestMethod]
    public void FirstWhereNotOrDefault_ShouldReturnDefault_GivenSourceWithNoMatchingElements()
    {
        int result = 2.AsArrayValue().FirstWhereNotOrDefault(x => x % 2 == 0);
        Assert.AreEqual(default, result);
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
    public void LastWhereNot_ShouldReturnCorrectElements_GivenSequence()
    {
        var enumerable = new[] {2, 4, 6, 7, 8, 9, 10};
        int result = enumerable.LastWhereNot(x => x % 2 == 0);
        Assert.AreEqual(9, result);
    }

    [TestMethod]
    public void LastWhereNot_ShouldThrowArgumentNullException_GivenNullSource()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((IEnumerable<int>?)null)!.LastWhereNot(x => x % 2 == 0));
    }

    [TestMethod]
    public void LastWhereNot_ShouldThrowArgumentNullException_GivenNullPredicate()
    {
        Assert.ThrowsException<ArgumentNullException>(() => Array.Empty<int>().LastWhereNot(null!));
    }

    [TestMethod]
    public void LastWhereNot_ShouldThrowInvalidOperationException_GivenEmptySource()
    {
        Assert.ThrowsException<InvalidOperationException>(() => Array.Empty<int>().LastWhereNot(x => x % 2 == 0));
    }

    [TestMethod]
    public void LastWhereNot_ShouldThrowInvalidOperationException_GivenSourceWithNoMatchingElements()
    {
        Assert.ThrowsException<InvalidOperationException>(() => 2.AsArrayValue().LastWhereNot(x => x % 2 == 0));
    }

    [TestMethod]
    public void LastWhereNotOrDefault_ShouldReturnCorrectElements_GivenSequence()
    {
        var enumerable = new[] {2, 4, 6, 7, 8, 9, 10};
        int result = enumerable.LastWhereNotOrDefault(x => x % 2 == 0);
        Assert.AreEqual(9, result);
    }

    [TestMethod]
    public void LastWhereNotOrDefault_ShouldThrowArgumentNullException_GivenNullSource()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((IEnumerable<int>?)null)!.LastWhereNotOrDefault(x => x % 2 == 0));
    }

    [TestMethod]
    public void LastWhereNotOrDefault_ShouldThrowArgumentNullException_GivenNullPredicate()
    {
        Assert.ThrowsException<ArgumentNullException>(() => Array.Empty<int>().LastWhereNotOrDefault(null!));
    }

    [TestMethod]
    public void LastWhereNotOrDefault_ShouldReturnDefault_GivenEmptySource()
    {
        int result = Array.Empty<int>().LastWhereNotOrDefault(x => x % 2 == 0);
        Assert.AreEqual(default, result);
    }

    [TestMethod]
    public void LastWhereNotOrDefault_ShouldReturnDefault_GivenSourceWithNoMatchingElements()
    {
        int result = 2.AsArrayValue().LastWhereNotOrDefault(x => x % 2 == 0);
        Assert.AreEqual(default, result);
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

    [TestMethod]
    public void WhereNot_ShouldReturnCorrectElements_GivenSequence()
    {
        var enumerable = new[] {2, 4, 6, 7, 8, 9, 10};
        IEnumerable<int> result = enumerable.WhereNot(x => x % 2 == 0);
        CollectionAssert.AreEqual(new[] {7, 9}, result.ToArray());
    }

    [TestMethod]
    public void WhereNot_ShouldThrowArgumentNullException_GivenNullSource()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((IEnumerable<int>?)null)!.WhereNot(x => x % 2 == 0));
    }

    [TestMethod]
    public void WhereNotNull_ShouldContainNoNullElements()
    {
        object?[] array = Enumerable.Repeat(new object(), 10).ToArray();
        array[1] = null;
        array[2] = null;
        array[8] = null;
        array[9] = null;

        const int expectedCount = 6;
        var actualCount = 0;

        foreach (object o in array.WhereNotNull())
        {
            Assert.IsNotNull(o);
            actualCount++;
        }

        Assert.AreEqual(expectedCount, actualCount);
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

#pragma warning disable CS1998
        public async ValueTask DisposeAsync()
#pragma warning restore CS1998
        {
            Assert.IsTrue(IsDisposed = true);
        }
    }
}
