using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.IO;

namespace X10D.Tests.IO;

public partial class StreamTests
{
    [TestMethod]
    public void ReadSingle_ShouldThrowArgumentException_GivenNonReadableStream()
    {
        Stream stream = new DummyStream();
        Assert.ThrowsException<ArgumentException>(() => stream.ReadSingle());
        Assert.ThrowsException<ArgumentException>(() => stream.ReadSingle(Endianness.LittleEndian));
        Assert.ThrowsException<ArgumentException>(() => stream.ReadSingle(Endianness.BigEndian));
    }

    [TestMethod]
    public void ReadSingle_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.ThrowsException<ArgumentNullException>(() => stream.ReadSingle());
        Assert.ThrowsException<ArgumentNullException>(() => stream.ReadSingle(Endianness.LittleEndian));
        Assert.ThrowsException<ArgumentNullException>(() => stream.ReadSingle(Endianness.BigEndian));
    }

    [TestMethod]
    public void ReadSingle_ShouldThrowArgumentOutOfRangeException_GivenInvalidEndiannessValue()
    {
        // we don't need to enclose this stream in a using declaration, since disposing a
        // null stream is meaningless. NullStream.Dispose actually does nothing, anyway.
        // that - coupled with the fact that encapsulating the stream in a using declaration causes the
        // analyser to trip up and think the stream is disposed by the time the local is captured in
        // assertion lambda - means this line is fine as it is. please do not change.
        Stream stream = Stream.Null;
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => stream.ReadSingle((Endianness)(-1)));
    }

    [TestMethod]
    public void ReadSingle_ShouldReadBigEndian_GivenBigEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] {0x43, 0xD2, 0x00, 0x00};
        stream.Write(bytes);
        stream.Position = 0;

        const float expected = 420.0f;
        float actual = stream.ReadSingle(Endianness.BigEndian);

        Assert.AreEqual(4, stream.Position);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ReadSingle_ShouldReadLittleEndian_GivenLittleEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] {0x00, 0x00, 0xD2, 0x43};
        stream.Write(bytes);
        stream.Position = 0;

        const float expected = 420.0f;
        float actual = stream.ReadSingle(Endianness.LittleEndian);

        Assert.AreEqual(4, stream.Position);
        Assert.AreEqual(expected, actual);
    }
}
