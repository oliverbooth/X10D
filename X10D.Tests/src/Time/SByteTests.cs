using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
[CLSCompliant(false)]
public class SByteTests
{
    [TestMethod]
    public void FromUnixTimeMilliseconds_ShouldBeEpoch_GivenZero()
    {
        Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), ((sbyte)0).FromUnixTimeMilliseconds());
    }

    [TestMethod]
    public void FromUnixTimeSeconds_ShouldBeEpoch_GivenZero()
    {
        Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), ((sbyte)0).FromUnixTimeSeconds());
    }

    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.AreEqual(TimeSpan.Zero, ((sbyte)0).Ticks());
        Assert.AreEqual(TimeSpan.Zero, ((sbyte)0).Milliseconds());
        Assert.AreEqual(TimeSpan.Zero, ((sbyte)0).Seconds());
        Assert.AreEqual(TimeSpan.Zero, ((sbyte)0).Minutes());
        Assert.AreEqual(TimeSpan.Zero, ((sbyte)0).Days());
        Assert.AreEqual(TimeSpan.Zero, ((sbyte)0).Hours());
        Assert.AreEqual(TimeSpan.Zero, ((sbyte)0).Weeks());
    }

    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.IsTrue(((sbyte)1).Ticks() > TimeSpan.Zero);
        Assert.IsTrue(((sbyte)1).Milliseconds() > TimeSpan.Zero);
        Assert.IsTrue(((sbyte)1).Seconds() > TimeSpan.Zero);
        Assert.IsTrue(((sbyte)1).Minutes() > TimeSpan.Zero);
        Assert.IsTrue(((sbyte)1).Days() > TimeSpan.Zero);
        Assert.IsTrue(((sbyte)1).Hours() > TimeSpan.Zero);
        Assert.IsTrue(((sbyte)1).Weeks() > TimeSpan.Zero);
    }

    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeNegative_GivenMinusOne()
    {
        Assert.IsTrue(((sbyte)-1).Ticks() < TimeSpan.Zero);
        Assert.IsTrue(((sbyte)-1).Milliseconds() < TimeSpan.Zero);
        Assert.IsTrue(((sbyte)-1).Seconds() < TimeSpan.Zero);
        Assert.IsTrue(((sbyte)-1).Minutes() < TimeSpan.Zero);
        Assert.IsTrue(((sbyte)-1).Days() < TimeSpan.Zero);
        Assert.IsTrue(((sbyte)-1).Hours() < TimeSpan.Zero);
        Assert.IsTrue(((sbyte)-1).Weeks() < TimeSpan.Zero);
    }
}
