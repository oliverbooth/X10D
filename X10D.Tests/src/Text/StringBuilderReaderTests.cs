using System.Text;
using NUnit.Framework;
using X10D.Text;

namespace X10D.Tests.Text;

[TestFixture]
internal class StringBuilderReaderTests
{
    [Test]
    public void Peek_ShouldReturnNextChar_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        Assert.That(reader.Peek(), Is.EqualTo('H'));

        reader.Close();
    }

    [Test]
    public void Read_ShouldReturnNextChar_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        Assert.That(reader.Read(), Is.EqualTo('H'));
        Assert.That(reader.Read(), Is.EqualTo('e'));
        Assert.That(reader.Read(), Is.EqualTo('l'));
        Assert.That(reader.Read(), Is.EqualTo('l'));
        Assert.That(reader.Read(), Is.EqualTo('o'));
        Assert.That(reader.Read(), Is.EqualTo('\n'));
        Assert.That(reader.Read(), Is.EqualTo('W'));
        Assert.That(reader.Read(), Is.EqualTo('o'));
        Assert.That(reader.Read(), Is.EqualTo('r'));
        Assert.That(reader.Read(), Is.EqualTo('l'));
        Assert.That(reader.Read(), Is.EqualTo('d'));
        Assert.That(reader.Read(), Is.EqualTo(-1));

        reader.Close();
    }

    [Test]
    public void Read_ShouldPopulateArray_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        var array = new char[5];
        int read = reader.Read(array, 0, 5);
        Assert.That(read, Is.EqualTo(5));

        CollectionAssert.AreEqual("Hello".ToCharArray(), array);

        reader.Close();
    }

    [Test]
    public void Read_ShouldReturnNegative1_GivenEndOfReader()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));
        var array = new char[11];
        reader.Read(array);
        Assert.That(reader.Read(array, 0, 1), Is.EqualTo(-1));
        reader.Close();
    }

    [Test]
    public void Read_ShouldThrow_GivenNullArray()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));
            reader.Read(null!, 0, 5);
            reader.Close();
        });
    }

    [Test]
    public void Read_ShouldThrow_GivenNegativeIndex()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));
            var array = new char[5];
            reader.Read(array, -1, 5);
            reader.Close();
        });
    }

    [Test]
    public void Read_ShouldThrow_GivenNegativeCount()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));
            var array = new char[5];
            reader.Read(array, 0, -1);
            reader.Close();
        });
    }

    [Test]
    public void Read_ShouldThrow_GivenSmallBuffer()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));
            var array = new char[1];
            reader.Read(array, 0, 5);
            reader.Close();
        });
    }

    [Test]
    public void Read_ShouldPopulateSpan_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        Span<char> span = stackalloc char[5];
        int read = reader.Read(span);
        Assert.That(read, Is.EqualTo(5));

        CollectionAssert.AreEqual("Hello".ToCharArray(), span.ToArray());

        reader.Close();
    }

    [Test]
    public void ReadAsync_ShouldPopulateArray_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        var array = new char[5];
        int read = reader.ReadAsync(array, 0, 5).GetAwaiter().GetResult();
        Assert.That(read, Is.EqualTo(5));

        CollectionAssert.AreEqual("Hello".ToCharArray(), array);

        reader.Close();
    }

    [Test]
    public void ReadAsync_ShouldPopulateMemory_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        Memory<char> memory = new char[5];
        int read = reader.ReadAsync(memory).GetAwaiter().GetResult();
        Assert.That(read, Is.EqualTo(5));

        CollectionAssert.AreEqual("Hello".ToCharArray(), memory.ToArray());

        reader.Close();
    }

    [Test]
    public void ReadBlock_ShouldPopulateArray_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        var array = new char[5];
        int read = reader.ReadBlock(array, 0, 5);
        Assert.That(read, Is.EqualTo(5));

        CollectionAssert.AreEqual("Hello".ToCharArray(), array);

        reader.Close();
    }

    [Test]
    public void ReadBlock_ShouldPopulateSpan_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        Span<char> span = stackalloc char[5];
        int read = reader.ReadBlock(span);
        Assert.That(read, Is.EqualTo(5));

        CollectionAssert.AreEqual("Hello".ToCharArray(), span.ToArray());

        reader.Close();
    }

    [Test]
    public void ReadBlock_ShouldReturnNegative1_GivenEndOfReader()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        var array = new char[11];
        reader.Read(array);

        int read = reader.ReadBlock(array, 0, 5);
        Assert.That(read, Is.EqualTo(-1));

        reader.Close();
    }

    [Test]
    public void ReadBlockAsync_ShouldPopulateArray_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        var array = new char[5];
        int read = reader.ReadBlockAsync(array, 0, 5).GetAwaiter().GetResult();
        Assert.That(read, Is.EqualTo(5));

        CollectionAssert.AreEqual("Hello".ToCharArray(), array);

        reader.Close();
    }

    [Test]
    public void ReadBlockAsync_ShouldPopulateMemory_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        Memory<char> memory = new char[5];
        int read = reader.ReadBlockAsync(memory).GetAwaiter().GetResult();
        Assert.That(read, Is.EqualTo(5));

        CollectionAssert.AreEqual("Hello".ToCharArray(), memory.ToArray());

        reader.Close();
    }

    [Test]
    public void ReadToEnd_ShouldReturnSourceString_GivenBuilder()
    {
        const string value = "Hello World";
        using var reader = new StringBuilderReader(new StringBuilder(value));
        Assert.That(reader.ReadToEnd(), Is.EqualTo(value));

        reader.Close();
    }

    [Test]
    public void ReadToEndAsync_ShouldReturnSourceString_GivenBuilder()
    {
        const string value = "Hello World";
        using var reader = new StringBuilderReader(new StringBuilder(value));
        Assert.That(reader.ReadToEndAsync().GetAwaiter().GetResult(), Is.EqualTo(value));

        reader.Close();
    }

    [Test]
    public void ReadLine_ShouldReturnSourceString_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        Assert.That(reader.ReadLine(), Is.EqualTo("Hello"));
        Assert.That(reader.ReadLine(), Is.EqualTo("World"));
        Assert.That(reader.ReadLine(), Is.EqualTo(null));

        Assert.That(reader.Peek(), Is.EqualTo(-1));

        reader.Close();
    }

    [Test]
    public void ReadLineAsync_ShouldReturnSourceString_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        Assert.That(reader.ReadLineAsync().GetAwaiter().GetResult(), Is.EqualTo("Hello"));
        Assert.That(reader.ReadLineAsync().GetAwaiter().GetResult(), Is.EqualTo("World"));
        Assert.That(reader.ReadLineAsync().GetAwaiter().GetResult(), Is.EqualTo(null));

        Assert.That(reader.Peek(), Is.EqualTo(-1));

        reader.Close();
    }
}
