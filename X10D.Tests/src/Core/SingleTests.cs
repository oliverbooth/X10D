using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X10D.Tests.Core;

[TestClass]
public class SingleTests
{
    [TestMethod]
    public void ComplexSqrt()
    {
        Assert.AreEqual(0.0f, 0.0f.ComplexSqrt());
        Assert.AreEqual(1.4142135f, 2.0f.ComplexSqrt());
        Assert.AreEqual(3.0f, 9.0f.ComplexSqrt());
        Assert.AreEqual(4.0f, 16.0f.ComplexSqrt());
        Assert.AreEqual(new Complex(1.4142135f, 1), (-2.0f).ComplexSqrt());
        Assert.AreEqual(new Complex(3.0f, 1), (-9.0f).ComplexSqrt());
        Assert.AreEqual(new Complex(4.0f, 1), (-16.0f).ComplexSqrt());
        Assert.AreEqual(Complex.NaN, float.NaN.ComplexSqrt());
        Assert.AreEqual(new Complex(1, 1), (-1.0f).ComplexSqrt());
        Assert.AreEqual(Complex.Infinity, float.NegativeInfinity.ComplexSqrt());
        Assert.AreEqual(Complex.Infinity, float.PositiveInfinity.ComplexSqrt());
    }

    [TestMethod]
    public void DegreesToRadians()
    {
        Assert.AreEqual(MathF.PI, 180.0f.DegreesToRadians());
        Assert.AreEqual(MathF.PI * 1.5f, 270.0f.DegreesToRadians());
        Assert.AreEqual(0.0f, 0.0f.DegreesToRadians());
        Assert.AreEqual(0.017453292f, 1.0f.DegreesToRadians());
        Assert.AreEqual(0.10471976f, 6.0f.DegreesToRadians());
        Assert.AreEqual(0.20943952f, 12.0f.DegreesToRadians());
    }

    [TestMethod]
    public void RadiansToDegrees()
    {
        Assert.AreEqual(180.0f, MathF.PI.RadiansToDegrees());
        Assert.AreEqual(270.0f, (MathF.PI * 1.5f).RadiansToDegrees());
        Assert.AreEqual(0.0, 0.0f.RadiansToDegrees());
        Assert.AreEqual(0.99999994f, 0.017453292f.RadiansToDegrees()); // rounding errors are fun
        Assert.AreEqual(6.0f, 0.10471976f.RadiansToDegrees());
        Assert.AreEqual(12.0f, 0.20943952f.RadiansToDegrees());
    }

    [TestMethod]
    public void Sqrt()
    {
        Assert.AreEqual(0.0f, 0.0f.Sqrt());
        Assert.AreEqual(1.4142135f, 2.0f.Sqrt());
        Assert.AreEqual(3.0f, 9.0f.Sqrt());
        Assert.AreEqual(4.0f, 16.0f.Sqrt());
        Assert.AreEqual(float.NaN, float.NaN.Sqrt());
        Assert.AreEqual(float.NaN, (-1.0f).Sqrt());
        Assert.AreEqual(float.NaN, float.NegativeInfinity.Sqrt());
        Assert.AreEqual(float.PositiveInfinity, float.PositiveInfinity.Sqrt());
    }
}
