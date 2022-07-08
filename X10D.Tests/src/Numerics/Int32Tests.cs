using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestClass]
public class Int32Tests
{
    [TestMethod]
    public void PopCount_ShouldBe0_Given0()
    {
        Assert.AreEqual(0, ((uint)0).PopCount());
    }

    [TestMethod]
    public void PopCount_ShouldBe5_Given11010101()
    {
        Assert.AreEqual(5, ((uint)0b11010101).PopCount());
    }

    [TestMethod]
    public void PopCount_ShouldBe31_Given11111111111111111111111111111111()
    {
        Assert.AreEqual(31, 0b01111111111111111111111111111111.PopCount());
    }

    [TestMethod]
    public void RotateLeft_ShouldRotateCorrectly()
    {
        const int value = 284719;         // 00000000 00000100 01011000 00101111
        const int expected = -1336016888; // 10110000 01011110 00000000 00001000

        Assert.AreEqual(value, value.RotateLeft(0));
        Assert.AreEqual(expected, value.RotateLeft(17));
    }

    [TestMethod]
    public void RotateLeft_ShouldModForLargeCount()
    {
        const int value = 284719; // 00000000 00000100 01011000 00101111
        Assert.AreEqual(value, value.RotateLeft(32));
    }

    [TestMethod]
    public void RotateRight_ShouldRotateCorrectly()
    {
        const int value = 284719;       // 00000000 00000100 01011000 00101111
        const int expected = 739737602; // 00101100 00010111 10000000 00000010

        Assert.AreEqual(value, value.RotateRight(0));
        Assert.AreEqual(expected, value.RotateRight(17));
    }

    [TestMethod]
    public void RotateRight_ShouldModForLargeCount()
    {
        const int value = 284719; // 00000000 00000100 01011000 00101111
        Assert.AreEqual(value, value.RotateRight(32));
    }

    [TestMethod]
    public void RoundUpToPowerOf2_ShouldReturnRoundedValue_GivenValue()
    {
        Assert.AreEqual(4, 3.RoundUpToPowerOf2());
        Assert.AreEqual(8, 5.RoundUpToPowerOf2());
        Assert.AreEqual(8, 6.RoundUpToPowerOf2());
        Assert.AreEqual(8, 7.RoundUpToPowerOf2());
    }

    [TestMethod]
    public void RoundUpToPowerOf2_ShouldReturnSameValue_GivenPowerOf2()
    {
        for (var i = 0; i < 8; i++)
        {
            var value = (int)System.Math.Pow(2, i);
            Assert.AreEqual(value, value.RoundUpToPowerOf2());
        }
    }

    [TestMethod]
    public void RoundUpToPowerOf2_ShouldReturn0_Given0()
    {
        Assert.AreEqual(0, 0.RoundUpToPowerOf2());
    }
}
