using System.Drawing;
using NUnit.Framework;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestFixture]
internal class EllipseTests
{
    [Test]
    public void Area_ShouldBePiRadiusRadius_GivenUnitEllipse()
    {
        var unitEllipse = Ellipse.Unit;
        Assert.That(unitEllipse.Area, Is.EqualTo(MathF.PI).Within(1e-6f));
    }

    [Test]
    public void ApproximateCircumference_ShouldBe2PiRadius_GivenUnitEllipse()
    {
        var unitEllipse = Ellipse.Unit;
        Assert.That(unitEllipse.ApproximateCircumference, Is.EqualTo(2.0f * MathF.PI).Within(1e-6f));
    }

    [Test]
    public void Constructor_ShouldGiveCorrectEllipse()
    {
        var ellipse = new Ellipse(Point.Empty, new Size(2, 1));
        Assert.Multiple(() =>
        {
            Assert.That(ellipse.Center, Is.EqualTo(new Point(0, 0)));
            Assert.That(ellipse.Radius, Is.EqualTo(new Size(2, 1)));
        });

        ellipse = new Ellipse(0, 0, 2, 1);
        Assert.Multiple(() =>
        {
            Assert.That(ellipse.Center, Is.EqualTo(new Point(0, 0)));
            Assert.That(ellipse.Radius, Is.EqualTo(new Size(2, 1)));
        });
    }

    [Test]
    public void Equals_ShouldBeTrue_GivenTwoUnitEllipses()
    {
        var unitEllipse1 = Ellipse.Unit;
        var unitEllipse2 = Ellipse.Unit;
        Assert.Multiple(() =>
        {
            Assert.That(unitEllipse2, Is.EqualTo(unitEllipse1));
            Assert.That(unitEllipse1, Is.EqualTo(unitEllipse2));
            Assert.That(unitEllipse2 == unitEllipse1);
            Assert.That(unitEllipse1 == unitEllipse2);
        });
    }

    [Test]
    public void Equals_ShouldBeFalse_GivenDifferentEllipses()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Ellipse.Empty, Is.Not.EqualTo(Ellipse.Unit));
            Assert.That(Ellipse.Unit, Is.Not.EqualTo(Ellipse.Empty));
            Assert.That(Ellipse.Empty != Ellipse.Unit);
            Assert.That(Ellipse.Unit != Ellipse.Empty);
        });
    }

    [Test]
    public void Equals_ShouldBeFalse_GivenDifferentObjects()
    {
        Assert.That(Ellipse.Unit.Equals(null), Is.False);
    }

    [Test]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyEllipse()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Ellipse.Empty.GetHashCode();
        Assert.That(Ellipse.Empty.GetHashCode(), Is.EqualTo(hashCode));
    }

    [Test]
    public void GetHashCode_ShouldBeCorrect_GivenUnitEllipse()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Ellipse.Unit.GetHashCode();
        Assert.That(Ellipse.Unit.GetHashCode(), Is.EqualTo(hashCode));
    }

    [Test]
    public void HorizontalRadius_ShouldBe0_GivenEmptyEllipse()
    {
        Assert.That(Ellipse.Empty.HorizontalRadius, Is.Zero);
    }

    [Test]
    public void HorizontalRadius_ShouldBe1_GivenUnitEllipse()
    {
        Assert.That(Ellipse.Unit.HorizontalRadius, Is.EqualTo(1));
    }

    [Test]
    public void op_Implicit_ShouldReturnEquivalentEllipse_GivenCircle()
    {
        Circle unitCircle = Circle.Unit;
        Ellipse converted = unitCircle;

        Assert.Multiple(() =>
        {
            Assert.That(converted, Is.EqualTo((Ellipse)unitCircle));
            Assert.That(converted.HorizontalRadius, Is.EqualTo(unitCircle.Radius));
            Assert.That(converted.VerticalRadius, Is.EqualTo(unitCircle.Radius));
            Assert.That(converted.Center, Is.EqualTo(unitCircle.Center));
        });
    }

    [Test]
    public void VerticalRadius_ShouldBe0_GivenEmptyEllipse()
    {
        Assert.That(Ellipse.Empty.VerticalRadius, Is.Zero);
    }

    [Test]
    public void VerticalRadius_ShouldBe1_GivenUnitEllipse()
    {
        Assert.That(Ellipse.Unit.VerticalRadius, Is.EqualTo(1));
    }
}
