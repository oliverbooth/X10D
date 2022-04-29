using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestClass]
public class ByteTests
{
    [TestMethod]
    public void RotateLeft_ShouldRotateCorrectly()
    {
        const byte value = 181;   // 10110101
        const byte expected = 91; // 01011011

        Assert.AreEqual(value, value.RotateLeft(0));
        Assert.AreEqual(expected, value.RotateLeft(4));
    }

    [TestMethod]
    public void RotateLeft_ShouldModForLargeCount()
    {
        const byte value = 181; // 10110101
        Assert.AreEqual(value, value.RotateLeft(8));
    }

    [TestMethod]
    public void RotateRight_ShouldRotateCorrectly()
    {
        const byte value = 181;   // 10110101
        const byte expected = 91; // 01011011

        Assert.AreEqual(value, value.RotateRight(0));
        Assert.AreEqual(expected, value.RotateRight(4));
    }

    [TestMethod]
    public void RotateRight_ShouldModForLargeCount()
    {
        const byte value = 181; // 10110101
        Assert.AreEqual(value, value.RotateRight(8));
    }
}
