using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestClass]
public class ListTests
{
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
}
