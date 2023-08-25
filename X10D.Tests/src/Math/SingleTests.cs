using System.Numerics;
using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

[TestFixture]
internal partial class SingleTests
{
    [Test]
    public void DegreesToRadians_ShouldBeCorrect()
    {
        Assert.That(180.0f.DegreesToRadians(), Is.EqualTo(MathF.PI).Within(1e-6f));
        Assert.That(270.0f.DegreesToRadians(), Is.EqualTo(MathF.PI * 1.5f).Within(1e-6f));
        Assert.That(0.0f.DegreesToRadians(), Is.EqualTo(0.0f).Within(1e-6f));
        Assert.That(1.0f.DegreesToRadians(), Is.EqualTo(0.017453292f).Within(1e-6f));
        Assert.That(6.0f.DegreesToRadians(), Is.EqualTo(0.10471976f).Within(1e-6f));
        Assert.That(12.0f.DegreesToRadians(), Is.EqualTo(0.20943952f).Within(1e-6f));
    }

    [Test]
    public void RadiansToDegrees_ShouldBeCorrect()
    {
        Assert.That(MathF.PI.RadiansToDegrees(), Is.EqualTo(180.0f).Within(1e-6f));
        Assert.That((MathF.PI * 1.5f).RadiansToDegrees(), Is.EqualTo(270.0f).Within(1e-6f));
        Assert.That(0.0f.RadiansToDegrees(), Is.EqualTo(0.0).Within(1e-6f));
        Assert.That(0.017453292f.RadiansToDegrees(), Is.EqualTo(0.99999994f).Within(1e-6f)); // rounding errors are fun
        Assert.That(0.10471976f.RadiansToDegrees(), Is.EqualTo(6.0f).Within(1e-6f));
        Assert.That(0.20943952f.RadiansToDegrees(), Is.EqualTo(12.0f).Within(1e-6f));
    }

    [Test]
    public void ComplexSqrt_ShouldBeCorrect_GivenReal()
    {
        Assert.That(0.0f.ComplexSqrt(), Is.EqualTo((Complex)0.0f));
        Assert.That(2.0f.ComplexSqrt(), Is.EqualTo((Complex)1.4142135f));
        Assert.That(9.0f.ComplexSqrt(), Is.EqualTo((Complex)3.0f));
        Assert.That(16.0f.ComplexSqrt(), Is.EqualTo((Complex)4.0f));
        Assert.That(10000.0f.ComplexSqrt(), Is.EqualTo((Complex)100.0f));
    }

    [Test]
    public void ComplexSqrt_ShouldBeImaginary_GivenNegativeValue()
    {
        Assert.That((-1.0f).ComplexSqrt(), Is.EqualTo(new Complex(0, 1)));
        Assert.That((-2.0f).ComplexSqrt(), Is.EqualTo(new Complex(0, 1.4142135f)));
        Assert.That((-9.0f).ComplexSqrt(), Is.EqualTo(new Complex(0, 3.0f)));
        Assert.That((-16.0f).ComplexSqrt(), Is.EqualTo(new Complex(0, 4.0f)));
    }

    [Test]
    public void ComplexSqrt_ShouldBeComplexInfinity_GivenInfinity()
    {
        Assert.Multiple(() =>
        {
            Assert.That(float.NegativeInfinity.ComplexSqrt(), Is.EqualTo(Complex.Infinity));
            Assert.That(float.PositiveInfinity.ComplexSqrt(), Is.EqualTo(Complex.Infinity));
        });
    }

    [Test]
    public void ComplexSqrt_ShouldBeNaN_GivenNaN()
    {
        Assert.That(float.NaN.ComplexSqrt(), Is.EqualTo(Complex.NaN));
    }

    [Test]
    public void IsEven_ShouldBeFalse_GivenOddNumber()
    {
        Assert.Multiple(() =>
        {
            Assert.That((-3.0f).IsEven(), Is.False);
            Assert.That((-1.0f).IsEven(), Is.False);
            Assert.That(1.0f.IsEven(), Is.False);
            Assert.That(3.0f.IsEven(), Is.False);
        });
    }

    [Test]
    public void IsEven_ShouldBeTrue_GivenOddNumber()
    {
        Assert.Multiple(() =>
        {
            Assert.That((-4.0f).IsEven());
            Assert.That((-2.0f).IsEven());
            Assert.That(0.0f.IsEven());
            Assert.That(2.0f.IsEven());
            Assert.That(4.0f.IsEven());
        });
    }

    [Test]
    public void IsOdd_ShouldBeFalse_GivenEvenNumber()
    {
        Assert.Multiple(() =>
        {
            Assert.That((-4.0f).IsOdd(), Is.False);
            Assert.That((-2.0f).IsOdd(), Is.False);
            Assert.That(0.0f.IsOdd(), Is.False);
            Assert.That(2.0f.IsOdd(), Is.False);
            Assert.That(4.0f.IsOdd(), Is.False);
        });
    }

    [Test]
    public void IsOdd_ShouldBeTrue_GivenOddNumber()
    {
        Assert.Multiple(() =>
        {
            Assert.That((-3.0f).IsOdd());
            Assert.That((-1.0f).IsOdd());
            Assert.That(1.0f.IsOdd());
            Assert.That(3.0f.IsOdd());
        });
    }

    [Test]
    public void Round_ShouldRoundToNearestInteger()
    {
        Assert.Multiple(() =>
        {
            Assert.That(3.5f.Round(), Is.EqualTo(4.0f).Within(1e-6f));
            Assert.That(6.8f.Round(), Is.EqualTo(7.0f).Within(1e-6f));
            Assert.That(7.2f.Round(), Is.EqualTo(7.0f).Within(1e-6f));
        });
    }

    [Test]
    public void Round_ShouldRoundToNearestMultiple()
    {
        Assert.Multiple(() =>
        {
            Assert.That(3.5f.Round(5), Is.EqualTo(5.0f).Within(1e-6f));
            Assert.That(7.0f.Round(5), Is.EqualTo(5.0f).Within(1e-6f));
            Assert.That(7.5f.Round(5), Is.EqualTo(10.0f).Within(1e-6f));
        });
    }

    [Test]
    public void Saturate_ShouldClampValueTo1_GivenGreaterThan1()
    {
        Assert.That(1.5f.Saturate(), Is.EqualTo(1.0f).Within(1e-6f));
    }

    [Test]
    public void Saturate_ShouldClampValueTo0_GivenLessThan0()
    {
        Assert.That((-0.5f).Saturate(), Is.EqualTo(0.0f).Within(1e-6f));
    }

    [Test]
    public void Saturate_ShouldReturnValue_GivenValueBetween0And1()
    {
        Assert.That(0.5f.Saturate(), Is.EqualTo(0.5f).Within(1e-6f));
    }

    [Test]
    public void Sign_ShouldBeMinus1_GivenNegative()
    {
        Assert.That(-1.0f.Sign(), Is.EqualTo(-1));
        Assert.That(-2.0f.Sign(), Is.EqualTo(-1));
        Assert.That(-3.0f.Sign(), Is.EqualTo(-1));
    }

    [Test]
    public void Sign_ShouldBe0_Given0()
    {
        Assert.That(0.0f.Sign(), Is.Zero);
    }

    [Test]
    public void Sign_ShouldBe1_GivenPositive()
    {
        Assert.Multiple(() =>
        {
            Assert.That(1.0f.Sign(), Is.EqualTo(1));
            Assert.That(2.0f.Sign(), Is.EqualTo(1));
            Assert.That(3.0f.Sign(), Is.EqualTo(1));
        });
    }

    [Test]
    public void Sqrt_ShouldBeCorrect_GivenValue()
    {
        Assert.Multiple(() =>
        {
            Assert.That(0.0f.Sqrt(), Is.EqualTo(0.0f).Within(1e-6f));
            Assert.That(2.0f.Sqrt(), Is.EqualTo(1.4142135f).Within(1e-6f));
            Assert.That(9.0f.Sqrt(), Is.EqualTo(3.0f).Within(1e-6f));
            Assert.That(16.0f.Sqrt(), Is.EqualTo(4.0f).Within(1e-6f));
            Assert.That(10000.0f.Sqrt(), Is.EqualTo(100.0f).Within(1e-6f));
        });
    }

    [Test]
    public void Sqrt_ShouldBeNaN_GivenNaN()
    {
        Assert.That(float.NaN.Sqrt(), Is.EqualTo(float.NaN));
    }

    [Test]
    public void Sqrt_ShouldBeNaN_GivenNegativeValue()
    {
        Assert.Multiple(() =>
        {
            Assert.That((-1.0f).Sqrt(), Is.EqualTo(float.NaN));
            Assert.That((-2.0f).Sqrt(), Is.EqualTo(float.NaN));
            Assert.That((-3.0f).Sqrt(), Is.EqualTo(float.NaN));
            Assert.That(float.NegativeInfinity.Sqrt(), Is.EqualTo(float.NaN));
        });
    }

    [Test]
    public void Sqrt_ShouldBePositiveInfinity_GivenPositiveInfinity()
    {
        Assert.That(float.PositiveInfinity.Sqrt(), Is.EqualTo(float.PositiveInfinity));
    }

    [Test]
    public void Acos_ShouldBeCorrect()
    {
        Assert.That(0.5f.Acos(), Is.EqualTo(1.0471975803375244f).Within(1e-6f));
    }

    [Test]
    public void Acosh_ShouldBeCorrect()
    {
        Assert.That(1.5f.Acosh(), Is.EqualTo(0.9624236822128296f).Within(1e-6f));
    }

    [Test]
    public void Asin_ShouldBeCorrect()
    {
        Assert.That(0.5f.Asin(), Is.EqualTo(0.5235987901687622f).Within(1e-6f));
    }

    [Test]
    public void Asinh_ShouldBeCorrect()
    {
        Assert.That(1.5f.Asinh(), Is.EqualTo(1.19476318359375f).Within(1e-6f));
    }

    [Test]
    public void Atan_ShouldBeCorrect()
    {
        Assert.That(0.5f.Atan(), Is.EqualTo(0.46364760398864746).Within(1e-6f));
    }

    [Test]
    public void Atanh_ShouldBeCorrect()
    {
        Assert.That(0.5f.Atanh(), Is.EqualTo(0.5493061542510986f).Within(1e-6f));
    }

    [Test]
    public void Cos_ShouldBeCorrect()
    {
        Assert.That(0.5f.Cos(), Is.EqualTo(0.8775825500488281f).Within(1e-6f));
    }

    [Test]
    public void Cosh_ShouldBeCorrect()
    {
        Assert.That(1.5f.Cosh(), Is.EqualTo(2.352409601211548f).Within(1e-6f));
    }

    [Test]
    public void Sin_ShouldBeCorrect()
    {
        Assert.That(0.5f.Sin(), Is.EqualTo(0.4794255495071411).Within(1e-6f));
    }

    [Test]
    public void Sinh_ShouldBeCorrect()
    {
        Assert.That(1.5f.Sinh(), Is.EqualTo(2.129279375076294f).Within(1e-6f));
    }

    [Test]
    public void Tan_ShouldBeCorrect()
    {
        Assert.That(0.5f.Tan(), Is.EqualTo(0.4794255495071411f).Within(1e-6f));
    }

    [Test]
    public void Tanh_ShouldBeCorrect()
    {
        Assert.That(0.5f.Tanh(), Is.EqualTo(0.46211716532707214f).Within(1e-6f));
    }
}
