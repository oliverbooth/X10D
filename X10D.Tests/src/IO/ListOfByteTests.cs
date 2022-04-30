using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.IO;

namespace X10D.Tests.IO;

[TestClass]
public class ListOfByteTests
{
    [TestMethod]
    public void AsString_ShouldReturnBytes_GivenBytes()
    {
        var bytes = new byte[] {0x01, 0x02, 0x03, 0x04, 0x05};
        Assert.AreEqual("01-02-03-04-05", bytes.AsString());
    }

    [TestMethod]
    public void AsString_ShouldThrow_GivenNullArray()
    {
        byte[]? bytes = null;
        Assert.ThrowsException<ArgumentNullException>(() => bytes!.AsString());
    }

    [TestMethod]
    public void ToDouble_ShouldReturnDouble_GivenBytes()
    {
        var bytes = new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x7A, 0x40};

        if (!BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }

        Assert.AreEqual(420.0, bytes.ToDouble(), 1e-6);
    }

    [TestMethod]
    public void ToDouble_ShouldThrow_GivenNullArray()
    {
        byte[]? bytes = null;
        Assert.ThrowsException<ArgumentNullException>(() => bytes!.ToDouble());
    }

    [TestMethod]
    public void ToInt16_ShouldReturnInt16_GivenBytes()
    {
        var bytes = new byte[] {0xA4, 0x01};
        Assert.AreEqual(420, bytes.ToInt16());
    }

    [TestMethod]
    public void ToInt16_ShouldThrow_GivenNullArray()
    {
        byte[]? bytes = null;
        Assert.ThrowsException<ArgumentNullException>(() => bytes!.ToInt16());
    }

    [TestMethod]
    public void ToInt32_ShouldReturnInt32_GivenBytes()
    {
        var bytes = new byte[] {0xA4, 0x01, 0x00, 0x00};
        Assert.AreEqual(420, bytes.ToInt32());
    }

    [TestMethod]
    public void ToInt32_ShouldThrow_GivenNullArray()
    {
        byte[]? bytes = null;
        Assert.ThrowsException<ArgumentNullException>(() => bytes!.ToInt32());
    }

    [TestMethod]
    public void ToInt64_ShouldReturnInt32_GivenBytes()
    {
        var bytes = new byte[] {0xA4, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
        Assert.AreEqual(420L, bytes.ToInt64());
    }

    [TestMethod]
    public void ToInt64_ShouldThrow_GivenNullArray()
    {
        byte[]? bytes = null;
        Assert.ThrowsException<ArgumentNullException>(() => bytes!.ToInt64());
    }

    [TestMethod]
    public void ToSingle_ShouldReturnDouble_GivenBytes()
    {
        var bytes = new byte[] {0x00, 0x00, 0xD2, 0x43};

        if (!BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }

        Assert.AreEqual(420.0, bytes.ToSingle(), 1e-6);
    }

    [TestMethod]
    public void ToSingle_ShouldThrow_GivenNullArray()
    {
        byte[]? bytes = null;
        Assert.ThrowsException<ArgumentNullException>(() => bytes!.ToSingle());
    }

    [TestMethod]
    public void ToString_ShouldReturnHelloWorld_GivenUTF8()
    {
        var bytes = new byte[] {0x48, 0x65, 0x6C, 0x6C, 0x6F, 0x20, 0x57, 0x6F, 0x72, 0x6C, 0x64};
        Assert.AreEqual("Hello World", bytes.ToString(Encoding.UTF8));
    }

    [TestMethod]
    public void ToString_ShouldThrow_GivenNullArray()
    {
        byte[]? bytes = null;
        Assert.ThrowsException<ArgumentNullException>(() => bytes!.ToString(Encoding.UTF8));
    }

    [TestMethod]
    public void ToString_ShouldThrow_GivenNullEncoding()
    {
        var bytes = new byte[] {0x48, 0x65, 0x6C, 0x6C, 0x6F, 0x20, 0x57, 0x6F, 0x72, 0x6C, 0x64};
        Assert.ThrowsException<ArgumentNullException>(() => bytes.ToString(null!));
    }

    [TestMethod]
    public void ToUInt16_ShouldReturnInt16_GivenBytes()
    {
        var bytes = new byte[] {0xA4, 0x01};
        Assert.AreEqual((ushort)420, bytes.ToUInt16());
    }

    [TestMethod]
    public void ToUInt16_ShouldThrow_GivenNullArray()
    {
        byte[]? bytes = null;
        Assert.ThrowsException<ArgumentNullException>(() => bytes!.ToUInt16());
    }

    [TestMethod]
    public void ToUInt32_ShouldReturnInt32_GivenBytes()
    {
        var bytes = new byte[] {0xA4, 0x01, 0x00, 0x00};
        Assert.AreEqual(420U, bytes.ToUInt32());
    }

    [TestMethod]
    public void ToUInt32_ShouldThrow_GivenNullArray()
    {
        byte[]? bytes = null;
        Assert.ThrowsException<ArgumentNullException>(() => bytes!.ToUInt32());
    }

    [TestMethod]
    public void ToUInt64_ShouldReturnInt32_GivenBytes()
    {
        var bytes = new byte[] {0xA4, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
        Assert.AreEqual(420UL, bytes.ToUInt64());
    }

    [TestMethod]
    public void ToUInt64_ShouldThrow_GivenNullArray()
    {
        byte[]? bytes = null;
        Assert.ThrowsException<ArgumentNullException>(() => bytes!.ToUInt64());
    }
}
