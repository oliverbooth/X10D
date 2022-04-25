using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.IO;

namespace X10D.Tests.IO;

[TestClass]
public class BooleanTests
{
    [TestMethod]
    public void GetBytes_ReturnsArrayContaining1()
    {
        const bool value = true;
        CollectionAssert.AreEqual(new byte[] {1}, value.GetBytes());
    }

    [TestMethod]
    public void TryWriteBytes_ReturnsTrue_FillsSpanContaining1_GivenLargeEnoughSpan()
    {
        const bool value = true;
        Span<byte> buffer = stackalloc byte[1];
        Assert.IsTrue(value.TryWriteBytes(buffer));
        CollectionAssert.AreEqual(new byte[] {1}, buffer.ToArray());
    }

    [TestMethod]
    public void TryWriteBytes_ReturnsFalse_GivenSmallSpan()
    {
        const bool value = true;
        Span<byte> buffer = stackalloc byte[0];
        Assert.IsFalse(value.TryWriteBytes(buffer));
    }
}
