using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestClass]
[CLSCompliant(false)]
public class UInt16Tests
{
    [TestMethod]
    public void RotateLeft_ShouldRotateCorrectly()
    {
        const ushort value = 2896;     // 00001011 01010000
        const ushort expected = 27137; // 01101010 00000001

        Assert.AreEqual(value, value.RotateLeft(0));
        Assert.AreEqual(expected, value.RotateLeft(5));
        Assert.AreEqual(value, value.RotateLeft(16));
    }

    [TestMethod]
    public void RotateLeft_ShouldModForLargeCount()
    {
        const ushort value = 2896; // 00001011 01010000
        Assert.AreEqual(value, value.RotateLeft(16));
    }

    [TestMethod]
    public void RotateRight_ShouldRotateCorrectly()
    {
        const ushort value = 2896;     // 00001011 01010000
        const ushort expected = 32858; // 10000000 01011010

        Assert.AreEqual(value, value.RotateRight(0));
        Assert.AreEqual(expected, value.RotateRight(5));
        Assert.AreEqual(value, value.RotateRight(16));
    }

    [TestMethod]
    public void RotateRight_ShouldModForLargeCount()
    {
        const ushort value = 2896; // 00001011 01010000
        Assert.AreEqual(value, value.RotateRight(16));
    }
}
