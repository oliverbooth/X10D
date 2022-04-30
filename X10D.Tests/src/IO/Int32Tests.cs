using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.IO;

namespace X10D.Tests.IO;

[TestClass]
public class Int32Tests
{
    [TestMethod]
    public void GetBytes_ReturnsCorrectValue()
    {
        const int value = 0x0F;
        byte[] bytes = BitConverter.IsLittleEndian ? new byte[] {0x0F, 0, 0, 0} : new byte[] {0, 0, 0, 0x0F};
        CollectionAssert.AreEqual(bytes, value.GetBytes());
    }

    [TestMethod]
    public void GetBytes_ReturnsCorrectValue_WithEndianness()
    {
        const int value = 0x0F;
        byte[] littleEndian = {0x0F, 0, 0, 0};
        byte[] bigEndian = {0, 0, 0, 0x0F};

        CollectionAssert.AreEqual(littleEndian, value.GetBytes(Endianness.LittleEndian));
        CollectionAssert.AreEqual(bigEndian, value.GetBytes(Endianness.BigEndian));
    }

    [TestMethod]
    public void TryWriteBytes_ReturnsTrue_FillsSpanCorrectly_GivenLargeEnoughSpan()
    {
        const int value = 0x0F;
        byte[] bytes = BitConverter.IsLittleEndian ? new byte[] {0x0F, 0, 0, 0} : new byte[] {0, 0, 0, 0x0F};

        Span<byte> buffer = stackalloc byte[4];
        Assert.IsTrue(value.TryWriteBytes(buffer));
        CollectionAssert.AreEqual(bytes, buffer.ToArray());
    }

    [TestMethod]
    public void TryWriteBytes_ReturnsTrue_FillsSpanCorrectly_GivenLargeEnoughSpan_WithEndianness()
    {
        const int value = 0x0F;
        byte[] littleEndian = {0x0F, 0, 0, 0};
        byte[] bigEndian = {0, 0, 0, 0x0F};

        Span<byte> buffer = stackalloc byte[4];

        Assert.IsTrue(value.TryWriteBytes(buffer, Endianness.LittleEndian));
        CollectionAssert.AreEqual(littleEndian, buffer.ToArray());

        Assert.IsTrue(value.TryWriteBytes(buffer, Endianness.BigEndian));
        CollectionAssert.AreEqual(bigEndian, buffer.ToArray());
    }

    [TestMethod]
    public void TryWriteBytes_ReturnsFalse_GivenSmallSpan()
    {
        const int value = 0x0F;
        Span<byte> buffer = stackalloc byte[0];
        Assert.IsFalse(value.TryWriteBytes(buffer));
    }
}
