using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Core;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
public class MathUtilityTests
{
    [TestMethod]
    public void GammaToLinear_ShouldReturnQuarter_GivenQuarterAndGamma1()
    {
        double doubleResult = MathUtility.GammaToLinear(0.25, 1.0);
        float floatResult = MathUtility.GammaToLinear(0.25f, 1.0f);

        Assert.AreEqual(0.25, doubleResult);
        Assert.AreEqual(0.25f, floatResult);
    }

    [TestMethod]
    public void GammaToLinear_ShouldReturn1_Given1AndDefaultGamma()
    {
        double doubleResult = MathUtility.GammaToLinear(1.0);
        float floatResult = MathUtility.GammaToLinear(1.0f);

        Assert.AreEqual(1.0, doubleResult);
        Assert.AreEqual(1.0f, floatResult);
    }

    [TestMethod]
    public void InverseLerp_ShouldReturn0_5_Given0_5_0_1()
    {
        double doubleResult = MathUtility.InverseLerp(0.5, 0.0, 1.0);
        float floatResult = MathUtility.InverseLerp(0.5f, 0f, 1f);

        Assert.AreEqual(0.5, doubleResult, 1e-6);
        Assert.AreEqual(0.5f, floatResult, 1e-6f);
    }

    [TestMethod]
    public void InverseLerp_ShouldReturn0_5_Given5_0_10()
    {
        double doubleResult = MathUtility.InverseLerp(5.0, 0.0, 10.0);
        float floatResult = MathUtility.InverseLerp(5f, 0f, 10f);

        Assert.AreEqual(0.5, doubleResult, 1e-6);
        Assert.AreEqual(0.5f, floatResult, 1e-6f);
    }

    [TestMethod]
    public void InverseLerp_ShouldReturn0_GivenTwoEqualValues()
    {
        var random = new Random();
        double doubleA = random.NextDouble();
        double doubleB = random.NextDouble();

        float floatA = random.NextSingle();
        float floatB = random.NextSingle();

        double doubleResult = MathUtility.InverseLerp(doubleA, doubleB, doubleB);
        float floatResult = MathUtility.InverseLerp(floatA, floatB, floatB);

        Assert.AreEqual(0.0, doubleResult, 1e-6);
        Assert.AreEqual(0.0f, floatResult, 1e-6f);
    }

    [TestMethod]
    public void LinearToGamma_ShouldReturnQuarter_GivenQuarterAndGamma1()
    {
        double doubleResult = MathUtility.LinearToGamma(0.25, 1.0);
        float floatResult = MathUtility.LinearToGamma(0.25f, 1.0f);

        Assert.AreEqual(0.25, doubleResult);
        Assert.AreEqual(0.25f, floatResult);
    }

    [TestMethod]
    public void LinearToGamma_ShouldReturn1_Given1AndDefaultGamma()
    {
        double doubleResult = MathUtility.LinearToGamma(1.0);
        float floatResult = MathUtility.LinearToGamma(1.0f);

        Assert.AreEqual(1.0, doubleResult);
        Assert.AreEqual(1.0f, floatResult);
    }

    [TestMethod]
    public void ScaleRangeDouble_ShouldScaleRange_GivenItsValues()
    {
        double result = MathUtility.ScaleRange(0.5, 0.0, 1.0, 5.0, 10.0);
        Assert.AreEqual(7.5, result);
    }

    [TestMethod]
    public void ScaleRangeSingle_ShouldScaleRange_GivenItsValues()
    {
        float result = MathUtility.ScaleRange(0.5f, 0.0f, 1.0f, 5.0f, 10.0f);
        Assert.AreEqual(7.5f, result);
    }
}
