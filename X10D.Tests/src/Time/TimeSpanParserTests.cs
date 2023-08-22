using NUnit.Framework;
using X10D.Time;

namespace X10D.Tests.Time;

[TestFixture]
internal class TimeSpanParserTests
{
    [Test]
    public void TryParse_ShouldReturnTrue_GivenWellFormedTimeSpan()
    {
        bool result = TimeSpanParser.TryParse("3d6h", out TimeSpan timeSpan);
        Assert.Multiple(() =>
        {
            Assert.That(result);
            Assert.That(timeSpan, Is.EqualTo(TimeSpan.FromDays(3) + TimeSpan.FromHours(6)));
        });
    }

    [Test]
    public void TryParse_ShouldReturnFalse_GivenMalformedTimeSpan()
    {
        bool result = TimeSpanParser.TryParse("asdf", out TimeSpan timeSpan);
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.False);
            Assert.That(timeSpan, Is.EqualTo(default(TimeSpan)));
        });
    }

    [Test]
    public void TryParse_ShouldReturnFalse_GivenEmptySpan()
    {
        bool result = TimeSpanParser.TryParse(ReadOnlySpan<char>.Empty, out TimeSpan timeSpan);
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.False);
            Assert.That(timeSpan, Is.EqualTo(default(TimeSpan)));
        });
    }

    [Test]
    public void TryParse_ShouldReturnFalse_GivenWhiteSpaceSpan()
    {
        bool result = TimeSpanParser.TryParse("   ".AsSpan(), out TimeSpan timeSpan);
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.False);
            Assert.That(timeSpan, Is.EqualTo(default(TimeSpan)));
        });
    }

    [Test]
    public void TryParse_ShouldReturnFalse_GivenEmptyString()
    {
        bool result = TimeSpanParser.TryParse(string.Empty, out TimeSpan timeSpan);
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.False);
            Assert.That(timeSpan, Is.EqualTo(default(TimeSpan)));
        });
    }

    [Test]
    public void TryParse_ShouldReturnFalse_GivenWhiteSpaceString()
    {
        bool result = TimeSpanParser.TryParse("   ", out TimeSpan timeSpan);
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.False);
            Assert.That(timeSpan, Is.EqualTo(default(TimeSpan)));
        });
    }

    [Test]
    public void TryParse_ShouldReturnFalse_GivenNull()
    {
        bool result = TimeSpanParser.TryParse(null, out TimeSpan timeSpan);
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.False);
            Assert.That(timeSpan, Is.EqualTo(default(TimeSpan)));
        });
    }
}
