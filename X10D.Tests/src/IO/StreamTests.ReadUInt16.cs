using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.IO;

namespace X10D.Tests.IO;

public partial class StreamTests
{
    [TestMethod]
    [CLSCompliant(false)]
    public void ReadUInt16_ShouldThrowArgumentException_GivenNonReadableStream()
    {
        Stream stream = new DummyStream();
        Assert.ThrowsException<ArgumentException>(() => stream.ReadUInt16());
        Assert.ThrowsException<ArgumentException>(() => stream.ReadUInt16(Endianness.LittleEndian));
        Assert.ThrowsException<ArgumentException>(() => stream.ReadUInt16(Endianness.BigEndian));
    }

    [TestMethod]
    [CLSCompliant(false)]
    public void ReadUInt16_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.ThrowsException<ArgumentNullException>(() => stream.ReadUInt16());
        Assert.ThrowsException<ArgumentNullException>(() => stream.ReadUInt16(Endianness.LittleEndian));
        Assert.ThrowsException<ArgumentNullException>(() => stream.ReadUInt16(Endianness.BigEndian));
    }

    [TestMethod]
    [CLSCompliant(false)]
    public void ReadUInt16_ShouldThrowArgumentOutOfRangeException_GivenInvalidEndiannessValue()
    {
        // we don't need to enclose this stream in a using declaration, since disposing a
        // null stream is meaningless. NullStream.Dispose actually does nothing, anyway.
        // that - coupled with the fact that encapsulating the stream in a using declaration causes the
        // analyser to trip up and think the stream is disposed by the time the local is captured in
        // assertion lambda - means this line is fine as it is. please do not change.
        Stream stream = Stream.Null;
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => stream.ReadUInt16((Endianness)(-1)));
    }

    [TestMethod]
    [CLSCompliant(false)]
    public void ReadUInt16_ShouldReadBigEndian_GivenBigEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] {0x01, 0xA4};
        stream.Write(bytes);
        stream.Position = 0;

        const ushort expected = 420;
        ushort actual = stream.ReadUInt16(Endianness.BigEndian);

        Assert.AreEqual(2, stream.Position);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [CLSCompliant(false)]
    public void ReadUInt16_ShouldReadLittleEndian_GivenLittleEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] {0xA4, 0x01};
        stream.Write(bytes);
        stream.Position = 0;

        const ushort expected = 420;
        ushort actual = stream.ReadUInt16(Endianness.LittleEndian);

        Assert.AreEqual(2, stream.Position);
        Assert.AreEqual(expected, actual);
    }
}
