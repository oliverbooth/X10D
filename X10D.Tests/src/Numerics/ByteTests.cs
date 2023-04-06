using NUnit.Framework;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestFixture]
public class ByteTests
{
    [Test]
    public void PopCount_ShouldBe0_Given0()
    {
        Assert.That(((byte)0).PopCount(), Is.Zero);
    }

    [Test]
    public void PopCount_ShouldBe5_Given11010101()
    {
        Assert.That(((byte)0b11010101).PopCount(), Is.EqualTo(5));
    }

    [Test]
    public void PopCount_ShouldBe8_Given11111111()
    {
        Assert.That(((byte)0b11111111).PopCount(), Is.EqualTo(8));
    }

    [Test]
    public void RotateLeft_ShouldRotateCorrectly()
    {
        const byte value = 181;   // 10110101
        const byte expected = 91; // 01011011

        Assert.That(value.RotateLeft(0), Is.EqualTo(value));
        Assert.That(value.RotateLeft(4), Is.EqualTo(expected));
    }

    [Test]
    public void RotateLeft_ShouldModForLargeCount()
    {
        const byte value = 181; // 10110101
        Assert.That(value.RotateLeft(8), Is.EqualTo(value));
    }

    [Test]
    public void RotateRight_ShouldRotateCorrectly()
    {
        const byte value = 181;   // 10110101
        const byte expected = 91; // 01011011

        Assert.That(value.RotateRight(0), Is.EqualTo(value));
        Assert.That(value.RotateRight(4), Is.EqualTo(expected));
    }

    [Test]
    public void RotateRight_ShouldModForLargeCount()
    {
        const byte value = 181; // 10110101
        Assert.That(value.RotateRight(8), Is.EqualTo(value));
    }

    [Test]
    public void RoundUpToPowerOf2_ShouldReturnRoundedValue_GivenValue()
    {
        Assert.That(((byte)3).RoundUpToPowerOf2(), Is.EqualTo(4));
        Assert.That(((byte)5).RoundUpToPowerOf2(), Is.EqualTo(8));
        Assert.That(((byte)6).RoundUpToPowerOf2(), Is.EqualTo(8));
        Assert.That(((byte)7).RoundUpToPowerOf2(), Is.EqualTo(8));
    }

    [Test]
    public void RoundUpToPowerOf2_ShouldReturnSameValue_GivenPowerOf2()
    {
        for (var i = 0; i < 8; i++)
        {
            var value = (byte)System.Math.Pow(2, i);
            Assert.That(value.RoundUpToPowerOf2(), Is.EqualTo(value));
        }
    }

    [Test]
    public void RoundUpToPowerOf2_ShouldReturn0_Given0()
    {
        Assert.That(((byte)0).RoundUpToPowerOf2(), Is.Zero);
    }
}
