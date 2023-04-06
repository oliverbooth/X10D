using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

public partial class StreamTests
{
    [Test]
    public void ReadDouble_ShouldThrowArgumentException_GivenNonReadableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.ReadDouble());
        Assert.Throws<ArgumentException>(() => stream.ReadDouble(Endianness.LittleEndian));
        Assert.Throws<ArgumentException>(() => stream.ReadDouble(Endianness.BigEndian));
    }

    [Test]
    public void ReadDouble_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.ReadDouble());
        Assert.Throws<ArgumentNullException>(() => stream.ReadDouble(Endianness.LittleEndian));
        Assert.Throws<ArgumentNullException>(() => stream.ReadDouble(Endianness.BigEndian));
    }

    [Test]
    public void ReadDouble_ShouldThrowArgumentOutOfRangeException_GivenInvalidEndiannessValue()
    {
        // we don't need to enclose this stream in a using declaration, since disposing a
        // null stream is meaningless. NullStream.Dispose actually does nothing, anyway.
        // that - coupled with the fact that encapsulating the stream in a using declaration causes the
        // analyser to trip up and think the stream is disposed by the time the local is captured in
        // assertion lambda - means this line is fine as it is. please do not change.
        Stream stream = Stream.Null;
        Assert.Throws<ArgumentOutOfRangeException>(() => stream.ReadDouble((Endianness)(-1)));
    }

    [Test]
    public void ReadDouble_ShouldReadBigEndian_GivenBigEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] {0x40, 0x7A, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00};
        stream.Write(bytes);
        stream.Position = 0;

        const double expected = 420.0;
        double actual = stream.ReadDouble(Endianness.BigEndian);

        Assert.That(stream.Position, Is.EqualTo(8));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ReadDouble_ShouldWriteLittleEndian_GivenLittleEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x7A, 0x40};
        stream.Write(bytes);
        stream.Position = 0;

        const double expected = 420.0;
        double actual = stream.ReadDouble(Endianness.LittleEndian);

        Assert.That(stream.Position, Is.EqualTo(8));
        Assert.That(actual, Is.EqualTo(expected));
    }
}
