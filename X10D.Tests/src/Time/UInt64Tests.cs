using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
[CLSCompliant(false)]
public class UInt64Tests
{
    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.IsTrue(1UL.Ticks() > TimeSpan.Zero);
        Assert.IsTrue(1UL.Milliseconds() > TimeSpan.Zero);
        Assert.IsTrue(1UL.Seconds() > TimeSpan.Zero);
        Assert.IsTrue(1UL.Minutes() > TimeSpan.Zero);
        Assert.IsTrue(1UL.Days() > TimeSpan.Zero);
        Assert.IsTrue(1UL.Hours() > TimeSpan.Zero);
        Assert.IsTrue(1UL.Weeks() > TimeSpan.Zero);
    }

    [TestMethod]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.AreEqual(TimeSpan.Zero, 0UL.Ticks());
        Assert.AreEqual(TimeSpan.Zero, 0UL.Milliseconds());
        Assert.AreEqual(TimeSpan.Zero, 0UL.Seconds());
        Assert.AreEqual(TimeSpan.Zero, 0UL.Minutes());
        Assert.AreEqual(TimeSpan.Zero, 0UL.Days());
        Assert.AreEqual(TimeSpan.Zero, 0UL.Hours());
        Assert.AreEqual(TimeSpan.Zero, 0UL.Weeks());
    }
}
