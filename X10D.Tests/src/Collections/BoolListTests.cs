using NUnit.Framework;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestFixture]
internal class BoolListTests
{
    [Test]
    public void PackByte_Should_Pack_Correctly()
    {
        var array = new[] {true, false, true, false, true, false, true, false};
        Assert.That(array.PackByte(), Is.EqualTo(85)); // 01010101
    }

    [Test]
    public void Pack16Bit_Should_Pack_Correctly()
    {
        var array = new[] {true, false, true, false, true, false, true, false, true, true, false, true};
        Assert.That(array.PackInt16(), Is.EqualTo(2901)); // 101101010101
    }

    [Test]
    public void Pack32Bit_Should_Pack_Correctly()
    {
        var array = new[] {true, false, true, false, true, false, true, false, true, true, false, true};
        Assert.That(array.PackInt32(), Is.EqualTo(2901)); // 101101010101
    }

    [Test]
    public void Pack64Bit_Should_Pack_Correctly()
    {
        var array = new[] {true, false, true, false, true, false, true, false, true, true, false, true};
        Assert.That(array.PackInt64(), Is.EqualTo(2901)); // 101101010101
    }

    [Test]
    public void Pack_ShouldThrow_GivenLargeArray()
    {
        bool[] array = Enumerable.Repeat(false, 65).ToArray();
        Assert.Throws<ArgumentException>(() => _ = array.PackByte());
        Assert.Throws<ArgumentException>(() => _ = array.PackInt16());
        Assert.Throws<ArgumentException>(() => _ = array.PackInt32());
        Assert.Throws<ArgumentException>(() => _ = array.PackInt64());
    }

    [Test]
    public void Pack_ShouldThrow_GivenNull()
    {
        bool[] array = null!;
        Assert.Throws<ArgumentNullException>(() => _ = array.PackByte());
        Assert.Throws<ArgumentNullException>(() => _ = array.PackInt16());
        Assert.Throws<ArgumentNullException>(() => _ = array.PackInt32());
        Assert.Throws<ArgumentNullException>(() => _ = array.PackInt64());
    }
}
