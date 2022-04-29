using System.Diagnostics;
using System.Numerics;
using X10D.Math;
using X10D.Numerics;

namespace X10D.Tests.Core;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
///     Tests for <see cref="DoubleExtensions" />.
/// </summary>
[TestClass]
public class DoubleTests
{
    [TestMethod]
    public void ComplexSqrt()
    {
        Assert.AreEqual(0.0, 0.0.ComplexSqrt());
        Assert.AreEqual(1.414213562373095, 2.0.ComplexSqrt());
        Assert.AreEqual(3.0, 9.0.ComplexSqrt());
        Assert.AreEqual(4.0, 16.0.ComplexSqrt());
        Assert.AreEqual(new Complex(1.414213562373095, 1), (-2.0).ComplexSqrt());
        Assert.AreEqual(new Complex(3.0, 1), (-9.0).ComplexSqrt());
        Assert.AreEqual(new Complex(4.0, 1), (-16.0).ComplexSqrt());
        Assert.AreEqual(Complex.NaN, double.NaN.ComplexSqrt());
        Assert.AreEqual(new Complex(1, 1), (-1.0).ComplexSqrt());
        Assert.AreEqual(Complex.Infinity, double.NegativeInfinity.ComplexSqrt());
        Assert.AreEqual(Complex.Infinity, double.PositiveInfinity.ComplexSqrt());
    }

    /// <summary>
    ///     Tests for <see cref="DoubleExtensions.DegreesToRadians" />.
    /// </summary>
    [TestMethod]
    public void DegreesToRadians()
    {
        Assert.AreEqual(Math.PI, 180.0.DegreesToRadians());
        Assert.AreEqual(Math.PI * 1.5, 270.0.DegreesToRadians());
        Assert.AreEqual(0.0, 0.0.DegreesToRadians());
        Assert.AreEqual(0.017453292519943295, 1.0.DegreesToRadians());
        Assert.AreEqual(0.10471975511965978, 6.0.DegreesToRadians());
        Assert.AreEqual(0.20943951023931956, 12.0.DegreesToRadians());
    }

    /// <summary>
    ///     Tests for <see cref="DoubleExtensions.IsEven" />.
    /// </summary>
    [TestMethod]
    public void IsEven()
    {
        Assert.IsTrue(2.0.IsEven());
        Assert.IsFalse(1.0.IsEven());
    }

    /// <summary>
    ///     Tests for <see cref="DoubleExtensions.IsOdd" />.
    /// </summary>
    [TestMethod]
    public void IsOdd()
    {
        Assert.IsFalse(2.0.IsOdd());
        Assert.IsTrue(1.0.IsOdd());
    }

    /// <summary>
    ///     Tests for <see cref="DoubleExtensions.RadiansToDegrees" />.
    /// </summary>
    [TestMethod]
    public void RadiansToDegrees()
    {
        Assert.AreEqual(180.0, Math.PI.RadiansToDegrees());
        Assert.AreEqual(360.0, (2.0 * Math.PI).RadiansToDegrees());
        Assert.AreEqual(0.0, 0.0.RadiansToDegrees());
        Assert.AreEqual(1.0, 0.017453292519943295.RadiansToDegrees());
        Assert.AreEqual(6.000000000000001, 0.10471975511965978.RadiansToDegrees()); // rounding errors are fun
        Assert.AreEqual(12.0, 0.20943951023931953.RadiansToDegrees());
    }

    /// <summary>
    ///     Tests for <see cref="DoubleExtensions.Round(double)" /> and <see cref="DoubleExtensions.Round(double, double)" />.
    /// </summary>
    [TestMethod]
    public void Round()
    {
        Assert.AreEqual(4.0, 3.5.Round());
        Assert.AreEqual(7.0, 6.8.Round());
        Assert.AreEqual(7.0, 7.2.Round());

        Assert.AreEqual(5.0, 3.5.Round(5));
        Assert.AreEqual(5.0, 7.0.Round(5));
        Assert.AreEqual(10.0, 7.5.Round(5));
    }

    [TestMethod]
    public void Sqrt()
    {
        Assert.AreEqual(0.0, 0.0.Sqrt());
        Assert.AreEqual(1.414213562373095, 2.0.Sqrt());
        Assert.AreEqual(3.0, 9.0.Sqrt());
        Assert.AreEqual(4.0, 16.0.Sqrt());
        Assert.AreEqual(double.NaN, double.NaN.Sqrt());
        Assert.AreEqual(double.NaN, (-1.0).Sqrt());
        Assert.AreEqual(double.NaN, double.NegativeInfinity.Sqrt());
        Assert.AreEqual(double.PositiveInfinity, double.PositiveInfinity.Sqrt());
    }
}
