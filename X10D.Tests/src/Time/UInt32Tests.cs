using NUnit.Framework;
using X10D.Time;

namespace X10D.Tests.Time;

[TestFixture]
[CLSCompliant(false)]
public class UInt32Tests
{
    [Test]
    public void FromUnixTimeMilliseconds_ShouldBeEpoch_GivenZero()
    {
        DateTimeOffset expected = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        Assert.That(0U.FromUnixTimeMilliseconds(), Is.EqualTo(expected));
    }

    [Test]
    public void FromUnixTimeSeconds_ShouldBeEpoch_GivenZero()
    {
        DateTimeOffset expected = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        Assert.That(0U.FromUnixTimeSeconds(), Is.EqualTo(expected));
    }

    [Test]
    public void IsLeapYear_ShouldBeFalse_GivenMultipleOf100()
    {
        Assert.Multiple(() =>
        {
            Assert.That(100U.IsLeapYear(), Is.False);
            Assert.That(1900U.IsLeapYear(), Is.False);
            Assert.That(2100U.IsLeapYear(), Is.False);
        });
    }

    [Test]
    public void IsLeapYear_ShouldBeFalse_GivenOddNumber()
    {
        Assert.Multiple(() =>
        {
            Assert.That(1U.IsLeapYear(), Is.False);
            Assert.That(101U.IsLeapYear(), Is.False);
        });
    }

    [Test]
    public void IsLeapYear_ShouldBeTrue_GivenMultipleOf4Or400()
    {
        Assert.Multiple(() =>
        {
            Assert.That(4U.IsLeapYear());
            Assert.That(104U.IsLeapYear());
            Assert.That(400U.IsLeapYear());
            Assert.That(2000U.IsLeapYear());
        });
    }

    [Test]
    public void IsLeapYear_ShouldThrow_GivenZero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = 0U.IsLeapYear());
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.Multiple(() =>
        {
            Assert.That(1U.Ticks(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1U.Milliseconds(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1U.Seconds(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1U.Minutes(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1U.Days(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1U.Hours(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1U.Weeks(), Is.GreaterThan(TimeSpan.Zero));
        });
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.Multiple(() =>
        {
            Assert.That(0U.Ticks(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0U.Milliseconds(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0U.Seconds(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0U.Minutes(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0U.Days(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0U.Hours(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0U.Weeks(), Is.EqualTo(TimeSpan.Zero));
        });
    }
}
