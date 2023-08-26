using System.Drawing;
using System.Numerics;
using NUnit.Framework;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestFixture]
internal class EllipseFTests
{
    [Test]
    public void Area_ShouldBePiRadiusRadius_GivenUnitEllipse()
    {
        var unitEllipse = EllipseF.Unit;
        Assert.That(unitEllipse.Area, Is.EqualTo(MathF.PI).Within(1e-6f));
    }

    [Test]
    public void ApproximateCircumference_ShouldBe2PiRadius_GivenUnitEllipse()
    {
        var unitEllipse = EllipseF.Unit;
        Assert.That(unitEllipse.ApproximateCircumference, Is.EqualTo(2 * MathF.PI).Within(1e-6f));
    }

    [Test]
    public void Constructor_ShouldGiveCorrectEllipse()
    {
        var ellipse = new EllipseF(PointF.Empty, new SizeF(2, 1));
        Assert.That(ellipse.Center, Is.EqualTo(new PointF(0, 0)));
        Assert.That(ellipse.Radius, Is.EqualTo(new SizeF(2, 1)));

        ellipse = new EllipseF(0, 0, 2, 1);
        Assert.That(ellipse.Center, Is.EqualTo(new PointF(0, 0)));
        Assert.That(ellipse.Radius, Is.EqualTo(new SizeF(2, 1)));

        ellipse = new EllipseF(PointF.Empty, new Vector2(2, 1));
        Assert.That(ellipse.Center, Is.EqualTo(new PointF(0, 0)));
        Assert.That(ellipse.Radius, Is.EqualTo(new SizeF(2, 1)));

        ellipse = new EllipseF(Vector2.Zero, new Vector2(2, 1));
        Assert.That(ellipse.Center, Is.EqualTo(new PointF(0, 0)));
        Assert.That(ellipse.Radius, Is.EqualTo(new SizeF(2, 1)));
    }

    [Test]
    public void Equals_ShouldBeTrue_GivenTwoUnitEllipses()
    {
        var unitEllipse1 = EllipseF.Unit;
        var unitEllipse2 = EllipseF.Unit;
        Assert.That(unitEllipse2, Is.EqualTo(unitEllipse1));
        Assert.That(unitEllipse1, Is.EqualTo(unitEllipse2));
        Assert.That(unitEllipse2 == unitEllipse1);
        Assert.That(unitEllipse1 == unitEllipse2);
    }

    [Test]
    public void Equals_ShouldBeFalse_GivenDifferentEllipses()
    {
        Assert.That(EllipseF.Empty, Is.Not.EqualTo(EllipseF.Unit));
        Assert.That(EllipseF.Empty != EllipseF.Unit);
    }

    [Test]
    public void Equals_ShouldBeFalse_GivenDifferentObjects()
    {
        Assert.That(EllipseF.Unit, Is.Not.EqualTo(null));
        Assert.That(EllipseF.Unit.Equals(null), Is.False);
    }

    [Test]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyEllipse()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = EllipseF.Empty.GetHashCode();
        Assert.That(EllipseF.Empty.GetHashCode(), Is.EqualTo(hashCode));
    }

    [Test]
    public void GetHashCode_ShouldBeCorrect_GivenUnitEllipse()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = EllipseF.Unit.GetHashCode();
        Assert.That(EllipseF.Unit.GetHashCode(), Is.EqualTo(hashCode));
    }

    [Test]
    public void HorizontalRadius_ShouldBe0_GivenEmptyEllipse()
    {
        Assert.That(EllipseF.Empty.HorizontalRadius, Is.Zero);
    }

    [Test]
    public void HorizontalRadius_ShouldBe1_GivenUnitEllipse()
    {
        Assert.That(EllipseF.Unit.HorizontalRadius, Is.EqualTo(1));
    }

    [Test]
    public void op_Explicit_ShouldReturnEquivalentEllipse_GivenEllipse()
    {
        EllipseF unitEllipse = EllipseF.Unit;
        Ellipse converted = (Ellipse)unitEllipse;

        Assert.Multiple(() =>
        {
            Assert.That(converted, Is.EqualTo((Ellipse)unitEllipse));
            Assert.That(converted == unitEllipse);
            Assert.That(converted.HorizontalRadius, Is.EqualTo(unitEllipse.HorizontalRadius));
            Assert.That(converted.VerticalRadius, Is.EqualTo(unitEllipse.VerticalRadius));
            Assert.That((PointF)converted.Center, Is.EqualTo(unitEllipse.Center));
        });
    }

    [Test]
    public void op_Implicit_ShouldReturnEquivalentEllipse_GivenCircle()
    {
        Circle unitCircle = Circle.Unit;
        EllipseF converted = unitCircle;

        Assert.Multiple(() =>
        {
            Assert.That(converted, Is.EqualTo((EllipseF)unitCircle));
            Assert.That(converted == unitCircle);
            Assert.That(converted.HorizontalRadius, Is.EqualTo(unitCircle.Radius));
            Assert.That(converted.VerticalRadius, Is.EqualTo(unitCircle.Radius));
            Assert.That(converted.Center, Is.EqualTo((PointF)unitCircle.Center));
        });
    }

    [Test]
    public void op_Implicit_ShouldReturnEquivalentEllipse_GivenCircleF()
    {
        CircleF unitCircle = CircleF.Unit;
        EllipseF converted = unitCircle;

        Assert.Multiple(() =>
        {
            Assert.That(converted, Is.EqualTo((EllipseF)unitCircle));
            Assert.That(converted.HorizontalRadius, Is.EqualTo(unitCircle.Radius));
            Assert.That(converted.VerticalRadius, Is.EqualTo(unitCircle.Radius));
            Assert.That(converted.Center, Is.EqualTo(unitCircle.Center));
        });
    }

    [Test]
    public void op_Implicit_ShouldReturnEquivalentEllipse_GivenEllipse()
    {
        Ellipse unitEllipse = Ellipse.Unit;
        EllipseF converted = unitEllipse;

        Assert.Multiple(() =>
        {
            Assert.That(converted, Is.EqualTo((EllipseF)unitEllipse));
            Assert.That(converted.HorizontalRadius, Is.EqualTo(unitEllipse.HorizontalRadius));
            Assert.That(converted.VerticalRadius, Is.EqualTo(unitEllipse.VerticalRadius));
            Assert.That(converted.Center, Is.EqualTo((PointF)unitEllipse.Center));
        });
    }

    [Test]
    public void VerticalRadius_ShouldBe0_GivenEmptyEllipse()
    {
        Assert.That(EllipseF.Empty.VerticalRadius, Is.Zero);
    }

    [Test]
    public void VerticalRadius_ShouldBe1_GivenUnitEllipse()
    {
        Assert.That(EllipseF.Unit.VerticalRadius, Is.EqualTo(1));
    }
}
