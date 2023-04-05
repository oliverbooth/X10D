using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

[TestFixture]
public class BooleanTests
{
    [Test]
    public void GetBytes_ReturnsArrayContaining1()
    {
        const bool value = true;
        CollectionAssert.AreEqual(new byte[] {1}, value.GetBytes());
    }

    [Test]
    public void TryWriteBytes_ReturnsTrue_FillsSpanContaining1_GivenLargeEnoughSpan()
    {
        const bool value = true;
        Span<byte> buffer = stackalloc byte[1];
        Assert.That(value.TryWriteBytes(buffer));
        CollectionAssert.AreEqual(new byte[] {1}, buffer.ToArray());
    }

    [Test]
    public void TryWriteBytes_ReturnsFalse_GivenSmallSpan()
    {
        const bool value = true;
        Span<byte> buffer = stackalloc byte[0];
        Assert.That(value.TryWriteBytes(buffer), Is.False);
    }
}
