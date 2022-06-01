using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class PolygonTests
{
    [TestMethod]
    public void IsConvex_ShouldBeFalse_GivenEmptyPolygon()
    {
        Assert.IsFalse(Polygon.Empty.IsConvex);
    }

    [TestMethod]
    public void IsConvex_ShouldBeTrue_GivenHexagon()
    {
        Assert.IsTrue(CreateHexagon().IsConvex);
    }

    [TestMethod]
    public void PointCount_ShouldBe1_GivenPolygonWith1Point()
    {
        var polygon = new Polygon();
        polygon.AddPoint(new Point(1, 1));

        Assert.AreEqual(1, polygon.PointCount);

        // assert that the empty polygon was not modified
        Assert.AreEqual(0, Polygon.Empty.PointCount);
    }

    [TestMethod]
    public void PointCount_ShouldBe0_GivenEmptyPolygon()
    {
        Assert.AreEqual(0, Polygon.Empty.PointCount);
    }

    [TestMethod]
    public void Equals_ShouldBeTrue_GivenTwoUnitCircles()
    {
        var emptyPolygon1 = Polygon.Empty;
        var emptyPolygon2 = Polygon.Empty;
        Assert.AreEqual(emptyPolygon1, emptyPolygon2);
        Assert.IsTrue(emptyPolygon1 == emptyPolygon2);
        Assert.IsFalse(emptyPolygon1 != emptyPolygon2);
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Polygon.Empty.GetHashCode();
        Assert.AreEqual(hashCode, Polygon.Empty.GetHashCode());
    }

    private static Polygon CreateHexagon()
    {
        var hexagon = new Polygon();
        hexagon.AddPoint(new Point(0, 0));
        hexagon.AddPoint(new Point(1, 0));
        hexagon.AddPoint(new Point(1, 1));
        hexagon.AddPoint(new Point(0, 1));
        hexagon.AddPoint(new Point(-1, 1));
        hexagon.AddPoint(new Point(-1, 0));
        return hexagon;
    }
}
