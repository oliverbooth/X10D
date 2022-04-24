using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;
using X10D.Core;

namespace X10D.Tests.Collections;

[TestClass]
public class ArrayTests
{
    [TestMethod]
    [DataRow(1)]
    [DataRow("f")]
    [DataRow(true)]
    public void AsArrayShouldGiveLength1(object o)
    {
        object[] array = o.AsArray()!;
        Assert.IsNotNull(array);
        Assert.IsTrue(array.Length == 1);
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow("f")]
    [DataRow(true)]
    public void AsArrayShouldContainObject(object o)
    {
        object[] array = o.AsArray()!;
        Assert.IsNotNull(array);
        Assert.AreEqual(o, array[0]);
    }

    [TestMethod]
    public void AsReadOnlyShouldBeReadOnly()
    {
        var array = new object[] {1, "f", true};
        var readOnly = array.AsReadOnly();
        Assert.IsNotNull(readOnly);
        Assert.IsTrue(readOnly.Count == 3);

        // ReSharper disable once ConvertTypeCheckToNullCheck
        Assert.IsTrue(readOnly is IReadOnlyCollection<object>);
    }

    [TestMethod]
    public void AsReadOnlyNullShouldThrow()
    {
        object[]? array = null;
        Assert.ThrowsException<ArgumentNullException>(array!.AsReadOnly);
    }

    [TestMethod]
    [DataRow]
    [DataRow(1)]
    [DataRow(1, 2, 3)]
    [DataRow(1, 2, 3, 4, 5)]
    public void ClearShouldFillDefault(params int[] args)
    {
        args.Clear();

        int[] clearedArray = Enumerable.Repeat(0, args.Length).ToArray();
        CollectionAssert.AreEqual(clearedArray, args);
    }

    [TestMethod]
    public void ClearNullShouldThrow()
    {
        int[]? array = null;
        Assert.ThrowsException<ArgumentNullException>(array!.Clear);
        Assert.ThrowsException<ArgumentNullException>(() => array!.Clear(0, 0));
    }

    [TestMethod]
    [DataRow]
    [DataRow(1)]
    [DataRow(1, 2, 3)]
    [DataRow(1, 2, 3, 4, 5)]
    public void FillShouldBeCorrect(params int[] args)
    {
        args.Fill(1);

        int[] comparison = Enumerable.Repeat(1, args.Length).ToArray();
        CollectionAssert.AreEqual(comparison, args);
    }

    [TestMethod]
    public void FillNullShouldThrow()
    {
        int[]? array = null;
        Assert.ThrowsException<ArgumentNullException>(() => array!.Fill(0));
        Assert.ThrowsException<ArgumentNullException>(() => array!.Fill(0, 0, 0));
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(1, 2, 3)]
    [DataRow(1, 2, 3, 4, 5)]
    public void FillSlicedShouldBeCorrect(params int[] args)
    {
        int first = args[0];
        args.Fill(1, 1, args.Length - 1);

        int[] comparison = Enumerable.Repeat(1, args.Length - 1).ToArray();
        Assert.AreEqual(first, args[0]);
        CollectionAssert.AreEqual(comparison, args[1..]);
    }
}
