using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestClass]
public class Int16Tests
{
    [TestMethod]
    public void ProductShouldBeCorrect()
    {
        short Cast(int i) => (short)i;
        
        Assert.AreEqual(0, Enumerable.Range(0, 10).Select(Cast).Product());
        Assert.AreEqual(1, Enumerable.Range(1, 1).Select(Cast).Product());
        Assert.AreEqual(2, Enumerable.Range(1, 2).Select(Cast).Product());
        Assert.AreEqual(6, Enumerable.Range(1, 3).Select(Cast).Product());
        Assert.AreEqual(24, Enumerable.Range(1, 4).Select(Cast).Product());
        Assert.AreEqual(120, Enumerable.Range(1, 5).Select(Cast).Product());
        Assert.AreEqual(720, Enumerable.Range(1, 6).Select(Cast).Product());
        Assert.AreEqual(5040, Enumerable.Range(1, 7).Select(Cast).Product());

        // 8! will overflow for short
    }

    [TestMethod]
    public void ProductOfDoublesShouldBeCorrect()
    {
        short Double(int i) => (short)(i * 2);

        Assert.AreEqual(0, Enumerable.Range(0, 10).Product(Double));
        Assert.AreEqual(2, Enumerable.Range(1, 1).Product(Double));
        Assert.AreEqual(8, Enumerable.Range(1, 2).Product(Double));
        Assert.AreEqual(48, Enumerable.Range(1, 3).Product(Double));
        Assert.AreEqual(384, Enumerable.Range(1, 4).Product(Double));
        Assert.AreEqual(3840, Enumerable.Range(1, 5).Product(Double));

        // Π_(i=1)^n (2i) will overflow at i=6 for short
    }

    [TestMethod]
    public void RangeTo_Int16_ShouldYieldCorrectValues()
    {
        const short start = 1;
        const short end = 10;

        short current = 1;
        foreach (short value in start.RangeTo(end))
        {
            Assert.AreEqual(current++, value);
        }

        Assert.AreEqual(current, end);
    }

    [TestMethod]
    public void RangeTo_Int32_ShouldYieldCorrectValues()
    {
        const short start = 1;
        const int end = 10;

        int current = 1;
        foreach (int value in start.RangeTo(end))
        {
            Assert.AreEqual(current++, value);
        }

        Assert.AreEqual(current, end);
    }

    [TestMethod]
    public void RangeTo_Int64_ShouldYieldCorrectValues()
    {
        const short start = 1;
        const long end = 10;

        long current = 1;
        foreach (long value in start.RangeTo(end))
        {
            Assert.AreEqual(current++, value);
        }

        Assert.AreEqual(current, end);
    }
}
