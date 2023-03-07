using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class CircleFTests
{
    [TestMethod]
    public void Area_ShouldBePiRadiusRadius_GivenUnitCircle()
    {
        var unitCircle = CircleF.Unit;
        Assert.AreEqual(MathF.PI, unitCircle.Area);
    }

    [TestMethod]
    public void Circumference_ShouldBe2PiRadius_GivenUnitCircle()
    {
        var unitCircle = CircleF.Unit;
        Assert.AreEqual(2 * MathF.PI, unitCircle.Circumference, 1e-6f);
    }

    [TestMethod]
    public void CompareTo_ShouldBeNegativeOne_GivenUnitCircleAndEmpty()
    {
        Assert.AreEqual(-1, CircleF.Empty.CompareTo(CircleF.Unit));
    }

    [TestMethod]
    public void CompareTo_ShouldBeOne_GivenUnitCircleAndEmpty()
    {
        Assert.AreEqual(1, CircleF.Unit.CompareTo(CircleF.Empty));
    }

    [TestMethod]
    public void CompareTo_ShouldBeNegativeOne_GivenEmptyCircleAndUnitCircleAsObject()
    {
        Assert.AreEqual(-1, CircleF.Empty.CompareTo((object)CircleF.Unit));
    }

    [TestMethod]
    public void CompareTo_ShouldBeOne_GivenNull()
    {
        Assert.AreEqual(1, CircleF.Unit.CompareTo(null));
    }

    [TestMethod]
    public void CompareTo_ShouldBeZero_GivenUnitCircle()
    {
        var unitCircle = CircleF.Unit;
        Assert.AreEqual(0, unitCircle.CompareTo(unitCircle));
    }

    [TestMethod]
    public void CompareTo_ShouldThrowArgumentException_GivenInvalidType()
    {
        Assert.ThrowsException<ArgumentException>(() => CircleF.Unit.CompareTo(new object()));
    }

    [TestMethod]
    public void Diameter_ShouldBe2_GivenUnitCircle()
    {
        Assert.AreEqual(2.0f, CircleF.Unit.Diameter, 1e-6f);
    }

    [TestMethod]
    public void Equals_ShouldBeTrue_GivenTwoUnitCircles()
    {
        var unitCircle1 = CircleF.Unit;
        var unitCircle2 = CircleF.Unit;
        Assert.AreEqual(unitCircle1, unitCircle2);
        Assert.IsTrue(unitCircle1 == unitCircle2);
        Assert.IsFalse(unitCircle1 != unitCircle2);
    }

    [TestMethod]
    public void Equals_ShouldBeFalse_GivenDifferentCircles()
    {
        Assert.AreNotEqual(CircleF.Unit, CircleF.Empty);
        Assert.IsFalse(CircleF.Unit == CircleF.Empty);
        Assert.IsTrue(CircleF.Unit != CircleF.Empty);
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = CircleF.Empty.GetHashCode();
        Assert.AreEqual(hashCode, CircleF.Empty.GetHashCode());
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenUnitCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = CircleF.Unit.GetHashCode();
        Assert.AreEqual(hashCode, CircleF.Unit.GetHashCode());
    }

    [TestMethod]
    public void op_Explicit_ShouldReturnEquivalentCircle_GivenCircle()
    {
        CircleF unitCircle = CircleF.Unit;
        Circle converted = (Circle)unitCircle;

        Assert.AreEqual(unitCircle, converted);
        Assert.AreEqual(unitCircle.Radius, converted.Radius);
        Assert.AreEqual(unitCircle.Center, converted.Center);
    }

    [TestMethod]
    public void op_GreaterThan_True_GivenUnitAndEmptyCircle()
    {
        Assert.IsTrue(CircleF.Unit > CircleF.Empty);
        Assert.IsTrue(CircleF.Unit >= CircleF.Empty);
        Assert.IsFalse(CircleF.Unit < CircleF.Empty);
        Assert.IsFalse(CircleF.Unit <= CircleF.Empty);
    }

    [TestMethod]
    public void op_Implicit_ShouldReturnEquivalentCircle_GivenCircle()
    {
        Circle unitCircle = Circle.Unit;
        CircleF converted = unitCircle;

        Assert.AreEqual(unitCircle, converted);
        Assert.AreEqual(unitCircle.Radius, converted.Radius);
        Assert.AreEqual(unitCircle.Center, converted.Center);
    }

    [TestMethod]
    public void op_LessThan_True_GivenEmptyAndUnitCircle()
    {
        Assert.IsTrue(CircleF.Empty < CircleF.Unit);
        Assert.IsTrue(CircleF.Empty <= CircleF.Unit);
        Assert.IsFalse(CircleF.Empty > CircleF.Unit);
        Assert.IsFalse(CircleF.Empty >= CircleF.Unit);
    }

    [TestMethod]
    public void Radius_ShouldBe0_GivenEmptyCircle()
    {
        Assert.AreEqual(0.0f, CircleF.Empty.Radius, 1e-6f);
    }

    [TestMethod]
    public void Radius_ShouldBe1_GivenUnitCircle()
    {
        Assert.AreEqual(1.0f, CircleF.Unit.Radius, 1e-6f);
    }
}
