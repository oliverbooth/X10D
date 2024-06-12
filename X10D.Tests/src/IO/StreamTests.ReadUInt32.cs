using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

internal partial class StreamTests
{
    [Test]
    public void ReadUInt32BigEndian_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.ReadUInt32BigEndian());
    }

    [Test]
    public void ReadUInt32LittleEndian_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.ReadUInt32LittleEndian());
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void ReadUInt32BigEndian_ShouldThrowArgumentException_GivenNonReadableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.ReadUInt32BigEndian());
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void ReadUInt32LittleEndian_ShouldThrowArgumentException_GivenNonReadableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.ReadUInt32LittleEndian());
    }

    [Test]
    public void ReadUInt32BigEndian_ShouldReadBigEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] { 0x00, 0x00, 0x01, 0xA4 };
        stream.Write(bytes);
        stream.Position = 0;

        const uint expected = 420;
        uint actual = stream.ReadUInt32BigEndian();

        Assert.That(stream.Position, Is.EqualTo(4));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ReadUInt32LittleEndian_ShouldReadLittleEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] { 0xA4, 0x01, 0x00, 0x00 };
        stream.Write(bytes);
        stream.Position = 0;

        const uint expected = 420;
        uint actual = stream.ReadUInt32LittleEndian();

        Assert.That(stream.Position, Is.EqualTo(4));
        Assert.That(actual, Is.EqualTo(expected));
    }
}
