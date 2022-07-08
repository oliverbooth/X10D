using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestClass]
public class ByteTests
{
    [TestMethod]
    public void PopCount_ShouldBe0_Given0()
    {
        Assert.AreEqual(0, ((byte)0).PopCount());
    }

    [TestMethod]
    public void PopCount_ShouldBe5_Given11010101()
    {
        Assert.AreEqual(5, ((byte)0b11010101).PopCount());
    }

    [TestMethod]
    public void PopCount_ShouldBe8_Given11111111()
    {
        Assert.AreEqual(8, ((byte)0b11111111).PopCount());
    }

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

    [TestMethod]
    public void RoundUpToPowerOf2_ShouldReturnRoundedValue_GivenValue()
    {
        Assert.AreEqual(4, ((byte)3).RoundUpToPowerOf2());
        Assert.AreEqual(8, ((byte)5).RoundUpToPowerOf2());
        Assert.AreEqual(8, ((byte)6).RoundUpToPowerOf2());
        Assert.AreEqual(8, ((byte)7).RoundUpToPowerOf2());
    }

    [TestMethod]
    public void RoundUpToPowerOf2_ShouldReturnSameValue_GivenPowerOf2()
    {
        for (var i = 0; i < 8; i++)
        {
            var value = (byte)System.Math.Pow(2, i);
            Assert.AreEqual(value, value.RoundUpToPowerOf2());
        }
    }

    [TestMethod]
    public void RoundUpToPowerOf2_ShouldReturn0_Given0()
    {
        Assert.AreEqual(0, ((byte)0).RoundUpToPowerOf2());
    }
}
