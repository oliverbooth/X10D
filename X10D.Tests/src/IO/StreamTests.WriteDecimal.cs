using System.Diagnostics;
using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

public partial class StreamTests
{
    [Test]
    public void WriteDecimal_ShouldThrowArgumentException_GivenNonWriteableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.Write(420.0m, Endianness.LittleEndian));
        Assert.Throws<ArgumentException>(() => stream.Write(420.0m, Endianness.BigEndian));
    }

    [Test]
    public void WriteDecimal_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.Write(420.0m, Endianness.LittleEndian));
        Assert.Throws<ArgumentNullException>(() => stream.Write(420.0m, Endianness.BigEndian));
    }

    [Test]
    public void WriteDecimal_ShouldThrowArgumentOutOfRangeException_GivenInvalidEndiannessValue()
    {
        // we don't need to enclose this stream in a using declaration, since disposing a
        // null stream is meaningless. NullStream.Dispose actually does nothing, anyway.
        // that - coupled with the fact that encapsulating the stream in a using declaration causes the
        // analyser to trip up and think the stream is disposed by the time the local is captured in
        // assertion lambda - means this line is fine as it is. please do not change.
        Stream stream = Stream.Null;
        Assert.Throws<ArgumentOutOfRangeException>(() => stream.Write(420.0m, (Endianness)(-1)));
        Assert.Throws<ArgumentOutOfRangeException>(() => stream.Write(420.0m, (Endianness)(-1)));
    }

    [Test]
    public void WriteDecimal_ShouldWriteBigEndian_GivenBigEndian()
    {
        using var stream = new MemoryStream();
        stream.Write(420.0m, Endianness.BigEndian);
        Assert.That(stream.Position, Is.EqualTo(16));
        stream.Position = 0;

        Span<byte> actual = stackalloc byte[16];
        ReadOnlySpan<byte> expected = stackalloc byte[]
        {
            0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x10, 0x68
        };
        int read = stream.Read(actual);

        Assert.That(read, Is.EqualTo(16));
        CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
    }

    [Test]
    public void WriteDecimal_ShouldWriteLittleEndian_GivenLittleEndian()
    {
        using var stream = new MemoryStream();
        stream.Write(420.0m, Endianness.LittleEndian);
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
