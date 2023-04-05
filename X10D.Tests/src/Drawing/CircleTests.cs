using NUnit.Framework;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestFixture]
public class CircleTests
{
    [Test]
    public void Area_ShouldBePiRadiusRadius_GivenUnitCircle()
    {
        var unitCircle = Circle.Unit;
        Assert.That(unitCircle.Area, Is.EqualTo(MathF.PI * unitCircle.Radius * unitCircle.Radius));
    }

    [Test]
    public void Circumference_ShouldBe2PiRadius_GivenUnitCircle()
    {
        var unitCircle = Circle.Unit;
        Assert.That(unitCircle.Circumference, Is.EqualTo(2.0f * MathF.PI * unitCircle.Radius).Within(1e-6f));
    }

    [Test]
    public void CompareTo_ShouldBeNegativeOne_GivenUnitCircleAndEmpty()
    {
        Assert.That(Circle.Empty.CompareTo(Circle.Unit), Is.EqualTo(-1));
    }

    [Test]
    public void CompareTo_ShouldBeOne_GivenUnitCircleAndEmpty()
    {
        Assert.That(Circle.Unit.CompareTo(Circle.Empty), Is.EqualTo(1));
    }

    [Test]
    public void CompareTo_ShouldBeNegativeOne_GivenEmptyCircleAndUnitCircleAsObject()
    {
        Assert.That(Circle.Empty.CompareTo((object)Circle.Unit), Is.EqualTo(-1));
    }

    [Test]
    public void CompareTo_ShouldBeOne_GivenNull()
    {
        Assert.That(Circle.Unit.CompareTo(null), Is.EqualTo(1));
    }

    [Test]
    public void CompareTo_ShouldBeZero_GivenUnitCircle()
    {
        var unitCircle = Circle.Unit;
        Assert.That(unitCircle.CompareTo(unitCircle), Is.Zero);
    }

    [Test]
    public void CompareTo_ShouldThrowArgumentException_GivenInvalidType()
    {
        Assert.Throws<ArgumentException>(() => _ = Circle.Unit.CompareTo(new object()));
    }

    [Test]
    public void Diameter_ShouldBe2_GivenUnitCircle()
    {
        Assert.That(Circle.Unit.Diameter, Is.EqualTo(2.0f).Within(1e-6f));
    }

    [Test]
    public void Equals_ShouldBeTrue_GivenTwoUnitCircles()
    {
        var unitCircle1 = Circle.Unit;
        var unitCircle2 = Circle.Unit;
        Assert.Multiple(() =>
        {
            Assert.That(unitCircle2, Is.EqualTo(unitCircle1));
            Assert.That(unitCircle1, Is.EqualTo(unitCircle2));
        });
    }

    [Test]
    public void Equals_ShouldBeTrue_GivenUnitCirclesAsObjects()
    {
        Circle unitCircle1 = Circle.Unit;
        object unitCircle2 = Circle.Unit;
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
            Assert.That(Circle.Empty, Is.Not.EqualTo(Circle.Unit));
            Assert.That(Circle.Unit, Is.Not.EqualTo(Circle.Empty));
        });
    }

    [Test]
    public void Equals_ShouldBeFalse_GivenDifferentObjects()
    {
        Assert.That(Circle.Empty, Is.Not.EqualTo(null));
    }

    [Test]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Circle.Empty.GetHashCode();
        Assert.That(Circle.Empty.GetHashCode(), Is.EqualTo(hashCode));
    }

    [Test]
    public void GetHashCode_ShouldBeCorrect_GivenUnitCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Circle.Unit.GetHashCode();
        Assert.That(Circle.Unit.GetHashCode(), Is.EqualTo(hashCode));
    }

    [Test]
    public void op_GreaterThan_True_GivenUnitAndEmptyCircle()
    {
        Assert.That(Circle.Unit, Is.GreaterThan(Circle.Empty));
        Assert.That(Circle.Unit, Is.GreaterThanOrEqualTo(Circle.Empty));
    }

    [Test]
    public void op_LessThan_True_GivenEmptyAndUnitCircle()
    {
        Assert.That(Circle.Empty, Is.LessThan(Circle.Unit));
        Assert.That(Circle.Empty, Is.LessThanOrEqualTo(Circle.Unit));
    }

    [Test]
    public void Radius_ShouldBe0_GivenEmptyCircle()
    {
        Assert.That(Circle.Empty.Radius, Is.Zero);
    }

    [Test]
    public void Radius_ShouldBe1_GivenUnitCircle()
    {
        Assert.That(Circle.Unit.Radius, Is.EqualTo(1));
    }
}
