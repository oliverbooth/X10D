using System.Drawing;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class PolygonFTests
{
    [TestMethod]
    public void AddPoints_ShouldAddPoints()
    {
        var polygon = PolygonF.Empty;
        polygon.AddPoints(new[] {new PointF(1, 2), new PointF(3, 4)});
        Assert.AreEqual(2, polygon.PointCount);

        // assert that the empty polygon was not modified
        Assert.AreEqual(0, PolygonF.Empty.PointCount);
    }

    [TestMethod]
    public void ClearPoints_ShouldClearPoints()
    {
        var polygon = PolygonF.Empty;
        polygon.AddPoints(new[] {new Vector2(1, 2), new Vector2(3, 4)});
        Assert.AreEqual(2, polygon.PointCount);

        // assert that the empty polygon was not modified
        Assert.AreEqual(0, PolygonF.Empty.PointCount);

        polygon.ClearPoints();
        Assert.AreEqual(0, polygon.PointCount);
    }

    [TestMethod]
    public void Constructor_ShouldPopulatePoints_GivenPolygon()
    {
        var pointPolygon = new PolygonF(new[] {new PointF(1, 2), new PointF(3, 4)});
        var vectorPolygon = new PolygonF(new[] {new Vector2(1, 2), new Vector2(3, 4)});

        Assert.AreEqual(2, pointPolygon.PointCount);
        Assert.AreEqual(2, vectorPolygon.PointCount);
    }

    [TestMethod]
    public void CopyConstructor_ShouldCopyPoints_GivenPolygon()
    {
        var first = PolygonF.Empty;
        first.AddPoints(new[] {new PointF(1, 2), new PointF(3, 4)});

        var second = new PolygonF(first);
        Assert.AreEqual(2, first.PointCount);
        Assert.AreEqual(2, second.PointCount);

        // we cannot use CollectionAssert here for reasons I am not entirely sure of.
        // it seems to dislike casting from IReadOnlyList<Point> to ICollection. but okay.
        Assert.IsTrue(first.Points.SequenceEqual(second.Points));

        // assert that the empty polygon was not modified
        Assert.AreEqual(0, PolygonF.Empty.PointCount);
    }

    [TestMethod]
    public void Equals_ShouldBeTrue_GivenTwoEmptyPolygons()
    {
        var first = PolygonF.Empty;
        var second = PolygonF.Empty;

        Assert.AreEqual(first, second);
        Assert.AreEqual(second, first);
        Assert.IsTrue(first.Equals(second));
        Assert.IsTrue(second.Equals(first));
        Assert.IsTrue(first == second);
        Assert.IsTrue(second == first);
        Assert.IsFalse(first != second);
        Assert.IsFalse(second != first);
    }

    [TestMethod]
    public void Equals_ShouldBeTrue_GivenTwoHexagons()
    {
        PolygonF first = CreateHexagon();
        PolygonF second = CreateHexagon();

        Assert.AreEqual(first, second);
        Assert.AreEqual(second, first);
        Assert.IsTrue(first.Equals(second));
        Assert.IsTrue(second.Equals(first));
        Assert.IsTrue(first == second);
        Assert.IsTrue(second == first);
        Assert.IsFalse(first != second);
        Assert.IsFalse(second != first);
    }

    [TestMethod]
    public void Equals_ShouldBeFalse_GivenHexagonAndEmptyPolygon()
    {
        PolygonF first = CreateHexagon();
        PolygonF second = PolygonF.Empty;

        Assert.AreNotEqual(first, second);
        Assert.AreNotEqual(second, first);
        Assert.IsFalse(first.Equals(second));
        Assert.IsFalse(second.Equals(first));
        Assert.IsFalse(first == second);
        Assert.IsFalse(second == first);
        Assert.IsTrue(first != second);
        Assert.IsTrue(second != first);
    }

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
    public void IsConvex_ShouldBeFalse_GivenConcavePolygon()
    {
        Assert.IsFalse(CreateConcavePolygon().IsConvex);
    }

    [TestMethod]
    public void op_Explicit_ShouldReturnEquivalentCircle_GivenCircle()
    {
        PolygonF polygon = CreateHexagon();
        Polygon converted = (Polygon)polygon;

        Assert.AreEqual(polygon, converted);
        Assert.AreEqual(polygon.IsConvex, converted.IsConvex);
        Assert.AreEqual(polygon.PointCount, converted.PointCount);

        Assert.IsTrue(polygon.Points.SequenceEqual(converted.Points.Select(p => (PointF)p)));
    }

    [TestMethod]
    public void op_Implicit_ShouldReturnEquivalentCircle_GivenCircle()
    {
        Polygon polygon = PolygonTests.CreateHexagon();
        PolygonF converted = polygon;

        Assert.AreEqual(polygon, converted);
        Assert.AreEqual(polygon.IsConvex, converted.IsConvex);
        Assert.AreEqual(polygon.PointCount, converted.PointCount);

        Assert.IsTrue(converted.Points.SequenceEqual(polygon.Points.Select(p => (PointF)p)));
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
    public void GetHashCode_ShouldBeCorrect_GivenEmptyCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = PolygonF.Empty.GetHashCode();
        Assert.AreEqual(hashCode, PolygonF.Empty.GetHashCode());
    }

    internal static PolygonF CreateHexagon()
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

    internal static PolygonF CreateConcavePolygon()
    {
        var hexagon = new PolygonF();
        hexagon.AddPoint(new Vector2(0, 0));
        hexagon.AddPoint(new Vector2(2, 0));
        hexagon.AddPoint(new Vector2(1, 1));
        hexagon.AddPoint(new Vector2(2, 1));
        hexagon.AddPoint(new Vector2(0, 1));
        return hexagon;
    }
}
