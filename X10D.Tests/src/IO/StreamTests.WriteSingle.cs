using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

internal partial class StreamTests
{
    [Test]
    public void WriteBigEndian_ShouldThrowArgumentNullException_GivenNullStream_AndSingleArgument()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.WriteBigEndian(420.0f));
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void WriteBigEndian_ShouldThrowArgumentException_GivenNonWritableStream_AndSingleArgument()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.WriteBigEndian(420.0f));
    }

    [Test]
    public void WriteLittleEndian_ShouldThrowArgumentNullException_GivenNullStream_AndSingleArgument()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.WriteLittleEndian(420.0f));
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void WriteLittleEndian_ShouldThrowArgumentException_GivenNonWritableStream_AndSingleArgument()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.WriteLittleEndian(420.0f));
    }

    [Test]
    public void WriteBigEndian_ShouldWriteBigEndian_GivenSingleArgument()
    {
        using var stream = new MemoryStream();
        stream.WriteBigEndian(420.0f);
        Assert.That(stream.Position, Is.EqualTo(4));
        stream.Position = 0;

        Span<byte> actual = stackalloc byte[4];
        ReadOnlySpan<byte> expected = stackalloc byte[] { 0x43, 0xD2, 0x00, 0x00 };
        int read = stream.Read(actual);

        Assert.That(read, Is.EqualTo(4));
        CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
    }

    [Test]
    public void WriteLittleEndian_ShouldWriteLittleEndian_GivenSingleArgument()
    {
        using var stream = new MemoryStream();
        stream.WriteLittleEndian(420.0f);
        Assert.That(stream.Position, Is.EqualTo(4));
        stream.Position = 0;

        Span<byte> actual = stackalloc byte[4];
        ReadOnlySpan<byte> expected = stackalloc byte[] { 0x00, 0x00, 0xD2, 0x43 };
        int read = stream.Read(actual);

        Assert.That(read, Is.EqualTo(4));
        CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
    }
}
