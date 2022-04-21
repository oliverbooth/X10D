using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
public class ByteTests
{
    [TestMethod]
    public void Zero_Should_Be_Zero_TimeSpan()
    {
        Assert.AreEqual(TimeSpan.Zero, ((byte)0).Ticks());
        Assert.AreEqual(TimeSpan.Zero, ((byte)0).Milliseconds());
        Assert.AreEqual(TimeSpan.Zero, ((byte)0).Seconds());
        Assert.AreEqual(TimeSpan.Zero, ((byte)0).Minutes());
        Assert.AreEqual(TimeSpan.Zero, ((byte)0).Days());
        Assert.AreEqual(TimeSpan.Zero, ((byte)0).Hours());
        Assert.AreEqual(TimeSpan.Zero, ((byte)0).Weeks());
    }

    [TestMethod]
    public void One_Should_Be_Positive()
    {
        Assert.IsTrue(((byte)1).Ticks() > TimeSpan.Zero);
        Assert.IsTrue(((byte)1).Milliseconds() > TimeSpan.Zero);
        Assert.IsTrue(((byte)1).Seconds() > TimeSpan.Zero);
        Assert.IsTrue(((byte)1).Minutes() > TimeSpan.Zero);
        Assert.IsTrue(((byte)1).Days() > TimeSpan.Zero);
        Assert.IsTrue(((byte)1).Hours() > TimeSpan.Zero);
        Assert.IsTrue(((byte)1).Weeks() > TimeSpan.Zero);
    }
}
