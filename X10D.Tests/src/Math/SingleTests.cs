using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
public class SingleTests
{
    [TestMethod]
    public void DegreesToRadians_ShouldBeCorrect()
    {
        Assert.AreEqual(MathF.PI, 180.0f.DegreesToRadians());
        Assert.AreEqual(MathF.PI * 1.5f, 270.0f.DegreesToRadians());
        Assert.AreEqual(0.0f, 0.0f.DegreesToRadians());
        Assert.AreEqual(0.017453292f, 1.0f.DegreesToRadians());
        Assert.AreEqual(0.10471976f, 6.0f.DegreesToRadians());
        Assert.AreEqual(0.20943952f, 12.0f.DegreesToRadians());
    }

    [TestMethod]
    public void RadiansToDegrees_ShouldBeCorrect()
    {
        Assert.AreEqual(180.0f, MathF.PI.RadiansToDegrees());
        Assert.AreEqual(270.0f, (MathF.PI * 1.5f).RadiansToDegrees());
        Assert.AreEqual(0.0, 0.0f.RadiansToDegrees());
        Assert.AreEqual(0.99999994f, 0.017453292f.RadiansToDegrees()); // rounding errors are fun
        Assert.AreEqual(6.0f, 0.10471976f.RadiansToDegrees());
        Assert.AreEqual(12.0f, 0.20943952f.RadiansToDegrees());
    }

    [TestMethod]
    public void ComplexSqrt_ShouldBeCorrect_GivenReal()
    {
        Assert.AreEqual(0.0f, 0.0f.ComplexSqrt());
        Assert.AreEqual(1.4142135f, 2.0f.ComplexSqrt());
        Assert.AreEqual(3.0f, 9.0f.ComplexSqrt());
        Assert.AreEqual(4.0f, 16.0f.ComplexSqrt());
        Assert.AreEqual(100.0f, 10000.0f.ComplexSqrt());
    }

    [TestMethod]
    public void ComplexSqrt_ShouldBeImaginary_GivenNegativeValue()
    {
        Assert.AreEqual(new Complex(0, 1), (-1.0f).ComplexSqrt());
        Assert.AreEqual(new Complex(0, 1.4142135f), (-2.0f).ComplexSqrt());
        Assert.AreEqual(new Complex(0, 3.0f), (-9.0f).ComplexSqrt());
        Assert.AreEqual(new Complex(0, 4.0f), (-16.0f).ComplexSqrt());
    }

    [TestMethod]
    public void ComplexSqrt_ShouldBeComplexInfinity_GivenInfinity()
    {
        Assert.AreEqual(Complex.Infinity, float.NegativeInfinity.ComplexSqrt());
        Assert.AreEqual(Complex.Infinity, float.PositiveInfinity.ComplexSqrt());
    }

    [TestMethod]
    public void ComplexSqrt_ShouldBeNaN_GivenNaN()
    {
        Assert.AreEqual(Complex.NaN, float.NaN.ComplexSqrt());
    }

    [TestMethod]
    public void IsEven_ShouldBeFalse_GivenOddNumber()
    {
        Assert.IsFalse((-3.0f).IsEven());
        Assert.IsFalse((-1.0f).IsEven());
        Assert.IsFalse(1.0f.IsEven());
        Assert.IsFalse(3.0f.IsEven());
    }

    [TestMethod]
    public void IsEven_ShouldBeTrue_GivenOddNumber()
    {
        Assert.IsTrue((-4.0f).IsEven());
        Assert.IsTrue((-2.0f).IsEven());
        Assert.IsTrue(0.0f.IsEven());
        Assert.IsTrue(2.0f.IsEven());
        Assert.IsTrue(4.0f.IsEven());
    }

    [TestMethod]
    public void IsOdd_ShouldBeFalse_GivenEvenNumber()
    {
        Assert.IsFalse((-4.0f).IsOdd());
        Assert.IsFalse((-2.0f).IsOdd());
        Assert.IsFalse(0.0f.IsOdd());
        Assert.IsFalse(2.0f.IsOdd());
        Assert.IsFalse(4.0f.IsOdd());
    }

    [TestMethod]
    public void IsOdd_ShouldBeTrue_GivenOddNumber()
    {
        Assert.IsTrue((-3.0f).IsOdd());
        Assert.IsTrue((-1.0f).IsOdd());
        Assert.IsTrue(1.0f.IsOdd());
        Assert.IsTrue(3.0f.IsOdd());
    }

    [TestMethod]
    public void Round_ShouldRoundToNearestInteger()
    {
        Assert.AreEqual(4.0f, 3.5f.Round());
        Assert.AreEqual(7.0f, 6.8f.Round());
        Assert.AreEqual(7.0f, 7.2f.Round());
    }

    [TestMethod]
    public void Round_ShouldRoundToNearestMultiple()
    {
        Assert.AreEqual(5.0f, 3.5f.Round(5));
        Assert.AreEqual(5.0f, 7.0f.Round(5));
        Assert.AreEqual(10.0f, 7.5f.Round(5));
    }

    [TestMethod]
    public void Sign_ShouldBeMinus1_GivenNegative()
    {
        Assert.AreEqual(-1, -1.0f.Sign());
        Assert.AreEqual(-1, -2.0f.Sign());
        Assert.AreEqual(-1, -3.0f.Sign());
    }

    [TestMethod]
    public void Sign_ShouldBe0_Given0()
    {
        Assert.AreEqual(0, 0.0f.Sign());
    }

    [TestMethod]
    public void Sign_ShouldBe1_GivenPositive()
    {
        Assert.AreEqual(1, 1.0f.Sign());
        Assert.AreEqual(1, 2.0f.Sign());
        Assert.AreEqual(1, 3.0f.Sign());
    }

    [TestMethod]
    public void Sqrt_ShouldBeCorrect_GivenValue()
    {
        Assert.AreEqual(0.0f, 0.0f.Sqrt());
        Assert.AreEqual(1.4142135f, 2.0f.Sqrt());
        Assert.AreEqual(3.0f, 9.0f.Sqrt());
        Assert.AreEqual(4.0f, 16.0f.Sqrt());
        Assert.AreEqual(100.0f, 10000.0f.Sqrt());
    }

    [TestMethod]
    public void Sqrt_ShouldBeNaN_GivenNaN()
    {
        Assert.AreEqual(float.NaN, float.NaN.Sqrt());
    }

    [TestMethod]
    public void Sqrt_ShouldBeNaN_GivenNegativeValue()
    {
        Assert.AreEqual(float.NaN, (-1.0f).Sqrt());
        Assert.AreEqual(float.NaN, (-2.0f).Sqrt());
        Assert.AreEqual(float.NaN, (-3.0f).Sqrt());
        Assert.AreEqual(float.NaN, float.NegativeInfinity.Sqrt());
    }

    [TestMethod]
    public void Sqrt_ShouldBePositiveInfinity_GivenPositiveInfinity()
    {
        Assert.AreEqual(float.PositiveInfinity, float.PositiveInfinity.Sqrt());
    }

    [TestMethod]
    public void Acos_ShouldBeCorrect()
    {
        Assert.AreEqual(1.0471975803375244f, 0.5f.Acos());
    }

    [TestMethod]
    public void Acosh_ShouldBeCorrect()
    {
        Assert.AreEqual(0.9624236822128296f, 1.5f.Acosh());
    }

    [TestMethod]
    public void Asin_ShouldBeCorrect()
    {
        Assert.AreEqual(0.5235987901687622f, 0.5f.Asin());
    }

    [TestMethod]
    public void Asinh_ShouldBeCorrect()
    {
        Assert.AreEqual(1.19476318359375f, 1.5f.Asinh());
    }

    [TestMethod]
    public void Atan_ShouldBeCorrect()
    {
        Assert.AreEqual(0.46364760398864746, 0.5f.Atan());
    }

    [TestMethod]
    public void Atanh_ShouldBeCorrect()
    {
        Assert.AreEqual(0.5493061542510986f, 0.5f.Atanh());
    }

    [TestMethod]
    public void Cos_ShouldBeCorrect()
    {
        Assert.AreEqual(0.8775825500488281f, 0.5f.Cos());
    }

    [TestMethod]
    public void Cosh_ShouldBeCorrect()
    {
        Assert.AreEqual(2.352409601211548f, 1.5f.Cosh());
    }

    [TestMethod]
    public void Sin_ShouldBeCorrect()
    {
        Assert.AreEqual(0.4794255495071411, 0.5f.Sin());
    }

    [TestMethod]
    public void Sinh_ShouldBeCorrect()
    {
        Assert.AreEqual(2.129279375076294f, 1.5f.Sinh());
    }

    [TestMethod]
    public void Tan_ShouldBeCorrect()
    {
        Assert.AreEqual(0.4794255495071411f, 0.5f.Tan());
    }

    [TestMethod]
    public void Tanh_ShouldBeCorrect()
    {
        Assert.AreEqual(0.46211716532707214f, 0.5f.Tanh());
    }
}
