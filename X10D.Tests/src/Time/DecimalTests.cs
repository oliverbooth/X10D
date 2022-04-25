using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
public class DecimalTests
{
    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.AreEqual(TimeSpan.Zero, 0m.Milliseconds());
        Assert.AreEqual(TimeSpan.Zero, 0m.Seconds());
        Assert.AreEqual(TimeSpan.Zero, 0m.Minutes());
        Assert.AreEqual(TimeSpan.Zero, 0m.Days());
        Assert.AreEqual(TimeSpan.Zero, 0m.Hours());
        Assert.AreEqual(TimeSpan.Zero, 0m.Weeks());
    }

    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.IsTrue(1m.Milliseconds() > TimeSpan.Zero);
        Assert.IsTrue(1m.Seconds() > TimeSpan.Zero);
        Assert.IsTrue(1m.Minutes() > TimeSpan.Zero);
        Assert.IsTrue(1m.Days() > TimeSpan.Zero);
        Assert.IsTrue(1m.Hours() > TimeSpan.Zero);
        Assert.IsTrue(1m.Weeks() > TimeSpan.Zero);
    }

    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeNegative_GivenMinusOne()
    {
        Assert.IsTrue((-1m).Milliseconds() < TimeSpan.Zero);
        Assert.IsTrue((-1m).Seconds() < TimeSpan.Zero);
        Assert.IsTrue((-1m).Minutes() < TimeSpan.Zero);
        Assert.IsTrue((-1m).Days() < TimeSpan.Zero);
        Assert.IsTrue((-1m).Hours() < TimeSpan.Zero);
        Assert.IsTrue((-1m).Weeks() < TimeSpan.Zero);
    }
}
