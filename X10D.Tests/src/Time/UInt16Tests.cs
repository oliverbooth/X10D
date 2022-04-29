using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
[CLSCompliant(false)]
public class UInt16Tests
{
    [TestMethod]
    public void FromUnixTimeMilliseconds_ShouldBeEpoch_GivenZero()
    {
        Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), ((ushort)0).FromUnixTimeMilliseconds());
    }

    [TestMethod]
    public void FromUnixTimeSeconds_ShouldBeEpoch_GivenZero()
    {
        Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), ((ushort)0).FromUnixTimeSeconds());
    }

    [TestMethod]
    public void IsLeapYear_ShouldBeFalse_GivenMultipleOf100()
    {
        Assert.IsFalse(((ushort)100).IsLeapYear());
        Assert.IsFalse(((ushort)1900).IsLeapYear());
        Assert.IsFalse(((ushort)2100).IsLeapYear());
    }

    [TestMethod]
    public void IsLeapYear_ShouldBeFalse_GivenOddNumber()
    {
        Assert.IsFalse(((ushort)1).IsLeapYear());
        Assert.IsFalse(((ushort)101).IsLeapYear());
    }

    [TestMethod]
    public void IsLeapYear_ShouldBeTrue_GivenMultipleOf4Or400()
    {
        Assert.IsTrue(((ushort)4).IsLeapYear());
        Assert.IsTrue(((ushort)104).IsLeapYear());
        Assert.IsTrue(((ushort)400).IsLeapYear());
        Assert.IsTrue(((ushort)2000).IsLeapYear());
    }

    [TestMethod]
    public void IsLeapYear_ShouldThrow_GivenZero()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((ushort)0).IsLeapYear());
    }

    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.IsTrue(((ushort)1).Ticks() > TimeSpan.Zero);
        Assert.IsTrue(((ushort)1).Milliseconds() > TimeSpan.Zero);
        Assert.IsTrue(((ushort)1).Seconds() > TimeSpan.Zero);
        Assert.IsTrue(((ushort)1).Minutes() > TimeSpan.Zero);
        Assert.IsTrue(((ushort)1).Days() > TimeSpan.Zero);
        Assert.IsTrue(((ushort)1).Hours() > TimeSpan.Zero);
        Assert.IsTrue(((ushort)1).Weeks() > TimeSpan.Zero);
    }

    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.AreEqual(TimeSpan.Zero, ((ushort)0).Ticks());
        Assert.AreEqual(TimeSpan.Zero, ((ushort)0).Milliseconds());
        Assert.AreEqual(TimeSpan.Zero, ((ushort)0).Seconds());
        Assert.AreEqual(TimeSpan.Zero, ((ushort)0).Minutes());
        Assert.AreEqual(TimeSpan.Zero, ((ushort)0).Days());
        Assert.AreEqual(TimeSpan.Zero, ((ushort)0).Hours());
        Assert.AreEqual(TimeSpan.Zero, ((ushort)0).Weeks());
    }
}
