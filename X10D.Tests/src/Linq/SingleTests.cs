using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestClass]
public class SingleTests
{
    [TestMethod]
    public void ProductShouldBeCorrect()
    {
        float Cast(int i) => i;

        Assert.AreEqual(0f, Enumerable.Range(0, 10).Select(Cast).Product());
        Assert.AreEqual(1f, Enumerable.Range(1, 1).Select(Cast).Product());
        Assert.AreEqual(2f, Enumerable.Range(1, 2).Select(Cast).Product());
        Assert.AreEqual(6f, Enumerable.Range(1, 3).Select(Cast).Product());
        Assert.AreEqual(24f, Enumerable.Range(1, 4).Select(Cast).Product());
        Assert.AreEqual(120f, Enumerable.Range(1, 5).Select(Cast).Product());
        Assert.AreEqual(720f, Enumerable.Range(1, 6).Select(Cast).Product());
        Assert.AreEqual(5040f, Enumerable.Range(1, 7).Select(Cast).Product());
        Assert.AreEqual(40320f, Enumerable.Range(1, 8).Select(Cast).Product());
        Assert.AreEqual(362880f, Enumerable.Range(1, 9).Select(Cast).Product());
        Assert.AreEqual(3628800f, Enumerable.Range(1, 10).Select(Cast).Product());
    }

    [TestMethod]
    public void ProductOfDoublesShouldBeCorrect()
    {
        float Double(int i) => i * 2f;

        Assert.AreEqual(0f, Enumerable.Range(0, 10).Product(Double));
        Assert.AreEqual(2f, Enumerable.Range(1, 1).Product(Double));
        Assert.AreEqual(8f, Enumerable.Range(1, 2).Product(Double));
        Assert.AreEqual(48f, Enumerable.Range(1, 3).Product(Double));
        Assert.AreEqual(384f, Enumerable.Range(1, 4).Product(Double));
        Assert.AreEqual(3840f, Enumerable.Range(1, 5).Product(Double));
        Assert.AreEqual(46080f, Enumerable.Range(1, 6).Product(Double));
        Assert.AreEqual(645120f, Enumerable.Range(1, 7).Product(Double));
        Assert.AreEqual(10321920f, Enumerable.Range(1, 8).Product(Double));
        Assert.AreEqual(185794560f, Enumerable.Range(1, 9).Product(Double));
        Assert.AreEqual(3715891200f, Enumerable.Range(1, 10).Product(Double));
    }
}
