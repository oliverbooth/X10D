using NUnit.Framework;
using X10D.Time;

namespace X10D.Tests.Time;

[TestFixture]
public class Int64Tests
{
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
            Assert.That((-1L).Weeks(), Is.LessThan(TimeSpan.Zero));
        });
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.Multiple(() =>
        {
            Assert.That(1L.Weeks(), Is.GreaterThan(TimeSpan.Zero));
        });
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.Multiple(() =>
        {
            Assert.That(0L.Weeks(), Is.EqualTo(TimeSpan.Zero));
        });
    }
}
