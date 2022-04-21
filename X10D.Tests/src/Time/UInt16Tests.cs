using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
[CLSCompliant(false)]
public class UInt16Tests
{
    [TestMethod]
    public void ZeroShouldBeZeroTimeSpan()
    {
        Assert.AreEqual(TimeSpan.Zero, ((ushort)0).Ticks());
        Assert.AreEqual(TimeSpan.Zero, ((ushort)0).Milliseconds());
        Assert.AreEqual(TimeSpan.Zero, ((ushort)0).Seconds());
        Assert.AreEqual(TimeSpan.Zero, ((ushort)0).Minutes());
        Assert.AreEqual(TimeSpan.Zero, ((ushort)0).Days());
        Assert.AreEqual(TimeSpan.Zero, ((ushort)0).Hours());
        Assert.AreEqual(TimeSpan.Zero, ((ushort)0).Weeks());
    }

    [TestMethod]
    public void OneShouldBePositive()
    {
        Assert.IsTrue(((ushort)1).Ticks() > TimeSpan.Zero);
        Assert.IsTrue(((ushort)1).Milliseconds() > TimeSpan.Zero);
        Assert.IsTrue(((ushort)1).Seconds() > TimeSpan.Zero);
        Assert.IsTrue(((ushort)1).Minutes() > TimeSpan.Zero);
        Assert.IsTrue(((ushort)1).Days() > TimeSpan.Zero);
        Assert.IsTrue(((ushort)1).Hours() > TimeSpan.Zero);
        Assert.IsTrue(((ushort)1).Weeks() > TimeSpan.Zero);
    }
}
