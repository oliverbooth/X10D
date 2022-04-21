using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
[CLSCompliant(false)]
public class UInt32Tests
{
    [TestMethod]
    public void Zero_Should_Be_Zero_TimeSpan()
    {
        Assert.AreEqual(TimeSpan.Zero, 0U.Ticks());
        Assert.AreEqual(TimeSpan.Zero, 0U.Milliseconds());
        Assert.AreEqual(TimeSpan.Zero, 0U.Seconds());
        Assert.AreEqual(TimeSpan.Zero, 0U.Minutes());
        Assert.AreEqual(TimeSpan.Zero, 0U.Days());
        Assert.AreEqual(TimeSpan.Zero, 0U.Hours());
        Assert.AreEqual(TimeSpan.Zero, 0U.Weeks());
    }

    [TestMethod]
    public void One_Should_Be_Positive()
    {
        Assert.IsTrue(1U.Ticks() > TimeSpan.Zero);
        Assert.IsTrue(1U.Milliseconds() > TimeSpan.Zero);
        Assert.IsTrue(1U.Seconds() > TimeSpan.Zero);
        Assert.IsTrue(1U.Minutes() > TimeSpan.Zero);
        Assert.IsTrue(1U.Days() > TimeSpan.Zero);
        Assert.IsTrue(1U.Hours() > TimeSpan.Zero);
        Assert.IsTrue(1U.Weeks() > TimeSpan.Zero);
    }
}
