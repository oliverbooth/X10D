using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Text;

namespace X10D.Tests.Text;

[TestClass]
public class StringBuilderReaderTests
{
    [TestMethod]
    public void Peek_ShouldReturnNextChar_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        Assert.AreEqual('H', reader.Peek());

        reader.Close();
    }

    [TestMethod]
    public void Read_ShouldReturnNextChar_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        Assert.AreEqual('H', reader.Read());
        Assert.AreEqual('e', reader.Read());
        Assert.AreEqual('l', reader.Read());
        Assert.AreEqual('l', reader.Read());
        Assert.AreEqual('o', reader.Read());
        Assert.AreEqual('\n', reader.Read());
        Assert.AreEqual('W', reader.Read());
        Assert.AreEqual('o', reader.Read());
        Assert.AreEqual('r', reader.Read());
        Assert.AreEqual('l', reader.Read());
        Assert.AreEqual('d', reader.Read());
        Assert.AreEqual(-1, reader.Read());

        reader.Close();
    }

    [TestMethod]
    public void Read_ShouldPopulateArray_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        var array = new char[5];
        int read = reader.Read(array, 0, 5);
        Assert.AreEqual(5, read);

        CollectionAssert.AreEqual("Hello".ToCharArray(), array);

        reader.Close();
    }

    [TestMethod]
    public void Read_ShouldReturnNegative1_GivenEndOfReader()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));
        var array = new char[11];
        reader.Read(array);
        Assert.AreEqual(-1, reader.Read(array, 0, 1));
        reader.Close();
    }

    [TestMethod]
    public void Read_ShouldThrow_GivenNullArray()
    {
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));
            reader.Read(null!, 0, 5);
            reader.Close();
        });
    }

    [TestMethod]
    public void Read_ShouldThrow_GivenNegativeIndex()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));
            var array = new char[5];
            reader.Read(array, -1, 5);
            reader.Close();
        });
    }

    [TestMethod]
    public void Read_ShouldThrow_GivenNegativeCount()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));
            var array = new char[5];
            reader.Read(array, 0, -1);
            reader.Close();
        });
    }

    [TestMethod]
    public void Read_ShouldThrow_GivenSmallBuffer()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));
            var array = new char[1];
            reader.Read(array, 0, 5);
            reader.Close();
        });
    }

    [TestMethod]
    public void Read_ShouldPopulateSpan_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        Span<char> span = stackalloc char[5];
        int read = reader.Read(span);
        Assert.AreEqual(5, read);

        CollectionAssert.AreEqual("Hello".ToCharArray(), span.ToArray());

        reader.Close();
    }

    [TestMethod]
    public void ReadAsync_ShouldPopulateArray_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        var array = new char[5];
        int read = reader.ReadAsync(array, 0, 5).GetAwaiter().GetResult();
        Assert.AreEqual(5, read);

        CollectionAssert.AreEqual("Hello".ToCharArray(), array);

        reader.Close();
    }

    [TestMethod]
    public void ReadAsync_ShouldPopulateMemory_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        Memory<char> memory = new char[5];
        int read = reader.ReadAsync(memory).GetAwaiter().GetResult();
        Assert.AreEqual(5, read);

        CollectionAssert.AreEqual("Hello".ToCharArray(), memory.ToArray());

        reader.Close();
    }

    [TestMethod]
    public void ReadBlock_ShouldPopulateArray_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        var array = new char[5];
        int read = reader.ReadBlock(array, 0, 5);
        Assert.AreEqual(5, read);

        CollectionAssert.AreEqual("Hello".ToCharArray(), array);

        reader.Close();
    }

    [TestMethod]
    public void ReadBlock_ShouldPopulateSpan_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        Span<char> span = stackalloc char[5];
        int read = reader.ReadBlock(span);
        Assert.AreEqual(5, read);

        CollectionAssert.AreEqual("Hello".ToCharArray(), span.ToArray());

        reader.Close();
    }

    [TestMethod]
    public void ReadBlock_ShouldReturnNegative1_GivenEndOfReader()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        var array = new char[11];
        reader.Read(array);

        int read = reader.ReadBlock(array, 0, 5);
        Assert.AreEqual(-1, read);

        reader.Close();
    }

    [TestMethod]
    public void ReadBlockAsync_ShouldPopulateArray_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        var array = new char[5];
        int read = reader.ReadBlockAsync(array, 0, 5).GetAwaiter().GetResult();
        Assert.AreEqual(5, read);

        CollectionAssert.AreEqual("Hello".ToCharArray(), array);

        reader.Close();
    }

    [TestMethod]
    public void ReadBlockAsync_ShouldPopulateMemory_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        Memory<char> memory = new char[5];
        int read = reader.ReadBlockAsync(memory).GetAwaiter().GetResult();
        Assert.AreEqual(5, read);

        CollectionAssert.AreEqual("Hello".ToCharArray(), memory.ToArray());

        reader.Close();
    }

    [TestMethod]
    public void ReadToEnd_ShouldReturnSourceString_GivenBuilder()
    {
        const string value = "Hello World";
        using var reader = new StringBuilderReader(new StringBuilder(value));
        Assert.AreEqual(value, reader.ReadToEnd());

        reader.Close();
    }

    [TestMethod]
    public void ReadToEndAsync_ShouldReturnSourceString_GivenBuilder()
    {
        const string value = "Hello World";
        using var reader = new StringBuilderReader(new StringBuilder(value));
        Assert.AreEqual(value, reader.ReadToEndAsync().GetAwaiter().GetResult());

        reader.Close();
    }

    [TestMethod]
    public void ReadLine_ShouldReturnSourceString_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        Assert.AreEqual("Hello", reader.ReadLine());
        Assert.AreEqual("World", reader.ReadLine());
        Assert.AreEqual(null, reader.ReadLine());

        Assert.AreEqual(-1, reader.Peek());

        reader.Close();
    }

    [TestMethod]
    public void ReadLineAsync_ShouldReturnSourceString_GivenBuilder()
    {
        using var reader = new StringBuilderReader(new StringBuilder("Hello\nWorld"));

        Assert.AreEqual("Hello", reader.ReadLineAsync().GetAwaiter().GetResult());
        Assert.AreEqual("World", reader.ReadLineAsync().GetAwaiter().GetResult());
        Assert.AreEqual(null, reader.ReadLineAsync().GetAwaiter().GetResult());

        Assert.AreEqual(-1, reader.Peek());

        reader.Close();
    }
}
