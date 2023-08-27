using NUnit.Framework;
using X10D.Text;

namespace X10D.Tests.Text;

[TestFixture]
internal class CharTests
{
    [Test]
    public void IsEmoji_ShouldReturnTrue_GivenBasicEmoji()
    {
        Assert.Multiple(() =>
        {
            Assert.That('✂'.IsEmoji());
            Assert.That('✅'.IsEmoji());
            Assert.That('❎'.IsEmoji());
            Assert.That('➕'.IsEmoji());
            Assert.That('➖'.IsEmoji());
        });
    }

    [Test]
    public void IsEmoji_ShouldReturnFalse_GivenNonEmoji()
    {
        for (var letter = 'A'; letter <= 'Z'; letter++)
        {
            Assert.That(letter.IsEmoji(), Is.False);
        }
    }

    [Test]
    public void Repeat_ShouldPopulateSpanWithRepeatedCharacter_GivenValidCount()
    {
        const string expected = "aaaaaaaaaa";
        Span<char> destination = new char[10];
        'a'.Repeat(10, destination);

        Assert.That(destination.ToString(), Is.EqualTo(expected));
    }

    [Test]
    public void Repeat_ShouldOnlyWriteOneCharToSpan_GivenCount1()
    {
        Span<char> destination = new char[10];
        'a'.Repeat(1, destination);

        Assert.That(destination.ToString(), Is.EqualTo("a\0\0\0\0\0\0\0\0\0"));
    }

    [Test]
    public void Repeat_ShouldReturnRepeatedCharacter_GivenValidCount()
    {
        const string expected = "aaaaaaaaaa";
        string actual = 'a'.Repeat(10);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Repeat_ShouldReturnSingleCharString_GivenCount1()
    {
        string repeated = 'a'.Repeat(1);
        Assert.That(repeated, Has.Length.EqualTo(1));
        Assert.That(repeated, Is.EqualTo("a"));
    }

    [Test]
    public void Repeat_ShouldReturnEmptyString_GivenCount0()
    {
        Assert.That('a'.Repeat(0), Is.EqualTo(string.Empty));
    }

    [Test]
    public void Repeat_ShouldNotManipulateSpan_GivenCount0()
    {
        Span<char> destination = new char[10];
        destination.Fill(' ');
        'a'.Repeat(0, destination);

        const string expected = "          ";
        Assert.That(destination.ToString(), Is.EqualTo(expected));
    }

    [Test]
    public void Repeat_ShouldThrowArgumentOutOfRangeException_GivenNegativeCount()
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = 'a'.Repeat(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => 'a'.Repeat(-1, Span<char>.Empty));
        });
    }

    [Test]
    public void Repeat_ShouldThrowArgumentException_GivenSmallSpan()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var destination = Span<char>.Empty;
            'a'.Repeat(1, destination);
        });
    }
}
