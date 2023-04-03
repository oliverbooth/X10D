using System.Drawing;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class EllipseFTests
{
    [TestMethod]
    public void Area_ShouldBePiRadiusRadius_GivenUnitEllipse()
    {
        var unitEllipse = EllipseF.Unit;
        Assert.AreEqual(MathF.PI, unitEllipse.Area, 1e-6f);
    }

    [TestMethod]
    public void ApproximateCircumference_ShouldBe2PiRadius_GivenUnitEllipse()
    {
        var unitEllipse = EllipseF.Unit;
        Assert.AreEqual(2 * MathF.PI, unitEllipse.ApproximateCircumference, 1e-6f);
    }

    [TestMethod]
    public void Constructor_ShouldGiveCorrectEllipse()
    {
        var ellipse = new EllipseF(PointF.Empty, new SizeF(2, 1));
        Assert.AreEqual(new PointF(0, 0), ellipse.Center);
        Assert.AreEqual(new SizeF(2, 1), ellipse.Radius);

        ellipse = new EllipseF(0, 0, 2, 1);
        Assert.AreEqual(new PointF(0, 0), ellipse.Center);
        Assert.AreEqual(new SizeF(2, 1), ellipse.Radius);

        ellipse = new EllipseF(PointF.Empty, new Vector2(2, 1));
        Assert.AreEqual(new PointF(0, 0), ellipse.Center);
        Assert.AreEqual(new SizeF(2, 1), ellipse.Radius);

        ellipse = new EllipseF(Vector2.Zero, new Vector2(2, 1));
        Assert.AreEqual(new PointF(0, 0), ellipse.Center);
        Assert.AreEqual(new SizeF(2, 1), ellipse.Radius);
    }

    [TestMethod]
    public void Equals_ShouldBeTrue_GivenTwoUnitEllipses()
    {
        var unitEllipse1 = EllipseF.Unit;
        var unitEllipse2 = EllipseF.Unit;
        Assert.AreEqual(unitEllipse1, unitEllipse2);
        Assert.IsTrue(unitEllipse1 == unitEllipse2);
        Assert.IsFalse(unitEllipse1 != unitEllipse2);
    }

    [TestMethod]
    public void Equals_ShouldBeFalse_GivenDifferentEllipses()
    {
        Assert.AreNotEqual(EllipseF.Unit, EllipseF.Empty);
        Assert.IsFalse(EllipseF.Unit == EllipseF.Empty);
        Assert.IsTrue(EllipseF.Unit != EllipseF.Empty);
    }

    [TestMethod]
    public void Equals_ShouldBeFalse_GivenDifferentObjects()
    {
        Assert.IsFalse(EllipseF.Unit.Equals(null));
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyEllipse()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = EllipseF.Empty.GetHashCode();
        Assert.AreEqual(hashCode, EllipseF.Empty.GetHashCode());
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenUnitEllipse()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = EllipseF.Unit.GetHashCode();
        Assert.AreEqual(hashCode, EllipseF.Unit.GetHashCode());
    }

    [TestMethod]
    public void HorizontalRadius_ShouldBe0_GivenEmptyEllipse()
    {
        Assert.AreEqual(0, EllipseF.Empty.HorizontalRadius);
    }

    [TestMethod]
    public void HorizontalRadius_ShouldBe1_GivenUnitEllipse()
    {
        Assert.AreEqual(1, EllipseF.Unit.HorizontalRadius);
    }

    [TestMethod]
    public void op_Explicit_ShouldReturnEquivalentEllipse_GivenEllipse()
    {
        EllipseF unitEllipse = EllipseF.Unit;
        Ellipse converted = (Ellipse)unitEllipse;

        Assert.AreEqual(unitEllipse, converted);
        Assert.AreEqual(unitEllipse.HorizontalRadius, converted.HorizontalRadius);
        Assert.AreEqual(unitEllipse.VerticalRadius, converted.VerticalRadius);
        Assert.AreEqual(unitEllipse.Center, converted.Center);
    }

    [TestMethod]
    public void op_Implicit_ShouldReturnEquivalentEllipse_GivenCircle()
    {
        Circle unitCircle = Circle.Unit;
        EllipseF converted = unitCircle;

        Assert.AreEqual(unitCircle, converted);
        Assert.AreEqual(unitCircle.Radius, converted.HorizontalRadius);
        Assert.AreEqual(unitCircle.Radius, converted.VerticalRadius);
        Assert.AreEqual(unitCircle.Center, converted.Center);
    }

    [TestMethod]
    public void op_Implicit_ShouldReturnEquivalentEllipse_GivenCircleF()
    {
        CircleF unitCircle = CircleF.Unit;
        EllipseF converted = unitCircle;

        Assert.AreEqual(unitCircle, converted);
        Assert.AreEqual(unitCircle.Radius, converted.HorizontalRadius);
        Assert.AreEqual(unitCircle.Radius, converted.VerticalRadius);
        Assert.AreEqual(unitCircle.Center, converted.Center);
    }

    [TestMethod]
    public void op_Implicit_ShouldReturnEquivalentEllipse_GivenEllipse()
    {
        Ellipse unitEllipse = Ellipse.Unit;
        EllipseF converted = unitEllipse;

        Assert.AreEqual(unitEllipse, converted);
        Assert.AreEqual(unitEllipse.HorizontalRadius, converted.HorizontalRadius);
        Assert.AreEqual(unitEllipse.VerticalRadius, converted.VerticalRadius);
        Assert.AreEqual(unitEllipse.Center, converted.Center);
    }

    [TestMethod]
    public void VerticalRadius_ShouldBe0_GivenEmptyEllipse()
    {
        Assert.AreEqual(0, EllipseF.Empty.VerticalRadius);
    }

    [TestMethod]
    public void VerticalRadius_ShouldBe1_GivenUnitEllipse()
    {
        Assert.AreEqual(1, EllipseF.Unit.VerticalRadius);
    }
}
