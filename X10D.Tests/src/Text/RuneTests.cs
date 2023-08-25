#if NET5_0_OR_GREATER
using System.Text;
using NUnit.Framework;
using X10D.Text;

namespace X10D.Tests.Text;

[TestFixture]
internal class RuneTests
{
    [Test]
    public void IsEmoji_ShouldReturnTrue_GivenBasicEmoji()
    {
        Assert.That(new Rune('✂').IsEmoji());
        Assert.That(new Rune('✅').IsEmoji());
        Assert.That(new Rune('❎').IsEmoji());
        Assert.That(new Rune('➕').IsEmoji());
        Assert.That(new Rune('➖').IsEmoji());
    }

    [Test]
    public void IsEmoji_ShouldReturnFalse_GivenNonEmoji()
    {
        for (var letter = 'A'; letter <= 'Z'; letter++)
        {
            Assert.That(new Rune(letter).IsEmoji(), Is.False);
        }
    }

    [Test]
    public void Repeat_ShouldRepeatRune_GivenValidCount()
    {
        const string expected = "aaaaaaaaaa";
        var rune = new Rune('a');
        string actual = rune.Repeat(10);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Repeat_ShouldReturnStringOfLength1_GivenCountOf1()
    {
        string repeated = new Rune('a').Repeat(1);
        Assert.That(repeated.Length, Is.EqualTo(1));
        Assert.That(repeated, Is.EqualTo("a"));
    }

    [Test]
    public void Repeat_ShouldThrowArgumentOutOfRangeException_GivenNegativeCount()
    {
        var rune = new Rune('a');
        Assert.Throws<ArgumentOutOfRangeException>(() => rune.Repeat(-1));
    }

    [Test]
    public void Repeat_ShouldReturnEmptyString_GivenCountOf0()
    {
        Assert.That(new Rune('a').Repeat(0), Is.EqualTo(string.Empty));
    }

    [Test]
    public void RepeatCodepoint_0000_007F_ShouldReturnString()
    {
        string repeated = new Rune(69).Repeat(16);
        Assert.That(repeated.Length, Is.EqualTo(16));
        Assert.That(repeated, Is.EqualTo("EEEEEEEEEEEEEEEE"));
    }

    [Test]
    public void RepeatCodepoint_0080_07FF_ShouldReturnString()
    {
        string repeated = new Rune(192).Repeat(8);
        Assert.That(repeated.Length, Is.EqualTo(8));
        Assert.That(repeated, Is.EqualTo("ÀÀÀÀÀÀÀÀ"));
    }

    [Test]
    public void RepeatCodepoint_0800_FFFF_ShouldReturnString()
    {
        string repeated = new Rune(0x0800).Repeat(5);
        Assert.That(repeated.Length, Is.EqualTo(5));
        Assert.That(repeated, Is.EqualTo("ࠀࠀࠀࠀࠀ"));
    }

    [Test]
    public void RepeatCodepointBeyondU10000ShouldReturnString()
    {
        string repeated = new Rune('\uD800', '\uDC00').Repeat(6);
        Assert.That(repeated.Length, Is.EqualTo(12));
        Assert.That(repeated, Is.EqualTo("𐀀𐀀𐀀𐀀𐀀𐀀"));
    }
}
#endif
