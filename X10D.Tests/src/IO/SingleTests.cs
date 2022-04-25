using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.IO;

namespace X10D.Tests.IO;

[TestClass]
public class SingleTests
{
    [TestMethod]
    public void GetBytes_ReturnsCorrectValue()
    {
        const float value = 42.5f;
        byte[] bytes = BitConverter.IsLittleEndian
            ? new byte[] {0, 0, 0x2A, 0x42}
            : new byte[] {0x42, 0x2A, 0, 0};
        CollectionAssert.AreEqual(bytes, value.GetBytes());
    }

    [TestMethod]
    public void GetBytes_ReturnsCorrectValue_WithEndianness()
    {
        const float value = 42.5f;
        byte[] littleEndian = {0, 0, 0x2A, 0x42};
        byte[] bigEndian = {0x42, 0x2A, 0, 0};

        CollectionAssert.AreEqual(littleEndian, value.GetBytes(Endianness.LittleEndian));
        CollectionAssert.AreEqual(bigEndian, value.GetBytes(Endianness.BigEndian));
    }

    [TestMethod]
    public void TryWriteBytes_ReturnsTrue_FillsSpanCorrectly_GivenLargeEnoughSpan()
    {
        const float value = 42.5f;
        byte[] bytes = BitConverter.IsLittleEndian
            ? new byte[] {0, 0, 0x2A, 0x42}
            : new byte[] {0x42, 0x2A, 0, 0};

        Span<byte> buffer = stackalloc byte[4];
        Assert.IsTrue(value.TryWriteBytes(buffer));
        CollectionAssert.AreEqual(bytes, buffer.ToArray());
    }

    [TestMethod]
    public void TryWriteBytes_ReturnsTrue_FillsSpanCorrectly_GivenLargeEnoughSpan_WithEndianness()
    {
        const float value = 42.5f;
        byte[] littleEndian = {0, 0, 0x2A, 0x42};
        byte[] bigEndian = {0x42, 0x2A, 0, 0};

        Span<byte> buffer = stackalloc byte[4];

        Assert.IsTrue(value.TryWriteBytes(buffer, Endianness.LittleEndian));
        CollectionAssert.AreEqual(littleEndian, buffer.ToArray());

        Assert.IsTrue(value.TryWriteBytes(buffer, Endianness.BigEndian));
        CollectionAssert.AreEqual(bigEndian, buffer.ToArray());
    }

    [TestMethod]
    public void TryWriteBytes_ReturnsFalse_GivenSmallSpan()
    {
        const float value = 42.5f;
        Span<byte> buffer = stackalloc byte[0];
        Assert.IsFalse(value.TryWriteBytes(buffer));
    }
}
