﻿using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
public class DoubleTests
{
    [TestMethod]
    public void DegreesToRadians_ShouldBeCorrect()
    {
        Assert.AreEqual(System.Math.PI, 180.0.DegreesToRadians());
        Assert.AreEqual(System.Math.PI * 1.5, 270.0.DegreesToRadians());
        Assert.AreEqual(0.0, 0.0.DegreesToRadians());
        Assert.AreEqual(0.017453292519943295, 1.0.DegreesToRadians());
        Assert.AreEqual(0.10471975511965978, 6.0.DegreesToRadians());
        Assert.AreEqual(0.20943951023931956, 12.0.DegreesToRadians());
    }

    [TestMethod]
    public void RadiansToDegrees_ShouldBeCorrect()
    {
        Assert.AreEqual(180.0, System.Math.PI.RadiansToDegrees());
        Assert.AreEqual(360.0, (2.0 * System.Math.PI).RadiansToDegrees());
        Assert.AreEqual(0.0, 0.0.RadiansToDegrees());
        Assert.AreEqual(1.0, 0.017453292519943295.RadiansToDegrees());
        Assert.AreEqual(6.000000000000001, 0.10471975511965978.RadiansToDegrees()); // rounding errors are fun
        Assert.AreEqual(12.0, 0.20943951023931953.RadiansToDegrees());
    }

    [TestMethod]
    public void ComplexSqrt_ShouldBeCorrect_GivenReal()
    {
        Assert.AreEqual(0.0, 0.0.ComplexSqrt());
        Assert.AreEqual(1.4142135623730951, 2.0.ComplexSqrt());
        Assert.AreEqual(3.0, 9.0.ComplexSqrt());
        Assert.AreEqual(4.0, 16.0.ComplexSqrt());
        Assert.AreEqual(100.0, 10000.0.ComplexSqrt());
    }

    [TestMethod]
    public void ComplexSqrt_ShouldBeImaginary_GivenNegativeValue()
    {
        Assert.AreEqual(new Complex(0, 1), (-1.0).ComplexSqrt());
        Assert.AreEqual(new Complex(0, 1.4142135623730951), (-2.0).ComplexSqrt());
        Assert.AreEqual(new Complex(0, 3.0), (-9.0).ComplexSqrt());
        Assert.AreEqual(new Complex(0, 4.0), (-16.0).ComplexSqrt());
    }

    [TestMethod]
    public void ComplexSqrt_ShouldBeComplexInfinity_GivenInfinity()
    {
        Assert.AreEqual(Complex.Infinity, double.NegativeInfinity.ComplexSqrt());
        Assert.AreEqual(Complex.Infinity, double.PositiveInfinity.ComplexSqrt());
    }

    [TestMethod]
    public void ComplexSqrt_ShouldBeNaN_GivenNaN()
    {
        Assert.AreEqual(Complex.NaN, double.NaN.ComplexSqrt());
    }

    [TestMethod]
    public void IsEven_ShouldBeFalse_GivenOddNumber()
    {
        Assert.IsFalse((-3.0).IsEven());
        Assert.IsFalse((-1.0).IsEven());
        Assert.IsFalse(1.0.IsEven());
        Assert.IsFalse(3.0.IsEven());
    }

    [TestMethod]
    public void IsEven_ShouldBeTrue_GivenOddNumber()
    {
        Assert.IsTrue((-4.0).IsEven());
        Assert.IsTrue((-2.0).IsEven());
        Assert.IsTrue(0.0.IsEven());
        Assert.IsTrue(2.0.IsEven());
        Assert.IsTrue(4.0.IsEven());
    }

    [TestMethod]
    public void IsOdd_ShouldBeFalse_GivenEvenNumber()
    {
        Assert.IsFalse((-4.0).IsOdd());
        Assert.IsFalse((-2.0).IsOdd());
        Assert.IsFalse(0.0.IsOdd());
        Assert.IsFalse(2.0.IsOdd());
        Assert.IsFalse(4.0.IsOdd());
    }

    [TestMethod]
    public void IsOdd_ShouldBeTrue_GivenOddNumber()
    {
        Assert.IsTrue((-3.0).IsOdd());
        Assert.IsTrue((-1.0).IsOdd());
        Assert.IsTrue(1.0.IsOdd());
        Assert.IsTrue(3.0.IsOdd());
    }

    [TestMethod]
    public void Round_ShouldRoundToNearestInteger()
    {
        Assert.AreEqual(4.0, 3.5.Round());
        Assert.AreEqual(7.0, 6.8.Round());
        Assert.AreEqual(7.0, 7.2.Round());
    }

    [TestMethod]
    public void Round_ShouldRoundToNearestMultiple()
    {
        Assert.AreEqual(5.0, 3.5.Round(5));
        Assert.AreEqual(5.0, 7.0.Round(5));
        Assert.AreEqual(10.0, 7.5.Round(5));
    }

    [TestMethod]
    public void Sign_ShouldBeMinus1_GivenNegative()
    {
        Assert.AreEqual(-1, -1.0.Sign());
        Assert.AreEqual(-1, -2.0.Sign());
        Assert.AreEqual(-1, -3.0.Sign());
    }

    [TestMethod]
    public void Sign_ShouldBe0_Given0()
    {
        Assert.AreEqual(0, 0.0.Sign());
    }

    [TestMethod]
    public void Sign_ShouldBe1_GivenPositive()
    {
        Assert.AreEqual(1, 1.0.Sign());
        Assert.AreEqual(1, 2.0.Sign());
        Assert.AreEqual(1, 3.0.Sign());
    }

    [TestMethod]
    public void Sqrt_ShouldBeCorrect_GivenValue()
    {
        Assert.AreEqual(0.0, 0.0.Sqrt());
        Assert.AreEqual(1.414213562373095, 2.0.Sqrt());
        Assert.AreEqual(3.0, 9.0.Sqrt());
        Assert.AreEqual(4.0, 16.0.Sqrt());
        Assert.AreEqual(100.0, 10000.0.Sqrt());
    }

    [TestMethod]
    public void Sqrt_ShouldBeNaN_GivenNaN()
    {
        Assert.AreEqual(double.NaN, double.NaN.Sqrt());
    }

    [TestMethod]
    public void Sqrt_ShouldBeNaN_GivenNegativeValue()
    {
        Assert.AreEqual(double.NaN, (-1.0).Sqrt());
        Assert.AreEqual(double.NaN, (-2.0).Sqrt());
        Assert.AreEqual(double.NaN, (-3.0).Sqrt());
        Assert.AreEqual(double.NaN, double.NegativeInfinity.Sqrt());
    }

    [TestMethod]
    public void Sqrt_ShouldBePositiveInfinity_GivenPositiveInfinity()
    {
        Assert.AreEqual(double.PositiveInfinity, double.PositiveInfinity.Sqrt());
    }

    [TestMethod]
    public void Acos_ShouldBeCorrect()
    {
        Assert.AreEqual(1.0471975511965979, 0.5.Acos());
    }

    [TestMethod]
    public void Acosh_ShouldBeCorrect()
    {
        Assert.AreEqual(0.9624236501192069, 1.5.Acosh());
    }

    [TestMethod]
    public void Asin_ShouldBeCorrect()
    {
        Assert.AreEqual(0.5235987755982989, 0.5.Asin());
    }

    [TestMethod]
    public void Asinh_ShouldBeCorrect()
    {
        Assert.AreEqual(1.1947632172871094, 1.5.Asinh());
    }

    [TestMethod]
    public void Atan_ShouldBeCorrect()
    {
        Assert.AreEqual(0.4636476090008061, 0.5.Atan());
    }

    [TestMethod]
    public void Atanh_ShouldBeCorrect()
    {
        try
        {
            Assert.AreEqual(0.5493061443340548, 0.5.Atanh());
        }
        catch
        {
            // floating point rounding errors cause this value to be different on CI vs my local machine.
            // I have no idea why, but here we are. if THIS assertion fails, we'll just throw it back
            Assert.AreEqual(0.5493061443340549, 0.5.Atanh());
        }
    }

    [TestMethod]
    public void Cos_ShouldBeCorrect()
    {
        Assert.AreEqual(0.8775825618903728, 0.5.Cos());
    }

    [TestMethod]
    public void Cosh_ShouldBeCorrect()
    {
        Assert.AreEqual(2.352409615243247, 1.5.Cosh());
    }

    [TestMethod]
    public void Sin_ShouldBeCorrect()
    {
        Assert.AreEqual(0.479425538604203, 0.5.Sin());
    }

    [TestMethod]
    public void Sinh_ShouldBeCorrect()
    {
        Assert.AreEqual(2.1292794550948173, 1.5.Sinh());
    }

    [TestMethod]
    public void Tan_ShouldBeCorrect()
    {
        Assert.AreEqual(0.5463024898437905, 0.5.Tan());
    }

    [TestMethod]
    public void Tanh_ShouldBeCorrect()
    {
        Assert.AreEqual(0.46211715726000974, 0.5.Tanh());
    }
}
