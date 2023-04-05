using NUnit.Framework;
using X10D.Time;

namespace X10D.Tests.Time;

[TestFixture]
public class StringTests
{
    [Test]
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

        Assert.That(value.ToTimeSpan(), Is.EqualTo(expected));
    }

    [Test]
    public void ToTimeSpan_ShouldReturnZero_GivenInvalidString()
    {
        Assert.That("Hello World".ToTimeSpan(), Is.EqualTo(TimeSpan.Zero));
    }

    [Test]
    public void ToTimeSpan_ShouldThrow_GivenNullString()
    {
        string? value = null;
        Assert.Throws<ArgumentNullException>(() => value!.ToTimeSpan());
    }
}
