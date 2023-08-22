using NUnit.Framework;
using X10D.Time;

namespace X10D.Tests.Time;

[TestFixture]
internal class SByteTests
{
    [Test]
    public void FromUnixTimeMilliseconds_ShouldBeEpoch_GivenZero()
    {
        DateTimeOffset expected = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        Assert.That(((sbyte)0).FromUnixTimeMilliseconds(), Is.EqualTo(expected));
    }

    [Test]
    public void FromUnixTimeSeconds_ShouldBeEpoch_GivenZero()
    {
        DateTimeOffset expected = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        Assert.That(((sbyte)0).FromUnixTimeSeconds(), Is.EqualTo(expected));
    }

    [Test]
    public void IsLeapYear_ShouldBeFalse_GivenMultipleOf100()
    {
        Assert.Multiple(() =>
        {
            Assert.That(((sbyte)100).IsLeapYear(), Is.False);
            Assert.That(((sbyte)-100).IsLeapYear(), Is.False);
        });
    }

    [Test]
    public void IsLeapYear_ShouldBeFalse_GivenOddNumber()
    {
        Assert.Multiple(() =>
        {
            Assert.That(((sbyte)1).IsLeapYear(), Is.False);
            Assert.That(((sbyte)101).IsLeapYear(), Is.False);
            Assert.That(((sbyte)-101).IsLeapYear(), Is.False);
        });
    }

    [Test]
    public void IsLeapYear_ShouldBeTrue_GivenMultipleOf4()
    {
        Assert.Multiple(() =>
        {
            Assert.That(((sbyte)4).IsLeapYear());
            Assert.That(((sbyte)104).IsLeapYear());
            Assert.That(((sbyte)-105).IsLeapYear());
        });
    }

    [Test]
    public void IsLeapYear_ShouldThrow_GivenZero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = ((sbyte)0).IsLeapYear());
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.Multiple(() =>
        {
            Assert.That(((sbyte)0).Ticks(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(((sbyte)0).Milliseconds(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(((sbyte)0).Seconds(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(((sbyte)0).Minutes(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(((sbyte)0).Days(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(((sbyte)0).Hours(), Is.EqualTo(TimeSpan.Zero));
            Assert.That(((sbyte)0).Weeks(), Is.EqualTo(TimeSpan.Zero));
        });
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.Multiple(() =>
        {
            Assert.That(((sbyte)1).Ticks(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(((sbyte)1).Milliseconds(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(((sbyte)1).Seconds(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(((sbyte)1).Minutes(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(((sbyte)1).Days(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(((sbyte)1).Hours(), Is.GreaterThan(TimeSpan.Zero));
            Assert.That(((sbyte)1).Weeks(), Is.GreaterThan(TimeSpan.Zero));
        });
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeNegative_GivenMinusOne()
    {
        Assert.Multiple(() =>
        {
            Assert.That(((sbyte)-1).Ticks(), Is.LessThan(TimeSpan.Zero));
            Assert.That(((sbyte)-1).Milliseconds(), Is.LessThan(TimeSpan.Zero));
            Assert.That(((sbyte)-1).Seconds(), Is.LessThan(TimeSpan.Zero));
            Assert.That(((sbyte)-1).Minutes(), Is.LessThan(TimeSpan.Zero));
            Assert.That(((sbyte)-1).Days(), Is.LessThan(TimeSpan.Zero));
            Assert.That(((sbyte)-1).Hours(), Is.LessThan(TimeSpan.Zero));
            Assert.That(((sbyte)-1).Weeks(), Is.LessThan(TimeSpan.Zero));
        });
    }
}
