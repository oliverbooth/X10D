using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
public class Int32Tests
{
    [TestMethod]
    public void FromUnixTimeMilliseconds_ShouldBeEpoch_GivenZero()
    {
        Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), 0.FromUnixTimeMilliseconds());
    }

    [TestMethod]
    public void FromUnixTimeSeconds_ShouldBeEpoch_GivenZero()
    {
        Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), 0.FromUnixTimeSeconds());
    }

    [TestMethod]
    public void IsLeapYear_ShouldBeFalse_GivenMultipleOf100()
    {
        Assert.IsFalse(100.IsLeapYear());
        Assert.IsFalse((-100).IsLeapYear());
        Assert.IsFalse(1900.IsLeapYear());
        Assert.IsFalse(2100.IsLeapYear());
    }

    [TestMethod]
    public void IsLeapYear_ShouldBeFalse_GivenOddNumber()
    {
        Assert.IsFalse(1.IsLeapYear());
        Assert.IsFalse(101.IsLeapYear());
        Assert.IsFalse((-101).IsLeapYear());
    }

    [TestMethod]
    public void IsLeapYear_ShouldBeTrue_GivenMultipleOf4Or400()
    {
        Assert.IsTrue((-401).IsLeapYear());
        Assert.IsTrue((-105).IsLeapYear());
        Assert.IsTrue(4.IsLeapYear());
        Assert.IsTrue(104.IsLeapYear());
        Assert.IsTrue(400.IsLeapYear());
        Assert.IsTrue(2000.IsLeapYear());
    }

    [TestMethod]
    public void IsLeapYear_ShouldThrow_GivenZero()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => 0.IsLeapYear());
    }

    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeNegative_GivenMinusOne()
    {
        Assert.IsTrue((-1).Ticks() < TimeSpan.Zero);
        Assert.IsTrue((-1).Milliseconds() < TimeSpan.Zero);
        Assert.IsTrue((-1).Seconds() < TimeSpan.Zero);
        Assert.IsTrue((-1).Minutes() < TimeSpan.Zero);
        Assert.IsTrue((-1).Days() < TimeSpan.Zero);
        Assert.IsTrue((-1).Hours() < TimeSpan.Zero);
        Assert.IsTrue((-1).Weeks() < TimeSpan.Zero);
    }

    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.IsTrue(1.Ticks() > TimeSpan.Zero);
        Assert.IsTrue(1.Milliseconds() > TimeSpan.Zero);
        Assert.IsTrue(1.Seconds() > TimeSpan.Zero);
        Assert.IsTrue(1.Minutes() > TimeSpan.Zero);
        Assert.IsTrue(1.Days() > TimeSpan.Zero);
        Assert.IsTrue(1.Hours() > TimeSpan.Zero);
        Assert.IsTrue(1.Weeks() > TimeSpan.Zero);
    }

    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.AreEqual(TimeSpan.Zero, 0.Ticks());
        Assert.AreEqual(TimeSpan.Zero, 0.Milliseconds());
        Assert.AreEqual(TimeSpan.Zero, 0.Seconds());
        Assert.AreEqual(TimeSpan.Zero, 0.Minutes());
        Assert.AreEqual(TimeSpan.Zero, 0.Days());
        Assert.AreEqual(TimeSpan.Zero, 0.Hours());
        Assert.AreEqual(TimeSpan.Zero, 0.Weeks());
    }
}
