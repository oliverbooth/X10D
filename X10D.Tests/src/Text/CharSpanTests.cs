using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Text;

namespace X10D.Tests.Text;

[TestClass]
public class CharSpanTests
{
    [TestMethod]
    public void CountSubstring_ShouldHonor_StringComparison()
    {
        Assert.AreEqual(0, "Hello World".AsSpan().CountSubstring('E'));
        Assert.AreEqual(0, "Hello World".AsSpan().CountSubstring("E".AsSpan()));
        Assert.AreEqual(1, "Hello World".AsSpan().CountSubstring("E".AsSpan(), StringComparison.OrdinalIgnoreCase));
    }

    [TestMethod]
    public void CountSubstring_ShouldReturn0_GivenNoInstanceChar()
    {
        Assert.AreEqual(0, "Hello World".AsSpan().CountSubstring('z'));
        Assert.AreEqual(0, "Hello World".AsSpan().CountSubstring("z".AsSpan()));
        Assert.AreEqual(0, "Hello World".AsSpan().CountSubstring("z".AsSpan(), StringComparison.OrdinalIgnoreCase));
    }

    [TestMethod]
    public void CountSubstring_ShouldReturn1_GivenSingleInstanceChar()
    {
        Assert.AreEqual(1, "Hello World".AsSpan().CountSubstring('e'));
        Assert.AreEqual(1, "Hello World".AsSpan().CountSubstring("e".AsSpan()));
        Assert.AreEqual(1, "Hello World".AsSpan().CountSubstring("e".AsSpan(), StringComparison.OrdinalIgnoreCase));
    }

    [TestMethod]
    public void CountSubstring_ShouldReturn0_GivenEmptyHaystack()
    {
        Assert.AreEqual(0, string.Empty.AsSpan().CountSubstring('\0'));
        Assert.AreEqual(0, string.Empty.AsSpan().CountSubstring(string.Empty.AsSpan(), StringComparison.OrdinalIgnoreCase));
    }

    [TestMethod]
    public void Split_OnEmptySpan_ShouldYieldNothing()
    {
        ReadOnlySpan<char> span = ReadOnlySpan<char>.Empty;
        Assert.AreEqual(0, span.Split(' ', Span<Range>.Empty));
    }

    [TestMethod]
    public void Split_OnOneWord_ShouldYieldLength1()
    {
        ReadOnlySpan<char> span = "Hello".AsSpan();
        Span<Range> wordRanges = stackalloc Range[1];

        Assert.AreEqual(1, span.Split(' ', wordRanges));
        Assert.AreEqual(..5, wordRanges[0]);

        Assert.AreEqual("Hello", span[wordRanges[0]].ToString());
    }

    [TestMethod]
    public void Split_OnTwoWords_ShouldYieldLength2()
    {
        ReadOnlySpan<char> span = "Hello World".AsSpan();
        Span<Range> wordRanges = stackalloc Range[2];

        Assert.AreEqual(2, span.Split(' ', wordRanges));
        Assert.AreEqual(..5, wordRanges[0]);
        Assert.AreEqual(6..11, wordRanges[1]);

        Assert.AreEqual("Hello", span[wordRanges[0]].ToString());
        Assert.AreEqual("World", span[wordRanges[1]].ToString());
    }

    [TestMethod]
    public void Split_OnThreeWords_ShouldYieldLength2()
    {
        ReadOnlySpan<char> span = "Hello, the World".AsSpan();
        Span<Range> wordRanges = stackalloc Range[3];

        Assert.AreEqual(3, span.Split(' ', wordRanges));
        Assert.AreEqual(..6, wordRanges[0]);
        Assert.AreEqual(7..10, wordRanges[1]);
        Assert.AreEqual(11..16, wordRanges[2]);

        Assert.AreEqual("Hello,", span[wordRanges[0]].ToString());
        Assert.AreEqual("the", span[wordRanges[1]].ToString());
        Assert.AreEqual("World", span[wordRanges[2]].ToString());
    }
}
