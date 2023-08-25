using NUnit.Framework;
using X10D.Collections;
using X10D.Core;

namespace X10D.Tests.Collections;

[TestFixture]
internal partial class EnumerableTests
{
    [Test]
    public void CountWhereNot_ShouldReturnCorrectCount_GivenSequence()
    {
        var enumerable = new[] {2, 4, 6, 7, 8, 9, 10};
        int count = enumerable.CountWhereNot(x => x % 2 == 0);
        Assert.That(count, Is.EqualTo(2));
    }

    [Test]
    public void CountWhereNot_ShouldThrowArgumentNullException_GivenNullSource()
    {
        Assert.Throws<ArgumentNullException>(() => ((IEnumerable<int>?)null)!.CountWhereNot(x => x % 2 == 0));
    }

    [Test]
    public void CountWhereNot_ShouldThrowArgumentNullException_GivenNullPredicate()
    {
        Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<int>().CountWhereNot(null!));
    }

    [Test]
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

        Assert.Throws<OverflowException>(() => _ = GetValues().CountWhereNot(x => x % 2 == 0));
    }

    [Test]
    public void FirstWhereNot_ShouldReturnCorrectElements_GivenSequence()
    {
        var enumerable = new[] {2, 4, 6, 7, 8, 9, 10};
        int result = enumerable.FirstWhereNot(x => x % 2 == 0);
        Assert.That(result, Is.EqualTo(7));
    }

    [Test]
    public void FirstWhereNot_ShouldThrowArgumentNullException_GivenNullSource()
    {
        Assert.Throws<ArgumentNullException>(() => _ = ((IEnumerable<int>?)null)!.FirstWhereNot(x => x % 2 == 0));
    }

    [Test]
    public void FirstWhereNot_ShouldThrowArgumentNullException_GivenNullPredicate()
    {
        Assert.Throws<ArgumentNullException>(() => _ = Enumerable.Range(0, 1).FirstWhereNot(null!));
    }

    [Test]
    public void FirstWhereNot_ShouldThrowInvalidOperationException_GivenEmptySource()
    {
        Assert.Throws<InvalidOperationException>(() => _ = Enumerable.Empty<int>().FirstWhereNot(x => x % 2 == 0));
    }

    [Test]
    public void FirstWhereNot_ShouldThrowInvalidOperationException_GivenSourceWithNoMatchingElements()
    {
        Assert.Throws<InvalidOperationException>(() => _ = 2.AsArrayValue().FirstWhereNot(x => x % 2 == 0));
    }

    [Test]
    public void FirstWhereNotOrDefault_ShouldReturnCorrectElements_GivenSequence()
    {
        var enumerable = new[] {2, 4, 6, 7, 8, 9, 10};
        int result = enumerable.FirstWhereNotOrDefault(x => x % 2 == 0);
        Assert.That(result, Is.EqualTo(7));
    }

    [Test]
    public void FirstWhereNotOrDefault_ShouldThrowArgumentNullException_GivenNullSource()
    {
        Assert.Throws<ArgumentNullException>(() => _ = ((IEnumerable<int>?)null)!.FirstWhereNotOrDefault(x => x % 2 == 0));
    }

    [Test]
    public void FirstWhereNotOrDefault_ShouldThrowArgumentNullException_GivenNullPredicate()
    {
        Assert.Throws<ArgumentNullException>(() => _ = Enumerable.Empty<int>().FirstWhereNotOrDefault(null!));
    }

    [Test]
    public void FirstWhereNotOrDefault_ShouldReturnDefault_GivenEmptySource()
    {
        int result = Enumerable.Empty<int>().FirstWhereNotOrDefault(x => x % 2 == 0);
        Assert.That(result, Is.Zero);
    }

    [Test]
    public void FirstWhereNotOrDefault_ShouldReturnDefault_GivenSourceWithNoMatchingElements()
    {
        int result = 2.AsArrayValue().FirstWhereNotOrDefault(x => x % 2 == 0);
        Assert.That(result, Is.Zero);
    }

    [Test]
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

    [Test]
    public void For_ShouldThrow_GivenNullSource()
    {
        IEnumerable<object>? source = null;
        Assert.Throws<ArgumentNullException>(() => source!.For((_, _) => { }));
    }

    [Test]
    public void For_ShouldThrow_GivenNullAction()
    {
        IEnumerable<object> source = ArraySegment<object>.Empty;
        Assert.Throws<ArgumentNullException>(() => source.For(null!));
    }

    [Test]
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

    [Test]
    public void ForEach_ShouldThrow_GivenNullSource()
    {
        IEnumerable<object>? source = null;
        Assert.Throws<ArgumentNullException>(() => source!.ForEach(_ => { }));
    }

    [Test]
    public void ForEach_ShouldThrow_GivenNullAction()
    {
        IEnumerable<object> source = ArraySegment<object>.Empty;
        Assert.Throws<ArgumentNullException>(() => source.ForEach(null!));
    }

    [Test]
    public void LastWhereNot_ShouldReturnCorrectElements_GivenSequence()
    {
        var enumerable = new[] {2, 4, 6, 7, 8, 9, 10};
        int result = enumerable.LastWhereNot(x => x % 2 == 0);
        Assert.That(result, Is.EqualTo(9));
    }

    [Test]
    public void LastWhereNot_ShouldThrowArgumentNullException_GivenNullSource()
    {
        Assert.Throws<ArgumentNullException>(() => _ = ((IEnumerable<int>?)null)!.LastWhereNot(x => x % 2 == 0));
    }

    [Test]
    public void LastWhereNot_ShouldThrowArgumentNullException_GivenNullPredicate()
    {
        Assert.Throws<ArgumentNullException>(() => _ = Array.Empty<int>().LastWhereNot(null!));
    }

    [Test]
    public void LastWhereNot_ShouldThrowInvalidOperationException_GivenEmptySource()
    {
        Assert.Throws<InvalidOperationException>(() => _ = Array.Empty<int>().LastWhereNot(x => x % 2 == 0));
    }

    [Test]
    public void LastWhereNot_ShouldThrowInvalidOperationException_GivenSourceWithNoMatchingElements()
    {
        Assert.Throws<InvalidOperationException>(() => _ = 2.AsArrayValue().LastWhereNot(x => x % 2 == 0));
    }

    [Test]
    public void LastWhereNotOrDefault_ShouldReturnCorrectElements_GivenSequence()
    {
        var enumerable = new[] {2, 4, 6, 7, 8, 9, 10};
        int result = enumerable.LastWhereNotOrDefault(x => x % 2 == 0);
        Assert.That(result, Is.EqualTo(9));
    }

    [Test]
    public void LastWhereNotOrDefault_ShouldThrowArgumentNullException_GivenNullSource()
    {
        Assert.Throws<ArgumentNullException>(() => _ = ((IEnumerable<int>?)null)!.LastWhereNotOrDefault(x => x % 2 == 0));
    }

    [Test]
    public void LastWhereNotOrDefault_ShouldThrowArgumentNullException_GivenNullPredicate()
    {
        Assert.Throws<ArgumentNullException>(() => _ = Array.Empty<int>().LastWhereNotOrDefault(null!));
    }

    [Test]
    public void LastWhereNotOrDefault_ShouldReturnDefault_GivenEmptySource()
    {
        int result = Array.Empty<int>().LastWhereNotOrDefault(x => x % 2 == 0);
        Assert.That(result, Is.Zero);
    }

    [Test]
    public void LastWhereNotOrDefault_ShouldReturnDefault_GivenSourceWithNoMatchingElements()
    {
        int result = 2.AsArrayValue().LastWhereNotOrDefault(x => x % 2 == 0);
        Assert.That(result, Is.Zero);
    }

    [Test]
    public void Shuffled_ShouldThrow_GivenNull()
    {
        Assert.Throws<ArgumentNullException>(() => _ = ((List<int>?)null)!.Shuffled());
    }

    [Test]
    public void Shuffled_ShouldReorder_GivenNotNull()
    {
        int[] array = Enumerable.Range(1, 52).ToArray(); // 52! chance of being shuffled to the same order
        int[] shuffled = array[..];

        CollectionAssert.AreEqual(array, shuffled);

        shuffled = array.Shuffled().ToArray();
        CollectionAssert.AreNotEqual(array, shuffled);
    }

    [Test]
    public void WhereNot_ShouldReturnCorrectElements_GivenSequence()
    {
        var enumerable = new[] {2, 4, 6, 7, 8, 9, 10};
        IEnumerable<int> result = enumerable.WhereNot(x => x % 2 == 0);
        CollectionAssert.AreEqual(new[] {7, 9}, result.ToArray());
    }

    [Test]
    public void WhereNot_ShouldThrowArgumentNullException_GivenNullSource()
    {
        Assert.Throws<ArgumentNullException>(() => _ = ((IEnumerable<int>?)null)!.WhereNot(x => x % 2 == 0));
    }

    [Test]
    public void WhereNot_ShouldThrowArgumentNullException_GivenNullPredicate()
    {
        Assert.Throws<ArgumentNullException>(() => _ = Enumerable.Empty<int>().WhereNot(null!));
    }

    [Test]
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

        Assert.That(actualCount, Is.EqualTo(expectedCount));
    }

    [Test]
    public void WhereNotNull_ShouldThrowArgumentNullException_GivenNullSource()
    {
        IEnumerable<string> source = null!;
        Assert.Throws<ArgumentNullException>(() => source.WhereNotNull());
    }

    private class DummyClass
    {
        public int Value { get; set; }
    }
}
