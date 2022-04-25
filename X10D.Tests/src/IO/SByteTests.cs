using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.IO;

namespace X10D.Tests.IO;

[TestClass]
[CLSCompliant(false)]
public class SByteTests
{
    [TestMethod]
    public void GetBytes_ReturnsArrayContainingItself()
    {
        const sbyte value = 0x0F;
        CollectionAssert.AreEqual(new[] {(byte)value}, value.GetBytes());
    }

    [TestMethod]
    public void TryWriteBytes_ReturnsTrue_FillsSpanContainingItself_GivenLargeEnoughSpan()
    {
        const sbyte value = 0x0F;
        Span<byte> buffer = stackalloc byte[1];
        Assert.IsTrue(value.TryWriteBytes(buffer));
        CollectionAssert.AreEqual(new[] {(byte)value}, buffer.ToArray());
    }

    [TestMethod]
    public void TryWriteBytes_ReturnsFalse_GivenSmallSpan()
    {
        const sbyte value = 0x0F;
        Span<byte> buffer = stackalloc byte[0];
        Assert.IsFalse(value.TryWriteBytes(buffer));
    }
}
