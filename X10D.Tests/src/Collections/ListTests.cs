using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestClass]
public class ListTests
{
    [CLSCompliant(false)]
    [TestMethod]
    [DataRow(1)]
    [DataRow(1, 2, 3)]
    [DataRow(1, 2, 3, 4, 5)]
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

    [CLSCompliant(false)]
    [TestMethod]
    [DataRow(1)]
    [DataRow(1, 2, 3)]
    [DataRow(1, 2, 3, 4, 5)]
    public void SlicedFill_ShouldLeaveFirstElement_GivenStartIndex1(params int[] args)
    {
        int first = args[0];
        args.Fill(1, 1, args.Length - 1);

        int[] comparison = Enumerable.Repeat(1, args.Length - 1).ToArray();
        Assert.AreEqual(first, args[0]);
        CollectionAssert.AreEqual(comparison, args[1..]);
    }

    [TestMethod]
    public void Fill_ShouldThrow_GivenExceededCount()
    {
        int[] array = Array.Empty<int>();
        var list = new List<int>();
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => array.Fill(0, 0, 1));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.Fill(0, 0, 1));
    }

    [TestMethod]
    public void Fill_ShouldThrow_GivenNegativeCount()
    {
        int[] array = Array.Empty<int>();
        var list = new List<int>();
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => array.Fill(0, 0, -1));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.Fill(0, 0, -1));
    }

    [TestMethod]
    public void Fill_ShouldThrow_GivenNegativeStartIndex()
    {
        int[] array = Array.Empty<int>();
        var list = new List<int>();
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => array.Fill(0, -1, 0));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.Fill(0, -1, 0));
    }

    [TestMethod]
    public void Fill_ShouldThrow_GivenNull()
    {
        int[]? array = null;
        List<int>? list = null;
        Assert.ThrowsException<ArgumentNullException>(() => array!.Fill(0));
        Assert.ThrowsException<ArgumentNullException>(() => list!.Fill(0));
        Assert.ThrowsException<ArgumentNullException>(() => array!.Fill(0, 0, 0));
        Assert.ThrowsException<ArgumentNullException>(() => list!.Fill(0, 0, 0));
    }

    [TestMethod]
    public void Random_ShouldReturnContainedObject_GivenNotNull()
    {
        var list = new List<int>(Enumerable.Range(1, 52)); // 52! chance of being shuffled to the same order
        int random = list.Random();

        Assert.IsTrue(list.Contains(random));
    }

    [TestMethod]
    public void Random_ShouldThrow_GivenNull()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((List<int>?)null)!.Random());
    }

    [TestMethod]
    public void RemoveRange_ShouldThrowArgumentNullException_GivenNull()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((List<int>?)null)!.RemoveRange(new Range()));
    }

    [TestMethod]
    public void RemoveRange_ShouldThrowArgumentException_GivenEndIndexLessThanStart()
    {
        Assert.ThrowsException<ArgumentException>(() => new List<int>().RemoveRange(2..0));
    }

    [TestMethod]
    public void RemoveRange_ShouldThrowArgumentOutOfRangeException_GivenEndIndexGreaterThanOrEqualToCount()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new List<int>().RemoveRange(..0));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new List<int> {1}.RemoveRange(..2));
    }

    [TestMethod]
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

        Assert.AreEqual(10, list.Count);
        list.RemoveRange(2..5);
        Assert.AreEqual(6, list.Count);
        CollectionAssert.AreEqual(new[] {1, 2, 7, 8, 9, 10}, list);
    }

    [TestMethod]
    public void Shuffle_ShouldReorder_GivenNotNull()
    {
        var list = new List<int>(Enumerable.Range(1, 52)); // 52! chance of being shuffled to the same order
        var shuffled = new List<int>(list);

        CollectionAssert.AreEqual(list, shuffled);

        shuffled.Shuffle();

        CollectionAssert.AreNotEqual(list, shuffled);
    }

    [TestMethod]
    public void Shuffle_ShouldThrow_GivenNull()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((List<int>?)null)!.Shuffle());
    }

    [TestMethod]
    public void Swap_ShouldThrowArgumentNullException_GivenNullSource()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((IList<int>?)null)!.Swap(new List<int>()));
    }

    [TestMethod]
    public void Swap_ShouldThrowArgumentNullException_GivenNullTarget()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new List<int>().Swap(null!));
    }

    [TestMethod]
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

    [TestMethod]
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
