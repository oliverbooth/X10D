using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class SphereTests
{
    [TestMethod]
    public void Circumference_ShouldBe2PiRadius_GivenUnitCircle()
    {
        var unitSphere = Sphere.Unit;
        Assert.AreEqual(2.0f * MathF.PI * unitSphere.Radius, unitSphere.Circumference, 1e-6f);
    }

    [TestMethod]
    public void CompareTo_ShouldBeNegativeOne_GivenUnitCircleAndEmpty()
    {
        Assert.AreEqual(-1, Sphere.Empty.CompareTo(Sphere.Unit));
    }

    [TestMethod]
    public void CompareTo_ShouldBeOne_GivenUnitCircleAndEmpty()
    {
        Assert.AreEqual(1, Sphere.Unit.CompareTo(Sphere.Empty));
    }

    [TestMethod]
    public void CompareTo_ShouldBeNegativeOne_GivenEmptyCircleAndUnitCircleAsObject()
    {
        Assert.AreEqual(-1, Sphere.Empty.CompareTo((object)Sphere.Unit));
    }

    [TestMethod]
    public void CompareTo_ShouldBeOne_GivenNull()
    {
        Assert.AreEqual(1, Sphere.Unit.CompareTo(null));
    }

    [TestMethod]
    public void CompareTo_ShouldBeZero_GivenUnitCircle()
    {
        var unitCircle = Sphere.Unit;
        Assert.AreEqual(0, unitCircle.CompareTo(unitCircle));
    }

    [TestMethod]
    public void CompareTo_ShouldThrowArgumentException_GivenInvalidType()
    {
        Assert.ThrowsException<ArgumentException>(() => Sphere.Unit.CompareTo(new object()));
    }

    [TestMethod]
    public void Diameter_ShouldBe2_GivenUnitSphere()
    {
        Assert.AreEqual(2.0f, Sphere.Unit.Diameter, 1e-6f);
    }

    [TestMethod]
    public void Equals_ShouldBeTrue_GivenTwoUnitCircles()
    {
        var unitCircle1 = Sphere.Unit;
        var unitCircle2 = Sphere.Unit;
        Assert.AreEqual(unitCircle1, unitCircle2);
        Assert.IsTrue(unitCircle1 == unitCircle2);
        Assert.IsFalse(unitCircle1 != unitCircle2);
    }

    [TestMethod]
    public void Equals_ShouldBeFalse_GivenDifferentCircles()
    {
        Assert.AreNotEqual(Sphere.Unit, Sphere.Empty);
        Assert.IsFalse(Sphere.Unit == Sphere.Empty);
        Assert.IsTrue(Sphere.Unit != Sphere.Empty);
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Sphere.Empty.GetHashCode();
        Assert.AreEqual(hashCode, Sphere.Empty.GetHashCode());
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenUnitCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Sphere.Unit.GetHashCode();
        Assert.AreEqual(hashCode, Sphere.Unit.GetHashCode());
    }

    [TestMethod]
    public void op_GreaterThan_True_GivenUnitAndEmptyCircle()
    {
        Assert.IsTrue(Sphere.Unit > Sphere.Empty);
        Assert.IsTrue(Sphere.Unit >= Sphere.Empty);
        Assert.IsFalse(Sphere.Unit < Sphere.Empty);
        Assert.IsFalse(Sphere.Unit <= Sphere.Empty);
    }

    [TestMethod]
    public void op_LessThan_True_GivenEmptyAndUnitCircle()
    {
        Assert.IsTrue(Sphere.Empty < Sphere.Unit);
        Assert.IsTrue(Sphere.Empty <= Sphere.Unit);
        Assert.IsFalse(Sphere.Empty > Sphere.Unit);
        Assert.IsFalse(Sphere.Empty >= Sphere.Unit);
    }

    [TestMethod]
    public void Radius_ShouldBe0_GivenEmptySphere()
    {
        Assert.AreEqual(0, Sphere.Empty.Radius);
    }

    [TestMethod]
    public void Radius_ShouldBe1_GivenUnitSphere()
    {
        Assert.AreEqual(1, Sphere.Unit.Radius);
    }

    [TestMethod]
    public void Volume_ShouldBe4Over3TimesPi_GivenUnitCircle()
    {
        var unitSphere = Sphere.Unit;
        Assert.AreEqual(4.0f / 3.0f * MathF.PI, unitSphere.Volume);
    }
}
