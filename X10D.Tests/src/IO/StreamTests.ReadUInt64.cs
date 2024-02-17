using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

internal partial class StreamTests
{
    [Test]
    public void ReadUInt64BigEndian_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.ReadUInt64BigEndian());
    }

    [Test]
    public void ReadUInt64LittleEndian_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.ReadUInt64LittleEndian());
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void ReadUInt64BigEndian_ShouldThrowArgumentException_GivenNonReadableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.ReadUInt64BigEndian());
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void ReadUInt64LittleEndian_ShouldThrowArgumentException_GivenNonReadableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.ReadUInt64LittleEndian());
    }

    [Test]
    public void ReadUInt64BigEndian_ShouldReadBigEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0xA4 };
        stream.Write(bytes);
        stream.Position = 0;

        const ulong expected = 420;
        ulong actual = stream.ReadUInt64BigEndian();

        Assert.That(stream.Position, Is.EqualTo(8));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ReadUInt64LittleEndian_ShouldWriteLittleEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] { 0xA4, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        stream.Write(bytes);
        stream.Position = 0;

        const ulong expected = 420;
        ulong actual = stream.ReadUInt64LittleEndian();

        Assert.That(stream.Position, Is.EqualTo(8));
        Assert.That(actual, Is.EqualTo(expected));
    }
}
