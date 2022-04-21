using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
public class Int64Tests
{
    [TestMethod]
    public void Zero_Should_Be_Zero_TimeSpan()
    {
        Assert.AreEqual(TimeSpan.Zero, 0L.Ticks());
        Assert.AreEqual(TimeSpan.Zero, 0L.Milliseconds());
        Assert.AreEqual(TimeSpan.Zero, 0L.Seconds());
        Assert.AreEqual(TimeSpan.Zero, 0L.Minutes());
        Assert.AreEqual(TimeSpan.Zero, 0L.Days());
        Assert.AreEqual(TimeSpan.Zero, 0L.Hours());
        Assert.AreEqual(TimeSpan.Zero, 0L.Weeks());
    }

    [TestMethod]
    public void One_Should_Be_Positive()
    {
        Assert.IsTrue(1L.Ticks() > TimeSpan.Zero);
        Assert.IsTrue(1L.Milliseconds() > TimeSpan.Zero);
        Assert.IsTrue(1L.Seconds() > TimeSpan.Zero);
        Assert.IsTrue(1L.Minutes() > TimeSpan.Zero);
        Assert.IsTrue(1L.Days() > TimeSpan.Zero);
        Assert.IsTrue(1L.Hours() > TimeSpan.Zero);
        Assert.IsTrue(1L.Weeks() > TimeSpan.Zero);
    }

    [TestMethod]
    public void MinusOne_Should_Be_Negative()
    {
        Assert.IsTrue((-1L).Ticks() < TimeSpan.Zero);
        Assert.IsTrue((-1L).Milliseconds() < TimeSpan.Zero);
        Assert.IsTrue((-1L).Seconds() < TimeSpan.Zero);
        Assert.IsTrue((-1L).Minutes() < TimeSpan.Zero);
        Assert.IsTrue((-1L).Days() < TimeSpan.Zero);
        Assert.IsTrue((-1L).Hours() < TimeSpan.Zero);
        Assert.IsTrue((-1L).Weeks() < TimeSpan.Zero);
    }
}
