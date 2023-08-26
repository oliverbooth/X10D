using NUnit.Framework;
using X10D.Text;

namespace X10D.Tests.Text;

[TestFixture]
internal class CharSpanTests
{
    [Test]
    public void CountSubstring_ShouldHonor_StringComparison()
    {
        var readOnlySpan = "Hello World".AsSpan();
        Span<char> span = stackalloc char[readOnlySpan.Length];
        readOnlySpan.CopyTo(span);

        Assert.That(readOnlySpan.CountSubstring('E'), Is.Zero);
        Assert.That(readOnlySpan.CountSubstring("E".AsSpan()), Is.Zero);
        Assert.That(readOnlySpan.CountSubstring("E".AsSpan(), StringComparison.OrdinalIgnoreCase), Is.EqualTo(1));

        Assert.That(span.CountSubstring('E'), Is.Zero);
        Assert.That(span.CountSubstring("E".AsSpan()), Is.Zero);
        Assert.That(span.CountSubstring("E".AsSpan(), StringComparison.OrdinalIgnoreCase), Is.EqualTo(1));
    }

    [Test]
    public void CountSubstring_ShouldReturn0_GivenNoInstanceChar()
    {
        var readOnlySpan = "Hello World".AsSpan();
        Span<char> span = stackalloc char[readOnlySpan.Length];
        readOnlySpan.CopyTo(span);

        Assert.That(readOnlySpan.CountSubstring('z'), Is.Zero);
        Assert.That(readOnlySpan.CountSubstring("z".AsSpan()), Is.Zero);
        Assert.That(readOnlySpan.CountSubstring("z".AsSpan(), StringComparison.OrdinalIgnoreCase), Is.Zero);

        Assert.That(span.CountSubstring('z'), Is.Zero);
        Assert.That(span.CountSubstring("z".AsSpan()), Is.Zero);
        Assert.That(span.CountSubstring("z".AsSpan(), StringComparison.OrdinalIgnoreCase), Is.Zero);
    }

    [Test]
    public void CountSubstring_ShouldReturn1_GivenSingleInstanceChar()
    {
        var readOnlySpan = "Hello World".AsSpan();
        Span<char> span = stackalloc char[readOnlySpan.Length];
        readOnlySpan.CopyTo(span);

        Assert.That(readOnlySpan.CountSubstring('e'), Is.EqualTo(1));
        Assert.That(readOnlySpan.CountSubstring("e".AsSpan()), Is.EqualTo(1));
        Assert.That(readOnlySpan.CountSubstring("e".AsSpan(), StringComparison.OrdinalIgnoreCase), Is.EqualTo(1));

        Assert.That(span.CountSubstring('e'), Is.EqualTo(1));
        Assert.That(span.CountSubstring("e".AsSpan()), Is.EqualTo(1));
        Assert.That(span.CountSubstring("e".AsSpan(), StringComparison.OrdinalIgnoreCase), Is.EqualTo(1));
    }

    [Test]
    public void CountSubstring_ShouldReturn0_GivenEmptyHaystack()
    {
        Assert.That(string.Empty.AsSpan().CountSubstring('\0'), Is.Zero);
        Assert.That(string.Empty.AsSpan().CountSubstring(string.Empty.AsSpan(), StringComparison.OrdinalIgnoreCase), Is.Zero);
    }
}
