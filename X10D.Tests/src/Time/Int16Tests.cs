using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
public class Int16Tests
{
    [TestMethod]
    public void FromUnixTimeMilliseconds_ShouldBeEpoch_GivenZero()
    {
        Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), ((short)0).FromUnixTimeMilliseconds());
    }

    [TestMethod]
    public void FromUnixTimeSeconds_ShouldBeEpoch_GivenZero()
    {
        Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), ((short)0).FromUnixTimeSeconds());
    }

    [TestMethod]
    public void IsLeapYear_ShouldBeFalse_GivenMultipleOf100()
    {
        Assert.IsFalse(((short)100).IsLeapYear());
        Assert.IsFalse(((short)-100).IsLeapYear());
        Assert.IsFalse(((short)1900).IsLeapYear());
        Assert.IsFalse(((short)2100).IsLeapYear());
    }

    [TestMethod]
    public void IsLeapYear_ShouldBeFalse_GivenOddNumber()
    {
        Assert.IsFalse(((short)1).IsLeapYear());
        Assert.IsFalse(((short)101).IsLeapYear());
        Assert.IsFalse(((short)-101).IsLeapYear());
    }

    [TestMethod]
    public void IsLeapYear_ShouldBeTrue_GivenMultipleOf4Or400()
    {
        Assert.IsTrue(((short)-401).IsLeapYear());
        Assert.IsTrue(((short)-105).IsLeapYear());
        Assert.IsTrue(((short)4).IsLeapYear());
        Assert.IsTrue(((short)104).IsLeapYear());
        Assert.IsTrue(((short)400).IsLeapYear());
        Assert.IsTrue(((short)2000).IsLeapYear());
    }

    [TestMethod]
    public void IsLeapYear_ShouldThrow_GivenZero()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((short)0).IsLeapYear());
    }

    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeNegative_GivenMinusOne()
    {
        Assert.IsTrue(((short)-1).Ticks() < TimeSpan.Zero);
        Assert.IsTrue(((short)-1).Milliseconds() < TimeSpan.Zero);
        Assert.IsTrue(((short)-1).Seconds() < TimeSpan.Zero);
        Assert.IsTrue(((short)-1).Minutes() < TimeSpan.Zero);
        Assert.IsTrue(((short)-1).Days() < TimeSpan.Zero);
        Assert.IsTrue(((short)-1).Hours() < TimeSpan.Zero);
        Assert.IsTrue(((short)-1).Weeks() < TimeSpan.Zero);
    }

    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.IsTrue(((short)1).Ticks() > TimeSpan.Zero);
        Assert.IsTrue(((short)1).Milliseconds() > TimeSpan.Zero);
        Assert.IsTrue(((short)1).Seconds() > TimeSpan.Zero);
        Assert.IsTrue(((short)1).Minutes() > TimeSpan.Zero);
        Assert.IsTrue(((short)1).Days() > TimeSpan.Zero);
        Assert.IsTrue(((short)1).Hours() > TimeSpan.Zero);
        Assert.IsTrue(((short)1).Weeks() > TimeSpan.Zero);
    }

    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.AreEqual(TimeSpan.Zero, ((short)0).Ticks());
        Assert.AreEqual(TimeSpan.Zero, ((short)0).Milliseconds());
        Assert.AreEqual(TimeSpan.Zero, ((short)0).Seconds());
        Assert.AreEqual(TimeSpan.Zero, ((short)0).Minutes());
        Assert.AreEqual(TimeSpan.Zero, ((short)0).Days());
        Assert.AreEqual(TimeSpan.Zero, ((short)0).Hours());
        Assert.AreEqual(TimeSpan.Zero, ((short)0).Weeks());
    }
}
