using NUnit.Framework;
using X10D.Time;

namespace X10D.Tests.Time;

[TestFixture]
public class HalfTests
{
    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.That(0.0.Milliseconds(), Is.EqualTo(TimeSpan.Zero));
        Assert.That(0.0.Seconds(), Is.EqualTo(TimeSpan.Zero));
        Assert.That(0.0.Minutes(), Is.EqualTo(TimeSpan.Zero));
        Assert.That(0.0.Days(), Is.EqualTo(TimeSpan.Zero));
        Assert.That(0.0.Hours(), Is.EqualTo(TimeSpan.Zero));
        Assert.That(0.0.Weeks(), Is.EqualTo(TimeSpan.Zero));
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.That(1.0.Milliseconds() > TimeSpan.Zero);
        Assert.That(1.0.Seconds() > TimeSpan.Zero);
        Assert.That(1.0.Minutes() > TimeSpan.Zero);
        Assert.That(1.0.Days() > TimeSpan.Zero);
        Assert.That(1.0.Hours() > TimeSpan.Zero);
        Assert.That(1.0.Weeks() > TimeSpan.Zero);
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeNegative_GivenMinusOne()
    {
        Assert.That((-1.0).Milliseconds() < TimeSpan.Zero);
        Assert.That((-1.0).Seconds() < TimeSpan.Zero);
        Assert.That((-1.0).Minutes() < TimeSpan.Zero);
        Assert.That((-1.0).Days() < TimeSpan.Zero);
        Assert.That((-1.0).Hours() < TimeSpan.Zero);
        Assert.That((-1.0).Weeks() < TimeSpan.Zero);
    }
}
