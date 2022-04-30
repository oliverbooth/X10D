using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
public class DecimalTests
{
    [TestMethod]
    public void ComplexSqrt_ShouldBeCorrect_GivenReal()
    {
        Assert.AreEqual(0.0, 0.0m.ComplexSqrt());
        Assert.AreEqual(1.4142135623730951, 2.0m.ComplexSqrt());
        Assert.AreEqual(3.0, 9.0m.ComplexSqrt());
        Assert.AreEqual(4.0, 16.0m.ComplexSqrt());
        Assert.AreEqual(100.0, 10000.0m.ComplexSqrt());
    }

    [TestMethod]
    public void ComplexSqrt_ShouldBeImaginary_GivenNegativeValue()
    {
        Assert.AreEqual(new Complex(0, 1), (-1.0m).ComplexSqrt());
        Assert.AreEqual(new Complex(0, 1.4142135623730951), (-2.0m).ComplexSqrt());
        Assert.AreEqual(new Complex(0, 3.0), (-9.0m).ComplexSqrt());
        Assert.AreEqual(new Complex(0, 4.0), (-16.0m).ComplexSqrt());
    }

    [TestMethod]
    public void IsEven_ShouldBeFalse_GivenOddNumber()
    {
        Assert.IsFalse((-3.0m).IsEven());
        Assert.IsFalse((-1.0m).IsEven());
        Assert.IsFalse(1.0m.IsEven());
        Assert.IsFalse(3.0m.IsEven());
    }

    [TestMethod]
    public void IsEven_ShouldBeTrue_GivenOddNumber()
    {
        Assert.IsTrue((-4.0m).IsEven());
        Assert.IsTrue((-2.0m).IsEven());
        Assert.IsTrue(0.0m.IsEven());
        Assert.IsTrue(2.0m.IsEven());
        Assert.IsTrue(4.0m.IsEven());
    }

    [TestMethod]
    public void IsOdd_ShouldBeFalse_GivenEvenNumber()
    {
        Assert.IsFalse((-4.0m).IsOdd());
        Assert.IsFalse((-2.0m).IsOdd());
        Assert.IsFalse(0.0m.IsOdd());
        Assert.IsFalse(2.0m.IsOdd());
        Assert.IsFalse(4.0m.IsOdd());
    }

    [TestMethod]
    public void IsOdd_ShouldBeTrue_GivenOddNumber()
    {
        Assert.IsTrue((-3.0m).IsOdd());
        Assert.IsTrue((-1.0m).IsOdd());
        Assert.IsTrue(1.0m.IsOdd());
        Assert.IsTrue(3.0m.IsOdd());
    }

    [TestMethod]
    public void Round_ShouldRoundToNearestInteger()
    {
        Assert.AreEqual(4.0m, 3.5m.Round());
        Assert.AreEqual(7.0m, 6.8m.Round());
        Assert.AreEqual(7.0m, 7.2m.Round());
    }

    [TestMethod]
    public void Round_ShouldRoundToNearestMultiple()
    {
        Assert.AreEqual(5.0m, 3.5m.Round(5));
        Assert.AreEqual(5.0m, 7.0m.Round(5));
        Assert.AreEqual(10.0m, 7.5m.Round(5));
    }

    [TestMethod]
    public void Sign_ShouldBeMinus1_GivenNegative()
    {
        Assert.AreEqual(-1, -1.0m.Sign());
        Assert.AreEqual(-1, -2.0m.Sign());
        Assert.AreEqual(-1, -3.0m.Sign());
    }

    [TestMethod]
    public void Sign_ShouldBe0_Given0()
    {
        Assert.AreEqual(0, 0.0m.Sign());
    }

    [TestMethod]
    public void Sign_ShouldBe1_GivenPositive()
    {
        Assert.AreEqual(1, 1.0m.Sign());
        Assert.AreEqual(1, 2.0m.Sign());
        Assert.AreEqual(1, 3.0m.Sign());
    }

    [TestMethod]
    public void Sqrt_ShouldBeCorrect_GivenValue()
    {
        Assert.AreEqual(0.0m, 0.0m.Sqrt());
        Assert.AreEqual(1.4142135623730950488016887242m, 2.0m.Sqrt());
        Assert.AreEqual(3.0m, 9.0m.Sqrt());
        Assert.AreEqual(4.0m, 16.0m.Sqrt());
        Assert.AreEqual(100.0m, 10000.0m.Sqrt());
    }

    [TestMethod]
    public void Sqrt_ShouldThrow_GivenNegativeValue()
    {
        Assert.ThrowsException<ArgumentException>(() => (-1.0m).Sqrt());
        Assert.ThrowsException<ArgumentException>(() => (-2.0m).Sqrt());
        Assert.ThrowsException<ArgumentException>(() => (-3.0m).Sqrt());
    }
}
