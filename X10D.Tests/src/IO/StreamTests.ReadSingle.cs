using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

internal partial class StreamTests
{
    [Test]
    public void ReadSingleBigEndian_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.ReadSingleBigEndian());
    }

    [Test]
    public void ReadSingleLittleEndian_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.ReadSingleLittleEndian());
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void ReadSingleBigEndian_ShouldThrowArgumentException_GivenNonReadableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.ReadSingleBigEndian());
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void ReadSingleLittleEndian_ShouldThrowArgumentException_GivenNonReadableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.ReadSingleLittleEndian());
    }

    [Test]
    public void ReadSingleBigEndian_ShouldReadBigEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] { 0x43, 0xD2, 0x00, 0x00 };
        stream.Write(bytes);
        stream.Position = 0;

        const float expected = 420.0f;
        float actual = stream.ReadSingleBigEndian();

        Assert.That(stream.Position, Is.EqualTo(4));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ReadSingleLittleEndian_ShouldReadLittleEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] { 0x00, 0x00, 0xD2, 0x43 };
        stream.Write(bytes);
        stream.Position = 0;

        const float expected = 420.0f;
        float actual = stream.ReadSingleLittleEndian();

        Assert.That(stream.Position, Is.EqualTo(4));
        Assert.That(actual, Is.EqualTo(expected));
    }
}
