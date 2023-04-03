using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestClass]
[CLSCompliant(false)]
public class SByteTests
{
    [TestMethod]
    public void PopCount_ShouldBe0_Given0()
    {
        Assert.AreEqual(0, ((sbyte)0).PopCount());
    }

    [TestMethod]
    public void PopCount_ShouldBe4_Given01010101()
    {
        Assert.AreEqual(4, ((sbyte)0b01010101).PopCount());
    }

    [TestMethod]
    public void PopCount_ShouldBe7_Given01111111()
    {
        Assert.AreEqual(7, ((sbyte)0b01111111).PopCount());
    }

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

    [TestMethod]
    public void RoundUpToPowerOf2_ShouldReturnRoundedValue_GivenValue()
    {
        Assert.AreEqual(4, ((sbyte)3).RoundUpToPowerOf2());
        Assert.AreEqual(8, ((sbyte)5).RoundUpToPowerOf2());
        Assert.AreEqual(8, ((sbyte)6).RoundUpToPowerOf2());
        Assert.AreEqual(8, ((sbyte)7).RoundUpToPowerOf2());
    }

    [TestMethod]
    public void RoundUpToPowerOf2_ShouldReturnSameValue_GivenPowerOf2()
    {
        for (var i = 0; i < 7; i++)
        {
            var value = (sbyte)System.Math.Pow(2, i);
            Assert.AreEqual(value, value.RoundUpToPowerOf2());
        }
    }

    [TestMethod]
    public void RoundUpToPowerOf2_ShouldReturn0_Given0()
    {
        Assert.AreEqual(0, ((sbyte)0).RoundUpToPowerOf2());
    }
}
