using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

[TestFixture]
internal class DecimalTests
{
    [Test]
    public void GetBigEndianBytes_ShouldReturnBytes_InBigEndian()
    {
        const decimal value = 1234m;
        byte[] expected = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 210];

        byte[] bytes = value.GetBigEndianBytes();

        CollectionAssert.AreEqual(expected, bytes);
    }

    [Test]
    public void GetLittleEndianBytes_ShouldReturnBytes_InLittleEndian()
    {
        const decimal value = 1234m;
        byte[] expected = [210, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

        byte[] bytes = value.GetLittleEndianBytes();

        CollectionAssert.AreEqual(expected, bytes);
    }

    [Test]
    public void TryWriteBigEndianBytes_ShouldWriteBytes_InBigEndian()
    {
        const decimal value = 1234m;
        byte[] expected = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 210];

        Span<byte> bytes = stackalloc byte[16];
        value.TryWriteBigEndianBytes(bytes);

        CollectionAssert.AreEqual(expected, bytes.ToArray());
    }

    [Test]
    public void TryWriteLittleEndianBytes_ShouldWriteBytes_InLittleEndian()
    {
        const decimal value = 1234m;
        byte[] expected = [210, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

        Span<byte> bytes = stackalloc byte[16];
        value.TryWriteLittleEndianBytes(bytes);

        CollectionAssert.AreEqual(expected, bytes.ToArray());
    }
}
