using NUnit.Framework;
using X10D.Time;

namespace X10D.Tests.Time;

[TestFixture]
public class Int32Tests
{
    [Test]
    public void FromUnixTimeMilliseconds_ShouldBeEpoch_GivenZero()
    {
        DateTimeOffset expected = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        Assert.That(0.FromUnixTimeMilliseconds(), Is.EqualTo(expected));
    }

    [Test]
    public void FromUnixTimeSeconds_ShouldBeEpoch_GivenZero()
    {
        DateTimeOffset expected = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        Assert.That(0.FromUnixTimeSeconds(), Is.EqualTo(expected));
    }

    [Test]
    public void IsLeapYear_ShouldBeFalse_GivenMultipleOf100()
    {
        Assert.Multiple(() =>
        {
            Assert.That(100.IsLeapYear(), Is.False);
            Assert.That((-100).IsLeapYear(), Is.False);
            Assert.That(1900.IsLeapYear(), Is.False);
            Assert.That(2100.IsLeapYear(), Is.False);
        });
    }

    [Test]
    public void IsLeapYear_ShouldBeFalse_GivenOddNumber()
    {
        Assert.Multiple(() =>
        {
            Assert.That(1.IsLeapYear(), Is.False);
            Assert.That(101.IsLeapYear(), Is.False);
            Assert.That((-101).IsLeapYear(), Is.False);
        });
    }

    [Test]
    public void IsLeapYear_ShouldBeTrue_GivenMultipleOf4Or400()
    {
        Assert.Multiple(() =>
        {
            Assert.That((-401).IsLeapYear());
            Assert.That((-105).IsLeapYear());
            Assert.That(4.IsLeapYear());
            Assert.That(104.IsLeapYear());
            Assert.That(400.IsLeapYear());
            Assert.That(2000.IsLeapYear());
        });
    }

    [Test]
    public void IsLeapYear_ShouldThrow_GivenZero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = 0.IsLeapYear());
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeNegative_GivenMinusOne()
    {
        Assert.Multiple(() =>
        {
            Assert.That((-1).Ticks(), Is.LessThan(TimeSpan.Zero));
            Assert.That((-1).Milliseconds(), Is.LessThan(TimeSpan.Zero));
            Assert.That((-1).Seconds(), Is.LessThan(TimeSpan.Zero));
            Assert.That((-1).Minutes(), Is.LessThan(TimeSpan.Zero));
            Assert.That((-1).Days(), Is.LessThan(TimeSpan.Zero));
            Assert.That((-1).Hours(), Is.LessThan(TimeSpan.Zero));
            Assert.That((-1).Weeks(), Is.LessThan(TimeSpan.Zero));
        });
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.Multiple(() =>
        {
            Assert.That(1.Ticks(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1.Milliseconds(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1.Seconds(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1.Minutes(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1.Days(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1.Hours(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(1.Weeks(), Is.GreaterThan(TimeSpan.Zero));
        });
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.Multiple(() =>
        {
            Assert.That(0.Ticks(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0.Milliseconds(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0.Seconds(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0.Minutes(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0.Days(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0.Hours(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(0.Weeks(), Is.EqualTo(TimeSpan.Zero));
        });
    }
}
