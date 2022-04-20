using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X10D.Tests.Core;

[TestClass]
public class SingleTests
{
    [TestMethod]
    public void DegreesToRadians()
    {
        Assert.AreEqual(MathF.PI, 180.0f.DegreesToRadians());
        Assert.AreEqual(MathF.PI * 1.5f, 270.0f.DegreesToRadians());
        Assert.AreEqual(0.0f, 0.0f.DegreesToRadians());
        Assert.AreEqual(0.017453292f, 1.0f.DegreesToRadians());
        Assert.AreEqual(0.10471976f, 6.0f.DegreesToRadians());
        Assert.AreEqual(0.20943952f, 12.0f.DegreesToRadians());
    }

    [TestMethod]
    public void RadiansToDegrees()
    {
        Assert.AreEqual(180.0f, MathF.PI.RadiansToDegrees());
        Assert.AreEqual(270.0f, (MathF.PI * 1.5f).RadiansToDegrees());
        Assert.AreEqual(0.0, 0.0f.RadiansToDegrees());
        Assert.AreEqual(0.99999994f, 0.017453292f.RadiansToDegrees()); // rounding errors are fun
        Assert.AreEqual(6.0f, 0.10471976f.RadiansToDegrees());
        Assert.AreEqual(12.0f, 0.20943952f.RadiansToDegrees());
    }
}
