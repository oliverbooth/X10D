using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
public class Int64Tests
{
    [TestMethod]
    public void FromUnixTimeMilliseconds_ShouldBeEpoch_GivenZero()
    {
        Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), 0L.FromUnixTimeMilliseconds());
    }

    [TestMethod]
    public void FromUnixTimeSeconds_ShouldBeEpoch_GivenZero()
    {
        Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), 0L.FromUnixTimeSeconds());
    }

    [TestMethod]
    public void IsLeapYear_ShouldBeFalse_GivenMultipleOf100()
    {
        Assert.IsFalse(100L.IsLeapYear());
        Assert.IsFalse((-100L).IsLeapYear());
        Assert.IsFalse(1900L.IsLeapYear());
        Assert.IsFalse(2100L.IsLeapYear());
    }

    [TestMethod]
    public void IsLeapYear_ShouldBeFalse_GivenOddNumber()
    {
        Assert.IsFalse(1L.IsLeapYear());
        Assert.IsFalse(101L.IsLeapYear());
        Assert.IsFalse((-101L).IsLeapYear());
    }

    [TestMethod]
    public void IsLeapYear_ShouldBeTrue_GivenMultipleOf4Or400()
    {
        Assert.IsTrue((-401L).IsLeapYear());
        Assert.IsTrue((-105L).IsLeapYear());
        Assert.IsTrue(4L.IsLeapYear());
        Assert.IsTrue(104L.IsLeapYear());
        Assert.IsTrue(400L.IsLeapYear());
        Assert.IsTrue(2000L.IsLeapYear());
    }

    [TestMethod]
    public void IsLeapYear_ShouldThrow_GivenZero()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => 0L.IsLeapYear());
    }

    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeNegative_GivenMinusOne()
    {
        Assert.IsTrue((-1L).Ticks() < TimeSpan.Zero);
        Assert.IsTrue((-1L).Milliseconds() < TimeSpan.Zero);
        Assert.IsTrue((-1L).Seconds() < TimeSpan.Zero);
        Assert.IsTrue((-1L).Minutes() < TimeSpan.Zero);
        Assert.IsTrue((-1L).Days() < TimeSpan.Zero);
        Assert.IsTrue((-1L).Hours() < TimeSpan.Zero);
        Assert.IsTrue((-1L).Weeks() < TimeSpan.Zero);
    }

    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.IsTrue(1L.Ticks() > TimeSpan.Zero);
        Assert.IsTrue(1L.Milliseconds() > TimeSpan.Zero);
        Assert.IsTrue(1L.Seconds() > TimeSpan.Zero);
        Assert.IsTrue(1L.Minutes() > TimeSpan.Zero);
        Assert.IsTrue(1L.Days() > TimeSpan.Zero);
        Assert.IsTrue(1L.Hours() > TimeSpan.Zero);
        Assert.IsTrue(1L.Weeks() > TimeSpan.Zero);
    }

    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.AreEqual(TimeSpan.Zero, 0L.Ticks());
        Assert.AreEqual(TimeSpan.Zero, 0L.Milliseconds());
        Assert.AreEqual(TimeSpan.Zero, 0L.Seconds());
        Assert.AreEqual(TimeSpan.Zero, 0L.Minutes());
        Assert.AreEqual(TimeSpan.Zero, 0L.Days());
        Assert.AreEqual(TimeSpan.Zero, 0L.Hours());
        Assert.AreEqual(TimeSpan.Zero, 0L.Weeks());
    }
}
