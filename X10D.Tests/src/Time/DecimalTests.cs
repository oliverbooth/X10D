using NUnit.Framework;
using X10D.Time;

namespace X10D.Tests.Time;

[TestFixture]
public class DecimalTests
{
    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.That(0m.Milliseconds(), Is.EqualTo(TimeSpan.Zero));
        Assert.That(0m.Seconds(), Is.EqualTo(TimeSpan.Zero));
        Assert.That(0m.Minutes(), Is.EqualTo(TimeSpan.Zero));
        Assert.That(0m.Days(), Is.EqualTo(TimeSpan.Zero));
        Assert.That(0m.Hours(), Is.EqualTo(TimeSpan.Zero));
        Assert.That(0m.Weeks(), Is.EqualTo(TimeSpan.Zero));
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.That(1m.Milliseconds() > TimeSpan.Zero);
        Assert.That(1m.Seconds() > TimeSpan.Zero);
        Assert.That(1m.Minutes() > TimeSpan.Zero);
        Assert.That(1m.Days() > TimeSpan.Zero);
        Assert.That(1m.Hours() > TimeSpan.Zero);
        Assert.That(1m.Weeks() > TimeSpan.Zero);
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeNegative_GivenMinusOne()
    {
        Assert.That((-1m).Milliseconds() < TimeSpan.Zero);
        Assert.That((-1m).Seconds() < TimeSpan.Zero);
        Assert.That((-1m).Minutes() < TimeSpan.Zero);
        Assert.That((-1m).Days() < TimeSpan.Zero);
        Assert.That((-1m).Hours() < TimeSpan.Zero);
        Assert.That((-1m).Weeks() < TimeSpan.Zero);
    }
}
