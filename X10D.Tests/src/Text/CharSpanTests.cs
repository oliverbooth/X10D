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

    [Test]
    public void Repeat_ShouldNotManipulateSpan_GivenCount0()
    {
        Span<char> destination = new char[11];
        "Hello world".AsSpan().CopyTo(destination);

        "a".AsSpan().Repeat(0, destination);
        Assert.That(destination.ToString(), Is.EqualTo("Hello world"));
    }

    [Test]
    public void Repeat_ShouldReturnItself_GivenCount1()
    {
        string repeated = "a".AsSpan().Repeat(1);
        Assert.That(repeated, Has.Length.EqualTo(1));
        Assert.That(repeated, Is.EqualTo("a"));
    }

    [Test]
    public void Repeat_ShouldPopulateSpan_GivenValidSpan()
    {
        const string expected = "aaaaaaaaaa";
        Span<char> destination = new char[10];
        "a".AsSpan().Repeat(10, destination);

        Assert.That(destination.ToString(), Is.EqualTo(expected));
    }

    [Test]
    public void Repeat_ShouldReturnEmptyString_GivenCount0()
    {
        Assert.That("a".AsSpan().Repeat(0), Is.EqualTo(string.Empty));
    }

    [Test]
    public void Repeat_ShouldReturnRepeatedString_GivenSpan()
    {
        const string expected = "aaaaaaaaaa";
        string actual = "a".AsSpan().Repeat(10);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Repeat_ShouldThrowArgumentException_GivenSmallSpan()
    {
        Assert.Throws<ArgumentException>(() => "a".AsSpan().Repeat(10, Span<char>.Empty));
    }

    [Test]
    public void Repeat_ShouldThrowArgumentOutOfRangeException_GivenNegativeCount()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = "a".AsSpan().Repeat(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => "a".AsSpan().Repeat(-1, Span<char>.Empty));
    }
}
