#if NETCOREAPP3_0_OR_GREATER
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Text;

namespace X10D.Tests.Text;

[TestClass]
public class RuneTests
{
    [TestMethod]
    public void IsEmoji_ShouldReturnTrue_GivenBasicEmoji()
    {
        Assert.IsTrue(new Rune('✂').IsEmoji());
        Assert.IsTrue(new Rune('✅').IsEmoji());
        Assert.IsTrue(new Rune('❎').IsEmoji());
        Assert.IsTrue(new Rune('➕').IsEmoji());
        Assert.IsTrue(new Rune('➖').IsEmoji());
    }

    [TestMethod]
    public void IsEmoji_ShouldReturnFalse_GivenNonEmoji()
    {
        for (var letter = 'A'; letter <= 'Z'; letter++)
        {
            Assert.IsFalse(new Rune(letter).IsEmoji());
        }
    }

    [TestMethod]
    public void RepeatShouldBeCorrect()
    {
        const string expected = "aaaaaaaaaa";
        var rune = new Rune('a');
        string actual = rune.Repeat(10);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void RepeatOneCountShouldBeLength1String()
    {
        string repeated = new Rune('a').Repeat(1);
        Assert.AreEqual(1, repeated.Length);
        Assert.AreEqual("a", repeated);
    }

    [TestMethod]
    public void RepeatCodepoint_0000_007F_ShouldCorrect()
    {
        string repeated = new Rune(69).Repeat(16);
        Assert.AreEqual(16, repeated.Length);
        Assert.AreEqual("EEEEEEEEEEEEEEEE", repeated);
    }

    [TestMethod]
    public void RepeatCodepoint_0080_07FF_ShouldCorrect()
    {
        string repeated = new Rune(192).Repeat(8);
        Assert.AreEqual(8, repeated.Length);
        Assert.AreEqual("ÀÀÀÀÀÀÀÀ", repeated);
    }

    [TestMethod]
    public void RepeatCodepoint_0800_FFFF_ShouldCorrect()
    {
        string repeated = new Rune(0x0800).Repeat(5);
        Assert.AreEqual(5, repeated.Length);
        Assert.AreEqual("ࠀࠀࠀࠀࠀ", repeated);
    }

    [TestMethod]
    public void RepeatCodepointBeyondU10000ShouldCorrect()
    {
        string repeated = new Rune('\uD800', '\uDC00').Repeat(6);
        Assert.AreEqual(12, repeated.Length);
        Assert.AreEqual("𐀀𐀀𐀀𐀀𐀀𐀀", repeated);
    }

    [TestMethod]
    public void RepeatZeroCountShouldBeEmpty()
    {
        Assert.AreEqual(string.Empty, new Rune('a').Repeat(0));
    }

    [TestMethod]
    public void RepeatNegativeCountShouldThrow()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Rune('a').Repeat(-1));
    }
}
#endif
