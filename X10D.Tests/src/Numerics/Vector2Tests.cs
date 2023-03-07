using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Core;
using X10D.Drawing;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestClass]
public class Vector2Tests
{
    [TestMethod]
    public void Deconstruct_ShouldReturnCorrectValues()
    {
        var vector = new Vector2(1, 2);
        (float x, float y) = vector;

        Assert.AreEqual(1, x);
        Assert.AreEqual(2, y);
    }

    [TestMethod]
    public void IsOnLine_ShouldReturnTrue_ForPointOnLine()
    {
        Vector2 start = Vector2.Zero;
        Vector2 end = Vector2.UnitX;
        Vector2 point = new Vector2(0.5f, 0.0f);
        var line = new LineF(start, end);
        
        Assert.IsTrue(point.IsOnLine(line));
        Assert.IsTrue(point.IsOnLine(line.Start, line.End));
        Assert.IsTrue(point.IsOnLine(line.Start.ToVector2(), line.End.ToVector2()));
    }

    [TestMethod]
    public void IsOnLine_ShouldReturnFalse_ForPointNotOnLine()
    {
        Vector2 start = Vector2.Zero;
        Vector2 end = Vector2.UnitX;
        Vector2 point = new Vector2(0.5f, 1.0f);
        var line = new LineF(start, end);
        
        Assert.IsFalse(point.IsOnLine(line));
        Assert.IsFalse(point.IsOnLine(line.Start, line.End));
        Assert.IsFalse(point.IsOnLine(line.Start.ToVector2(), line.End.ToVector2()));
    }

    [TestMethod]
    public void Round_ShouldRoundToNearestInteger_GivenNoParameters()
    {
        var vector = new Vector2(1.5f, 2.6f);
        var rounded = vector.Round();

        Assert.AreEqual(2, rounded.X);
        Assert.AreEqual(3, rounded.Y);
    }

    [TestMethod]
    public void Round_ShouldRoundToNearest10_GivenPrecision10()
    {
        var vector = new Vector2(1.5f, 25.2f);
        var rounded = vector.Round(10);

        Assert.AreEqual(0, rounded.X);
        Assert.AreEqual(30, rounded.Y);
    }

    [TestMethod]
    public void ToPointF_ShouldReturnPoint_WithEquivalentMembers()
    {
        var random = new Random();
        var vector = new Vector2(random.NextSingle(), random.NextSingle());
        var point = vector.ToPointF();

        Assert.AreEqual(vector.X, point.X, 1e-6f);
        Assert.AreEqual(vector.Y, point.Y, 1e-6f);
    }

    [TestMethod]
    public void ToSizeF_ShouldReturnSize_WithEquivalentMembers()
    {
        var random = new Random();
        var vector = new Vector2(random.NextSingle(), random.NextSingle());
        var size = vector.ToSizeF();

        Assert.AreEqual(vector.X, size.Width);
        Assert.AreEqual(vector.Y, size.Height);
    }

    [TestMethod]
    public void WithX_ShouldReturnVectorWithNewX_GivenVector()
    {
        Assert.AreEqual(Vector2.UnitY, Vector2.One.WithX(0));
        Assert.AreEqual(Vector2.Zero, Vector2.Zero.WithX(0));
        Assert.AreEqual(Vector2.Zero, Vector2.UnitX.WithX(0));
        Assert.AreEqual(Vector2.UnitY, Vector2.UnitY.WithX(0));

        Assert.AreEqual(Vector2.One, Vector2.One.WithX(1));
        Assert.AreEqual(Vector2.UnitX, Vector2.Zero.WithX(1));
        Assert.AreEqual(Vector2.UnitX, Vector2.UnitX.WithX(1));
        Assert.AreEqual(Vector2.One, Vector2.UnitY.WithX(1));
    }

    [TestMethod]
    public void WithY_ShouldReturnVectorWithNewY_GivenVector()
    {
        Assert.AreEqual(Vector2.UnitX, Vector2.One.WithY(0));
        Assert.AreEqual(Vector2.Zero, Vector2.Zero.WithY(0));
        Assert.AreEqual(Vector2.UnitX, Vector2.UnitX.WithY(0));
        Assert.AreEqual(Vector2.Zero, Vector2.UnitY.WithY(0));

        Assert.AreEqual(Vector2.One, Vector2.One.WithY(1));
        Assert.AreEqual(Vector2.UnitY, Vector2.Zero.WithY(1));
        Assert.AreEqual(Vector2.One, Vector2.UnitX.WithY(1));
        Assert.AreEqual(Vector2.UnitY, Vector2.UnitY.WithY(1));
    }
}
