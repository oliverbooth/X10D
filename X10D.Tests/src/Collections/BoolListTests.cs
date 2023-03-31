using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestClass]
public class BoolListTests
{
    [TestMethod]
    public void PackByte_Should_Pack_Correctly()
    {
        var array = new[] {true, false, true, false, true, false, true, false};
        Assert.AreEqual(85, array.PackByte()); // 01010101
    }

    [TestMethod]
    public void Pack16Bit_Should_Pack_Correctly()
    {
        var array = new[] {true, false, true, false, true, false, true, false, true, true, false, true};
        Assert.AreEqual(2901, array.PackInt16()); // 101101010101
    }

    [TestMethod]
    public void Pack32Bit_Should_Pack_Correctly()
    {
        var array = new[] {true, false, true, false, true, false, true, false, true, true, false, true};
        Assert.AreEqual(2901, array.PackInt32()); // 101101010101
    }

    [TestMethod]
    public void Pack64Bit_Should_Pack_Correctly()
    {
        var array = new[] {true, false, true, false, true, false, true, false, true, true, false, true};
        Assert.AreEqual(2901, array.PackInt64()); // 101101010101
    }

    [TestMethod]
    public void Pack_ShouldThrow_GivenLargeArray()
    {
        bool[] array = Enumerable.Repeat(false, 65).ToArray();
        Assert.ThrowsException<ArgumentException>(() => array.PackByte());
        Assert.ThrowsException<ArgumentException>(() => array.PackInt16());
        Assert.ThrowsException<ArgumentException>(() => array.PackInt32());
        Assert.ThrowsException<ArgumentException>(() => array.PackInt64());
    }

    [TestMethod]
    public void Pack_ShouldThrow_GivenNull()
    {
        bool[]? array = null;
        Assert.ThrowsException<ArgumentNullException>(() => array!.PackByte());
        Assert.ThrowsException<ArgumentNullException>(() => array!.PackInt16());
        Assert.ThrowsException<ArgumentNullException>(() => array!.PackInt32());
        Assert.ThrowsException<ArgumentNullException>(() => array!.PackInt64());
    }
}
