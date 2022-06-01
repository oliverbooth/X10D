using System.Drawing;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class PolygonFTests
{
    [TestMethod]
    public void IsConvex_ShouldBeFalse_GivenEmptyPolygon()
    {
        Assert.IsFalse(PolygonF.Empty.IsConvex);
    }

    [TestMethod]
    public void IsConvex_ShouldBeTrue_GivenHexagon()
    {
        Assert.IsTrue(CreateHexagon().IsConvex);
    }

    [TestMethod]
    public void PointCount_ShouldBe1_GivenPolygonFWith1Point()
    {
        var polygon = new PolygonF();
        polygon.AddPoint(new Point(1, 1));

        Assert.AreEqual(1, polygon.PointCount);

        // assert that the empty polygon was not modified
        Assert.AreEqual(0, PolygonF.Empty.PointCount);
    }

    [TestMethod]
    public void PointCount_ShouldBe0_GivenEmptyPolygon()
    {
        Assert.AreEqual(0, PolygonF.Empty.PointCount);
    }

    [TestMethod]
    public void Equals_ShouldBeTrue_GivenTwoUnitCircles()
    {
        var emptyPolygonF1 = PolygonF.Empty;
        var emptyPolygonF2 = PolygonF.Empty;
        Assert.AreEqual(emptyPolygonF1, emptyPolygonF2);
        Assert.IsTrue(emptyPolygonF1 == emptyPolygonF2);
        Assert.IsFalse(emptyPolygonF1 != emptyPolygonF2);
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = PolygonF.Empty.GetHashCode();
        Assert.AreEqual(hashCode, PolygonF.Empty.GetHashCode());
    }

    private static PolygonF CreateHexagon()
    {
        var hexagon = new PolygonF();
        hexagon.AddPoint(new Vector2(0, 0));
        hexagon.AddPoint(new Vector2(1, 0));
        hexagon.AddPoint(new Vector2(1, 1));
        hexagon.AddPoint(new Vector2(0, 1));
        hexagon.AddPoint(new Vector2(-1, 1));
        hexagon.AddPoint(new Vector2(-1, 0));
        return hexagon;
    }
}
