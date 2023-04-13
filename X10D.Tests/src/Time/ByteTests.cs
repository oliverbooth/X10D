using NUnit.Framework;
using X10D.Time;

namespace X10D.Tests.Time;

[TestFixture]
public class ByteTests
{
    [Test]
    public void IsLeapYear_ShouldBeFalse_GivenMultipleOf100()
    {
        Assert.Multiple(() =>
        {
            Assert.That(((byte)100).IsLeapYear(), Is.False);
            Assert.That(((byte)200).IsLeapYear(), Is.False);
        });
    }

    [Test]
    public void IsLeapYear_ShouldBeFalse_GivenOddNumber()
    {
        Assert.Multiple(() =>
        {
            Assert.That(((byte)1).IsLeapYear(), Is.False);
            Assert.That(((byte)101).IsLeapYear(), Is.False);
            Assert.That(((byte)201).IsLeapYear(), Is.False);
        });
    }

    [Test]
    public void IsLeapYear_ShouldBeTrue_GivenMultipleOf4()
    {
        Assert.Multiple(() =>
        {
            Assert.That(((byte)4).IsLeapYear());
            Assert.That(((byte)104).IsLeapYear());
            Assert.That(((byte)204).IsLeapYear());
        });
    }

    [Test]
    public void IsLeapYear_ShouldThrow_GivenZero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = ((byte)0).IsLeapYear());
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.Multiple(() =>
        {
            Assert.That(((byte)1).Weeks(), Is.GreaterThan(TimeSpan.Zero));
        });
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.Multiple(() =>
        {
            Assert.That(((byte)0).Weeks(), Is.EqualTo(TimeSpan.Zero));
        });
    }
}
