using System.Drawing;
using NUnit.Framework;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestFixture]
internal class CircleFTests
{
    [Test]
    public void Area_ShouldBePiRadiusRadius_GivenUnitCircle()
    {
        var unitCircle = CircleF.Unit;
        Assert.That(unitCircle.Area, Is.EqualTo(MathF.PI));
    }

    [Test]
    public void Circumference_ShouldBe2PiRadius_GivenUnitCircle()
    {
        var unitCircle = CircleF.Unit;
        Assert.That(unitCircle.Circumference, Is.EqualTo(2 * MathF.PI).Within(1e-6f));
    }

    [Test]
    public void CompareTo_ShouldBeNegativeOne_GivenUnitCircleAndEmpty()
    {
        Assert.That(CircleF.Empty.CompareTo(CircleF.Unit), Is.EqualTo(-1));
    }

    [Test]
    public void CompareTo_ShouldBeOne_GivenUnitCircleAndEmpty()
    {
        Assert.That(CircleF.Unit.CompareTo(CircleF.Empty), Is.EqualTo(1));
    }

    [Test]
    public void CompareTo_ShouldBeNegativeOne_GivenEmptyCircleAndUnitCircleAsObject()
    {
        Assert.That(CircleF.Empty.CompareTo((object)CircleF.Unit), Is.EqualTo(-1));
    }

    [Test]
    public void CompareTo_ShouldBeOne_GivenNull()
    {
        Assert.That(CircleF.Unit.CompareTo(null), Is.EqualTo(1));
    }

    [Test]
    public void CompareTo_ShouldBeZero_GivenUnitCircle()
    {
        var unitCircle = CircleF.Unit;
        Assert.That(unitCircle.CompareTo(unitCircle), Is.Zero);
    }

    [Test]
    public void CompareTo_ShouldThrowArgumentException_GivenInvalidType()
    {
        Assert.Throws<ArgumentException>(() => _ = CircleF.Unit.CompareTo(new object()));
    }

    [Test]
    public void Diameter_ShouldBe2_GivenUnitCircle()
    {
        Assert.That(CircleF.Unit.Diameter, Is.EqualTo(2.0f).Within(1e-6f));
    }

    [Test]
    public void Equals_ShouldBeTrue_GivenTwoUnitCircles()
    {
        var unitCircle1 = CircleF.Unit;
        var unitCircle2 = CircleF.Unit;
        Assert.Multiple(() =>
        {
            Assert.That(unitCircle2, Is.EqualTo(unitCircle1));
            Assert.That(unitCircle1, Is.EqualTo(unitCircle2));
            Assert.That(unitCircle1 == unitCircle2);
            Assert.That(unitCircle2 == unitCircle1);
        });
    }

    [Test]
    public void Equals_ShouldBeTrue_GivenUnitCirclesAsObjects()
    {
        CircleF unitCircle1 = CircleF.Unit;
        object unitCircle2 = CircleF.Unit;
        Assert.Multiple(() =>
        {
            Assert.That(unitCircle2, Is.EqualTo(unitCircle1));
            Assert.That(unitCircle1, Is.EqualTo(unitCircle2));
        });
    }

    [Test]
    public void Equals_ShouldBeFalse_GivenDifferentCircles()
    {
        Assert.Multiple(() =>
        {
            Assert.That(CircleF.Empty, Is.Not.EqualTo(CircleF.Unit));
            Assert.That(CircleF.Unit, Is.Not.EqualTo(CircleF.Empty));

            Assert.That(CircleF.Empty != CircleF.Unit);
            Assert.That(CircleF.Unit != CircleF.Empty);
        });
    }

    [Test]
    public void Equals_ShouldBeFalse_GivenDifferentObjects()
    {
        Assert.That(CircleF.Empty, Is.Not.EqualTo(null));
        Assert.That(CircleF.Empty.Equals(null), Is.False);
    }

    [Test]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = CircleF.Empty.GetHashCode();
        Assert.That(CircleF.Empty.GetHashCode(), Is.EqualTo(hashCode));
    }

    [Test]
    public void GetHashCode_ShouldBeCorrect_GivenUnitCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = CircleF.Unit.GetHashCode();
        Assert.That(CircleF.Unit.GetHashCode(), Is.EqualTo(hashCode));
    }

    [Test]
    public void op_Explicit_ShouldReturnEquivalentCircle_GivenCircle()
    {
        CircleF unitCircle = CircleF.Unit;
        Circle converted = (Circle)unitCircle;

        Assert.Multiple(() =>
        {
            Assert.That(converted, Is.EqualTo((Circle)unitCircle));
            Assert.That(converted == (Circle)unitCircle);
            Assert.That(converted.Radius, Is.EqualTo(unitCircle.Radius));
            Assert.That((PointF)converted.Center, Is.EqualTo(unitCircle.Center));
        });
    }

    [Test]
    public void op_GreaterThan_True_GivenUnitAndEmptyCircle()
    {
        Assert.That(CircleF.Unit, Is.GreaterThan(CircleF.Empty));
        Assert.That(CircleF.Unit, Is.GreaterThanOrEqualTo(CircleF.Empty));

        Assert.That(CircleF.Unit > CircleF.Empty);
        Assert.That(CircleF.Unit >= CircleF.Empty);
    }

    [Test]
    public void op_Implicit_ShouldReturnEquivalentCircle_GivenCircle()
    {
        Circle unitCircle = Circle.Unit;
        CircleF converted = unitCircle;

        Assert.Multiple(() =>
        {
            Assert.That(converted, Is.EqualTo((CircleF)unitCircle));
            Assert.That(converted == unitCircle);
            Assert.That(converted.Radius, Is.EqualTo(unitCircle.Radius));
            Assert.That(converted.Center, Is.EqualTo((PointF)unitCircle.Center));
        });
    }

    [Test]
    public void op_LessThan_True_GivenEmptyAndUnitCircle()
    {
        Assert.Multiple(() =>
        {
            Assert.That(CircleF.Empty, Is.LessThan(CircleF.Unit));
            Assert.That(CircleF.Empty, Is.LessThanOrEqualTo(CircleF.Unit));

            Assert.That(CircleF.Empty < CircleF.Unit);
            Assert.That(CircleF.Empty <= CircleF.Unit);
        });
    }

    [Test]
    public void Radius_ShouldBe0_GivenEmptyCircle()
    {
        Assert.That(CircleF.Empty.Radius, Is.EqualTo(0.0f).Within(1e-6f));
    }

    [Test]
    public void Radius_ShouldBe1_GivenUnitCircle()
    {
        Assert.That(CircleF.Unit.Radius, Is.EqualTo(1.0f).Within(1e-6f));
    }
}
