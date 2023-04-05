#if NET5_0_OR_GREATER
using NUnit.Framework;
using X10D.Time;

namespace X10D.Tests.Time;

[TestFixture]
public class DoubleTests
{
    private Half _negativeOne;
    private Half _one;
    private Half _zero;

    [SetUp]
    public void Initialize()
    {
        _negativeOne = (Half)(-1);
        _one = (Half)1;
        _zero = (Half)0;
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.That(_zero.Milliseconds(), Is.EqualTo(TimeSpan.Zero));
        Assert.That(_zero.Seconds(), Is.EqualTo(TimeSpan.Zero));
        Assert.That(_zero.Minutes(), Is.EqualTo(TimeSpan.Zero));
        Assert.That(_zero.Days(), Is.EqualTo(TimeSpan.Zero));
        Assert.That(_zero.Hours(), Is.EqualTo(TimeSpan.Zero));
        Assert.That(_zero.Weeks(), Is.EqualTo(TimeSpan.Zero));
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.That(_one.Milliseconds() > TimeSpan.Zero);
        Assert.That(_one.Seconds() > TimeSpan.Zero);
        Assert.That(_one.Minutes() > TimeSpan.Zero);
        Assert.That(_one.Days() > TimeSpan.Zero);
        Assert.That(_one.Hours() > TimeSpan.Zero);
        Assert.That(_one.Weeks() > TimeSpan.Zero);
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeNegative_GivenMinusOne()
    {
        Assert.That((_negativeOne).Milliseconds() < TimeSpan.Zero);
        Assert.That((_negativeOne).Seconds() < TimeSpan.Zero);
        Assert.That((_negativeOne).Minutes() < TimeSpan.Zero);
        Assert.That((_negativeOne).Days() < TimeSpan.Zero);
        Assert.That((_negativeOne).Hours() < TimeSpan.Zero);
        Assert.That((_negativeOne).Weeks() < TimeSpan.Zero);
    }
}
#endif
