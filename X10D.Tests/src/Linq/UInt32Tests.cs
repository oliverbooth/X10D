using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestClass]
[CLSCompliant(false)]
public class UInt32Tests
{
    [TestMethod]
    public void ProductShouldBeCorrect()
    {
        ulong Cast(int i) => (ulong)i;

        Assert.AreEqual(0U, Enumerable.Range(0, 10).Select(Cast).Product());
        Assert.AreEqual(1U, Enumerable.Range(1, 1).Select(Cast).Product());
        Assert.AreEqual(2U, Enumerable.Range(1, 2).Select(Cast).Product());
        Assert.AreEqual(6U, Enumerable.Range(1, 3).Select(Cast).Product());
        Assert.AreEqual(24U, Enumerable.Range(1, 4).Select(Cast).Product());
        Assert.AreEqual(120U, Enumerable.Range(1, 5).Select(Cast).Product());
        Assert.AreEqual(720U, Enumerable.Range(1, 6).Select(Cast).Product());
        Assert.AreEqual(5040U, Enumerable.Range(1, 7).Select(Cast).Product());
        Assert.AreEqual(40320U, Enumerable.Range(1, 8).Select(Cast).Product());
        Assert.AreEqual(362880U, Enumerable.Range(1, 9).Select(Cast).Product());
        Assert.AreEqual(3628800U, Enumerable.Range(1, 10).Select(Cast).Product());
    }

    [TestMethod]
    public void ProductOfDoublesShouldBeCorrect()
    {
        uint Double(int i) => (uint)i * 2;

        Assert.AreEqual(0U, Enumerable.Range(0, 10).Product(Double));
        Assert.AreEqual(2U, Enumerable.Range(1, 1).Product(Double));
        Assert.AreEqual(8U, Enumerable.Range(1, 2).Product(Double));
        Assert.AreEqual(48U, Enumerable.Range(1, 3).Product(Double));
        Assert.AreEqual(384U, Enumerable.Range(1, 4).Product(Double));
        Assert.AreEqual(3840U, Enumerable.Range(1, 5).Product(Double));
        Assert.AreEqual(46080U, Enumerable.Range(1, 6).Product(Double));
        Assert.AreEqual(645120U, Enumerable.Range(1, 7).Product(Double));
        Assert.AreEqual(10321920U, Enumerable.Range(1, 8).Product(Double));
        Assert.AreEqual(185794560U, Enumerable.Range(1, 9).Product(Double));
        Assert.AreEqual(3715891200U, Enumerable.Range(1, 10).Product(Double));
    }
}
