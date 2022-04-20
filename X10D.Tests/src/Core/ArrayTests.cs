using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X10D.Tests.Core;

[TestClass]
public class ArrayTests
{
    [TestMethod]
    [DataRow]
    [DataRow(1)]
    [DataRow(1, 2, 3)]
    [DataRow(1, 2, 3, 4, 5)]
    public void Clear(params int[] args)
    {
        args.Clear();

        int[] comparison = Enumerable.Repeat(0, args.Length).ToArray();
        CollectionAssert.AreEqual(args, comparison, $"{string.Join(", ", args)} is not equal to" +
                                                    $"{string.Join(", ", comparison)}. ");
    }

    [TestMethod]
    public void ClearNull()
    {
        int[]? array = null;
        Assert.ThrowsException<ArgumentNullException>(array!.Clear);
    }
}
