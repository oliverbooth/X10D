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

    [TestMethod]
    public void RoundUpToPowerOf2_ShouldReturnRoundedValue_GivenValue()
    {
        Assert.AreEqual(4, ((short)3).RoundUpToPowerOf2());
        Assert.AreEqual(8, ((short)5).RoundUpToPowerOf2());
        Assert.AreEqual(8, ((short)6).RoundUpToPowerOf2());
        Assert.AreEqual(8, ((short)7).RoundUpToPowerOf2());
    }

    [TestMethod]
    public void RoundUpToPowerOf2_ShouldReturnSameValue_GivenPowerOf2()
    {
        for (var i = 0; i < 8; i++)
        {
            var value = (short)System.Math.Pow(2, i);
            Assert.AreEqual(value, value.RoundUpToPowerOf2());
        }
    }

    [TestMethod]
    public void RoundUpToPowerOf2_ShouldReturn0_Given0()
    {
        Assert.AreEqual(0, ((short)0).RoundUpToPowerOf2());
    }
}
