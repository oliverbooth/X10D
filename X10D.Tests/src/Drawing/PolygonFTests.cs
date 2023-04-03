using System.Drawing;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class PolygonFTests
{
    [TestMethod]
    public void AddVertices_ShouldAddVertices()
    {
        var polygon = PolygonF.Empty;
        polygon.AddVertices(new[] {new PointF(1, 2), new PointF(3, 4)});
        Assert.AreEqual(2, polygon.VertexCount);

        // assert that the empty polygon was not modified
        Assert.AreEqual(0, PolygonF.Empty.VertexCount);
    }

    [TestMethod]
    public void AddVertices_ShouldThrowArgumentNullException_GivenNullEnumerableOfPointF()
    {
        var polygon = PolygonF.Empty;
        IEnumerable<PointF> vertices = null!;
        Assert.ThrowsException<ArgumentNullException>(() => polygon.AddVertices(vertices));
    }

    [TestMethod]
    public void AddVertices_ShouldThrowArgumentNullException_GivenNullEnumerableOfVector2()
    {
        var polygon = PolygonF.Empty;
        IEnumerable<Vector2> vertices = null!;
        Assert.ThrowsException<ArgumentNullException>(() => polygon.AddVertices(vertices));
    }

    [TestMethod]
    public void ClearVertices_ShouldClearVertices()
    {
        var polygon = PolygonF.Empty;
        polygon.AddVertices(new[] {new Vector2(1, 2), new Vector2(3, 4)});
        Assert.AreEqual(2, polygon.VertexCount);

        // assert that the empty polygon was not modified
        Assert.AreEqual(0, PolygonF.Empty.VertexCount);

        polygon.ClearVertices();
        Assert.AreEqual(0, polygon.VertexCount);
    }

    [TestMethod]
    public void Constructor_ShouldPopulateVertices_GivenPolygon()
    {
        var pointPolygon = new PolygonF(new[] {new PointF(1, 2), new PointF(3, 4)});
        var vectorPolygon = new PolygonF(new[] {new Vector2(1, 2), new Vector2(3, 4)});

        Assert.AreEqual(2, pointPolygon.VertexCount);
        Assert.AreEqual(2, vectorPolygon.VertexCount);
    }
    
    [TestMethod]
    public void Constructor_ShouldThrowArgumentNullException_GivenNullEnumerableOfPointF()
    {
        IEnumerable<PointF> vertices = null!;
        Assert.ThrowsException<ArgumentNullException>(() => new PolygonF(vertices));
    }

    [TestMethod]
    public void Constructor_ShouldThrowArgumentNullException_GivenNullEnumerableOfVector2()
    {
        IEnumerable<Vector2> vertices = null!;
        Assert.ThrowsException<ArgumentNullException>(() => new PolygonF(vertices));
    }

    [TestMethod]
    public void CopyConstructor_ShouldCopyVertices_GivenPolygon()
    {
        var first = PolygonF.Empty;
        first.AddVertices(new[] {new PointF(1, 2), new PointF(3, 4)});

        var second = new PolygonF(first);
        Assert.AreEqual(2, first.VertexCount);
        Assert.AreEqual(2, second.VertexCount);

        // we cannot use CollectionAssert here for reasons I am not entirely sure of.
        // it seems to dislike casting from IReadOnlyList<Point> to ICollection. but okay.
        Assert.IsTrue(first.Vertices.SequenceEqual(second.Vertices));

        // assert that the empty polygon was not modified
        Assert.AreEqual(0, PolygonF.Empty.VertexCount);
    }

    [TestMethod]
    public void CopyConstructor_ShouldThrowArgumentNullException_GivenNullPolygonF()
    {
        PolygonF polygon = null!;
        Assert.ThrowsException<ArgumentNullException>(() => new PolygonF(polygon));
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
    public void FromPolygon_ShouldThrowArgumentNullException_GivenNullPolygonF()
    {
        Assert.ThrowsException<ArgumentNullException>(() => PolygonF.FromPolygon(null!));
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
        Assert.AreEqual(polygon.VertexCount, converted.VertexCount);

        Assert.IsTrue(polygon.Vertices.SequenceEqual(converted.Vertices.Select(p => (PointF)p)));
    }

    [TestMethod]
    public void op_Implicit_ShouldReturnEquivalentCircle_GivenCircle()
    {
        Polygon polygon = PolygonTests.CreateHexagon();
        PolygonF converted = polygon;

        Assert.AreEqual(polygon, converted);
        Assert.AreEqual(polygon.IsConvex, converted.IsConvex);
        Assert.AreEqual(polygon.VertexCount, converted.VertexCount);

        Assert.IsTrue(converted.Vertices.SequenceEqual(polygon.Vertices.Select(p => (PointF)p)));
    }

    [TestMethod]
    public void PointCount_ShouldBe1_GivenPolygonFWith1Point()
    {
        var polygon = new PolygonF();
        polygon.AddVertex(new Point(1, 1));

        Assert.AreEqual(1, polygon.VertexCount);

        // assert that the empty polygon was not modified
        Assert.AreEqual(0, PolygonF.Empty.VertexCount);
    }

    [TestMethod]
    public void PointCount_ShouldBe0_GivenEmptyPolygon()
    {
        Assert.AreEqual(0, PolygonF.Empty.VertexCount);
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
        hexagon.AddVertex(new Vector2(0, 0));
        hexagon.AddVertex(new Vector2(1, 0));
        hexagon.AddVertex(new Vector2(1, 1));
        hexagon.AddVertex(new Vector2(0, 1));
        hexagon.AddVertex(new Vector2(-1, 1));
        hexagon.AddVertex(new Vector2(-1, 0));
        return hexagon;
    }

    internal static PolygonF CreateConcavePolygon()
    {
        var hexagon = new PolygonF();
        hexagon.AddVertex(new Vector2(0, 0));
        hexagon.AddVertex(new Vector2(2, 0));
        hexagon.AddVertex(new Vector2(1, 1));
        hexagon.AddVertex(new Vector2(2, 1));
        hexagon.AddVertex(new Vector2(0, 1));
        return hexagon;
    }
}
