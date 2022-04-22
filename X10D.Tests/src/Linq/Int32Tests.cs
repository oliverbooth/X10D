using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestClass]
public class Int32Tests
{
    [TestMethod]
    public void ProductShouldBeCorrect()
    {
        Assert.AreEqual(0, Enumerable.Range(0, 10).Product());
        Assert.AreEqual(1, Enumerable.Range(1, 1).Product());
        Assert.AreEqual(2, Enumerable.Range(1, 2).Product());
        Assert.AreEqual(6, Enumerable.Range(1, 3).Product());
        Assert.AreEqual(24, Enumerable.Range(1, 4).Product());
        Assert.AreEqual(120, Enumerable.Range(1, 5).Product());
        Assert.AreEqual(720, Enumerable.Range(1, 6).Product());
        Assert.AreEqual(5040, Enumerable.Range(1, 7).Product());
        Assert.AreEqual(40320, Enumerable.Range(1, 8).Product());
        Assert.AreEqual(362880, Enumerable.Range(1, 9).Product());
        Assert.AreEqual(3628800, Enumerable.Range(1, 10).Product());
    }

    [TestMethod]
    public void ProductOfDoublesShouldBeCorrect()
    {
        int Double(int i) => i * 2;

        Assert.AreEqual(0, Enumerable.Range(0, 10).Product(Double));
        Assert.AreEqual(2, Enumerable.Range(1, 1).Product(Double));
        Assert.AreEqual(8, Enumerable.Range(1, 2).Product(Double));
        Assert.AreEqual(48, Enumerable.Range(1, 3).Product(Double));
        Assert.AreEqual(384, Enumerable.Range(1, 4).Product(Double));
        Assert.AreEqual(3840, Enumerable.Range(1, 5).Product(Double));
        Assert.AreEqual(46080, Enumerable.Range(1, 6).Product(Double));
        Assert.AreEqual(645120, Enumerable.Range(1, 7).Product(Double));
        Assert.AreEqual(10321920, Enumerable.Range(1, 8).Product(Double));
        Assert.AreEqual(185794560, Enumerable.Range(1, 9).Product(Double));

        // Π_(i=1)^(n(i*2)) will overflow at i=10 for int
    }
}
