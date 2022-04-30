using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
public class StringTests
{
    [TestMethod]
    public void ToTimeSpan_ShouldReturnCorrectTimeSpan_GivenString()
    {
        const string value = "1y 1mo 1w 1d 1h 1m 1s 1ms";

        TimeSpan expected = TimeSpan.FromMilliseconds(1);
        expected += TimeSpan.FromSeconds(1);
        expected += TimeSpan.FromMinutes(1);
        expected += TimeSpan.FromHours(1);
        expected += TimeSpan.FromDays(1);
        expected += TimeSpan.FromDays(7);
        expected += TimeSpan.FromDays(30);
        expected += TimeSpan.FromDays(365);

        Assert.AreEqual(expected, value.ToTimeSpan());
    }

    [TestMethod]
    public void ToTimeSpan_ShouldReturnZero_GivenInvalidString()
    {
        Assert.AreEqual(TimeSpan.Zero, "Hello World".ToTimeSpan());
    }

    [TestMethod]
    public void ToTimeSpan_ShouldThrow_GivenNullString()
    {
        string? value = null;
        Assert.ThrowsException<ArgumentNullException>(() => value!.ToTimeSpan());
    }
}
