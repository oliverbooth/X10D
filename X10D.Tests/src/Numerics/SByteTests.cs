using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestClass]
[CLSCompliant(false)]
public class SByteTests
{
    [TestMethod]
    public void RotateLeft_ShouldRotateCorrectly()
    {
        const sbyte value = 117;   // 01110101
        const sbyte expected = 87; // 01010111

        Assert.AreEqual(value, value.RotateLeft(0));
        Assert.AreEqual(expected, value.RotateLeft(4));
    }

    [TestMethod]
    public void RotateLeft_ShouldModForLargeCount()
    {
        const sbyte value = 117; // 01110101
        Assert.AreEqual(value, value.RotateLeft(8));
    }

    [TestMethod]
    public void RotateRight_ShouldRotateCorrectly()
    {
        const sbyte value = 117;   // 01110101
        const sbyte expected = 87; // 01010111

        Assert.AreEqual(value, value.RotateRight(0));
        Assert.AreEqual(expected, value.RotateRight(4));
    }

    [TestMethod]
    public void RotateRight_ShouldModForLargeCount()
    {
        const sbyte value = 117; // 01110101
        Assert.AreEqual(value, value.RotateRight(8));
    }
}
