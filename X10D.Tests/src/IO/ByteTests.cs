using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.IO;

namespace X10D.Tests.IO;

[TestClass]
public class ByteTests
{
    [TestMethod]
    public void GetBytes_ReturnsArrayContainingItself()
    {
        const byte value = 0xFF;
        CollectionAssert.AreEqual(new[] {value}, value.GetBytes());
    }

    [TestMethod]
    public void TryWriteBytes_ReturnsTrue_FillsSpanContainingItself_GivenLargeEnoughSpan()
    {
        const byte value = 0xFF;
        Span<byte> buffer = stackalloc byte[1];
        Assert.IsTrue(value.TryWriteBytes(buffer));
        CollectionAssert.AreEqual(new[] {value}, buffer.ToArray());
    }

    [TestMethod]
    public void TryWriteBytes_ReturnsFalse_GivenSmallSpan()
    {
        const byte value = 0x0F;
        Span<byte> buffer = stackalloc byte[0];
        Assert.IsFalse(value.TryWriteBytes(buffer));
    }
}
