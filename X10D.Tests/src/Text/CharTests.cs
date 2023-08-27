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
    public void RepeatShouldBeCorrect()
    {
        const string expected = "aaaaaaaaaa";
        string actual = 'a'.Repeat(10);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void RepeatOneCountShouldBeLength1String()
    {
        string repeated = 'a'.Repeat(1);
        Assert.That(repeated, Has.Length.EqualTo(1));
        Assert.That(repeated, Is.EqualTo("a"));
    }

    [Test]
    public void RepeatZeroCountShouldBeEmpty()
    {
        Assert.That('a'.Repeat(0), Is.EqualTo(string.Empty));
    }

    [Test]
    public void RepeatNegativeCountShouldThrow()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = 'a'.Repeat(-1));
    }
}
