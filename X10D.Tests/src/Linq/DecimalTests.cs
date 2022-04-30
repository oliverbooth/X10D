using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestClass]
public class DecimalTests
{
    [TestMethod]
    public void ProductShouldBeCorrect()
    {
        decimal Cast(int i) => i;

        Assert.AreEqual(0m, Enumerable.Range(0, 10).Select(Cast).Product());
        Assert.AreEqual(1m, Enumerable.Range(1, 1).Select(Cast).Product());
        Assert.AreEqual(2m, Enumerable.Range(1, 2).Select(Cast).Product());
        Assert.AreEqual(6m, Enumerable.Range(1, 3).Select(Cast).Product());
        Assert.AreEqual(24m, Enumerable.Range(1, 4).Select(Cast).Product());
        Assert.AreEqual(120m, Enumerable.Range(1, 5).Select(Cast).Product());
        Assert.AreEqual(720m, Enumerable.Range(1, 6).Select(Cast).Product());
        Assert.AreEqual(5040m, Enumerable.Range(1, 7).Select(Cast).Product());
        Assert.AreEqual(40320m, Enumerable.Range(1, 8).Select(Cast).Product());
        Assert.AreEqual(362880m, Enumerable.Range(1, 9).Select(Cast).Product());
        Assert.AreEqual(3628800m, Enumerable.Range(1, 10).Select(Cast).Product());
    }

    [TestMethod]
    public void ProductOfDoublesShouldBeCorrect()
    {
        decimal Double(int i) => i * 2m;

        Assert.AreEqual(0m, Enumerable.Range(0, 10).Product(Double));
        Assert.AreEqual(2m, Enumerable.Range(1, 1).Product(Double));
        Assert.AreEqual(8m, Enumerable.Range(1, 2).Product(Double));
        Assert.AreEqual(48m, Enumerable.Range(1, 3).Product(Double));
        Assert.AreEqual(384m, Enumerable.Range(1, 4).Product(Double));
        Assert.AreEqual(3840m, Enumerable.Range(1, 5).Product(Double));
        Assert.AreEqual(46080m, Enumerable.Range(1, 6).Product(Double));
        Assert.AreEqual(645120m, Enumerable.Range(1, 7).Product(Double));
        Assert.AreEqual(10321920m, Enumerable.Range(1, 8).Product(Double));
        Assert.AreEqual(185794560m, Enumerable.Range(1, 9).Product(Double));
        Assert.AreEqual(3715891200m, Enumerable.Range(1, 10).Product(Double));
    }
}
