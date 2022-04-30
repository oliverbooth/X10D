using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestClass]
public class ArrayTests
{
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
}
