using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestClass]
public class EnumerableTests
{
    [TestMethod]
    public void EnumerableShuffledShouldBeDifferentOrder()
    {
        var list = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };
        var shuffled = new List<int>(list);

        CollectionAssert.AreEqual(list, shuffled);

        shuffled = new List<int>(list.Shuffled());

        CollectionAssert.AreNotEqual(list, shuffled);
    }

    [TestMethod]
    public void NullShuffledShouldThrow()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((List<int>?)null)!.Shuffled());
    }
}
