using NUnit.Framework;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestFixture]
[CLSCompliant(false)]
public class UInt64Tests
{
    [Test]
    public void PopCount_ShouldBe0_Given0()
    {
        Assert.That(0UL.PopCount(), Is.Zero);
    }

    [Test]
    public void PopCount_ShouldBe5_Given11010101()
    {
        Assert.That(0b11010101UL.PopCount(), Is.EqualTo(5));
    }

    [Test]
    public void PopCount_ShouldBe64_Given1111111111111111111111111111111111111111111111111111111111111111()
    {
        Assert.That(0b1111111111111111111111111111111111111111111111111111111111111111UL.PopCount(), Is.EqualTo(64));
    }

    [Test]
    public void RotateLeft_ShouldRotateCorrectly()
    {
        const ulong value = 5972019251303316844;     // 01010010 11100000 11011111 11011110 00110001 10111010 01111101 01101100
        const ulong expected = 16858575718018152646; // 11101001 11110101 10110001 01001011 10000011 01111111 01111000 11000110

        Assert.That(value.RotateLeft(0), Is.EqualTo(value));
        Assert.That(value.RotateLeft(42), Is.EqualTo(expected));
    }

    [Test]
    public void RotateLeft_ShouldModForLargeCount()
    {
        const ulong value = 5972019251303316844; // 01010010 11100000 11011111 11011110 00110001 10111010 01111101 01101100
        Assert.That(value.RotateLeft(64), Is.EqualTo(value));
    }

    [Test]
    public void RotateRight_ShouldRotateCorrectly()
    {
        const ulong value = 5972019251303316844;     // 01010010 11100000 11011111 11011110 00110001 10111010 01111101 01101100
        const ulong expected = 17837753854814631991; // 11110111 10001100 01101110 10011111 01011011 00010100 10111000 00110111

        Assert.That(value.RotateRight(0), Is.EqualTo(value));
        Assert.That(value.RotateRight(42), Is.EqualTo(expected));
    }

    [Test]
    public void RotateRight_ShouldModForLargeCount()
    {
        const ulong value = 5972019251303316844; // 01010010 11100000 11011111 11011110 00110001 10111010 01111101 01101100
        Assert.That(value.RotateRight(64), Is.EqualTo(value));
    }

    [Test]
    public void RoundUpToPowerOf2_ShouldReturnRoundedValue_GivenValue()
    {
        Assert.That(3UL.RoundUpToPowerOf2(), Is.EqualTo(4UL));
        Assert.That(5UL.RoundUpToPowerOf2(), Is.EqualTo(8UL));
        Assert.That(6UL.RoundUpToPowerOf2(), Is.EqualTo(8UL));
        Assert.That(7UL.RoundUpToPowerOf2(), Is.EqualTo(8UL));
    }

    [Test]
    public void RoundUpToPowerOf2_ShouldReturnSameValue_GivenPowerOf2()
    {
        for (var i = 0; i < 8; i++)
        {
            var value = (ulong)System.Math.Pow(2, i);
            Assert.That(value.RoundUpToPowerOf2(), Is.EqualTo(value));
        }
    }

    [Test]
    public void RoundUpToPowerOf2_ShouldReturn0_Given0()
    {
        Assert.That(0UL.RoundUpToPowerOf2(), Is.EqualTo(0UL));
    }
}
