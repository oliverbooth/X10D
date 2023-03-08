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
}
