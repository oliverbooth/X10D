using System.Drawing;
using NUnit.Framework;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestFixture]
internal class SizeTests
{
    [Test]
    public void ToPoint_ShouldReturnPoint_WithEquivalentMembers()
    {
        var random = new Random();
        var size = new Size(random.Next(), random.Next());
        var point = size.ToPoint();

        Assert.Multiple(() =>
        {
            Assert.That(point.X, Is.EqualTo(size.Width));
            Assert.That(point.Y, Is.EqualTo(size.Height));
        });
    }

    [Test]
    public void ToPointF_ShouldReturnPoint_WithEquivalentMembers()
    {
        var random = new Random();
        var size = new Size(random.Next(), random.Next());
        var point = size.ToPointF();

        Assert.Multiple(() =>
        {
            Assert.That(point.X, Is.EqualTo(size.Width).Within(1e-6f));
            Assert.That(point.Y, Is.EqualTo(size.Height).Within(1e-6f));
        });
    }

    [Test]
    public void ToVector2_ShouldReturnVector_WithEquivalentMembers()
    {
        var random = new Random();
        var point = new Size(random.Next(), random.Next());
        var size = point.ToVector2();

        Assert.Multiple(() =>
        {
            Assert.That(size.X, Is.EqualTo(point.Width).Within(1e-6f));
            Assert.That(size.Y, Is.EqualTo(point.Height).Within(1e-6f));
        });
    }
}
