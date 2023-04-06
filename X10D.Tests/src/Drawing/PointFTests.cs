using System.Drawing;
using NUnit.Framework;
#if !NET6_0_OR_GREATER
using X10D.Core;
#endif
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestFixture]
public class PointFTests
{
    [Test]
    public void IsOnLine_ShouldReturnTrue_GivenPointOnLine()
    {
        var point = new PointF(1.0f, 0.0f);
        var line = new LineF(PointF.Empty, new PointF(2.0f, 0.0f));

        Assert.Multiple(() =>
        {
            Assert.That(point.IsOnLine(line));
            Assert.That(point.IsOnLine(line.Start, line.End));
            Assert.That(point.IsOnLine(line.Start.ToVector2(), line.End.ToVector2()));
        });
    }

    [Test]
    public void IsOnLine_ShouldReturnFalse_GivenPointNotOnLine()
    {
        var point = new PointF(1.0f, 1.0f);
        var line = new LineF(PointF.Empty, new PointF(2.0f, 0.0f));

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
        var point = new PointF(1.5f, 2.6f);
        var rounded = point.Round();

        Assert.Multiple(() =>
        {
            Assert.That(rounded.X, Is.EqualTo(2));
            Assert.That(rounded.Y, Is.EqualTo(3));
        });
    }

    [Test]
    public void Round_ShouldRoundToNearest10_GivenPrecision10()
    {
        var point = new PointF(1.5f, 25.2f);
        var rounded = point.Round(10);

        Assert.Multiple(() =>
        {
            Assert.That(rounded.X, Is.Zero);
            Assert.That(rounded.Y, Is.EqualTo(30));
        });
    }

    [Test]
    public void ToSizeF_ShouldReturnSize_WithEquivalentMembers()
    {
        var random = new Random();
        var point = new PointF(random.NextSingle(), random.NextSingle());
        var size = point.ToSizeF();

        Assert.Multiple(() =>
        {
            Assert.That(size.Width, Is.EqualTo(point.X).Within(1e-6f));
            Assert.That(size.Height, Is.EqualTo(point.Y).Within(1e-6f));
        });
    }
}
