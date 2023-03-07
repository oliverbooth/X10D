using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestClass]
[CLSCompliant(false)]
public class UInt64Tests
{
    [TestMethod]
    public void PopCount_ShouldBe0_Given0()
    {
        Assert.AreEqual(0, 0UL.PopCount());
    }

    [TestMethod]
    public void PopCount_ShouldBe5_Given11010101()
    {
        Assert.AreEqual(5, 0b11010101UL.PopCount());
    }

    [TestMethod]
    public void PopCount_ShouldBe64_Given1111111111111111111111111111111111111111111111111111111111111111()
    {
        Assert.AreEqual(64, 0b1111111111111111111111111111111111111111111111111111111111111111UL.PopCount());
    }

    [TestMethod]
    public void RotateLeft_ShouldRotateCorrectly()
    {
        const ulong value = 5972019251303316844;     // 01010010 11100000 11011111 11011110 00110001 10111010 01111101 01101100
        const ulong expected = 16858575718018152646; // 11101001 11110101 10110001 01001011 10000011 01111111 01111000 11000110

        Assert.AreEqual(value, value.RotateLeft(0));
        Assert.AreEqual(expected, value.RotateLeft(42));
    }

    [TestMethod]
    public void RotateLeft_ShouldModForLargeCount()
    {
        const ulong value = 5972019251303316844; // 01010010 11100000 11011111 11011110 00110001 10111010 01111101 01101100
        Assert.AreEqual(value, value.RotateLeft(64));
    }

    [TestMethod]
    public void RotateRight_ShouldRotateCorrectly()
    {
        const ulong value = 5972019251303316844;     // 01010010 11100000 11011111 11011110 00110001 10111010 01111101 01101100
        const ulong expected = 17837753854814631991; // 11110111 10001100 01101110 10011111 01011011 00010100 10111000 00110111

        Assert.AreEqual(value, value.RotateRight(0));
        Assert.AreEqual(expected, value.RotateRight(42));
    }

    [TestMethod]
    public void RotateRight_ShouldModForLargeCount()
    {
        const ulong value = 5972019251303316844; // 01010010 11100000 11011111 11011110 00110001 10111010 01111101 01101100
        Assert.AreEqual(value, value.RotateRight(64));
    }

    [TestMethod]
    public void RoundUpToPowerOf2_ShouldReturnRoundedValue_GivenValue()
    {
        Assert.AreEqual(4UL, 3UL.RoundUpToPowerOf2());
        Assert.AreEqual(8UL, 5UL.RoundUpToPowerOf2());
        Assert.AreEqual(8UL, 6UL.RoundUpToPowerOf2());
        Assert.AreEqual(8UL, 7UL.RoundUpToPowerOf2());
    }

    [TestMethod]
    public void RoundUpToPowerOf2_ShouldReturnSameValue_GivenPowerOf2()
    {
        for (var i = 0; i < 8; i++)
        {
            var value = (ulong)System.Math.Pow(2, i);
            Assert.AreEqual(value, value.RoundUpToPowerOf2());
        }
    }

    [TestMethod]
    public void RoundUpToPowerOf2_ShouldReturn0_Given0()
    {
        Assert.AreEqual(0UL, 0UL.RoundUpToPowerOf2());
    }
}
