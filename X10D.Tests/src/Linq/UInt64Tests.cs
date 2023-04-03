using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestClass]
[CLSCompliant(false)]
public class UInt64Tests
{
    [TestMethod]
    public void ProductShouldBeCorrect()
    {
        ulong Cast(int i) => (ulong)i;

        Assert.AreEqual(0UL, Enumerable.Range(0, 10).Select(Cast).Product());
        Assert.AreEqual(1UL, Enumerable.Range(1, 1).Select(Cast).Product());
        Assert.AreEqual(2UL, Enumerable.Range(1, 2).Select(Cast).Product());
        Assert.AreEqual(6UL, Enumerable.Range(1, 3).Select(Cast).Product());
        Assert.AreEqual(24UL, Enumerable.Range(1, 4).Select(Cast).Product());
        Assert.AreEqual(120UL, Enumerable.Range(1, 5).Select(Cast).Product());
        Assert.AreEqual(720UL, Enumerable.Range(1, 6).Select(Cast).Product());
        Assert.AreEqual(5040UL, Enumerable.Range(1, 7).Select(Cast).Product());
        Assert.AreEqual(40320UL, Enumerable.Range(1, 8).Select(Cast).Product());
        Assert.AreEqual(362880UL, Enumerable.Range(1, 9).Select(Cast).Product());
        Assert.AreEqual(3628800UL, Enumerable.Range(1, 10).Select(Cast).Product());
    }

    [TestMethod]
    public void ProductOfDoublesShouldBeCorrect()
    {
        ulong Double(int i) => (ulong)i * 2;

        Assert.AreEqual(0UL, Enumerable.Range(0, 10).Product(Double));
        Assert.AreEqual(2UL, Enumerable.Range(1, 1).Product(Double));
        Assert.AreEqual(8UL, Enumerable.Range(1, 2).Product(Double));
        Assert.AreEqual(48UL, Enumerable.Range(1, 3).Product(Double));
        Assert.AreEqual(384UL, Enumerable.Range(1, 4).Product(Double));
        Assert.AreEqual(3840UL, Enumerable.Range(1, 5).Product(Double));
        Assert.AreEqual(46080UL, Enumerable.Range(1, 6).Product(Double));
        Assert.AreEqual(645120UL, Enumerable.Range(1, 7).Product(Double));
        Assert.AreEqual(10321920UL, Enumerable.Range(1, 8).Product(Double));
        Assert.AreEqual(185794560UL, Enumerable.Range(1, 9).Product(Double));
        Assert.AreEqual(3715891200UL, Enumerable.Range(1, 10).Product(Double));
    }

    [TestMethod]
    public void Product_ShouldThrowArgumentNullException_GivenNullSource()
    {
        IEnumerable<ulong> source = null!;
        Assert.ThrowsException<ArgumentNullException>(() => source.Product());
        Assert.ThrowsException<ArgumentNullException>(() => source.Product(v => v));
    }
}
