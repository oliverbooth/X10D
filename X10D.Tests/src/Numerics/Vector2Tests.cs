using System.Numerics;
using NUnit.Framework;
#if !NET6_0_OR_GREATER
using X10D.Core;
#endif
using X10D.Drawing;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestFixture]
internal class Vector2Tests
{
    [Test]
    public void Deconstruct_ShouldReturnCorrectValues()
    {
        var vector = new Vector2(1, 2);
        (float x, float y) = vector;

        Assert.Multiple(() =>
        {
            Assert.That(x, Is.EqualTo(1));
            Assert.That(y, Is.EqualTo(2));
        });
    }

    [Test]
    public void IsOnLine_ShouldReturnTrue_ForPointOnLine()
    {
        Vector2 start = Vector2.Zero;
        Vector2 end = Vector2.UnitX;
        Vector2 point = new Vector2(0.5f, 0.0f);
        var line = new LineF(start, end);

        Assert.Multiple(() =>
        {
            Assert.That(point.IsOnLine(line));
            Assert.That(point.IsOnLine(line.Start, line.End));
            Assert.That(point.IsOnLine(line.Start.ToVector2(), line.End.ToVector2()));
        });
    }

    [Test]
    public void IsOnLine_ShouldReturnFalse_ForPointNotOnLine()
    {
        Vector2 start = Vector2.Zero;
        Vector2 end = Vector2.UnitX;
        Vector2 point = new Vector2(0.5f, 1.0f);
        var line = new LineF(start, end);

        Assert.Multiple(() =>
        {
            Assert.That(point.IsOnLine(line), Is.False);
            Assert.That(point.IsOnLine(line.Start, line.End), Is.False);
            Assert.That(point.IsOnLine(line.Start.ToVector2(), line.End.ToVector2()), Is.False);
        });
    }

    [Test]
    public void Round_ShouldRoundToNearestInteger_GivenNoParameters()
    {
        var vector = new Vector2(1.5f, 2.6f);
        var rounded = vector.Round();

        Assert.Multiple(() =>
        {
            Assert.That(rounded.X, Is.EqualTo(2));
            Assert.That(rounded.Y, Is.EqualTo(3));
        });
    }

    [Test]
    public void Round_ShouldRoundToNearest10_GivenPrecision10()
    {
        var vector = new Vector2(1.5f, 25.2f);
        var rounded = vector.Round(10);

        Assert.Multiple(() =>
        {
            Assert.That(rounded.X, Is.Zero);
            Assert.That(rounded.Y, Is.EqualTo(30));
        });
    }

    [Test]
    public void ToPointF_ShouldReturnPoint_WithEquivalentMembers()
    {
        var random = new Random();
        var vector = new Vector2(random.NextSingle(), random.NextSingle());
        var point = vector.ToPointF();

        Assert.Multiple(() =>
        {
            Assert.That(point.X, Is.EqualTo(vector.X).Within(1e-6f));
            Assert.That(point.Y, Is.EqualTo(vector.Y).Within(1e-6f));
        });
    }

    [Test]
    public void ToSizeF_ShouldReturnSize_WithEquivalentMembers()
    {
        var random = new Random();
        var vector = new Vector2(random.NextSingle(), random.NextSingle());
        var size = vector.ToSizeF();

        Assert.Multiple(() =>
        {
            Assert.That(size.Width, Is.EqualTo(vector.X));
            Assert.That(size.Height, Is.EqualTo(vector.Y));
        });
    }

    [Test]
    public void WithX_ShouldReturnVectorWithNewX_GivenVector()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Vector2.One.WithX(0), Is.EqualTo(Vector2.UnitY));
            Assert.That(Vector2.Zero.WithX(0), Is.EqualTo(Vector2.Zero));
            Assert.That(Vector2.UnitX.WithX(0), Is.EqualTo(Vector2.Zero));
            Assert.That(Vector2.UnitY.WithX(0), Is.EqualTo(Vector2.UnitY));

            Assert.That(Vector2.One.WithX(1), Is.EqualTo(Vector2.One));
            Assert.That(Vector2.Zero.WithX(1), Is.EqualTo(Vector2.UnitX));
            Assert.That(Vector2.UnitX.WithX(1), Is.EqualTo(Vector2.UnitX));
            Assert.That(Vector2.UnitY.WithX(1), Is.EqualTo(Vector2.One));
        });
    }

    [Test]
    public void WithY_ShouldReturnVectorWithNewY_GivenVector()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Vector2.One.WithY(0), Is.EqualTo(Vector2.UnitX));
            Assert.That(Vector2.Zero.WithY(0), Is.EqualTo(Vector2.Zero));
            Assert.That(Vector2.UnitX.WithY(0), Is.EqualTo(Vector2.UnitX));
            Assert.That(Vector2.UnitY.WithY(0), Is.EqualTo(Vector2.Zero));

            Assert.That(Vector2.One.WithY(1), Is.EqualTo(Vector2.One));
            Assert.That(Vector2.Zero.WithY(1), Is.EqualTo(Vector2.UnitY));
            Assert.That(Vector2.UnitX.WithY(1), Is.EqualTo(Vector2.One));
            Assert.That(Vector2.UnitY.WithY(1), Is.EqualTo(Vector2.UnitY));
        });
    }
}
