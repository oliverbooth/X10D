using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class SizeTests
{
    [TestMethod]
    public void ToPoint_ShouldReturnPoint_WithEquivalentMembers()
    {
        var random = new Random();
        var size = new Size(random.Next(), random.Next());
        var point = size.ToPoint();

        Assert.AreEqual(size.Width, point.X);
        Assert.AreEqual(size.Height, point.Y);
    }

    [TestMethod]
    public void ToPointF_ShouldReturnPoint_WithEquivalentMembers()
    {
        var random = new Random();
        var size = new Size(random.Next(), random.Next());
        var point = size.ToPointF();

        Assert.AreEqual(size.Width, point.X, 1e-6f);
        Assert.AreEqual(size.Height, point.Y, 1e-6f);
    }

    [TestMethod]
    public void ToVector2_ShouldReturnVector_WithEquivalentMembers()
    {
        var random = new Random();
        var point = new Size(random.Next(), random.Next());
        var size = point.ToVector2();

        Assert.AreEqual(point.Width, size.X, 1e-6f);
        Assert.AreEqual(point.Height, size.Y, 1e-6f);
    }
}
