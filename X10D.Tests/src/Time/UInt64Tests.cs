using NUnit.Framework;
using X10D.Time;

namespace X10D.Tests.Time;

[TestFixture]
[CLSCompliant(false)]
public class UInt64Tests
{
    [Test]
    public void FromUnixTimeMilliseconds_ShouldBeEpoch_GivenZero()
    {
        DateTimeOffset expected = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        Assert.That(0UL.FromUnixTimeMilliseconds(), Is.EqualTo(expected));
    }

    [Test]
    public void FromUnixTimeSeconds_ShouldBeEpoch_GivenZero()
    {
        DateTimeOffset expected = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        Assert.That(0UL.FromUnixTimeSeconds(), Is.EqualTo(expected));
    }

    [Test]
    public void IsLeapYear_ShouldBeFalse_GivenMultipleOf100()
    {
        Assert.Multiple(() =>
        {
            Assert.That(100UL.IsLeapYear(), Is.False);
            Assert.That(1900UL.IsLeapYear(), Is.False);
            Assert.That(2100UL.IsLeapYear(), Is.False);
        });
    }

    [Test]
    public void IsLeapYear_ShouldBeFalse_GivenOddNumber()
    {
        Assert.Multiple(() =>
        {
            Assert.That(1UL.IsLeapYear(), Is.False);
            Assert.That(101UL.IsLeapYear(), Is.False);
        });
    }

    [Test]
    public void IsLeapYear_ShouldBeTrue_GivenMultipleOf4Or400()
    {
        Assert.Multiple(() =>
        {
            Assert.That(4UL.IsLeapYear());
            Assert.That(104UL.IsLeapYear());
            Assert.That(400UL.IsLeapYear());
            Assert.That(2000UL.IsLeapYear());
        });
    }

    [Test]
    public void IsLeapYear_ShouldThrow_GivenZero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = 0UL.IsLeapYear());
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.Multiple(() =>
        {
            Assert.That(1UL.Ticks(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1UL.Milliseconds(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1UL.Seconds(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1UL.Minutes(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1UL.Days(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1UL.Hours(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1UL.Weeks(), Is.GreaterThan(TimeSpan.Zero));
        });
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.Multiple(() =>
        {
            Assert.That(0UL.Ticks(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0UL.Milliseconds(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0UL.Seconds(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0UL.Minutes(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0UL.Days(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0UL.Hours(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0UL.Weeks(), Is.EqualTo(TimeSpan.Zero));
        });
    }
}
