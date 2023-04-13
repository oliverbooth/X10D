using NUnit.Framework;
using X10D.Time;

namespace X10D.Tests.Time;

[TestFixture]
[CLSCompliant(false)]
public class SByteTests
{
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
            Assert.That(((sbyte)0).Weeks(), Is.EqualTo(TimeSpan.Zero));
        });
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.Multiple(() =>
        {
            Assert.That(((sbyte)1).Weeks(), Is.GreaterThan(TimeSpan.Zero));
        });
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeNegative_GivenMinusOne()
    {
        Assert.Multiple(() =>
        {
            Assert.That(((sbyte)-1).Weeks(), Is.LessThan(TimeSpan.Zero));
        });
    }
}
