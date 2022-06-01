using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class CircleTests
{
    [TestMethod]
    public void Area_ShouldBePiRadiusRadius_GivenUnitCircle()
    {
        var unitCircle = Circle.Unit;
        Assert.AreEqual(MathF.PI * unitCircle.Radius * unitCircle.Radius, unitCircle.Area);
    }

    [TestMethod]
    public void Circumference_ShouldBe2PiRadius_GivenUnitCircle()
    {
        var unitCircle = Circle.Unit;
        Assert.AreEqual(2.0f * MathF.PI * unitCircle.Radius, unitCircle.Circumference, 1e-6f);
    }

    [TestMethod]
    public void CompareTo_ShouldBeNegativeOne_GivenUnitCircleAndEmpty()
    {
        Assert.AreEqual(-1, Circle.Empty.CompareTo(Circle.Unit));
    }

    [TestMethod]
    public void CompareTo_ShouldBeOne_GivenUnitCircleAndEmpty()
    {
        Assert.AreEqual(1, Circle.Unit.CompareTo(Circle.Empty));
    }

    [TestMethod]
    public void CompareTo_ShouldBeZero_GivenUnitCircle()
    {
        var unitCircle = Circle.Unit;
        Assert.AreEqual(0, unitCircle.CompareTo(unitCircle));
    }

    [TestMethod]
    public void Diameter_ShouldBe2_GivenUnitCircle()
    {
        Assert.AreEqual(2.0f, Circle.Unit.Diameter, 1e-6f);
    }

    [TestMethod]
    public void Equals_ShouldBeTrue_GivenTwoUnitCircles()
    {
        var unitCircle1 = Circle.Unit;
        var unitCircle2 = Circle.Unit;
        Assert.AreEqual(unitCircle1, unitCircle2);
        Assert.IsTrue(unitCircle1 == unitCircle2);
        Assert.IsFalse(unitCircle1 != unitCircle2);
    }

    [TestMethod]
    public void Equals_ShouldBeFalse_GivenDifferentCircles()
    {
        Assert.AreNotEqual(Circle.Unit, Circle.Empty);
        Assert.IsFalse(Circle.Unit == Circle.Empty);
        Assert.IsTrue(Circle.Unit != Circle.Empty);
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Circle.Empty.GetHashCode();
        Assert.AreEqual(hashCode, Circle.Empty.GetHashCode());
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenUnitCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Circle.Unit.GetHashCode();
        Assert.AreEqual(hashCode, Circle.Unit.GetHashCode());
    }

    [TestMethod]
    public void Radius_ShouldBe0_GivenEmptyCircle()
    {
        Assert.AreEqual(0, Circle.Empty.Radius);
    }

    [TestMethod]
    public void Radius_ShouldBe1_GivenUnitCircle()
    {
        Assert.AreEqual(1, Circle.Unit.Radius);
    }
}
