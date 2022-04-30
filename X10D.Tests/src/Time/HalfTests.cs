using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
public class HalfTests
{
    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.AreEqual(TimeSpan.Zero, 0.0.Milliseconds());
        Assert.AreEqual(TimeSpan.Zero, 0.0.Seconds());
        Assert.AreEqual(TimeSpan.Zero, 0.0.Minutes());
        Assert.AreEqual(TimeSpan.Zero, 0.0.Days());
        Assert.AreEqual(TimeSpan.Zero, 0.0.Hours());
        Assert.AreEqual(TimeSpan.Zero, 0.0.Weeks());
    }

    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.IsTrue(1.0.Milliseconds() > TimeSpan.Zero);
        Assert.IsTrue(1.0.Seconds() > TimeSpan.Zero);
        Assert.IsTrue(1.0.Minutes() > TimeSpan.Zero);
        Assert.IsTrue(1.0.Days() > TimeSpan.Zero);
        Assert.IsTrue(1.0.Hours() > TimeSpan.Zero);
        Assert.IsTrue(1.0.Weeks() > TimeSpan.Zero);
    }

    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeNegative_GivenMinusOne()
    {
        Assert.IsTrue((-1.0).Milliseconds() < TimeSpan.Zero);
        Assert.IsTrue((-1.0).Seconds() < TimeSpan.Zero);
        Assert.IsTrue((-1.0).Minutes() < TimeSpan.Zero);
        Assert.IsTrue((-1.0).Days() < TimeSpan.Zero);
        Assert.IsTrue((-1.0).Hours() < TimeSpan.Zero);
        Assert.IsTrue((-1.0).Weeks() < TimeSpan.Zero);
    }
}
