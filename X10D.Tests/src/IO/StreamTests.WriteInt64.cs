using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

internal partial class StreamTests
{
    [Test]
    public void WriteBigEndian_ShouldThrowArgumentNullException_GivenNullStream_AndInt64Argument()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.WriteBigEndian(420L));
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void WriteBigEndian_ShouldThrowArgumentException_GivenNonWritableStream_AndInt64Argument()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.WriteBigEndian(420L));
    }

    [Test]
    public void WriteLittleEndian_ShouldThrowArgumentNullException_GivenNullStream_AndInt64Argument()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.WriteLittleEndian(420L));
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void WriteLittleEndian_ShouldThrowArgumentException_GivenNonWritableStream_AndInt64Argument()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.WriteLittleEndian(420L));
    }

    [Test]
    public void WriteBigEndian_ShouldWriteBigEndian_GivenInt64Argument()
    {
        using var stream = new MemoryStream();
        stream.WriteBigEndian(420L);
        Assert.That(stream.Position, Is.EqualTo(8));
        stream.Position = 0;

        Span<byte> actual = stackalloc byte[8];
        ReadOnlySpan<byte> expected = stackalloc byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0xA4 };
        int read = stream.Read(actual);

        Assert.That(read, Is.EqualTo(8));
        CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
    }

    [Test]
    public void WriteLittleEndian_ShouldWriteLittleEndian_GivenLittleEndian()
    {
        using var stream = new MemoryStream();
        stream.WriteLittleEndian(420L);
        Assert.That(stream.Position, Is.EqualTo(8));
        stream.Position = 0;

        Span<byte> actual = stackalloc byte[8];
        ReadOnlySpan<byte> expected = stackalloc byte[] { 0xA4, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        int read = stream.Read(actual);

        Assert.That(read, Is.EqualTo(8));
        CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
    }
}
