using System.Numerics;
using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

[TestFixture]
public partial class DoubleTests
{
    [Test]
    public void DegreesToRadians_ShouldBeCorrect()
    {
        Assert.Multiple(() =>
        {
            Assert.That(180.0.DegreesToRadians(), Is.EqualTo(System.Math.PI).Within(1e-6));
            Assert.That(270.0.DegreesToRadians(), Is.EqualTo(System.Math.PI * 1.5).Within(1e-6));
            Assert.That(0.0.DegreesToRadians(), Is.EqualTo(0.0).Within(1e-6));
            Assert.That(1.0.DegreesToRadians(), Is.EqualTo(0.017453292519943295).Within(1e-6));
            Assert.That(6.0.DegreesToRadians(), Is.EqualTo(0.10471975511965978).Within(1e-6));
            Assert.That(12.0.DegreesToRadians(), Is.EqualTo(0.20943951023931956).Within(1e-6));
        });
    }

    [Test]
    public void RadiansToDegrees_ShouldBeCorrect()
    {
        Assert.Multiple(() =>
        {
            Assert.That(System.Math.PI.RadiansToDegrees(), Is.EqualTo(180.0).Within(1e-6));
            Assert.That((2.0 * System.Math.PI).RadiansToDegrees(), Is.EqualTo(360.0).Within(1e-6));
            Assert.That(0.0.RadiansToDegrees(), Is.EqualTo(0.0).Within(1e-6));
            Assert.That(0.017453292519943295.RadiansToDegrees(), Is.EqualTo(1.0).Within(1e-6));
            // rounding errors are fun
            Assert.That(0.10471975511965978.RadiansToDegrees(), Is.EqualTo(6.000000000000001).Within(1e-6));
            Assert.That(0.20943951023931953.RadiansToDegrees(), Is.EqualTo(12.0).Within(1e-6));
        });
    }

    [Test]
    public void ComplexSqrt_ShouldBeCorrect_GivenReal()
    {
        Assert.Multiple(() =>
        {
            Assert.That(0.0.ComplexSqrt(), Is.EqualTo((Complex)0.0));
            Assert.That(2.0.ComplexSqrt(), Is.EqualTo((Complex)1.4142135623730951));
            Assert.That(9.0.ComplexSqrt(), Is.EqualTo((Complex)3.0));
            Assert.That(16.0.ComplexSqrt(), Is.EqualTo((Complex)4.0));
            Assert.That(10000.0.ComplexSqrt(), Is.EqualTo((Complex)100.0));
        });
    }

    [Test]
    public void ComplexSqrt_ShouldBeImaginary_GivenNegativeValue()
    {
        Assert.Multiple(() =>
        {
            Assert.That((-1.0).ComplexSqrt(), Is.EqualTo(new Complex(0, 1)));
            Assert.That((-2.0).ComplexSqrt(), Is.EqualTo(new Complex(0, 1.4142135623730951)));
            Assert.That((-9.0).ComplexSqrt(), Is.EqualTo(new Complex(0, 3.0)));
            Assert.That((-16.0).ComplexSqrt(), Is.EqualTo(new Complex(0, 4.0)));
        });
    }

    [Test]
    public void ComplexSqrt_ShouldBeComplexInfinity_GivenInfinity()
    {
        Assert.Multiple(() =>
        {
            Assert.That(double.NegativeInfinity.ComplexSqrt(), Is.EqualTo(Complex.Infinity));
            Assert.That(double.PositiveInfinity.ComplexSqrt(), Is.EqualTo(Complex.Infinity));
        });
    }

    [Test]
    public void ComplexSqrt_ShouldBeNaN_GivenNaN()
    {
        Assert.That(double.NaN.ComplexSqrt(), Is.EqualTo(Complex.NaN));
    }

    [Test]
    public void IsEven_ShouldBeFalse_GivenOddNumber()
    {
        Assert.Multiple(() =>
        {
            Assert.That((-3.0).IsEven(), Is.False);
            Assert.That((-1.0).IsEven(), Is.False);
            Assert.That(1.0.IsEven(), Is.False);
            Assert.That(3.0.IsEven(), Is.False);
        });
    }

    [Test]
    public void IsEven_ShouldBeTrue_GivenOddNumber()
    {
        Assert.Multiple(() =>
        {
            Assert.That((-4.0).IsEven());
            Assert.That((-2.0).IsEven());
            Assert.That(0.0.IsEven());
            Assert.That(2.0.IsEven());
            Assert.That(4.0.IsEven());
        });
    }

    [Test]
    public void IsOdd_ShouldBeFalse_GivenEvenNumber()
    {
        Assert.Multiple(() =>
        {
            Assert.That((-4.0).IsOdd(), Is.False);
            Assert.That((-2.0).IsOdd(), Is.False);
            Assert.That(0.0.IsOdd(), Is.False);
            Assert.That(2.0.IsOdd(), Is.False);
            Assert.That(4.0.IsOdd(), Is.False);
        });
    }

    [Test]
    public void IsOdd_ShouldBeTrue_GivenOddNumber()
    {
        Assert.Multiple(() =>
        {
            Assert.That((-3.0).IsOdd());
            Assert.That((-1.0).IsOdd());
            Assert.That(1.0.IsOdd());
            Assert.That(3.0.IsOdd());
        });
    }

    [Test]
    public void Round_ShouldRoundToNearestInteger()
    {
        Assert.That(3.5.Round(), Is.EqualTo(4.0).Within(1e-6));
        Assert.That(6.8.Round(), Is.EqualTo(7.0).Within(1e-6));
        Assert.That(7.2.Round(), Is.EqualTo(7.0).Within(1e-6));
    }

    [Test]
    public void Round_ShouldRoundToNearestMultiple()
    {
        Assert.That(3.5.Round(5), Is.EqualTo(5.0).Within(1e-6));
        Assert.That(7.0.Round(5), Is.EqualTo(5.0).Within(1e-6));
        Assert.That(7.5.Round(5), Is.EqualTo(10.0).Within(1e-6));
    }

    [Test]
    public void Saturate_ShouldClampValueTo1_GivenGreaterThan1()
    {
        Assert.That(1.5.Saturate(), Is.EqualTo(1.0).Within(1e-6));
    }

    [Test]
    public void Saturate_ShouldClampValueTo0_GivenLessThan0()
    {
        Assert.That((-0.5).Saturate(), Is.EqualTo(0.0).Within(1e-6));
    }

    [Test]
    public void Saturate_ShouldReturnValue_GivenValueBetween0And1()
    {
        Assert.That(0.5.Saturate(), Is.EqualTo(0.5).Within(1e-6));
    }

    [Test]
    public void Sign_ShouldBeMinus1_GivenNegative()
    {
        Assert.Multiple(() =>
        {
            Assert.That(-1.0.Sign(), Is.EqualTo(-1));
            Assert.That(-2.0.Sign(), Is.EqualTo(-1));
            Assert.That(-3.0.Sign(), Is.EqualTo(-1));
        });
    }

    [Test]
    public void Sign_ShouldBe0_Given0()
    {
        Assert.That(0.0.Sign(), Is.Zero);
    }

    [Test]
    public void Sign_ShouldBe1_GivenPositive()
    {
        Assert.Multiple(() =>
        {
            Assert.That(1.0.Sign(), Is.EqualTo(1));
            Assert.That(2.0.Sign(), Is.EqualTo(1));
            Assert.That(3.0.Sign(), Is.EqualTo(1));
        });
    }

    [Test]
    public void Sqrt_ShouldBeCorrect_GivenValue()
    {
        Assert.Multiple(() =>
        {
            Assert.That(0.0.Sqrt(), Is.EqualTo(0.0).Within(1e-6));
            Assert.That(2.0.Sqrt(), Is.EqualTo(1.414213562373095).Within(1e-6));
            Assert.That(9.0.Sqrt(), Is.EqualTo(3.0).Within(1e-6));
            Assert.That(16.0.Sqrt(), Is.EqualTo(4.0).Within(1e-6));
            Assert.That(10000.0.Sqrt(), Is.EqualTo(100.0).Within(1e-6));
        });
    }

    [Test]
    public void Sqrt_ShouldBeNaN_GivenNaN()
    {
        Assert.That(double.NaN.Sqrt(), Is.EqualTo(double.NaN));
    }

    [Test]
    public void Sqrt_ShouldBeNaN_GivenNegativeValue()
    {
        Assert.Multiple(() =>
        {
            Assert.That((-1.0).Sqrt(), Is.EqualTo(double.NaN));
            Assert.That((-2.0).Sqrt(), Is.EqualTo(double.NaN));
            Assert.That((-3.0).Sqrt(), Is.EqualTo(double.NaN));
            Assert.That(double.NegativeInfinity.Sqrt(), Is.EqualTo(double.NaN));
        });
    }

    [Test]
    public void Sqrt_ShouldBePositiveInfinity_GivenPositiveInfinity()
    {
        Assert.That(double.PositiveInfinity.Sqrt(), Is.EqualTo(double.PositiveInfinity));
    }

    [Test]
    public void Acos_ShouldBeCorrect()
    {
        Assert.That(0.5.Acos(), Is.EqualTo(1.0471975511965979).Within(1e-6));
    }

    [Test]
    public void Acosh_ShouldBeCorrect()
    {
        Assert.That(1.5.Acosh(), Is.EqualTo(0.9624236501192069).Within(1e-6));
    }

    [Test]
    public void Asin_ShouldBeCorrect()
    {
        Assert.That(0.5.Asin(), Is.EqualTo(0.5235987755982989).Within(1e-6));
    }

    [Test]
    public void Asinh_ShouldBeCorrect()
    {
        Assert.That(1.5.Asinh(), Is.EqualTo(1.1947632172871094).Within(1e-6));
    }

    [Test]
    public void Atan_ShouldBeCorrect()
    {
        Assert.That(0.5.Atan(), Is.EqualTo(0.4636476090008061).Within(1e-6));
    }

    [Test]
    public void Atanh_ShouldBeCorrect()
    {
        Assert.That(0.5.Atanh(), Is.EqualTo(0.5493061443340549).Within(1e-6));
    }

    [Test]
    public void Cos_ShouldBeCorrect()
    {
        Assert.That(0.5.Cos(), Is.EqualTo(0.8775825618903728).Within(1e-6));
    }

    [Test]
    public void Cosh_ShouldBeCorrect()
    {
        Assert.That(1.5.Cosh(), Is.EqualTo(2.352409615243247).Within(1e-6));
    }

    [Test]
    public void Sin_ShouldBeCorrect()
    {
        Assert.That(0.5.Sin(), Is.EqualTo(0.479425538604203).Within(1e-6));
    }

    [Test]
    public void Sinh_ShouldBeCorrect()
    {
        Assert.That(1.5.Sinh(), Is.EqualTo(2.1292794550948173).Within(1e-6));
    }

    [Test]
    public void Tan_ShouldBeCorrect()
    {
        Assert.That(0.5.Tan(), Is.EqualTo(0.5463024898437905).Within(1e-6));
    }

    [Test]
    public void Tanh_ShouldBeCorrect()
    {
        Assert.That(0.5.Tanh(), Is.EqualTo(0.46211715726000974).Within(1e-6));
    }
}
