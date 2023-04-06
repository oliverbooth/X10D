using NUnit.Framework;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestFixture]
[CLSCompliant(false)]
public class UInt16Tests
{
    [Test]
    public void PopCount_ShouldBe0_Given0()
    {
        Assert.That(((ushort)0).PopCount(), Is.Zero);
    }

    [Test]
    public void PopCount_ShouldBe5_Given11010101()
    {
        Assert.That(((ushort)0b11010101).PopCount(), Is.EqualTo(5));
    }

    [Test]
    public void PopCount_ShouldBe16_Given1111111111111111()
    {
        Assert.That(((ushort)0b1111111111111111).PopCount(), Is.EqualTo(16));
    }

    [Test]
    public void RotateLeft_ShouldRotateCorrectly()
    {
        const ushort value = 2896;     // 00001011 01010000
        const ushort expected = 27137; // 01101010 00000001

        Assert.That(value.RotateLeft(0), Is.EqualTo(value));
        Assert.That(value.RotateLeft(5), Is.EqualTo(expected));
        Assert.That(value.RotateLeft(16), Is.EqualTo(value));
    }

    [Test]
    public void RotateLeft_ShouldModForLargeCount()
    {
        const ushort value = 2896; // 00001011 01010000
        Assert.That(value.RotateLeft(16), Is.EqualTo(value));
    }

    [Test]
    public void RotateRight_ShouldRotateCorrectly()
    {
        const ushort value = 2896;     // 00001011 01010000
        const ushort expected = 32858; // 10000000 01011010

        Assert.That(value.RotateRight(0), Is.EqualTo(value));
        Assert.That(value.RotateRight(5), Is.EqualTo(expected));
        Assert.That(value.RotateRight(16), Is.EqualTo(value));
    }

    [Test]
    public void RotateRight_ShouldModForLargeCount()
    {
        const ushort value = 2896; // 00001011 01010000
        Assert.That(value.RotateRight(16), Is.EqualTo(value));
    }

    [Test]
    public void RoundUpToPowerOf2_ShouldReturnRoundedValue_GivenValue()
    {
        Assert.That(((ushort)3).RoundUpToPowerOf2(), Is.EqualTo(4U));
        Assert.That(((ushort)5).RoundUpToPowerOf2(), Is.EqualTo(8U));
        Assert.That(((ushort)6).RoundUpToPowerOf2(), Is.EqualTo(8U));
        Assert.That(((ushort)7).RoundUpToPowerOf2(), Is.EqualTo(8U));
    }

    [Test]
    public void RoundUpToPowerOf2_ShouldReturnSameValue_GivenPowerOf2()
    {
        for (var i = 0; i < 8; i++)
        {
            var value = (ushort)System.Math.Pow(2, i);
            Assert.That(value.RoundUpToPowerOf2(), Is.EqualTo(value));
        }
    }

    [Test]
    public void RoundUpToPowerOf2_ShouldReturn0_Given0()
    {
        Assert.That(((ushort)0).RoundUpToPowerOf2(), Is.EqualTo(0U));
    }
}
