using System.Drawing;
using NUnit.Framework;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestFixture]
internal class PointTests
{
    [Test]
    public void IsOnLine_ShouldReturnTrue_GivenPointOnLine()
    {
        var point = new Point(1, 0);
        var line = new Line(Point.Empty, new Point(2, 0));

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
        var point = new Point(1, 1);
        var line = new Line(Point.Empty, new Point(2, 0));

        Assert.Multiple(() =>
        {
            Assert.That(point.IsOnLine(line), Is.False);
            Assert.That(point.IsOnLine(line.Start, line.End), Is.False);
            Assert.That(point.IsOnLine(line.Start.ToVector2(), line.End.ToVector2()), Is.False);
        });
    }

    [Test]
    public void ToSize_ShouldReturnSize_WithEquivalentMembers()
    {
        var random = new Random();
        var point = new Point(random.Next(), random.Next());
        var size = point.ToSize();

        Assert.Multiple(() =>
        {
            Assert.That(size.Width, Is.EqualTo(point.X));
            Assert.That(size.Height, Is.EqualTo(point.Y));
        });
    }

    [Test]
    public void ToSizeF_ShouldReturnSize_WithEquivalentMembers()
    {
        var random = new Random();
        var point = new Point(random.Next(), random.Next());
        var size = point.ToSizeF();

        Assert.Multiple(() =>
        {
            Assert.That(size.Width, Is.EqualTo(point.X).Within(1e-6f));
            Assert.That(size.Height, Is.EqualTo(point.Y).Within(1e-6f));
        });
    }

    [Test]
    public void ToVector2_ShouldReturnVector_WithEquivalentMembers()
    {
        var random = new Random();
        var point = new Point(random.Next(), random.Next());
        var size = point.ToVector2();

        Assert.Multiple(() =>
        {
            Assert.That(size.X, Is.EqualTo(point.X).Within(1e-6f));
            Assert.That(size.Y, Is.EqualTo(point.Y).Within(1e-6f));
        });
    }
}
