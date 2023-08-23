using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

internal partial class StreamTests
{
    [Test]
    public void ReadInt16BigEndian_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.ReadInt16BigEndian());
    }

    [Test]
    public void ReadInt16LittleEndian_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.ReadInt16LittleEndian());
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void ReadInt16BigEndian_ShouldThrowArgumentException_GivenNonReadableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.ReadInt16BigEndian());
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void ReadInt16LittleEndian_ShouldThrowArgumentException_GivenNonReadableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.ReadInt16LittleEndian());
    }

    [Test]
    public void ReadInt16BigEndian_ShouldReadBigEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] { 0x01, 0xA4 };
        stream.Write(bytes);
        stream.Position = 0;

        const short expected = 420;
        short actual = stream.ReadInt16BigEndian();

        Assert.That(stream.Position, Is.EqualTo(2));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ReadInt16LittleEndian_ShouldReadLittleEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] { 0xA4, 0x01 };
        stream.Write(bytes);
        stream.Position = 0;

        const short expected = 420;
        short actual = stream.ReadInt16LittleEndian();

        Assert.That(stream.Position, Is.EqualTo(2));
        Assert.That(actual, Is.EqualTo(expected));
    }
}
