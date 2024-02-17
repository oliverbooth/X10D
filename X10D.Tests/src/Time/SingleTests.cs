using NUnit.Framework;
using X10D.Time;

namespace X10D.Tests.Time;

[TestFixture]
internal class SingleTests
{
    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.That(0f.Milliseconds(), Is.EqualTo(TimeSpan.Zero));
        Assert.That(0f.Seconds(), Is.EqualTo(TimeSpan.Zero));
        Assert.That(0f.Minutes(), Is.EqualTo(TimeSpan.Zero));
        Assert.That(0f.Days(), Is.EqualTo(TimeSpan.Zero));
        Assert.That(0f.Hours(), Is.EqualTo(TimeSpan.Zero));
        Assert.That(0f.Weeks(), Is.EqualTo(TimeSpan.Zero));
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.That(1f.Milliseconds() > TimeSpan.Zero);
        Assert.That(1f.Seconds() > TimeSpan.Zero);
        Assert.That(1f.Minutes() > TimeSpan.Zero);
        Assert.That(1f.Days() > TimeSpan.Zero);
        Assert.That(1f.Hours() > TimeSpan.Zero);
        Assert.That(1f.Weeks() > TimeSpan.Zero);
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeNegative_GivenMinusOne()
    {
        Assert.That((-1f).Milliseconds() < TimeSpan.Zero);
        Assert.That((-1f).Seconds() < TimeSpan.Zero);
        Assert.That((-1f).Minutes() < TimeSpan.Zero);
        Assert.That((-1f).Days() < TimeSpan.Zero);
        Assert.That((-1f).Hours() < TimeSpan.Zero);
        Assert.That((-1f).Weeks() < TimeSpan.Zero);
    }
}
