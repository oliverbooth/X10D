using NUnit.Framework;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestFixture]
internal class Int16Tests
{
    [Test]
    public void PopCount_ShouldBe0_Given0()
    {
        Assert.That(((short)0).PopCount(), Is.Zero);
    }

    [Test]
    public void PopCount_ShouldBe5_Given11010101()
    {
        Assert.That(((short)0b11010101).PopCount(), Is.EqualTo(5));
    }

    [Test]
    public void PopCount_ShouldBe15_Given0111111111111111()
    {
        Assert.That(((short)0b0111111111111111).PopCount(), Is.EqualTo(15));
    }

    [Test]
    public void RotateLeft_ShouldRotateCorrectly()
    {
        const short value = 2896;     // 00001011 01010000
        const short expected = 27137; // 01101010 00000001

        Assert.That(value.RotateLeft(0), Is.EqualTo(value));
        Assert.That(value.RotateLeft(5), Is.EqualTo(expected));
        Assert.That(value.RotateLeft(16), Is.EqualTo(value));
    }

    [Test]
    public void RotateLeft_ShouldModForLargeCount()
    {
        const short value = 2896; // 00001011 01010000
        Assert.That(value.RotateLeft(16), Is.EqualTo(value));
    }

    [Test]
    public void RotateRight_ShouldRotateCorrectly()
    {
        const short value = 2896;      // 00001011 01010000
        const short expected = -32678; // 01111111 10100110

        Assert.That(value.RotateRight(0), Is.EqualTo(value));
        Assert.That(value.RotateRight(5), Is.EqualTo(expected));
        Assert.That(value.RotateRight(16), Is.EqualTo(value));
    }

    [Test]
    public void RotateRight_ShouldModForLargeCount()
    {
        const short value = 2896; // 00001011 01010000
        Assert.That(value.RotateRight(16), Is.EqualTo(value));
    }

    [Test]
    public void RoundUpToPowerOf2_ShouldReturnRoundedValue_GivenValue()
    {
        Assert.That(((short)3).RoundUpToPowerOf2(), Is.EqualTo(4));
        Assert.That(((short)5).RoundUpToPowerOf2(), Is.EqualTo(8));
        Assert.That(((short)6).RoundUpToPowerOf2(), Is.EqualTo(8));
        Assert.That(((short)7).RoundUpToPowerOf2(), Is.EqualTo(8));
    }

    [Test]
    public void RoundUpToPowerOf2_ShouldReturnSameValue_GivenPowerOf2()
    {
        for (var i = 0; i < 8; i++)
        {
            var value = (short)System.Math.Pow(2, i);
            Assert.That(value.RoundUpToPowerOf2(), Is.EqualTo(value));
        }
    }

    [Test]
    public void RoundUpToPowerOf2_ShouldReturn0_Given0()
    {
        Assert.That(((short)0).RoundUpToPowerOf2(), Is.Zero);
    }
}
