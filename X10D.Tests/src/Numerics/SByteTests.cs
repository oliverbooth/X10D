using NUnit.Framework;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestFixture]
internal class SByteTests
{
    [Test]
    public void PopCount_ShouldBe0_Given0()
    {
        Assert.That(((sbyte)0).PopCount(), Is.Zero);
    }

    [Test]
    public void PopCount_ShouldBe4_Given01010101()
    {
        Assert.That(((sbyte)0b01010101).PopCount(), Is.EqualTo(4));
    }

    [Test]
    public void PopCount_ShouldBe7_Given01111111()
    {
        Assert.That(((sbyte)0b01111111).PopCount(), Is.EqualTo(7));
    }

    [Test]
    public void RotateLeft_ShouldRotateCorrectly()
    {
        const sbyte value = 117;   // 01110101
        const sbyte expected = 87; // 01010111

        Assert.That(value.RotateLeft(0), Is.EqualTo(value));
        Assert.That(value.RotateLeft(4), Is.EqualTo(expected));
    }

    [Test]
    public void RotateLeft_ShouldModForLargeCount()
    {
        const sbyte value = 117; // 01110101
        Assert.That(value.RotateLeft(8), Is.EqualTo(value));
    }

    [Test]
    public void RotateRight_ShouldRotateCorrectly()
    {
        const sbyte value = 117;   // 01110101
        const sbyte expected = 87; // 01010111

        Assert.That(value.RotateRight(0), Is.EqualTo(value));
        Assert.That(value.RotateRight(4), Is.EqualTo(expected));
    }

    [Test]
    public void RotateRight_ShouldModForLargeCount()
    {
        const sbyte value = 117; // 01110101
        Assert.That(value.RotateRight(8), Is.EqualTo(value));
    }

    [Test]
    public void RoundUpToPowerOf2_ShouldReturnRoundedValue_GivenValue()
    {
        Assert.That(((sbyte)3).RoundUpToPowerOf2(), Is.EqualTo(4));
        Assert.That(((sbyte)5).RoundUpToPowerOf2(), Is.EqualTo(8));
        Assert.That(((sbyte)6).RoundUpToPowerOf2(), Is.EqualTo(8));
        Assert.That(((sbyte)7).RoundUpToPowerOf2(), Is.EqualTo(8));
    }

    [Test]
    public void RoundUpToPowerOf2_ShouldReturnSameValue_GivenPowerOf2()
    {
        for (var i = 0; i < 7; i++)
        {
            var value = (sbyte)System.Math.Pow(2, i);
            Assert.That(value.RoundUpToPowerOf2(), Is.EqualTo(value));
        }
    }

    [Test]
    public void RoundUpToPowerOf2_ShouldReturn0_Given0()
    {
        Assert.That(((sbyte)0).RoundUpToPowerOf2(), Is.Zero);
    }
}
