using NUnit.Framework;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestFixture]
internal class ListTests
{
        [Test]
    [TestCase(1)]
    [TestCase(1, 2, 3)]
    [TestCase(1, 2, 3, 4, 5)]
    public void Fill_ShouldGiveHomogenousList_GivenValue(params int[] args)
    {
        int[] all42 = Enumerable.Repeat(42, args.Length).ToArray();
        var list = new List<int>(args);

        CollectionAssert.AreEqual(args, list);

        args.Fill(42);
        list.Fill(42);

        CollectionAssert.AreEqual(args, list);
        CollectionAssert.AreEqual(all42, args);
        CollectionAssert.AreEqual(all42, list);
    }

        [Test]
    [TestCase(1)]
    [TestCase(1, 2, 3)]
    [TestCase(1, 2, 3, 4, 5)]
    public void SlicedFill_ShouldLeaveFirstElement_GivenStartIndex1(params int[] args)
    {
        int first = args[0];
        args.Fill(1, 1, args.Length - 1);

        int[] comparison = Enumerable.Repeat(1, args.Length - 1).ToArray();
        Assert.That(args[0], Is.EqualTo(first));
        CollectionAssert.AreEqual(comparison, args[1..]);
    }

    [Test]
    public void Fill_ShouldThrow_GivenExceededCount()
    {
        int[] array = Array.Empty<int>();
        var list = new List<int>();
        Assert.Throws<ArgumentOutOfRangeException>(() => array.Fill(0, 0, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => list.Fill(0, 0, 1));
    }

    [Test]
    public void Fill_ShouldThrow_GivenNegativeCount()
    {
        int[] array = Array.Empty<int>();
        var list = new List<int>();
        Assert.Throws<ArgumentOutOfRangeException>(() => array.Fill(0, 0, -1));
        Assert.Throws<ArgumentOutOfRangeException>(() => list.Fill(0, 0, -1));
    }

    [Test]
    public void Fill_ShouldThrow_GivenNegativeStartIndex()
    {
        int[] array = Array.Empty<int>();
        var list = new List<int>();
        Assert.Throws<ArgumentOutOfRangeException>(() => array.Fill(0, -1, 0));
        Assert.Throws<ArgumentOutOfRangeException>(() => list.Fill(0, -1, 0));
    }

    [Test]
    public void Fill_ShouldThrow_GivenNull()
    {
        int[]? array = null;
        List<int>? list = null;
        Assert.Throws<ArgumentNullException>(() => array!.Fill(0));
        Assert.Throws<ArgumentNullException>(() => list!.Fill(0));
        Assert.Throws<ArgumentNullException>(() => array!.Fill(0, 0, 0));
        Assert.Throws<ArgumentNullException>(() => list!.Fill(0, 0, 0));
    }

    [Test]
    public void IndexOf_ShouldReturnCorrectValue_FromStartOfList()
    {
        int[] array = {0, 1, 2, 3, 4};
        Assert.Multiple(() =>
        {
            Assert.That(array.IndexOf(2), Is.EqualTo(2));
            Assert.That(array.IndexOf(2, 0), Is.EqualTo(2));
            Assert.That(array.IndexOf(2, 0, 5), Is.EqualTo(2));
        });
    }

    [Test]
    public void IndexOf_ShouldReturnCorrectValue_GivenSubRange()
    {
        int[] array = {0, 1, 2, 3, 4, 0};
        Assert.Multiple(() =>
        {
            Assert.That(array.IndexOf(0), Is.Zero);
            Assert.That(array.IndexOf(0, 0), Is.Zero);
            Assert.That(array.IndexOf(0, 0, 5), Is.Zero);

            Assert.That(array.IndexOf(0, 1), Is.EqualTo(5));
            Assert.That(array.IndexOf(0, 1, 5), Is.EqualTo(5));
        });
    }

    [Test]
    public void IndexOf_ShouldReturnNegative1_ForEmptyList()
    {
        int[] array = Array.Empty<int>();
        Assert.Multiple(() =>
        {
            Assert.That(array.IndexOf(0), Is.EqualTo(-1));
            Assert.That(array.IndexOf(0, 0), Is.EqualTo(-1));
            Assert.That(array.IndexOf(0, 0, 0), Is.EqualTo(-1));
        });
    }

    [Test]
    public void IndexOf_ShouldThrowArgumentNullException_GivenNullList()
    {
        int[]? array = null;
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentNullException>(() => array!.IndexOf(0));
            Assert.Throws<ArgumentNullException>(() => array!.IndexOf(0, 0));
            Assert.Throws<ArgumentNullException>(() => array!.IndexOf(0, 0, 0));
        });
    }

    [Test]
    public void IndexOf_ShouldThrowArgumentOutOfRangeException_GivenNegativeCount()
    {
        int[] array = Array.Empty<int>();
        Assert.Throws<ArgumentOutOfRangeException>(() => array.IndexOf(0, 0, -1));
    }

    [Test]
    public void IndexOf_ShouldThrowArgumentOutOfRangeException_GivenNegativeStartIndex()
    {
        int[] array = Array.Empty<int>();
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => array.IndexOf(0, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => array.IndexOf(0, -1, 0));
        });
    }

    [Test]
    public void IndexOf_ShouldThrowArgumentOutOfRangeException_GivenInvalidStartIndexCountPair()
    {
        int[] array = {0, 1, 2};
        Assert.Throws<ArgumentOutOfRangeException>(() => array.IndexOf(0, 2, 4));
    }

    [Test]
    public void Random_ShouldReturnContainedObject_GivenNotNull()
    {
        var list = new List<int>(Enumerable.Range(1, 52)); // 52! chance of being shuffled to the same order
        int random = list.Random();

        Assert.That(list, Does.Contain(random));
    }

    [Test]
    public void Random_ShouldThrow_GivenNull()
    {
        Assert.Throws<ArgumentNullException>(() => _ = ((List<int>?)null)!.Random());
    }

    [Test]
    public void RemoveRange_ShouldThrowArgumentNullException_GivenNull()
    {
        Assert.Throws<ArgumentNullException>(() => ((List<int>?)null)!.RemoveRange(new Range()));
    }

    [Test]
    public void RemoveRange_ShouldThrowArgumentException_GivenEndIndexLessThanStart()
    {
        Assert.Throws<ArgumentException>(() => new List<int>().RemoveRange(2..0));
    }

    [Test]
    public void RemoveRange_ShouldThrowArgumentOutOfRangeException_GivenEndIndexGreaterThanOrEqualToCount()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new List<int>().RemoveRange(..0));
        Assert.Throws<ArgumentOutOfRangeException>(() => new List<int> {1}.RemoveRange(..2));
    }

    [Test]
    public void RemoveRange_ShouldRemoveElements_GivenList()
    {
        var list = new List<int>
        {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10
        };

        Assert.That(list, Has.Count.EqualTo(10));
        list.RemoveRange(2..5);

        Assert.That(list, Has.Count.EqualTo(6));
        CollectionAssert.AreEqual(new[] {1, 2, 7, 8, 9, 10}, list);
    }

    [Test]
    public void Shuffle_ShouldReorder_GivenNotNull()
    {
        var list = new List<int>(Enumerable.Range(1, 52)); // 52! chance of being shuffled to the same order
        var shuffled = new List<int>(list);

        CollectionAssert.AreEqual(list, shuffled);

        shuffled.Shuffle();

        CollectionAssert.AreNotEqual(list, shuffled);
    }

    [Test]
    public void Shuffle_ShouldThrow_GivenNull()
    {
        Assert.Throws<ArgumentNullException>(() => ((List<int>?)null)!.Shuffle());
    }

    [Test]
    public void Slice_ShouldReturnCorrectValue_GivenStartIndex()
    {
        int[] array = {0, 1, 2, 3, 4, 5};
        CollectionAssert.AreEqual(new[] {2, 3, 4, 5}, array.Slice(2).ToArray());
    }

    [Test]
    public void Slice_ShouldReturnCorrectValue_GivenStartIndexAndLength()
    {
        int[] array = {0, 1, 2, 3, 4, 5};
        CollectionAssert.AreEqual(new[] {2, 3, 4}, array.Slice(2, 3).ToArray());
    }

    [Test]
    public void Slice_ShouldReturnEmptyList_ForEmptyList()
    {
        int[] array = Array.Empty<int>();
        CollectionAssert.AreEqual(Array.Empty<int>(), array.Slice(0).ToArray());
        CollectionAssert.AreEqual(Array.Empty<int>(), array.Slice(0, 0).ToArray());
    }

    [Test]
    public void Slice_ShouldThrowArgumentNullException_GivenNullList()
    {
        int[]? array = null;
        Assert.Throws<ArgumentNullException>(() => array!.Slice(0));
        Assert.Throws<ArgumentNullException>(() => array!.Slice(0, 0));
    }

    [Test]
    public void Slice_ShouldThrowArgumentOutOfRangeException_GivenNegativeCount()
    {
        int[] array = Array.Empty<int>();
        Assert.Throws<ArgumentOutOfRangeException>(() => array.Slice(0, -1));
    }

    [Test]
    public void Slice_ShouldThrowArgumentOutOfRangeException_GivenNegativeStartIndex()
    {
        int[] array = Array.Empty<int>();
        Assert.Throws<ArgumentOutOfRangeException>(() => array.Slice(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => array.Slice(-1, 0));
    }

    [Test]
    public void Slice_ShouldThrowArgumentOutOfRangeException_GivenInvalidStartIndexCountPair()
    {
        int[] array = {0, 1, 2};
        Assert.Throws<ArgumentOutOfRangeException>(() => array.Slice(2, 4));
    }

    [Test]
    public void Swap_ShouldThrowArgumentNullException_GivenNullSource()
    {
        Assert.Throws<ArgumentNullException>(() => ((IList<int>?)null)!.Swap(new List<int>()));
    }

    [Test]
    public void Swap_ShouldThrowArgumentNullException_GivenNullTarget()
    {
        Assert.Throws<ArgumentNullException>(() => new List<int>().Swap(null!));
    }

    [Test]
    public void Swap_ShouldSwapElements_GivenMatchingElementCount()
    {
        var first = new List<int> {1, 2, 3};
        var second = new List<int> {4, 5, 6};

        first.Swap(second);

        CollectionAssert.AreEqual(new[] {4, 5, 6}, first, string.Join(' ', first));
        CollectionAssert.AreEqual(new[] {1, 2, 3}, second, string.Join(' ', second));

        first.Swap(second);

        CollectionAssert.AreEqual(new[] {1, 2, 3}, first, string.Join(' ', first));
        CollectionAssert.AreEqual(new[] {4, 5, 6}, second, string.Join(' ', second));
    }

    [Test]
    public void Swap_ShouldSwapElements_GivenDifferentElementCount()
    {
        var first = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };
        var second = new List<int> {6, 7};

        first.Swap(second);

        CollectionAssert.AreEqual(new[] {6, 7}, first, string.Join(' ', first));
        CollectionAssert.AreEqual(new[] {1, 2, 3, 4, 5}, second, string.Join(' ', second));

        first.Swap(second);

        CollectionAssert.AreEqual(new[] {1, 2, 3, 4, 5}, first, string.Join(' ', first));
        CollectionAssert.AreEqual(new[] {6, 7}, second, string.Join(' ', second));
    }
}
