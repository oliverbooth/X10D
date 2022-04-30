using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestClass]
public class EnumerableTests
{
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
}
