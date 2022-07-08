using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestClass]
public class Int64Tests
{
    [TestMethod]
    public void PopCount_ShouldBe0_Given0()
    {
        Assert.AreEqual(0, 0L.PopCount());
    }

    [TestMethod]
    public void PopCount_ShouldBe5_Given11010101()
    {
        Assert.AreEqual(5, 0b11010101L.PopCount());
    }

    [TestMethod]
    public void PopCount_ShouldBe63_Given0111111111111111111111111111111111111111111111111111111111111111()
    {
        Assert.AreEqual(63, 0b0111111111111111111111111111111111111111111111111111111111111111L.PopCount());
    }

    [TestMethod]
    public void RotateLeft_ShouldRotateCorrectly()
    {
        const long value = 5972019251303316844;     // 01010010 11100000 11011111 11011110 00110001 10111010 01111101 01101100
        const long expected = -1588168355691398970; // 11101001 11110101 10110001 01001011 10000011 01111111 01111000 11000110

        Assert.AreEqual(value, value.RotateLeft(0));
        Assert.AreEqual(expected, value.RotateLeft(42));
    }

    [TestMethod]
    public void RotateLeft_ShouldModForLargeCount()
    {
        const long value = 5972019251303316844; // 01010010 11100000 11011111 11011110 00110001 10111010 01111101 01101100
        Assert.AreEqual(value, value.RotateLeft(64));
    }

    [TestMethod]
    public void RotateRight_ShouldRotateCorrectly()
    {
        const long value = 5972019251303316844;    // 01010010 11100000 11011111 11011110 00110001 10111010 01111101 01101100
        const long expected = -608990218894919625; // 11110111 10001100 01101110 10011111 01011011 00010100 10111000 00110111

        Assert.AreEqual(value, value.RotateRight(0));
        Assert.AreEqual(expected, value.RotateRight(42));
    }

    [TestMethod]
    public void RotateRight_ShouldModForLargeCount()
    {
        const long value = 5972019251303316844; // 01010010 11100000 11011111 11011110 00110001 10111010 01111101 01101100
        Assert.AreEqual(value, value.RotateRight(64));
    }

    [TestMethod]
    public void RoundUpToPowerOf2_ShouldReturnRoundedValue_GivenValue()
    {
        Assert.AreEqual(4L, 3L.RoundUpToPowerOf2());
        Assert.AreEqual(8L, 5L.RoundUpToPowerOf2());
        Assert.AreEqual(8L, 6L.RoundUpToPowerOf2());
        Assert.AreEqual(8L, 7L.RoundUpToPowerOf2());
    }

    [TestMethod]
    public void RoundUpToPowerOf2_ShouldReturnSameValue_GivenPowerOf2()
    {
        for (var i = 0; i < 8; i++)
        {
            var value = (long)System.Math.Pow(2, i);
            Assert.AreEqual(value, value.RoundUpToPowerOf2());
        }
    }

    [TestMethod]
    public void RoundUpToPowerOf2_ShouldReturn0_Given0()
    {
        Assert.AreEqual(0L, 0L.RoundUpToPowerOf2());
    }
}
