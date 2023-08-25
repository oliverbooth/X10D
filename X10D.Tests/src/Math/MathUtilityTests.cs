using NUnit.Framework;
#if !NET6_0_OR_GREATER
using X10D.Core;
#endif
using X10D.Math;

namespace X10D.Tests.Math;

[TestFixture]
internal class MathUtilityTests
{
    [Test]
    public void Bias_ReturnsCorrectResult_WhenBiasIsLessThanPointFive()
    {
        double doubleResult = MathUtility.Bias(0.5, 0.3);
        float floatResult = MathUtility.Bias(0.5f, 0.3f);

        Assert.Multiple(() =>
        {
            Assert.That(doubleResult, Is.EqualTo(0.3).Within(1e-4));
            Assert.That(floatResult, Is.EqualTo(0.3f).Within(1e-4f));
        });
    }

    [Test]
    public void Bias_ReturnsCorrectResult_WhenBiasIsEqualToPointFive()
    {
        double doubleResult = MathUtility.Bias(0.5, 0.5);
        float floatResult = MathUtility.Bias(0.5f, 0.5f);

        Assert.Multiple(() =>
        {
            Assert.That(doubleResult, Is.EqualTo(0.5).Within(1e-4));
            Assert.That(floatResult, Is.EqualTo(0.5f).Within(1e-4f));
        });
    }

    [Test]
    public void Bias_ReturnsCorrectResult_WhenBiasIsGreaterThanPointFive()
    {
        double doubleResult = MathUtility.Bias(0.5, 0.8);
        float floatResult = MathUtility.Bias(0.5f, 0.8f);

        Assert.Multiple(() =>
        {
            Assert.That(doubleResult, Is.EqualTo(0.8).Within(1e-4));
            Assert.That(floatResult, Is.EqualTo(0.8f).Within(1e-4f));
        });
    }

    [Test]
    public void ExponentialDecay_ShouldReturnCorrectValue_GivenDouble()
    {
        const double value = 100.0;
        const double alpha = 0.5;
        const double decay = 0.1;

        const double expected = 95.122942;
        double actual = MathUtility.ExponentialDecay(value, alpha, decay);

        Assert.That(actual, Is.EqualTo(expected).Within(1e-6));
    }

    [Test]
    public void ExponentialDecay_ShouldReturnCorrectValue_GivenSingle()
    {
        const float value = 100.0f;
        const float alpha = 0.5f;
        const float decay = 0.1f;

        const float expected = 95.12295f;
        float actual = MathUtility.ExponentialDecay(value, alpha, decay);

        Assert.That(actual, Is.EqualTo(expected).Within(1e-6f));
    }

    [Test]
    public void GammaToLinear_ShouldReturnQuarter_GivenQuarterAndGamma1()
    {
        double doubleResult = MathUtility.GammaToLinear(0.25, 1.0);
        float floatResult = MathUtility.GammaToLinear(0.25f, 1.0f);

        Assert.Multiple(() =>
        {
            Assert.That(doubleResult, Is.EqualTo(0.25).Within(1e-6));
            Assert.That(floatResult, Is.EqualTo(0.25f).Within(1e-6f));
        });
    }

    [Test]
    public void GammaToLinear_ShouldReturn1_Given1AndDefaultGamma()
    {
        double doubleResult = MathUtility.GammaToLinear(1.0);
        float floatResult = MathUtility.GammaToLinear(1.0f);

        Assert.Multiple(() =>
        {
            Assert.That(doubleResult, Is.EqualTo(1.0));
            Assert.That(floatResult, Is.EqualTo(1.0f));
        });
    }

    [Test]
    public void InverseLerp_ShouldReturn0_5_Given0_5_0_1()
    {
        double doubleResult = MathUtility.InverseLerp(0.5, 0.0, 1.0);
        float floatResult = MathUtility.InverseLerp(0.5f, 0f, 1f);

        Assert.Multiple(() =>
        {
            Assert.That(doubleResult, Is.EqualTo(0.5).Within(1e-6));
            Assert.That(floatResult, Is.EqualTo(0.5f).Within(1e-6f));
        });
    }

    [Test]
    public void InverseLerp_ShouldReturn0_5_Given5_0_10()
    {
        double doubleResult = MathUtility.InverseLerp(5.0, 0.0, 10.0);
        float floatResult = MathUtility.InverseLerp(5f, 0f, 10f);

        Assert.Multiple(() =>
        {
            Assert.That(doubleResult, Is.EqualTo(0.5).Within(1e-6));
            Assert.That(floatResult, Is.EqualTo(0.5f).Within(1e-6f));
        });
    }

    [Test]
    public void InverseLerp_ShouldReturn0_GivenTwoEqualValues()
    {
        var random = new Random();
        double doubleA = random.NextDouble();
        double doubleB = random.NextDouble();

        float floatA = random.NextSingle();
        float floatB = random.NextSingle();

        double doubleResult = MathUtility.InverseLerp(doubleA, doubleB, doubleB);
        float floatResult = MathUtility.InverseLerp(floatA, floatB, floatB);

        Assert.Multiple(() =>
        {
            Assert.That(doubleResult, Is.EqualTo(0.0).Within(1e-6));
            Assert.That(floatResult, Is.EqualTo(0.0f).Within(1e-6f));
        });
    }

    [Test]
    public void Lerp_ShouldReturnHigher_GivenAlpha1()
    {
        Assert.Multiple(() =>
        {
            Assert.That(MathUtility.Lerp(10.0f, 20.0f, 1.0f), Is.EqualTo(20.0f));
            Assert.That(MathUtility.Lerp(10.0, 20.0, 1.0), Is.EqualTo(20.0));
        });
    }

    [Test]
    public void Lerp_ShouldReturnLower_GivenAlpha0()
    {
        Assert.Multiple(() =>
        {
            Assert.That(MathUtility.Lerp(10.0f, 20.0f, 0.0f), Is.EqualTo(10.0f));
            Assert.That(MathUtility.Lerp(10.0, 20.0, 0.0), Is.EqualTo(10.0));
        });
    }

    [Test]
    public void Lerp_ShouldReturnMidPoint_GivenAlphaPoint5()
    {
        Assert.Multiple(() =>
        {
            Assert.That(MathUtility.Lerp(10.0f, 20.0f, 0.5f), Is.EqualTo(15.0f));
            Assert.That(MathUtility.Lerp(10.0, 20.0, 0.5), Is.EqualTo(15.0));
        });
    }

    [Test]
    public void LinearToGamma_ShouldReturnQuarter_GivenQuarterAndGamma1()
    {
        double doubleResult = MathUtility.LinearToGamma(0.25, 1.0);
        float floatResult = MathUtility.LinearToGamma(0.25f, 1.0f);

        Assert.Multiple(() =>
        {
            Assert.That(doubleResult, Is.EqualTo(0.25));
            Assert.That(floatResult, Is.EqualTo(0.25f));
        });
    }

    [Test]
    public void LinearToGamma_ShouldReturn1_Given1AndDefaultGamma()
    {
        double doubleResult = MathUtility.LinearToGamma(1.0);
        float floatResult = MathUtility.LinearToGamma(1.0f);

        Assert.Multiple(() =>
        {
            Assert.That(doubleResult, Is.EqualTo(1.0));
            Assert.That(floatResult, Is.EqualTo(1.0f));
        });
    }

    [Test]
    public void Pulse_ShouldReturn1_GivenDoubleValueWithinBounds()
    {
        const double value = 0.5;
        const double lower = 0.0;
        const double upper = 1.0;

        double result = MathUtility.Pulse(value, lower, upper);

        Assert.That(result, Is.EqualTo(1.0).Within(1e-6));
    }

    [Test]
    public void Pulse_ShouldReturn0_GivenDoubleValueLessThanLowerBound()
    {
        const double value = -1.0;
        const double lower = 0.0;
        const double upper = 1.0;

        double result = MathUtility.Pulse(value, lower, upper);

        Assert.That(result, Is.EqualTo(0.0).Within(1e-6));
    }

    [Test]
    public void Pulse_ShouldReturn0_GivenDoubleValueGreaterThanUpperBound()
    {
        const double value = 2.0;
        const double lower = 0.0;
        const double upper = 1.0;

        double result = MathUtility.Pulse(value, lower, upper);

        Assert.That(result, Is.EqualTo(0.0).Within(1e-6));
    }

    [Test]
    public void Pulse_ShouldReturn1_GivenSingleValueWithinBounds()
    {
        const float value = 0.5f;
        const float lower = 0.0f;
        const float upper = 1.0f;

        float result = MathUtility.Pulse(value, lower, upper);

        Assert.That(result, Is.EqualTo(1.0f).Within(1e-6f));
    }

    [Test]
    public void Pulse_ShouldReturn0_GivenSingleValueLessThanLowerBound()
    {
        const float value = -1.0f;
        const float lower = 0.0f;
        const float upper = 1.0f;

        float result = MathUtility.Pulse(value, lower, upper);

        Assert.That(result, Is.EqualTo(0.0f).Within(1e-6f));
    }

    [Test]
    public void Pulse_ShouldReturn0_GivenSingleValueGreaterThanUpperBound()
    {
        const float value = 2.0f;
        const float lower = 0.0f;
        const float upper = 1.0f;

        float result = MathUtility.Pulse(value, lower, upper);

        Assert.That(result, Is.EqualTo(0.0f).Within(1e-6f));
    }

    [Test]
    public void Sawtooth_ShouldReturn0Point5_Given0Point5AsDouble()
    {
        const double value = 0.5;

        const double expected = 0.5;
        double actual = MathUtility.Sawtooth(value);

        Assert.That(actual, Is.EqualTo(expected).Within(1e-6));
    }

    [Test]
    public void Sawtooth_ShouldReturn0Point5_Given0Point5AsSingle()
    {
        const float value = 0.5f;

        const float expected = 0.5f;
        float actual = MathUtility.Sawtooth(value);

        Assert.That(actual, Is.EqualTo(expected).Within(1e-6f));
    }

    [Test]
    public void Sawtooth_ShouldReturn0Point5_Given1Point5AsDouble()
    {
        const double value = 1.5;

        const double expected = 0.5;
        double actual = MathUtility.Sawtooth(value);

        Assert.That(actual, Is.EqualTo(expected).Within(1e-6));
    }

    [Test]
    public void Sawtooth_ShouldReturn0Point5_Given1Point5AsSingle()
    {
        const float value = 1.5f;

        const float expected = 0.5f;
        float actual = MathUtility.Sawtooth(value);

        Assert.That(actual, Is.EqualTo(expected).Within(1e-6f));
    }

    [Test]
    public void Sawtooth_ShouldReturn0Point5_GivenNegative1Point5AsDouble()
    {
        const double value = -1.5;

        const double expected = 0.5;
        double actual = MathUtility.Sawtooth(value);

        Assert.That(actual, Is.EqualTo(expected).Within(1e-6));
    }

    [Test]
    public void Sawtooth_ShouldReturn0Point5_GivenNegative1Point5AsSingle()
    {
        const float value = -1.5f;

        const float expected = 0.5f;
        float actual = MathUtility.Sawtooth(value);

        Assert.That(actual, Is.EqualTo(expected).Within(1e-6f));
    }

    [Test]
    public void ScaleRangeDouble_ShouldScaleRange_GivenItsValues()
    {
        double result = MathUtility.ScaleRange(0.5, 0.0, 1.0, 5.0, 10.0);
        Assert.That(result, Is.EqualTo(7.5));
    }

    [Test]
    public void ScaleRangeSingle_ShouldScaleRange_GivenItsValues()
    {
        float result = MathUtility.ScaleRange(0.5f, 0.0f, 1.0f, 5.0f, 10.0f);
        Assert.That(result, Is.EqualTo(7.5f));
    }

    [Test]
    public void Sigmoid_ReturnsExpectedValue_UsingDouble()
    {
        const double input = 0.5f;
        const double expected = 0.622459331f;

        double actual = MathUtility.Sigmoid(input);

        Assert.That(actual, Is.EqualTo(expected).Within(1e-6));
    }

    [Test]
    public void Sigmoid_ReturnsExpectedValue_UsingSingle()
    {
        const float input = 0.5f;
        const float expected = 0.622459331f;

        float actual = MathUtility.Sigmoid(input);

        Assert.That(actual, Is.EqualTo(expected).Within(1e-6f));
    }

    [Test]
    public void Sigmoid_ReturnsZeroWhenInputIsNegativeInfinity_UsingDouble()
    {
        const double input = double.NegativeInfinity;
        const double expected = 0f;

        double actual = MathUtility.Sigmoid(input);

        Assert.That(actual, Is.EqualTo(expected).Within(1e-6));
    }

    [Test]
    public void Sigmoid_ReturnsZeroWhenInputIsNegativeInfinity_UsingSingle()
    {
        const float input = float.NegativeInfinity;
        const float expected = 0f;

        float actual = MathUtility.Sigmoid(input);

        Assert.That(actual, Is.EqualTo(expected).Within(1e-6f));
    }

    [Test]
    public void Sigmoid_ReturnsOneWhenInputIsPositiveInfinity_UsingDouble()
    {
        const double input = double.PositiveInfinity;
        const double expected = 1f;

        double actual = MathUtility.Sigmoid(input);

        Assert.That(actual, Is.EqualTo(expected).Within(1e-6));
    }

    [Test]
    public void Sigmoid_ReturnsOneWhenInputIsPositiveInfinity_UsingSingle()
    {
        const float input = float.PositiveInfinity;
        const float expected = 1f;

        float actual = MathUtility.Sigmoid(input);

        Assert.That(actual, Is.EqualTo(expected).Within(1e-6f));
    }

    [Test]
    public void Sigmoid_ReturnsZeroPointFiveWhenInputIsZero_UsingDouble()
    {
        const double input = 0f;
        const double expected = 0.5f;

        double actual = MathUtility.Sigmoid(input);

        Assert.That(actual, Is.EqualTo(expected).Within(1e-6));
    }

    [Test]
    public void Sigmoid_ReturnsZeroPointFiveWhenInputIsZero_UsingSingle()
    {
        const float input = 0f;
        const float expected = 0.5f;

        float actual = MathUtility.Sigmoid(input);

        Assert.That(actual, Is.EqualTo(expected).Within(1e-6f));
    }

    [Test]
    public void SmoothStep_ShouldReturnHigher_GivenAlpha1()
    {
        Assert.Multiple(() =>
        {
            Assert.That(MathUtility.SmoothStep(10.0f, 20.0f, 1.0f), Is.EqualTo(20.0f));
            Assert.That(MathUtility.SmoothStep(10.0, 20.0, 1.0), Is.EqualTo(20.0));
        });
    }

    [Test]
    public void SmoothStep_ShouldReturnLower_GivenAlpha0()
    {
        Assert.Multiple(() =>
        {
            Assert.That(MathUtility.SmoothStep(10.0f, 20.0f, 0.0f), Is.EqualTo(10.0f));
            Assert.That(MathUtility.SmoothStep(10.0, 20.0, 0.0), Is.EqualTo(10.0));
        });
    }

    [Test]
    public void SmoothStep_ShouldReturnMidPoint_GivenAlphaPoint5()
    {
        Assert.Multiple(() =>
        {
            Assert.That(MathUtility.SmoothStep(10.0f, 20.0f, 0.5f), Is.EqualTo(15.0f));
            Assert.That(MathUtility.SmoothStep(10.0, 20.0, 0.5), Is.EqualTo(15.0));
        });
    }
}
