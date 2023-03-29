using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class EllipseTests
{
    [TestMethod]
    public void Area_ShouldBePiRadiusRadius_GivenUnitEllipse()
    {
        var unitEllipse = Ellipse.Unit;
        Assert.AreEqual(MathF.PI, unitEllipse.Area, 1e-6f);
    }

    [TestMethod]
    public void ApproximateCircumference_ShouldBe2PiRadius_GivenUnitEllipse()
    {
        var unitEllipse = Ellipse.Unit;
        Assert.AreEqual(2 * MathF.PI, unitEllipse.ApproximateCircumference, 1e-6f);
    }

    [TestMethod]
    public void Constructor_ShouldGiveCorrectEllipse()
    {
        var ellipse = new Ellipse(Point.Empty, new Size(2, 1));
        Assert.AreEqual(new Point(0, 0), ellipse.Center);
        Assert.AreEqual(new Size(2, 1), ellipse.Radius);

        ellipse = new Ellipse(0, 0, 2, 1);
        Assert.AreEqual(new Point(0, 0), ellipse.Center);
        Assert.AreEqual(new Size(2, 1), ellipse.Radius);
    }

    [TestMethod]
    public void Equals_ShouldBeTrue_GivenTwoUnitEllipses()
    {
        var unitEllipse1 = Ellipse.Unit;
        var unitEllipse2 = Ellipse.Unit;
        Assert.AreEqual(unitEllipse1, unitEllipse2);
        Assert.IsTrue(unitEllipse1 == unitEllipse2);
        Assert.IsFalse(unitEllipse1 != unitEllipse2);
    }

    [TestMethod]
    public void Equals_ShouldBeFalse_GivenDifferentEllipses()
    {
        Assert.AreNotEqual(Ellipse.Unit, Ellipse.Empty);
        Assert.IsFalse(Ellipse.Unit == Ellipse.Empty);
        Assert.IsTrue(Ellipse.Unit != Ellipse.Empty);
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyEllipse()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Ellipse.Empty.GetHashCode();
        Assert.AreEqual(hashCode, Ellipse.Empty.GetHashCode());
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenUnitEllipse()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Ellipse.Unit.GetHashCode();
        Assert.AreEqual(hashCode, Ellipse.Unit.GetHashCode());
    }

    [TestMethod]
    public void HorizontalRadius_ShouldBe0_GivenEmptyEllipse()
    {
        Assert.AreEqual(0, Ellipse.Empty.HorizontalRadius);
    }

    [TestMethod]
    public void HorizontalRadius_ShouldBe1_GivenUnitEllipse()
    {
        Assert.AreEqual(1, Ellipse.Unit.HorizontalRadius);
    }

    [TestMethod]
    public void op_Implicit_ShouldReturnEquivalentEllipse_GivenCircle()
    {
        Circle unitCircle = Circle.Unit;
        Ellipse converted = unitCircle;

        Assert.AreEqual(unitCircle, converted);
        Assert.AreEqual(unitCircle.Radius, converted.HorizontalRadius);
        Assert.AreEqual(unitCircle.Radius, converted.VerticalRadius);
        Assert.AreEqual(unitCircle.Center, converted.Center);
    }

    [TestMethod]
    public void VerticalRadius_ShouldBe0_GivenEmptyEllipse()
    {
        Assert.AreEqual(0, Ellipse.Empty.VerticalRadius);
    }

    [TestMethod]
    public void VerticalRadius_ShouldBe1_GivenUnitEllipse()
    {
        Assert.AreEqual(1, Ellipse.Unit.VerticalRadius);
    }
}
