using System.Numerics;
using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

[TestFixture]
internal partial class DecimalTests
{
    [Test]
    public void ComplexSqrt_ShouldBeCorrect_GivenReal()
    {
        Assert.Multiple(() =>
        {
            Assert.That(0.0m.ComplexSqrt(), Is.EqualTo((Complex)0.0));
            Assert.That(2.0m.ComplexSqrt(), Is.EqualTo((Complex)1.4142135623730951));
            Assert.That(9.0m.ComplexSqrt(), Is.EqualTo((Complex)3.0));
            Assert.That(16.0m.ComplexSqrt(), Is.EqualTo((Complex)4.0));
            Assert.That(10000.0m.ComplexSqrt(), Is.EqualTo((Complex)100.0));
        });
    }

    [Test]
    public void ComplexSqrt_ShouldBeImaginary_GivenNegativeValue()
    {
        Assert.Multiple(() =>
        {
            Assert.That((-1.0m).ComplexSqrt(), Is.EqualTo(new Complex(0, 1)));
            Assert.That((-2.0m).ComplexSqrt(), Is.EqualTo(new Complex(0, 1.4142135623730951)));
            Assert.That((-9.0m).ComplexSqrt(), Is.EqualTo(new Complex(0, 3.0)));
            Assert.That((-16.0m).ComplexSqrt(), Is.EqualTo(new Complex(0, 4.0)));
        });
    }

    [Test]
    public void IsEven_ShouldBeFalse_GivenOddNumber()
    {
        Assert.Multiple(() =>
        {
            Assert.That((-3.0m).IsEven(), Is.False);
            Assert.That((-1.0m).IsEven(), Is.False);
            Assert.That(1.0m.IsEven(), Is.False);
            Assert.That(3.0m.IsEven(), Is.False);
        });
    }

    [Test]
    public void IsEven_ShouldBeTrue_GivenOddNumber()
    {
        Assert.Multiple(() =>
        {
            Assert.That((-4.0m).IsEven());
            Assert.That((-2.0m).IsEven());
            Assert.That(0.0m.IsEven());
            Assert.That(2.0m.IsEven());
            Assert.That(4.0m.IsEven());
        });
    }

    [Test]
    public void IsOdd_ShouldBeFalse_GivenEvenNumber()
    {
        Assert.Multiple(() =>
        {
            Assert.That((-4.0m).IsOdd(), Is.False);
            Assert.That((-2.0m).IsOdd(), Is.False);
            Assert.That(0.0m.IsOdd(), Is.False);
            Assert.That(2.0m.IsOdd(), Is.False);
            Assert.That(4.0m.IsOdd(), Is.False);
        });
    }

    [Test]
    public void IsOdd_ShouldBeTrue_GivenOddNumber()
    {
        Assert.Multiple(() =>
        {
            Assert.That((-3.0m).IsOdd());
            Assert.That((-1.0m).IsOdd());
            Assert.That(1.0m.IsOdd());
            Assert.That(3.0m.IsOdd());
        });
    }

    [Test]
    public void Round_ShouldRoundToNearestInteger()
    {
        Assert.Multiple(() =>
        {
            Assert.That(3.5m.Round(), Is.EqualTo(4.0m));
            Assert.That(6.8m.Round(), Is.EqualTo(7.0m));
            Assert.That(7.2m.Round(), Is.EqualTo(7.0m));
        });
    }

    [Test]
    public void Round_ShouldRoundToNearestMultiple()
    {
        Assert.Multiple(() =>
        {
            Assert.That(3.5m.Round(5), Is.EqualTo(5.0m));
            Assert.That(7.0m.Round(5), Is.EqualTo(5.0m));
            Assert.That(7.5m.Round(5), Is.EqualTo(10.0m));
        });
    }

    [Test]
    public void Saturate_ShouldClampValueTo1_GivenGreaterThan1()
    {
        Assert.That(1.5m.Saturate(), Is.EqualTo(1.0m));
    }

    [Test]
    public void Saturate_ShouldClampValueTo0_GivenLessThan0()
    {
        Assert.That((-0.5m).Saturate(), Is.EqualTo(0.0m));
    }

    [Test]
    public void Saturate_ShouldReturnValue_GivenValueBetween0And1()
    {
        Assert.That(0.5m.Saturate(), Is.EqualTo(0.5m));
    }

    [Test]
    public void Sign_ShouldBeMinus1_GivenNegative()
    {
        Assert.Multiple(() =>
        {
            Assert.That(-1.0m.Sign(), Is.EqualTo(-1));
            Assert.That(-2.0m.Sign(), Is.EqualTo(-1));
            Assert.That(-3.0m.Sign(), Is.EqualTo(-1));
        });
    }

    [Test]
    public void Sign_ShouldBe0_Given0()
    {
        Assert.That(0.0m.Sign(), Is.Zero);
    }

    [Test]
    public void Sign_ShouldBe1_GivenPositive()
    {
        Assert.Multiple(() =>
        {
            Assert.That(1.0m.Sign(), Is.EqualTo(1));
            Assert.That(2.0m.Sign(), Is.EqualTo(1));
            Assert.That(3.0m.Sign(), Is.EqualTo(1));
        });
    }

    [Test]
    public void Sqrt_ShouldBeCorrect_GivenValue()
    {
        Assert.Multiple(() =>
        {
            Assert.That(0.0m.Sqrt(), Is.EqualTo(0.0m));
            Assert.That(2.0m.Sqrt(), Is.EqualTo(1.4142135623730950488016887242m));
            Assert.That(9.0m.Sqrt(), Is.EqualTo(3.0m));
            Assert.That(16.0m.Sqrt(), Is.EqualTo(4.0m));
            Assert.That(10000.0m.Sqrt(), Is.EqualTo(100.0m));
        });
    }

    [Test]
    public void Sqrt_ShouldThrow_GivenNegativeValue()
    {
        Assert.Throws<ArgumentException>(() => _ = (-1.0m).Sqrt());
        Assert.Throws<ArgumentException>(() => _ = (-2.0m).Sqrt());
        Assert.Throws<ArgumentException>(() => _ = (-3.0m).Sqrt());
    }
}
