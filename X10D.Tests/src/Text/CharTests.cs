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
    public void Repeat_ShouldThrowArgumentOutOfRangeException_GivenNegativeCount()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = 'a'.Repeat(-1));
    }
}
