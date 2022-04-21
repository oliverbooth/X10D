using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
public class DoubleTests
{
    private Half _negativeOne;
    private Half _one;
    private Half _zero;

    [TestInitialize]
    public void Initialize()
    {
        _negativeOne = (Half)(-1);
        _one = (Half)1;
        _zero = (Half)0;
    }

    [TestMethod]
    public void ZeroShouldBeZeroTimeSpan()
    {
        Assert.AreEqual(TimeSpan.Zero, _zero.Milliseconds());
        Assert.AreEqual(TimeSpan.Zero, _zero.Seconds());
        Assert.AreEqual(TimeSpan.Zero, _zero.Minutes());
        Assert.AreEqual(TimeSpan.Zero, _zero.Days());
        Assert.AreEqual(TimeSpan.Zero, _zero.Hours());
        Assert.AreEqual(TimeSpan.Zero, _zero.Weeks());
    }

    [TestMethod]
    public void OneShouldBePositive()
    {
        Assert.IsTrue(_one.Milliseconds() > TimeSpan.Zero);
        Assert.IsTrue(_one.Seconds() > TimeSpan.Zero);
        Assert.IsTrue(_one.Minutes() > TimeSpan.Zero);
        Assert.IsTrue(_one.Days() > TimeSpan.Zero);
        Assert.IsTrue(_one.Hours() > TimeSpan.Zero);
        Assert.IsTrue(_one.Weeks() > TimeSpan.Zero);
    }

    [TestMethod]
    public void MinusOneShouldBeNegative()
    {
        Assert.IsTrue((_negativeOne).Milliseconds() < TimeSpan.Zero);
        Assert.IsTrue((_negativeOne).Seconds() < TimeSpan.Zero);
        Assert.IsTrue((_negativeOne).Minutes() < TimeSpan.Zero);
        Assert.IsTrue((_negativeOne).Days() < TimeSpan.Zero);
        Assert.IsTrue((_negativeOne).Hours() < TimeSpan.Zero);
        Assert.IsTrue((_negativeOne).Weeks() < TimeSpan.Zero);
    }
}
