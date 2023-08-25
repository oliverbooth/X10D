using NUnit.Framework;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestFixture]
internal class UInt32Tests
{
    [Test]
    public void PopCount_ShouldBe0_Given0()
    {
        Assert.That(0U.PopCount(), Is.Zero);
    }

    [Test]
    public void PopCount_ShouldBe5_Given11010101()
    {
        Assert.That(0b11010101U.PopCount(), Is.EqualTo(5));
    }

    [Test]
    public void PopCount_ShouldBe32_Given11111111111111111111111111111111()
    {
        Assert.That(0b11111111111111111111111111111111U.PopCount(), Is.EqualTo(32));
    }

    [Test]
    public void RotateLeft_ShouldRotateCorrectly()
    {
        const uint value = 284719;        // 00000000 00000100 01011000 00101111
        const uint expected = 2958950408; // 10110000 01011110 00000000 00001000

        Assert.That(value.RotateLeft(0), Is.EqualTo(value));
        Assert.That(value.RotateLeft(17), Is.EqualTo(expected));
    }

    [Test]
    public void RotateLeft_ShouldModForLargeCount()
    {
        const uint value = 284719; // 00000000 00000100 01011000 00101111
        Assert.That(value.RotateLeft(32), Is.EqualTo(value));
    }

    [Test]
    public void RotateRight_ShouldRotateCorrectly()
    {
        const uint value = 284719;       // 00000000 00000100 01011000 00101111
        const uint expected = 739737602; // 00101100 00010111 10000000 00000010

        Assert.That(value.RotateRight(0), Is.EqualTo(value));
        Assert.That(value.RotateRight(17), Is.EqualTo(expected));
    }

    [Test]
    public void RotateRight_ShouldModForLargeCount()
    {
        const uint value = 284719; // 00000000 00000100 01011000 00101111
        Assert.That(value.RotateRight(32), Is.EqualTo(value));
    }

    [Test]
    public void RoundUpToPowerOf2_ShouldReturnRoundedValue_GivenValue()
    {
        Assert.That(3U.RoundUpToPowerOf2(), Is.EqualTo(4U));
        Assert.That(5U.RoundUpToPowerOf2(), Is.EqualTo(8U));
        Assert.That(6U.RoundUpToPowerOf2(), Is.EqualTo(8U));
        Assert.That(7U.RoundUpToPowerOf2(), Is.EqualTo(8U));
    }

    [Test]
    public void RoundUpToPowerOf2_ShouldReturnSameValue_GivenPowerOf2()
    {
        for (var i = 0; i < 8; i++)
        {
            var value = (uint)System.Math.Pow(2, i);
            Assert.That(value.RoundUpToPowerOf2(), Is.EqualTo(value));
        }
    }

    [Test]
    public void RoundUpToPowerOf2_ShouldReturn0_Given0()
    {
        Assert.That(0U.RoundUpToPowerOf2(), Is.EqualTo(0U));
    }
}
