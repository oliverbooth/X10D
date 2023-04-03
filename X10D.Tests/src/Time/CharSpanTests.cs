using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
public class CharSpanTests
{
    [TestMethod]
    public void ToTimeSpan_ShouldReturnCorrectTimeSpan_GivenSpanOfCharacters()
    {
        ReadOnlySpan<char> value = "1y 1mo 1w 1d 1h 1m 1s 1ms".AsSpan();

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
    public void ToTimeSpan_ShouldReturnZero_GivenInvalidSpanOfCharacters()
    {
        Assert.AreEqual(TimeSpan.Zero, "Hello World".AsSpan().ToTimeSpan());
    }
}
