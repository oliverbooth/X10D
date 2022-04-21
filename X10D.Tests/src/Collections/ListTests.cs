using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestClass]
public class ListTests
{
    [TestMethod]
    public void ListShuffleShouldReorder()
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

        shuffled.Shuffle();

        CollectionAssert.AreNotEqual(list, shuffled);
    }

    [TestMethod]
    public void ListRandomShouldReturnExistingObject()
    {
        var list = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };

        int random = list.Random();

        Assert.IsTrue(list.Contains(random));
    }

    [TestMethod]
    public void NullShuffleShouldThrow()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((List<int>?)null)!.Shuffle());
    }

    [TestMethod]
    public void NullRandomShouldThrow()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((List<int>?)null)!.Random());
    }
}
