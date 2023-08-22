using NUnit.Framework;
using X10D.Time;

namespace X10D.Tests.Time;

[TestFixture]
internal class Int64Tests
{
    [Test]
    public void FromUnixTimeMilliseconds_ShouldBeEpoch_GivenZero()
    {
        DateTimeOffset expected = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        Assert.That(0L.FromUnixTimeMilliseconds(), Is.EqualTo(expected));
    }

    [Test]
    public void FromUnixTimeSeconds_ShouldBeEpoch_GivenZero()
    {
        DateTimeOffset expected = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        Assert.That(0L.FromUnixTimeSeconds(), Is.EqualTo(expected));
    }

    [Test]
    public void IsLeapYear_ShouldBeFalse_GivenMultipleOf100()
    {
        Assert.Multiple(() =>
        {
            Assert.That(100L.IsLeapYear(), Is.False);
            Assert.That((-100L).IsLeapYear(), Is.False);
            Assert.That(1900L.IsLeapYear(), Is.False);
            Assert.That(2100L.IsLeapYear(), Is.False);
        });
    }

    [Test]
    public void IsLeapYear_ShouldBeFalse_GivenOddNumber()
    {
        Assert.Multiple(() =>
        {
            Assert.That(1L.IsLeapYear(), Is.False);
            Assert.That(101L.IsLeapYear(), Is.False);
            Assert.That((-101L).IsLeapYear(), Is.False);
        });
    }

    [Test]
    public void IsLeapYear_ShouldBeTrue_GivenMultipleOf4Or400()
    {
        Assert.Multiple(() =>
        {
            Assert.That((-401L).IsLeapYear());
            Assert.That((-105L).IsLeapYear());
            Assert.That(4L.IsLeapYear());
            Assert.That(104L.IsLeapYear());
            Assert.That(400L.IsLeapYear());
            Assert.That(2000L.IsLeapYear());
        });
    }

    [Test]
    public void IsLeapYear_ShouldThrow_GivenZero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = 0L.IsLeapYear());
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeNegative_GivenMinusOne()
    {
        Assert.Multiple(() =>
        {
            Assert.That((-1L).Ticks(), Is.LessThan(TimeSpan.Zero));
            Assert.That((-1L).Milliseconds(), Is.LessThan(TimeSpan.Zero));
            Assert.That((-1L).Seconds(), Is.LessThan(TimeSpan.Zero));
            Assert.That((-1L).Minutes(), Is.LessThan(TimeSpan.Zero));
            Assert.That((-1L).Days(), Is.LessThan(TimeSpan.Zero));
            Assert.That((-1L).Hours(), Is.LessThan(TimeSpan.Zero));
            Assert.That((-1L).Weeks(), Is.LessThan(TimeSpan.Zero));
        });
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.Multiple(() =>
        {
            Assert.That(1L.Ticks(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1L.Milliseconds(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1L.Seconds(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1L.Minutes(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1L.Days(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1L.Hours(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1L.Weeks(), Is.GreaterThan(TimeSpan.Zero));
        });
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.Multiple(() =>
        {
            Assert.That(0L.Ticks(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0L.Milliseconds(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0L.Seconds(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0L.Minutes(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0L.Days(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0L.Hours(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0L.Weeks(), Is.EqualTo(TimeSpan.Zero));
        });
    }
}
