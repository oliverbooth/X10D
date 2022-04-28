using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestClass]
public class BoolListTests
{
    [TestMethod]
    public void Pack8Bit_Should_Pack_Correctly()
    {
        var array = new[] {true, false, true, false, true, false, true, false};
        Assert.AreEqual(85, array.Pack8Bit()); // 01010101
    }

    [TestMethod]
    public void Pack16Bit_Should_Pack_Correctly()
    {
        var array = new[] {true, false, true, false, true, false, true, false, true, true, false, true};
        Assert.AreEqual(2901, array.Pack16Bit()); // 101101010101
    }

    [TestMethod]
    public void Pack32Bit_Should_Pack_Correctly()
    {
        var array = new[] {true, false, true, false, true, false, true, false, true, true, false, true};
        Assert.AreEqual(2901, array.Pack32Bit()); // 101101010101
    }

    [TestMethod]
    public void Pack64Bit_Should_Pack_Correctly()
    {
        var array = new[] {true, false, true, false, true, false, true, false, true, true, false, true};
        Assert.AreEqual(2901, array.Pack64Bit()); // 101101010101
    }

    [TestMethod]
    public void Pack_ShouldThrow_GivenLargeArray()
    {
        bool[] array = Enumerable.Repeat(false, 65).ToArray();
        Assert.ThrowsException<ArgumentException>(() => array.Pack8Bit());
        Assert.ThrowsException<ArgumentException>(() => array.Pack16Bit());
        Assert.ThrowsException<ArgumentException>(() => array.Pack32Bit());
        Assert.ThrowsException<ArgumentException>(() => array.Pack64Bit());
    }

    [TestMethod]
    public void Pack_ShouldThrow_GivenNull()
    {
        bool[]? array = null;
        Assert.ThrowsException<ArgumentNullException>(() => array!.Pack8Bit());
        Assert.ThrowsException<ArgumentNullException>(() => array!.Pack16Bit());
        Assert.ThrowsException<ArgumentNullException>(() => array!.Pack32Bit());
        Assert.ThrowsException<ArgumentNullException>(() => array!.Pack64Bit());
    }
}
