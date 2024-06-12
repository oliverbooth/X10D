#if NET7_0_OR_GREATER
using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Numerics;

[TestFixture]
internal class NumberTests
{
    [Test]
    public void Sign_ShouldReturn1_GivenPositiveNumber()
    {
        Assert.That(NumberExtensions.Sign(2), Is.Positive);
        Assert.That(NumberExtensions.Sign(2), Is.EqualTo(1));
    }

    [Test]
    public void Sign_Should0_GivenZero()
    {
        Assert.That(NumberExtensions.Sign(0), Is.Not.Positive);
        Assert.That(NumberExtensions.Sign(0), Is.Not.Negative);
        Assert.That(NumberExtensions.Sign(0), Is.EqualTo(0));
    }

    [Test]
    public void Sign_ShouldReturnNegative1_GivenNegativeNumber()
    {
        Assert.That(NumberExtensions.Sign(-2), Is.Negative);
        Assert.That(NumberExtensions.Sign(-2), Is.EqualTo(-1));
    }
}
#endif
