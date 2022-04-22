using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestClass]
public class DoubleTests
{
    [TestMethod]
    public void ProductShouldBeCorrect()
    {
        double Cast(int i) => i;

        Assert.AreEqual(0.0, Enumerable.Range(0, 10).Select(Cast).Product());
        Assert.AreEqual(1.0, Enumerable.Range(1, 1).Select(Cast).Product());
        Assert.AreEqual(2.0, Enumerable.Range(1, 2).Select(Cast).Product());
        Assert.AreEqual(6.0, Enumerable.Range(1, 3).Select(Cast).Product());
        Assert.AreEqual(24.0, Enumerable.Range(1, 4).Select(Cast).Product());
        Assert.AreEqual(120.0, Enumerable.Range(1, 5).Select(Cast).Product());
        Assert.AreEqual(720.0, Enumerable.Range(1, 6).Select(Cast).Product());
        Assert.AreEqual(5040.0, Enumerable.Range(1, 7).Select(Cast).Product());
        Assert.AreEqual(40320.0, Enumerable.Range(1, 8).Select(Cast).Product());
        Assert.AreEqual(362880.0, Enumerable.Range(1, 9).Select(Cast).Product());
        Assert.AreEqual(3628800.0, Enumerable.Range(1, 10).Select(Cast).Product());
    }

    [TestMethod]
    public void ProductOfDoublesShouldBeCorrect()
    {
        double Double(int i) => i * 2.0;

        Assert.AreEqual(0.0, Enumerable.Range(0, 10).Product(Double));
        Assert.AreEqual(2.0, Enumerable.Range(1, 1).Product(Double));
        Assert.AreEqual(8.0, Enumerable.Range(1, 2).Product(Double));
        Assert.AreEqual(48.0, Enumerable.Range(1, 3).Product(Double));
        Assert.AreEqual(384.0, Enumerable.Range(1, 4).Product(Double));
        Assert.AreEqual(3840.0, Enumerable.Range(1, 5).Product(Double));
        Assert.AreEqual(46080.0, Enumerable.Range(1, 6).Product(Double));
        Assert.AreEqual(645120.0, Enumerable.Range(1, 7).Product(Double));
        Assert.AreEqual(10321920.0, Enumerable.Range(1, 8).Product(Double));
        Assert.AreEqual(185794560.0, Enumerable.Range(1, 9).Product(Double));
        Assert.AreEqual(3715891200.0, Enumerable.Range(1, 10).Product(Double));
    }
}
