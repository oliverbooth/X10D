using NUnit.Framework;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestFixture]
internal class SphereTests
{
    [Test]
    public void Circumference_ShouldBe2PiRadius_GivenUnitCircle()
    {
        var unitSphere = Sphere.Unit;
        Assert.That(unitSphere.Circumference, Is.EqualTo(2.0f * MathF.PI * unitSphere.Radius).Within(1e-6f));
    }

    [Test]
    public void CompareTo_ShouldBeNegativeOne_GivenUnitCircleAndEmpty()
    {
        Assert.That(Sphere.Empty.CompareTo(Sphere.Unit), Is.EqualTo(-1));
    }

    [Test]
    public void CompareTo_ShouldBeOne_GivenUnitCircleAndEmpty()
    {
        Assert.That(Sphere.Unit.CompareTo(Sphere.Empty), Is.EqualTo(1));
    }

    [Test]
    public void CompareTo_ShouldBeNegativeOne_GivenEmptyCircleAndUnitCircleAsObject()
    {
        Assert.That(Sphere.Empty.CompareTo((object)Sphere.Unit), Is.EqualTo(-1));
    }

    [Test]
    public void CompareTo_ShouldBeOne_GivenNull()
    {
        Assert.That(Sphere.Unit.CompareTo(null), Is.EqualTo(1));
    }

    [Test]
    public void CompareTo_ShouldBeZero_GivenUnitCircle()
    {
        var unitCircle = Sphere.Unit;
        Assert.That(unitCircle.CompareTo(unitCircle), Is.Zero);
    }

    [Test]
    public void CompareTo_ShouldThrowArgumentException_GivenInvalidType()
    {
        Assert.Throws<ArgumentException>(() => _ = Sphere.Unit.CompareTo(new object()));
    }

    [Test]
    public void Diameter_ShouldBe2_GivenUnitSphere()
    {
        Assert.That(Sphere.Unit.Diameter, Is.EqualTo(2.0f).Within(1e-6f));
    }

    [Test]
    public void Equals_ShouldBeTrue_GivenTwoUnitCircles()
    {
        var unitCircle1 = Sphere.Unit;
        var unitCircle2 = Sphere.Unit;

        Assert.Multiple(() =>
        {
            Assert.That(unitCircle2, Is.EqualTo(unitCircle1));
            Assert.That(unitCircle1, Is.EqualTo(unitCircle2));
            Assert.That(unitCircle2 == unitCircle1);
            Assert.That(unitCircle1 == unitCircle2);
        });
    }

    [Test]
    public void Equals_ShouldBeFalse_GivenDifferentObjects()
    {
        Assert.That(Sphere.Unit, Is.Not.EqualTo(null));
        Assert.That(Sphere.Unit.Equals(null), Is.False);
    }

    [Test]
    public void Equals_ShouldBeFalse_GivenDifferentCircles()
    {
        Assert.That(Sphere.Empty, Is.Not.EqualTo(Sphere.Unit));
        Assert.That(Sphere.Unit, Is.Not.EqualTo(Sphere.Empty));
        Assert.That(Sphere.Empty != Sphere.Unit);
        Assert.That(Sphere.Unit != Sphere.Empty);
    }

    [Test]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Sphere.Empty.GetHashCode();
        Assert.That(Sphere.Empty.GetHashCode(), Is.EqualTo(hashCode));
    }

    [Test]
    public void GetHashCode_ShouldBeCorrect_GivenUnitCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Sphere.Unit.GetHashCode();
        Assert.That(Sphere.Unit.GetHashCode(), Is.EqualTo(hashCode));
    }

    [Test]
    public void op_GreaterThan_True_GivenUnitAndEmptyCircle()
    {
        Assert.That(Sphere.Unit, Is.GreaterThan(Sphere.Empty));
        Assert.That(Sphere.Unit, Is.GreaterThanOrEqualTo(Sphere.Empty));
        Assert.That(Sphere.Unit > Sphere.Empty);
        Assert.That(Sphere.Unit >= Sphere.Empty);
    }

    [Test]
    public void op_LessThan_True_GivenEmptyAndUnitCircle()
    {
        Assert.That(Sphere.Empty, Is.LessThan(Sphere.Unit));
        Assert.That(Sphere.Empty, Is.LessThanOrEqualTo(Sphere.Unit));
        Assert.That(Sphere.Empty < Sphere.Unit);
        Assert.That(Sphere.Empty <= Sphere.Unit);
    }

    [Test]
    public void Radius_ShouldBe0_GivenEmptySphere()
    {
        Assert.That(Sphere.Empty.Radius, Is.Zero);
    }

    [Test]
    public void Radius_ShouldBe1_GivenUnitSphere()
    {
        Assert.That(Sphere.Unit.Radius, Is.EqualTo(1));
    }

    [Test]
    public void Volume_ShouldBe4Over3TimesPi_GivenUnitCircle()
    {
        var unitSphere = Sphere.Unit;
        Assert.That(unitSphere.Volume, Is.EqualTo(4.0f / 3.0f * MathF.PI));
    }
}
