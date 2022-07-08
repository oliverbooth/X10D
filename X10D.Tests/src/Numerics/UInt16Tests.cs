using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestClass]
[CLSCompliant(false)]
public class UInt16Tests
{
    [TestMethod]
    public void PopCount_ShouldBe0_Given0()
    {
        Assert.AreEqual(0, ((ushort)0).PopCount());
    }

    [TestMethod]
    public void PopCount_ShouldBe5_Given11010101()
    {
        Assert.AreEqual(5, ((ushort)0b11010101).PopCount());
    }

    [TestMethod]
    public void PopCount_ShouldBe16_Given1111111111111111()
    {
        Assert.AreEqual(16, ((ushort)0b1111111111111111).PopCount());
    }

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

    [TestMethod]
    public void RoundUpToPowerOf2_ShouldReturnRoundedValue_GivenValue()
    {
        Assert.AreEqual(4U, ((ushort)3).RoundUpToPowerOf2());
        Assert.AreEqual(8U, ((ushort)5).RoundUpToPowerOf2());
        Assert.AreEqual(8U, ((ushort)6).RoundUpToPowerOf2());
        Assert.AreEqual(8U, ((ushort)7).RoundUpToPowerOf2());
    }

    [TestMethod]
    public void RoundUpToPowerOf2_ShouldReturnSameValue_GivenPowerOf2()
    {
        for (var i = 0; i < 8; i++)
        {
            var value = (ushort)System.Math.Pow(2, i);
            Assert.AreEqual(value, value.RoundUpToPowerOf2());
        }
    }

    [TestMethod]
    public void RoundUpToPowerOf2_ShouldReturn0_Given0()
    {
        Assert.AreEqual(0U, ((ushort)0).RoundUpToPowerOf2());
    }
}
