using NUnit.Framework;
using X10D.Time;

namespace X10D.Tests.Time;

[TestFixture]
[CLSCompliant(false)]
public class UInt64Tests
{
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
            Assert.That(1UL.Weeks(), Is.GreaterThan(TimeSpan.Zero));
        });
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.Multiple(() =>
        {
            Assert.That(0UL.Weeks(), Is.EqualTo(TimeSpan.Zero));
        });
    }
}
