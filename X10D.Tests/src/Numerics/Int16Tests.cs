using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestClass]
public class Int16Tests
{
    [TestMethod]
    public void RotateLeft_ShouldRotateCorrectly()
    {
        const short value = 2896;     // 00001011 01010000
        const short expected = 27137; // 01101010 00000001

        Assert.AreEqual(value, value.RotateLeft(0));
        Assert.AreEqual(expected, value.RotateLeft(5));
        Assert.AreEqual(value, value.RotateLeft(16));
    }

    [TestMethod]
    public void RotateLeft_ShouldModForLargeCount()
    {
        const short value = 2896; // 00001011 01010000
        Assert.AreEqual(value, value.RotateLeft(16));
    }

    [TestMethod]
    public void RotateRight_ShouldRotateCorrectly()
    {
        const short value = 2896;      // 00001011 01010000
        const short expected = -32678; // 01111111 10100110

        Assert.AreEqual(value, value.RotateRight(0));
        Assert.AreEqual(expected, value.RotateRight(5));
        Assert.AreEqual(value, value.RotateRight(16));
    }

    [TestMethod]
    public void RotateRight_ShouldModForLargeCount()
    {
        const short value = 2896; // 00001011 01010000
        Assert.AreEqual(value, value.RotateRight(16));
    }
}
