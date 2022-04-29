using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestClass]
[CLSCompliant(false)]
public class UInt32Tests
{
    [TestMethod]
    public void RotateLeft_ShouldRotateCorrectly()
    {
        const uint value = 284719;        // 00000000 00000100 01011000 00101111
        const uint expected = 2958950408; // 10110000 01011110 00000000 00001000

        Assert.AreEqual(value, value.RotateLeft(0));
        Assert.AreEqual(expected, value.RotateLeft(17));
    }

    [TestMethod]
    public void RotateLeft_ShouldModForLargeCount()
    {
        const uint value = 284719; // 00000000 00000100 01011000 00101111
        Assert.AreEqual(value, value.RotateLeft(32));
    }

    [TestMethod]
    public void RotateRight_ShouldRotateCorrectly()
    {
        const uint value = 284719;       // 00000000 00000100 01011000 00101111
        const uint expected = 739737602; // 00101100 00010111 10000000 00000010

        Assert.AreEqual(value, value.RotateRight(0));
        Assert.AreEqual(expected, value.RotateRight(17));
    }

    [TestMethod]
    public void RotateRight_ShouldModForLargeCount()
    {
        const uint value = 284719; // 00000000 00000100 01011000 00101111
        Assert.AreEqual(value, value.RotateRight(32));
    }
}
