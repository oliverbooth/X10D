#if NETCOREAPP3_0_OR_GREATER
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Text;

namespace X10D.Tests.Text;

[TestClass]
public class RuneTests
{
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
