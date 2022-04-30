using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
public class SingleTests
{
    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.AreEqual(TimeSpan.Zero, 0f.Milliseconds());
        Assert.AreEqual(TimeSpan.Zero, 0f.Seconds());
        Assert.AreEqual(TimeSpan.Zero, 0f.Minutes());
        Assert.AreEqual(TimeSpan.Zero, 0f.Days());
        Assert.AreEqual(TimeSpan.Zero, 0f.Hours());
        Assert.AreEqual(TimeSpan.Zero, 0f.Weeks());
    }

    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.IsTrue(1f.Milliseconds() > TimeSpan.Zero);
        Assert.IsTrue(1f.Seconds() > TimeSpan.Zero);
        Assert.IsTrue(1f.Minutes() > TimeSpan.Zero);
        Assert.IsTrue(1f.Days() > TimeSpan.Zero);
        Assert.IsTrue(1f.Hours() > TimeSpan.Zero);
        Assert.IsTrue(1f.Weeks() > TimeSpan.Zero);
    }

    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeNegative_GivenMinusOne()
    {
        Assert.IsTrue((-1f).Milliseconds() < TimeSpan.Zero);
        Assert.IsTrue((-1f).Seconds() < TimeSpan.Zero);
        Assert.IsTrue((-1f).Minutes() < TimeSpan.Zero);
        Assert.IsTrue((-1f).Days() < TimeSpan.Zero);
        Assert.IsTrue((-1f).Hours() < TimeSpan.Zero);
        Assert.IsTrue((-1f).Weeks() < TimeSpan.Zero);
    }
}
