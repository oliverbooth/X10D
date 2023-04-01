using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#if !NET6_0_OR_GREATER
using X10D.Core;
#endif
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class PointFTests
{
    [TestMethod]
    public void IsOnLine_ShouldReturnTrue_GivenPointOnLine()
    {
        var point = new PointF(1.0f, 0.0f);
        var line = new LineF(PointF.Empty, new PointF(2.0f, 0.0f));

        Assert.IsTrue(point.IsOnLine(line));
        Assert.IsTrue(point.IsOnLine(line.Start, line.End));
        Assert.IsTrue(point.IsOnLine(line.Start.ToVector2(), line.End.ToVector2()));
    }

    [TestMethod]
    public void IsOnLine_ShouldReturnFalse_GivenPointNotOnLine()
    {
        var point = new PointF(1.0f, 1.0f);
        var line = new LineF(PointF.Empty, new PointF(2.0f, 0.0f));

        Assert.IsFalse(point.IsOnLine(line));
        Assert.IsFalse(point.IsOnLine(line.Start, line.End));
        Assert.IsFalse(point.IsOnLine(line.Start.ToVector2(), line.End.ToVector2()));
    }

    [TestMethod]
    public void Round_ShouldRoundToNearestInteger_GivenNoParameters()
    {
        var point = new PointF(1.5f, 2.6f);
        var rounded = point.Round();

        Assert.AreEqual(2, rounded.X);
        Assert.AreEqual(3, rounded.Y);
    }

    [TestMethod]
    public void Round_ShouldRoundToNearest10_GivenPrecision10()
    {
        var point = new PointF(1.5f, 25.2f);
        var rounded = point.Round(10);

        Assert.AreEqual(0, rounded.X);
        Assert.AreEqual(30, rounded.Y);
    }

    [TestMethod]
    public void ToSizeF_ShouldReturnSize_WithEquivalentMembers()
    {
        var random = new Random();
        var point = new PointF(random.NextSingle(), random.NextSingle());
        var size = point.ToSizeF();

        Assert.AreEqual(point.X, size.Width, 1e-6f);
        Assert.AreEqual(point.Y, size.Height, 1e-6f);
    }
}
