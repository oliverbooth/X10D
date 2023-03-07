using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class RandomTests
{
    [TestMethod]
    public void NextColorArgb_ShouldReturn331515e5_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.AreEqual(Color.FromArgb(51, 21, 21, 229), random.NextColorArgb());
    }

    [TestMethod]
    public void NextColorArgb_ShouldThrow_GivenNull()
    {
        Random? random = null;
        Assert.ThrowsException<ArgumentNullException>(() => random!.NextColorArgb());
    }

    [TestMethod]
    public void NextColorRgb_ShouldReturn1515e5_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.AreEqual(Color.FromArgb(255, 21, 21, 229), random.NextColorRgb());
    }

    [TestMethod]
    public void NextColorRgb_ShouldThrow_GivenNull()
    {
        Random? random = null;
        Assert.ThrowsException<ArgumentNullException>(() => random!.NextColorRgb());
    }
}
