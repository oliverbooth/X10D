using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.IO;

namespace X10D.Tests.IO;

public partial class StreamTests
{
    [TestMethod]
    [CLSCompliant(false)]
    public void WriteUInt16_ShouldThrowArgumentException_GivenNonWriteableStream()
    {
        Stream stream = new DummyStream();
        Assert.ThrowsException<ArgumentException>(() => stream.Write((ushort)420, Endianness.LittleEndian));
        Assert.ThrowsException<ArgumentException>(() => stream.Write((ushort)420, Endianness.BigEndian));
    }

    [TestMethod]
    [CLSCompliant(false)]
    public void WriteUInt16_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.ThrowsException<ArgumentNullException>(() => stream.Write((ushort)420, Endianness.LittleEndian));
        Assert.ThrowsException<ArgumentNullException>(() => stream.Write((ushort)420, Endianness.BigEndian));
    }

    [TestMethod]
    [CLSCompliant(false)]
    public void WriteUInt16_ShouldThrowArgumentOutOfRangeException_GivenInvalidEndiannessValue()
    {
        // we don't need to enclose this stream in a using declaration, since disposing a
        // null stream is meaningless. NullStream.Dispose actually does nothing, anyway.
        // that - coupled with the fact that encapsulating the stream in a using declaration causes the
        // analyser to trip up and think the stream is disposed by the time the local is captured in
        // assertion lambda - means this line is fine as it is. please do not change.
        Stream stream = Stream.Null;
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => stream.Write((ushort)420, (Endianness)(-1)));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => stream.Write((ushort)420, (Endianness)(-1)));
    }

    [TestMethod]
    [CLSCompliant(false)]
    public void WriteUInt16_ShouldWriteBigEndian_GivenBigEndian()
    {
        using var stream = new MemoryStream();
        stream.Write((ushort)420, Endianness.BigEndian);
        Assert.AreEqual(2, stream.Position);
        stream.Position = 0;

        Span<byte> actual = stackalloc byte[2];
        ReadOnlySpan<byte> expected = stackalloc byte[] {0x01, 0xA4};
        int read = stream.Read(actual);

        Assert.AreEqual(2, read);
        CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
    }

    [TestMethod]
    [CLSCompliant(false)]
    public void WriteUInt16_ShouldWriteLittleEndian_GivenLittleEndian()
    {
        using var stream = new MemoryStream();
        stream.Write((ushort)420, Endianness.LittleEndian);
        Assert.AreEqual(2, stream.Position);
        stream.Position = 0;

        Span<byte> actual = stackalloc byte[2];
        ReadOnlySpan<byte> expected = stackalloc byte[] {0xA4, 0x01};
        int read = stream.Read(actual);

        Assert.AreEqual(2, read);
        CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
    }
}
