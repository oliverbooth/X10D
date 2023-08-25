using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

internal partial class StreamTests
{
    [Test]
    public void WriteBigEndian_ShouldThrowArgumentNullException_GivenNullStream_AndDecimalArgument()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.WriteBigEndian(420.0m));
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void WriteBigEndian_ShouldThrowArgumentException_GivenNonWritableStream_AndDecimalArgument()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.WriteBigEndian(420.0m));
    }

    [Test]
    public void WriteLittleEndian_ShouldThrowArgumentNullException_GivenNullStream_AndDecimalArgument()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.WriteLittleEndian(420.0m));
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void WriteLittleEndian_ShouldThrowArgumentException_GivenNonWritableStream_AndDecimalArgument()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.WriteLittleEndian(420.0m));
    }

    [Test]
    public void WriteBigEndian_ShouldWriteBigEndian_GivenDecimalArgument()
    {
        using var stream = new MemoryStream();
        stream.WriteBigEndian(420.0m);
        Assert.That(stream.Position, Is.EqualTo(16));
        stream.Position = 0;

        Span<byte> actual = stackalloc byte[16];
        ReadOnlySpan<byte> expected = stackalloc byte[]
        {
            0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x68, 0x10, 0x00, 0x00
        };
        int read = stream.Read(actual);

        Assert.That(read, Is.EqualTo(16));
        CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
    }

    [Test]
    public void WriteLittleEndian_ShouldWriteLittleEndian_GivenDecimalArgument()
    {
        using var stream = new MemoryStream();
        stream.WriteLittleEndian(420.0m);
        Assert.That(stream.Position, Is.EqualTo(16));
        stream.Position = 0;

        Span<byte> actual = stackalloc byte[16];
        ReadOnlySpan<byte> expected = stackalloc byte[]
        {
            0x68, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00
        };
        int read = stream.Read(actual);

        Trace.WriteLine(string.Join(", ", actual.ToArray().Select(b => $"0x{b:X2}")));

        Assert.That(read, Is.EqualTo(16));
        CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
    }
}
