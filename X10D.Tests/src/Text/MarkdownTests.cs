using NUnit.Framework;
using X10D.Text;

namespace X10D.Tests.Text;

[TestFixture]
internal class MarkdownTests
{
    [Test]
    public void MDBold_ShouldThrowArgumentNullException_GivenNull()
    {
        Assert.Throws<ArgumentNullException>(() => ((string)null!).MDBold());
    }

    [Test]
    public void MDBold_ShouldReturnBoldText_GivenText()
    {
        Assert.That("Hello, world!".MDBold(), Is.EqualTo("**Hello, world!**"));
    }

    [Test]
    public void MDCode_ShouldThrowArgumentNullException_GivenNull()
    {
        Assert.Throws<ArgumentNullException>(() => ((string)null!).MDCode());
    }

    [Test]
    public void MDCode_ShouldReturnCodeText_GivenText()
    {
        Assert.That("Hello, world!".MDCode(), Is.EqualTo("`Hello, world!`"));
    }

    [Test]
    public void MDCodeBlock_ShouldThrowArgumentNullException_GivenNull()
    {
        Assert.Throws<ArgumentNullException>(() => ((string)null!).MDCodeBlock());
    }

    [Test]
    public void MDCodeBlock_ShouldReturnCodeBlockText_GivenText()
    {
        var expected = $"```{Environment.NewLine}Hello, world!{Environment.NewLine}```";
        string actual = "Hello, world!".MDCodeBlock();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void MDCodeBlock_ShouldReturnCodeBlockText_GivenTextAndLanguage()
    {
        var expected = $"```csharp{Environment.NewLine}Hello, world!{Environment.NewLine}```";
        string actual = "Hello, world!".MDCodeBlock("csharp");

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void MDHeading_ShouldThrowArgumentNullException_GivenNull()
    {
        Assert.Throws<ArgumentNullException>(() => ((string)null!).MDHeading(1));
    }

    [Test]
    public void MDHeading_ShouldThrowArgumentOutOfRangeException_GivenInvalidHeading()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => "Hello, world!".MDHeading(0));
        Assert.Throws<ArgumentOutOfRangeException>(() => "Hello, world!".MDHeading(7));
    }

    [Test]
    public void MDHeading_ShouldReturnHeadingText_GivenText()
    {
        Assert.Multiple(() =>
        {
            Assert.That("Hello, world!".MDHeading(1), Is.EqualTo("# Hello, world!"));
            Assert.That("Hello, world!".MDHeading(2), Is.EqualTo("## Hello, world!"));
            Assert.That("Hello, world!".MDHeading(3), Is.EqualTo("### Hello, world!"));
            Assert.That("Hello, world!".MDHeading(4), Is.EqualTo("#### Hello, world!"));
            Assert.That("Hello, world!".MDHeading(5), Is.EqualTo("##### Hello, world!"));
            Assert.That("Hello, world!".MDHeading(6), Is.EqualTo("###### Hello, world!"));
        });
    }

    [Test]
    public void MDItalic_ShouldThrowArgumentNullException_GivenNull()
    {
        Assert.Throws<ArgumentNullException>(() => ((string)null!).MDItalic());
    }

    [Test]
    public void MDItalic_ShouldReturnItalicTextWithAsterisk_GivenText()
    {
        Assert.That("Hello, world!".MDItalic(), Is.EqualTo("*Hello, world!*"));
    }

    [Test]
    public void MDItalic_ShouldReturnItalicTextWithAsterisk_GivenText_AndFalseUnderscoreFlag()
    {
        Assert.That("Hello, world!".MDItalic(false), Is.EqualTo("*Hello, world!*"));
    }

    [Test]
    public void MDItalic_ShouldReturnItalicTextWithUnderscores_GivenText_AndTrueUnderscoreFlag()
    {
        Assert.That("Hello, world!".MDItalic(true), Is.EqualTo("_Hello, world!_"));
    }

    [Test]
    public void MDLink_ShouldThrowArgumentNullException_GivenNullUrl()
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentNullException>(() => "".MDLink((string)null!));
            Assert.Throws<ArgumentNullException>(() => "".MDLink((Uri)null!));
            Assert.Throws<ArgumentNullException>(() => ((Uri)null!).MDLink("Hello, world!"));
        });
    }

    [Test]
    public void MDLink_ShouldReturnUrlOnly_GivenNullOrEmptyLabel()
    {
        const string url = "https://example.com/";
        Assert.Multiple(() =>
        {
            Assert.That(((string)null!).MDLink(url), Is.EqualTo(url));
            Assert.That(string.Empty.MDLink(url), Is.EqualTo(url));

            Assert.That(new Uri(url).MDLink(null), Is.EqualTo(url));
            Assert.That(new Uri(url).MDLink(string.Empty), Is.EqualTo(url));
        });
    }

    [Test]
    public void MDLink_ShouldReturnFormattedLink_GivenValidLabelAndUrl()
    {
        const string url = "https://example.com/";
        const string label = "Hello, world!";

        Assert.Multiple(() =>
        {
            Assert.That(label.MDLink(url), Is.EqualTo($"[{label}]({url})"));
            Assert.That(label.MDLink(new Uri(url)), Is.EqualTo($"[{label}]({url})"));

            Assert.That(new Uri(url).MDLink(label), Is.EqualTo($"[{label}]({url})"));
        });
    }

    [Test]
    public void MDStrikeOut_ShouldThrowArgumentNullException_GivenNull()
    {
        Assert.Throws<ArgumentNullException>(() => ((string)null!).MDStrikeOut());
    }

    [Test]
    public void MDStrikeOut_ShouldReturnStrikeOutText_GivenText()
    {
        Assert.That("Hello, world!".MDStrikeOut(), Is.EqualTo("~~Hello, world!~~"));
    }

    [Test]
    public void MDUnderline_ShouldThrowArgumentNullException_GivenNull()
    {
        Assert.Throws<ArgumentNullException>(() => ((string)null!).MDUnderline());
    }

    [Test]
    public void MDUnderline_ShouldReturnUnderlineText_GivenText()
    {
        Assert.That("Hello, world!".MDUnderline(), Is.EqualTo("__Hello, world!__"));
    }
}
