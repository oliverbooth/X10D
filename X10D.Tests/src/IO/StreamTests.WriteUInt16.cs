using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

internal partial class StreamTests
{
    [Test]
    public void WriteBigEndian_ShouldThrowArgumentNullException_GivenNullStream_AndUInt16Argument()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.WriteBigEndian((ushort)420));
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void WriteBigEndian_ShouldThrowArgumentException_GivenNonWritableStream_AndUInt16Argument()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.WriteBigEndian((ushort)420));
    }

    [Test]
    public void WriteLittleEndian_ShouldThrowArgumentNullException_GivenNullStream_AndUInt16Argument()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.WriteLittleEndian((ushort)420));
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void WriteLittleEndian_ShouldThrowArgumentException_GivenNonWritableStream_AndUInt16Argument()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.WriteLittleEndian((ushort)420));
    }

    [Test]
    public void WriteBigEndian_ShouldWriteBigEndian_GivenUInt16Endian()
    {
        using var stream = new MemoryStream();
        stream.WriteBigEndian((ushort)420);
        Assert.That(stream.Position, Is.EqualTo(2));
        stream.Position = 0;

        Span<byte> actual = stackalloc byte[2];
        ReadOnlySpan<byte> expected = stackalloc byte[] { 0x01, 0xA4 };
        int read = stream.Read(actual);

        Assert.That(read, Is.EqualTo(2));
        CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
    }

    [Test]
    public void WriteLittleEndian_ShouldWriteLittleEndian_GivenUInt16tleEndian()
    {
        using var stream = new MemoryStream();
        stream.WriteLittleEndian((ushort)420);
        Assert.That(stream.Position, Is.EqualTo(2));
        stream.Position = 0;

        Span<byte> actual = stackalloc byte[2];
        ReadOnlySpan<byte> expected = stackalloc byte[] { 0xA4, 0x01 };
        int read = stream.Read(actual);

        Assert.That(read, Is.EqualTo(2));
        CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
    }
}
