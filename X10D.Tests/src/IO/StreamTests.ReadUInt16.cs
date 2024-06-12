using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

internal partial class StreamTests
{
    [Test]
    public void ReadUInt16BigEndian_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.ReadUInt16BigEndian());
    }

    [Test]
    public void ReadUInt16LittleEndian_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.ReadUInt16LittleEndian());
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void ReadUInt16BigEndian_ShouldThrowArgumentException_GivenNonReadableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.ReadUInt16BigEndian());
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void ReadUInt16LittleEndian_ShouldThrowArgumentException_GivenNonReadableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.ReadUInt16LittleEndian());
    }

    [Test]
    public void ReadUInt16BigEndian_ShouldReadBigEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] { 0x01, 0xA4 };
        stream.Write(bytes);
        stream.Position = 0;

        const ushort expected = 420;
        ushort actual = stream.ReadUInt16BigEndian();

        Assert.That(stream.Position, Is.EqualTo(2));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ReadUInt16LittleEndian_ShouldReadLittleEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] { 0xA4, 0x01 };
        stream.Write(bytes);
        stream.Position = 0;

        const ushort expected = 420;
        ushort actual = stream.ReadUInt16LittleEndian();

        Assert.That(stream.Position, Is.EqualTo(2));
        Assert.That(actual, Is.EqualTo(expected));
    }
}
