using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestClass]
public class ByteTests
{
    [TestMethod]
    public void ProductShouldBeCorrect()
    {
        byte Cast(int i) => (byte)i;

        Assert.AreEqual(0, Enumerable.Range(0, 10).Select(Cast).Product());
        Assert.AreEqual(1, Enumerable.Range(1, 1).Select(Cast).Product());
        Assert.AreEqual(2, Enumerable.Range(1, 2).Select(Cast).Product());
        Assert.AreEqual(6, Enumerable.Range(1, 3).Select(Cast).Product());
        Assert.AreEqual(24, Enumerable.Range(1, 4).Select(Cast).Product());
        Assert.AreEqual(120, Enumerable.Range(1, 5).Select(Cast).Product());

        // 6! will overflow for byte
    }

    [TestMethod]
    public void ProductOfDoublesShouldBeCorrect()
    {
        byte Double(int i) => (byte)(i * 2);

        Assert.AreEqual(0, Enumerable.Range(0, 10).Product(Double));
        Assert.AreEqual(2, Enumerable.Range(1, 1).Product(Double));
        Assert.AreEqual(8, Enumerable.Range(1, 2).Product(Double));
        Assert.AreEqual(48, Enumerable.Range(1, 3).Product(Double));

        // Π_(i=1)^n (2i) will overflow at i=4 for byte
    }

    [TestMethod]
    public void Product_ShouldThrowArgumentNullException_GivenNullSource()
    {
        IEnumerable<byte> source = null!;
        Assert.ThrowsException<ArgumentNullException>(() => source.Product());
        Assert.ThrowsException<ArgumentNullException>(() => source.Product(v => v));
    }

    [TestMethod]
    public void RangeTo_Byte_ShouldYieldCorrectValues()
    {
        const byte start = 1;
        const byte end = 10;

        byte current = 1;
        foreach (byte value in start.RangeTo(end))
        {
            Assert.AreEqual(current++, value);
        }

        Assert.AreEqual(current, end);
    }

    [TestMethod]
    public void RangeTo_Int16_ShouldYieldCorrectValues()
    {
        const byte start = 1;
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
        const byte start = 1;
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
        const byte start = 1;
        const long end = 10;

        long current = 1;
        foreach (long value in start.RangeTo(end))
        {
            Assert.AreEqual(current++, value);
        }

        Assert.AreEqual(current, end);
    }
}
