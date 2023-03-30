using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Text;

namespace X10D.Tests.Text;

[TestClass]
public class CharSpanTests
{
    [TestMethod]
    public void CountSubstring_ShouldHonor_StringComparison()
    {
        var readOnlySpan = "Hello World".AsSpan();
        Span<char> span = stackalloc char[readOnlySpan.Length];
        readOnlySpan.CopyTo(span);

        Assert.AreEqual(0, readOnlySpan.CountSubstring('E'));
        Assert.AreEqual(0, readOnlySpan.CountSubstring("E".AsSpan()));
        Assert.AreEqual(1, readOnlySpan.CountSubstring("E".AsSpan(), StringComparison.OrdinalIgnoreCase));

        Assert.AreEqual(0, span.CountSubstring('E'));
        Assert.AreEqual(0, span.CountSubstring("E".AsSpan()));
        Assert.AreEqual(1, span.CountSubstring("E".AsSpan(), StringComparison.OrdinalIgnoreCase));
    }

    [TestMethod]
    public void CountSubstring_ShouldReturn0_GivenNoInstanceChar()
    {
        var readOnlySpan = "Hello World".AsSpan();
        Span<char> span = stackalloc char[readOnlySpan.Length];
        readOnlySpan.CopyTo(span);

        Assert.AreEqual(0, readOnlySpan.CountSubstring('z'));
        Assert.AreEqual(0, readOnlySpan.CountSubstring("z".AsSpan()));
        Assert.AreEqual(0, readOnlySpan.CountSubstring("z".AsSpan(), StringComparison.OrdinalIgnoreCase));

        Assert.AreEqual(0, span.CountSubstring('z'));
        Assert.AreEqual(0, span.CountSubstring("z".AsSpan()));
        Assert.AreEqual(0, span.CountSubstring("z".AsSpan(), StringComparison.OrdinalIgnoreCase));
    }

    [TestMethod]
    public void CountSubstring_ShouldReturn1_GivenSingleInstanceChar()
    {
        var readOnlySpan = "Hello World".AsSpan();
        Span<char> span = stackalloc char[readOnlySpan.Length];
        readOnlySpan.CopyTo(span);

        Assert.AreEqual(1, readOnlySpan.CountSubstring('e'));
        Assert.AreEqual(1, readOnlySpan.CountSubstring("e".AsSpan()));
        Assert.AreEqual(1, readOnlySpan.CountSubstring("e".AsSpan(), StringComparison.OrdinalIgnoreCase));

        Assert.AreEqual(1, span.CountSubstring('e'));
        Assert.AreEqual(1, span.CountSubstring("e".AsSpan()));
        Assert.AreEqual(1, span.CountSubstring("e".AsSpan(), StringComparison.OrdinalIgnoreCase));
    }

    [TestMethod]
    public void CountSubstring_ShouldReturn0_GivenEmptyHaystack()
    {
        Assert.AreEqual(0, string.Empty.AsSpan().CountSubstring('\0'));
        Assert.AreEqual(0, string.Empty.AsSpan().CountSubstring(string.Empty.AsSpan(), StringComparison.OrdinalIgnoreCase));
    }
}
