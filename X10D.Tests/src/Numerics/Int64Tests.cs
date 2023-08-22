using NUnit.Framework;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestFixture]
internal class Int64Tests
{
    [Test]
    public void PopCount_ShouldBe0_Given0()
    {
        Assert.That(0L.PopCount(), Is.Zero);
    }

    [Test]
    public void PopCount_ShouldBe5_Given11010101()
    {
        Assert.That(0b11010101L.PopCount(), Is.EqualTo(5));
    }

    [Test]
    public void PopCount_ShouldBe63_Given0111111111111111111111111111111111111111111111111111111111111111()
    {
        Assert.That(0b0111111111111111111111111111111111111111111111111111111111111111L.PopCount(), Is.EqualTo(63));
    }

    [Test]
    public void RotateLeft_ShouldRotateCorrectly()
    {
        const long value = 5972019251303316844;     // 01010010 11100000 11011111 11011110 00110001 10111010 01111101 01101100
        const long expected = -1588168355691398970; // 11101001 11110101 10110001 01001011 10000011 01111111 01111000 11000110

        Assert.That(value.RotateLeft(0), Is.EqualTo(value));
        Assert.That(value.RotateLeft(42), Is.EqualTo(expected));
    }

    [Test]
    public void RotateLeft_ShouldModForLargeCount()
    {
        const long value = 5972019251303316844; // 01010010 11100000 11011111 11011110 00110001 10111010 01111101 01101100
        Assert.That(value.RotateLeft(64), Is.EqualTo(value));
    }

    [Test]
    public void RotateRight_ShouldRotateCorrectly()
    {
        const long value = 5972019251303316844;    // 01010010 11100000 11011111 11011110 00110001 10111010 01111101 01101100
        const long expected = -608990218894919625; // 11110111 10001100 01101110 10011111 01011011 00010100 10111000 00110111

        Assert.That(value.RotateRight(0), Is.EqualTo(value));
        Assert.That(value.RotateRight(42), Is.EqualTo(expected));
    }

    [Test]
    public void RotateRight_ShouldModForLargeCount()
    {
        const long value = 5972019251303316844; // 01010010 11100000 11011111 11011110 00110001 10111010 01111101 01101100
        Assert.That(value.RotateRight(64), Is.EqualTo(value));
    }

    [Test]
    public void RoundUpToPowerOf2_ShouldReturnRoundedValue_GivenValue()
    {
        Assert.That(3L.RoundUpToPowerOf2(), Is.EqualTo(4L));
        Assert.That(5L.RoundUpToPowerOf2(), Is.EqualTo(8L));
        Assert.That(6L.RoundUpToPowerOf2(), Is.EqualTo(8L));
        Assert.That(7L.RoundUpToPowerOf2(), Is.EqualTo(8L));
    }

    [Test]
    public void RoundUpToPowerOf2_ShouldReturnSameValue_GivenPowerOf2()
    {
        for (var i = 0; i < 8; i++)
        {
            var value = (long)System.Math.Pow(2, i);
            Assert.That(value.RoundUpToPowerOf2(), Is.EqualTo(value));
        }
    }

    [Test]
    public void RoundUpToPowerOf2_ShouldReturn0_Given0()
    {
        Assert.That(0L.RoundUpToPowerOf2(), Is.EqualTo(0L));
    }
}
