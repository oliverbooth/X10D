using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
public class TimeSpanParserTests
{
    [TestMethod]
    public void TryParse_ShouldThrow_GivenNullString()
    {
        string? value = null;
        Assert.ThrowsException<ArgumentNullException>(() => TimeSpanParser.TryParse(value!, out _));
    }
}
