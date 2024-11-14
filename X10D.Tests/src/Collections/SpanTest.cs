using NUnit.Framework;
#if !NET9_0_OR_GREATER
using X10D.Collections;
#endif

namespace X10D.Tests.Collections;

[TestFixture]
internal class SpanTest
{
    [Test]
    public void Replace_ShouldReplaceAllElements_GivenSpanOfInt32()
    {
        Span<int> span = [1, 2, 3, 2, 5, 2, 7, 2, 9, 2, 11, 2, 13, 2, 15, 2];
        span.Replace(2, 4);
        Assert.That(span.ToArray(), Is.EqualTo(new[] { 1, 4, 3, 4, 5, 4, 7, 4, 9, 4, 11, 4, 13, 4, 15, 4 }));
    }

    [Test]
    public void Replace_ShouldReplaceAllElements_GivenSpanOfChar()
    {
        Span<char> chars = ['H', 'e', 'l', 'l', 'o', ' ', 'w', 'o', 'r', 'l', 'd', '!'];
        chars.Replace('l', 'w');
        Assert.That("Hewwo worwd!".ToCharArray(), Is.EqualTo(chars.ToArray()).AsCollection);
    }

    [Test]
    public void Replace_ShouldDoNothing_GivenSpanWithNoMatchingElements()
    {
        Span<int> span = [1, 2, 3, 2, 5, 2, 7, 2, 9, 2, 11, 2, 13, 2, 15, 2];
        span.Replace(4, 8);
        Assert.That(span.ToArray(), Is.EqualTo(new[] { 1, 2, 3, 2, 5, 2, 7, 2, 9, 2, 11, 2, 13, 2, 15, 2 }));
    }

#if !NET9_0_OR_GREATER
    [Test]
    public void Split_OnEmptySpan_ShouldYieldNothing_UsingCharDelimiter_GivenReadOnlySpan()
    {
        ReadOnlySpan<char> span = ReadOnlySpan<char>.Empty;

        var index = 0;
        foreach (ReadOnlySpan<char> unused in span.Split(' '))
        {
            index++;
        }

        Assert.That(index, Is.Zero);
    }

    [Test]
    public void Split_OnEmptySpan_ShouldYieldNothing_UsingCharDelimiter_GivenSpan()
    {
        Span<char> span = Span<char>.Empty;

        var index = 0;
        foreach (ReadOnlySpan<char> unused in span.Split(' '))
        {
            index++;
        }

        Assert.That(index, Is.Zero);
    }

    [Test]
    public void Split_OnEmptySpan_ShouldYieldNothing_UsingStringDelimiter_GivenReadOnlySpan()
    {
        ReadOnlySpan<char> span = ReadOnlySpan<char>.Empty;

        var index = 0;
        foreach (ReadOnlySpan<char> unused in span.Split(" "))
        {
            index++;
        }

        Assert.That(index, Is.Zero);
    }

    [Test]
    public void Split_OnEmptySpan_ShouldYieldNothing_UsingStringDelimiter_GivenSpan()
    {
        Span<char> span = Span<char>.Empty;

        var index = 0;
        foreach (ReadOnlySpan<char> unused in span.Split(" "))
        {
            index++;
        }

        Assert.That(index, Is.Zero);
    }

    [Test]
    public void Split_OnOneWord_ShouldYieldLength1_UsingCharDelimiter_GivenReadOnlySpan()
    {
        ReadOnlySpan<char> span = "Hello ".AsSpan();

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(' '))
        {
            if (index == 0)
            {
                Assert.That(subSpan.ToString(), Is.EqualTo("Hello"));
            }

            index++;
        }

        Assert.That(index, Is.EqualTo(1));
    }

    [Test]
    public void Split_OnOneWord_ShouldYieldLength1_UsingCharDelimiter_GivenSpan()
    {
        ReadOnlySpan<char> source = "Hello ".AsSpan();
        Span<char> span = stackalloc char[source.Length];
        source.CopyTo(span);

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(' '))
        {
            if (index == 0)
            {
                Assert.That(subSpan.ToString(), Is.EqualTo("Hello"));
            }

            index++;
        }

        Assert.That(index, Is.EqualTo(1));
    }

    [Test]
    public void Split_OnOneWord_ShouldYieldLength1_UsingStringDelimiter_GivenReadOnlySpan()
    {
        ReadOnlySpan<char> span = "Hello ".AsSpan();

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(" "))
        {
            if (index == 0)
            {
                Assert.That(subSpan.ToString(), Is.EqualTo("Hello"));
            }

            index++;
        }

        Assert.That(index, Is.EqualTo(1));
    }

    [Test]
    public void Split_OnOneWord_ShouldYieldLength1_UsingStringDelimiter_GivenSpan()
    {
        ReadOnlySpan<char> source = "Hello ".AsSpan();
        Span<char> span = stackalloc char[source.Length];
        source.CopyTo(span);

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(" "))
        {
            if (index == 0)
            {
                Assert.That(subSpan.ToString(), Is.EqualTo("Hello"));
            }

            index++;
        }

        Assert.That(index, Is.EqualTo(1));
    }

    [Test]
    public void Split_OnOneWordWithoutDelimiter_ShouldYieldLength1_UsingCharDelimiter_GivenReadOnlySpan()
    {
        ReadOnlySpan<char> span = "Hello".AsSpan();

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(' '))
        {
            if (index == 0)
            {
                Assert.That(subSpan.ToString(), Is.EqualTo("Hello"));
            }

            index++;
        }

        Assert.That(index, Is.EqualTo(1));
    }

    [Test]
    public void Split_OnOneWordWithoutDelimiter_ShouldYieldLength1_UsingCharDelimiter_GivenSpan()
    {
        ReadOnlySpan<char> source = "Hello".AsSpan();
        Span<char> span = stackalloc char[source.Length];
        source.CopyTo(span);

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(' '))
        {
            if (index == 0)
            {
                Assert.That(subSpan.ToString(), Is.EqualTo("Hello"));
            }

            index++;
        }

        Assert.That(index, Is.EqualTo(1));
    }

    [Test]
    public void Split_OnOneWordWithoutDelimiter_ShouldYieldLength1_UsingStringDelimiter_GivenReadOnlySpan()
    {
        ReadOnlySpan<char> span = "Hello".AsSpan();

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(" "))
        {
            if (index == 0)
            {
                Assert.That(subSpan.ToString(), Is.EqualTo("Hello"));
            }

            index++;
        }

        Assert.That(index, Is.EqualTo(1));
    }

    [Test]
    public void Split_OnOneWordWithoutDelimiter_ShouldYieldLength1_UsingStringDelimiter_GivenSpan()
    {
        ReadOnlySpan<char> source = "Hello".AsSpan();
        Span<char> span = stackalloc char[source.Length];
        source.CopyTo(span);

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(" "))
        {
            if (index == 0)
            {
                Assert.That(subSpan.ToString(), Is.EqualTo("Hello"));
            }

            index++;
        }

        Assert.That(index, Is.EqualTo(1));
    }

    [Test]
    public void Split_OnTwoWords_ShouldYieldLength2_UsingCharDelimiter_GivenReadOnlySpan()
    {
        ReadOnlySpan<char> span = "Hello World ".AsSpan();

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(' '))
        {
            switch (index)
            {
                case 0:
                    Assert.That(subSpan.ToString(), Is.EqualTo("Hello"));
                    break;
                case 1:
                    Assert.That(subSpan.ToString(), Is.EqualTo("World"));
                    break;
            }

            index++;
        }

        Assert.That(index, Is.EqualTo(2));
    }

    [Test]
    public void Split_OnTwoWords_ShouldYieldLength2_UsingCharDelimiter_GivenSpan()
    {
        ReadOnlySpan<char> source = "Hello World ".AsSpan();
        Span<char> span = stackalloc char[source.Length];
        source.CopyTo(span);

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(' '))
        {
            switch (index)
            {
                case 0:
                    Assert.That(subSpan.ToString(), Is.EqualTo("Hello"));
                    break;
                case 1:
                    Assert.That(subSpan.ToString(), Is.EqualTo("World"));
                    break;
            }

            index++;
        }

        Assert.That(index, Is.EqualTo(2));
    }

    [Test]
    public void Split_OnTwoWords_ShouldYieldLength2_UsingStringDelimiter_GivenReadOnlySpan()
    {
        ReadOnlySpan<char> span = "Hello World ".AsSpan();

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(" "))
        {
            switch (index)
            {
                case 0:
                    Assert.That(subSpan.ToString(), Is.EqualTo("Hello"));
                    break;
                case 1:
                    Assert.That(subSpan.ToString(), Is.EqualTo("World"));
                    break;
            }

            index++;
        }

        Assert.That(index, Is.EqualTo(2));
    }

    [Test]
    public void Split_OnTwoWords_ShouldYieldLength2_UsingStringDelimiter_GivenSpan()
    {
        ReadOnlySpan<char> source = "Hello World ".AsSpan();
        Span<char> span = stackalloc char[source.Length];
        source.CopyTo(span);

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(" "))
        {
            switch (index)
            {
                case 0:
                    Assert.That(subSpan.ToString(), Is.EqualTo("Hello"));
                    break;
                case 1:
                    Assert.That(subSpan.ToString(), Is.EqualTo("World"));
                    break;
            }

            index++;
        }

        Assert.That(index, Is.EqualTo(2));
    }

    [Test]
    public void Split_OnThreeWords_ShouldYieldLength3_UsingCharDelimiter_GivenReadOnlySpan()
    {
        ReadOnlySpan<char> span = "Hello, the World ".AsSpan();

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(' '))
        {
            switch (index)
            {
                case 0:
                    Assert.That(subSpan.ToString(), Is.EqualTo("Hello,"));
                    break;
                case 1:
                    Assert.That(subSpan.ToString(), Is.EqualTo("the"));
                    break;
                case 2:
                    Assert.That(subSpan.ToString(), Is.EqualTo("World"));
                    break;
            }

            index++;
        }

        Assert.That(index, Is.EqualTo(3));
    }

    [Test]
    public void Split_OnThreeWords_ShouldYieldLength3_UsingCharDelimiter_GivenSpan()
    {
        ReadOnlySpan<char> source = "Hello, the World ".AsSpan();
        Span<char> span = stackalloc char[source.Length];
        source.CopyTo(span);

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(' '))
        {
            switch (index)
            {
                case 0:
                    Assert.That(subSpan.ToString(), Is.EqualTo("Hello,"));
                    break;
                case 1:
                    Assert.That(subSpan.ToString(), Is.EqualTo("the"));
                    break;
                case 2:
                    Assert.That(subSpan.ToString(), Is.EqualTo("World"));
                    break;
            }

            index++;
        }

        Assert.That(index, Is.EqualTo(3));
    }

    [Test]
    public void Split_OnThreeWords_ShouldYieldLength3_UsingStringDelimiter_GivenReadOnlySpan()
    {
        ReadOnlySpan<char> span = "Hello, the World ".AsSpan();

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(" "))
        {
            switch (index)
            {
                case 0:
                    Assert.That(subSpan.ToString(), Is.EqualTo("Hello,"));
                    break;
                case 1:
                    Assert.That(subSpan.ToString(), Is.EqualTo("the"));
                    break;
                case 2:
                    Assert.That(subSpan.ToString(), Is.EqualTo("World"));
                    break;
            }

            index++;
        }

        Assert.That(index, Is.EqualTo(3));
    }

    [Test]
    public void Split_OnThreeWords_ShouldYieldLength3_UsingStringDelimiter_GivenSpan()
    {
        ReadOnlySpan<char> source = "Hello, the World ".AsSpan();
        Span<char> span = stackalloc char[source.Length];
        source.CopyTo(span);

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(" "))
        {
            switch (index)
            {
                case 0:
                    Assert.That(subSpan.ToString(), Is.EqualTo("Hello,"));
                    break;
                case 1:
                    Assert.That(subSpan.ToString(), Is.EqualTo("the"));
                    break;
                case 2:
                    Assert.That(subSpan.ToString(), Is.EqualTo("World"));
                    break;
            }

            index++;
        }

        Assert.That(index, Is.EqualTo(3));
    }
#endif
}
