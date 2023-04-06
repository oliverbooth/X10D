using System.Text;
using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

[TestFixture]
public class ListOfByteTests
{
    [Test]
    public void AsString_ShouldReturnBytes_GivenBytes()
    {
        var bytes = new byte[] {0x01, 0x02, 0x03, 0x04, 0x05};
        Assert.That(bytes.AsString(), Is.EqualTo("01-02-03-04-05"));
    }

    [Test]
    public void AsString_ShouldThrow_GivenNullArray()
    {
        byte[]? bytes = null;
        Assert.Throws<ArgumentNullException>(() => bytes!.AsString());
    }

    [Test]
    public void ToDouble_ShouldReturnDouble_GivenBytes()
    {
        var bytes = new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x7A, 0x40};

        if (!BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }

        Assert.That(bytes.ToDouble(), Is.EqualTo(420.0).Within(1e-6));
    }

    [Test]
    public void ToDouble_ShouldThrow_GivenNullArray()
    {
        byte[] bytes = null!;
        Assert.Throws<ArgumentNullException>(() => bytes.ToDouble());
    }

    [Test]
    public void ToInt16_ShouldReturnInt16_GivenBytes()
    {
        var bytes = new byte[] {0xA4, 0x01};
        Assert.That(bytes.ToInt16(), Is.EqualTo(420));
    }

    [Test]
    public void ToInt16_ShouldThrow_GivenNullArray()
    {
        byte[] bytes = null!;
        Assert.Throws<ArgumentNullException>(() => bytes.ToInt16());
    }

    [Test]
    public void ToInt32_ShouldReturnInt32_GivenBytes()
    {
        var bytes = new byte[] {0xA4, 0x01, 0x00, 0x00};
        Assert.That(bytes.ToInt32(), Is.EqualTo(420));
    }

    [Test]
    public void ToInt32_ShouldThrow_GivenNullArray()
    {
        byte[] bytes = null!;
        Assert.Throws<ArgumentNullException>(() => bytes.ToInt32());
    }

    [Test]
    public void ToInt64_ShouldReturnInt32_GivenBytes()
    {
        var bytes = new byte[] {0xA4, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
        Assert.That(bytes.ToInt64(), Is.EqualTo(420L));
    }

    [Test]
    public void ToInt64_ShouldThrow_GivenNullArray()
    {
        byte[]? bytes = null;
        Assert.Throws<ArgumentNullException>(() => bytes!.ToInt64());
    }

    [Test]
    public void ToSingle_ShouldReturnDouble_GivenBytes()
    {
        var bytes = new byte[] {0x00, 0x00, 0xD2, 0x43};

        if (!BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }

        Assert.That(bytes.ToSingle(), Is.EqualTo(420.0).Within(1e-6));
    }

    [Test]
    public void ToSingle_ShouldThrow_GivenNullArray()
    {
        byte[] bytes = null!;
        Assert.Throws<ArgumentNullException>(() => bytes.ToSingle());
    }

    [Test]
    public void ToString_ShouldReturnHelloWorld_GivenUTF8()
    {
        var bytes = new byte[] {0x48, 0x65, 0x6C, 0x6C, 0x6F, 0x20, 0x57, 0x6F, 0x72, 0x6C, 0x64};
        Assert.That(bytes.ToString(Encoding.UTF8), Is.EqualTo("Hello World"));
    }

    [Test]
    public void ToString_ShouldThrow_GivenNullArray()
    {
        byte[] bytes = null!;
        Assert.Throws<ArgumentNullException>(() => bytes.ToString(Encoding.UTF8));
    }

    [Test]
    public void ToString_ShouldThrow_GivenNullEncoding()
    {
        var bytes = new byte[] {0x48, 0x65, 0x6C, 0x6C, 0x6F, 0x20, 0x57, 0x6F, 0x72, 0x6C, 0x64};
        Assert.Throws<ArgumentNullException>(() => bytes.ToString(null!));
    }

    [Test]
    public void ToUInt16_ShouldReturnInt16_GivenBytes()
    {
        var bytes = new byte[] {0xA4, 0x01};
        Assert.That(bytes.ToUInt16(), Is.EqualTo((ushort)420));
    }

    [Test]
    public void ToUInt16_ShouldThrow_GivenNullArray()
    {
        byte[] bytes = null!;
        Assert.Throws<ArgumentNullException>(() => bytes.ToUInt16());
    }

    [Test]
    public void ToUInt32_ShouldReturnInt32_GivenBytes()
    {
        var bytes = new byte[] {0xA4, 0x01, 0x00, 0x00};
        Assert.That(bytes.ToUInt32(), Is.EqualTo(420U));
    }

    [Test]
    public void ToUInt32_ShouldThrow_GivenNullArray()
    {
        byte[]? bytes = null;
        Assert.Throws<ArgumentNullException>(() => bytes!.ToUInt32());
    }

    [Test]
    public void ToUInt64_ShouldReturnInt32_GivenBytes()
    {
        var bytes = new byte[] {0xA4, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
        Assert.That(bytes.ToUInt64(), Is.EqualTo(420UL));
    }

    [Test]
    public void ToUInt64_ShouldThrow_GivenNullArray()
    {
        byte[] bytes = null!;
        Assert.Throws<ArgumentNullException>(() => bytes.ToUInt64());
    }
}
