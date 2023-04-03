using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class PointTests
{
    [TestMethod]
    public void IsOnLine_ShouldReturnTrue_GivenPointOnLine()
    {
        var point = new Point(1, 0);
        var line = new Line(Point.Empty, new Point(2, 0));

        Assert.IsTrue(point.IsOnLine(line));
        Assert.IsTrue(point.IsOnLine(line.Start, line.End));
        Assert.IsTrue(point.IsOnLine(line.Start.ToVector2(), line.End.ToVector2()));
    }

    [TestMethod]
    public void IsOnLine_ShouldReturnFalse_GivenPointNotOnLine()
    {
        var point = new Point(1, 1);
        var line = new Line(Point.Empty, new Point(2, 0));

        Assert.IsFalse(point.IsOnLine(line));
        Assert.IsFalse(point.IsOnLine(line.Start, line.End));
        Assert.IsFalse(point.IsOnLine(line.Start.ToVector2(), line.End.ToVector2()));
    }

    [TestMethod]
    public void ToSize_ShouldReturnSize_WithEquivalentMembers()
    {
        var random = new Random();
        var point = new Point(random.Next(), random.Next());
        var size = point.ToSize();

        Assert.AreEqual(point.X, size.Width);
        Assert.AreEqual(point.Y, size.Height);
    }

    [TestMethod]
    public void ToSizeF_ShouldReturnSize_WithEquivalentMembers()
    {
        var random = new Random();
        var point = new Point(random.Next(), random.Next());
        var size = point.ToSizeF();

        Assert.AreEqual(point.X, size.Width, 1e-6f);
        Assert.AreEqual(point.Y, size.Height, 1e-6f);
    }

    [TestMethod]
    public void ToVector2_ShouldReturnVector_WithEquivalentMembers()
    {
        var random = new Random();
        var point = new Point(random.Next(), random.Next());
        var size = point.ToVector2();

        Assert.AreEqual(point.X, size.X, 1e-6f);
        Assert.AreEqual(point.Y, size.Y, 1e-6f);
    }
}
