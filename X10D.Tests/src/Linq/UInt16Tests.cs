using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestClass]
[CLSCompliant(false)]
public class UInt16Tests
{
    [TestMethod]
    public void ProductShouldBeCorrect()
    {
        ushort Cast(int i) => (ushort)i;

        Assert.AreEqual(0U, Enumerable.Range(0, 10).Select(Cast).Product());
        Assert.AreEqual(1U, Enumerable.Range(1, 1).Select(Cast).Product());
        Assert.AreEqual(2U, Enumerable.Range(1, 2).Select(Cast).Product());
        Assert.AreEqual(6U, Enumerable.Range(1, 3).Select(Cast).Product());
        Assert.AreEqual(24U, Enumerable.Range(1, 4).Select(Cast).Product());
        Assert.AreEqual(120U, Enumerable.Range(1, 5).Select(Cast).Product());
        Assert.AreEqual(720U, Enumerable.Range(1, 6).Select(Cast).Product());
        Assert.AreEqual(5040U, Enumerable.Range(1, 7).Select(Cast).Product());
        Assert.AreEqual(40320U, Enumerable.Range(1, 8).Select(Cast).Product());

        // 9! will overflow for ushort
    }

    [TestMethod]
    public void ProductOfDoublesShouldBeCorrect()
    {
        ushort Double(int i) => (ushort)(i * 2);

        Assert.AreEqual(0U, Enumerable.Range(0, 10).Product(Double));
        Assert.AreEqual(2U, Enumerable.Range(1, 1).Product(Double));
        Assert.AreEqual(8U, Enumerable.Range(1, 2).Product(Double));
        Assert.AreEqual(48U, Enumerable.Range(1, 3).Product(Double));
        Assert.AreEqual(384U, Enumerable.Range(1, 4).Product(Double));
        Assert.AreEqual(3840U, Enumerable.Range(1, 5).Product(Double));
        Assert.AreEqual(46080U, Enumerable.Range(1, 6).Product(Double));

        // Π_(i=1)^n (2i) will overflow at i=7 for ushort
    }

    [TestMethod]
    public void Product_ShouldThrowArgumentNullException_GivenNullSource()
    {
        IEnumerable<ushort> source = null!;
        Assert.ThrowsException<ArgumentNullException>(() => source.Product());
        Assert.ThrowsException<ArgumentNullException>(() => source.Product(v => v));
    }
}
