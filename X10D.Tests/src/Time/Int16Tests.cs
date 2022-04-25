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
