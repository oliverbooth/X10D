using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
public class TimeSpanParserTests
{
    [TestMethod]
    public void TryParse_ShouldReturnTrue_GivenWellFormedTimeSpan()
    {
        bool result = TimeSpanParser.TryParse("3d6h", out TimeSpan timeSpan);
        Assert.IsTrue(result);
        Assert.AreEqual(TimeSpan.FromDays(3) + TimeSpan.FromHours(6), timeSpan);
    }

    [TestMethod]
    public void TryParse_ShouldReturnFalse_GivenMalformedTimeSpan()
    {
        bool result = TimeSpanParser.TryParse("asdf", out TimeSpan timeSpan);
        Assert.IsFalse(result);
        Assert.AreEqual(default, timeSpan);
    }

    [TestMethod]
    public void TryParse_ShouldReturnFalse_GivenNull()
    {
        bool result = TimeSpanParser.TryParse(null, out TimeSpan timeSpan);
        Assert.IsFalse(result);
        Assert.AreEqual(default, timeSpan);
    }
}
