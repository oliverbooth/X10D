using System.Drawing;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class PolygonTests
{
    [TestMethod]
    public void AddVertices_ShouldAddVertices()
    {
        var polygon = Polygon.Empty;
        polygon.AddVertices(new[] {new Point(1, 2), new Point(3, 4)});
        Assert.AreEqual(2, polygon.VertexCount);


        // assert that the empty polygon was not modified
        Assert.AreEqual(0, Polygon.Empty.VertexCount);
    }

    [TestMethod]
    public void AddVertices_ShouldThrowArgumentNullException_GivenNullEnumerable()
    {
        var polygon = Polygon.Empty;
        IEnumerable<Point> vertices = null!;
        Assert.ThrowsException<ArgumentNullException>(() => polygon.AddVertices(vertices));
    }

    [TestMethod]
    public void ClearVertices_ShouldClearVertices()
    {
        var polygon = Polygon.Empty;
        polygon.AddVertices(new[] {new Point(1, 2), new Point(3, 4)});
        Assert.AreEqual(2, polygon.VertexCount);

        // assert that the empty polygon was not modified
        Assert.AreEqual(0, Polygon.Empty.VertexCount);

        polygon.ClearVertices();
        Assert.AreEqual(0, polygon.VertexCount);
    }

    [TestMethod]
    public void Constructor_ShouldPopulateVertices_GivenPolygon()
    {
        var pointPolygon = new Polygon(new[] {new Point(1, 2), new Point(3, 4)});

        Assert.AreEqual(2, pointPolygon.VertexCount);
    }

    [TestMethod]
    public void Constructor_ShouldThrowArgumentNullException_GivenNullEnumerableOfPoint()
    {
        IEnumerable<Point> vertices = null!;
        Assert.ThrowsException<ArgumentNullException>(() => new Polygon(vertices));
    }

    [TestMethod]
    public void CopyConstructor_ShouldCopyVertices_GivenPolygon()
    {
        var first = Polygon.Empty;
        first.AddVertices(new[] {new Point(1, 2), new Point(3, 4)});

        var second = new Polygon(first);
        Assert.AreEqual(2, first.VertexCount);
        Assert.AreEqual(2, second.VertexCount);

        // we cannot use CollectionAssert here for reasons I am not entirely sure of.
        // it seems to dislike casting from IReadOnlyList<Point> to ICollection. but okay.
        Assert.IsTrue(first.Vertices.SequenceEqual(second.Vertices));

        // assert that the empty polygon was not modified
        Assert.AreEqual(0, Polygon.Empty.VertexCount);
    }

    [TestMethod]
    public void CopyConstructor_ShouldThrowArgumentNullException_GivenNullPolygon()
    {
        Polygon polygon = null!;
        Assert.ThrowsException<ArgumentNullException>(() => new Polygon(polygon));
    }

    [TestMethod]
    public void Equals_ShouldBeTrue_GivenTwoEmptyPolygons()
    {
        var first = Polygon.Empty;
        var second = Polygon.Empty;

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
        Polygon first = CreateHexagon();
        Polygon second = CreateHexagon();

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
        Polygon first = CreateHexagon();
        Polygon second = Polygon.Empty;

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
    public void FromPolygonF_ShouldReturnEquivalentPolygon_GivenPolygon()
    {
        PolygonF hexagon = CreateHexagonF();

        Polygon expected = CreateHexagon();
        Polygon actual = Polygon.FromPolygonF(hexagon);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FromPolygonF_ShouldThrowArgumentNullException_GivenNullPolygon()
    {
        Assert.ThrowsException<ArgumentNullException>(() => Polygon.FromPolygonF(null!));
    }

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
    public void IsConvex_ShouldBeFalse_GivenConcavePolygon()
    {
        Assert.IsFalse(CreateConcavePolygon().IsConvex);
    }

    [TestMethod]
    public void PointCount_ShouldBe1_GivenPolygonWith1Point()
    {
        var polygon = Polygon.Empty;
        polygon.AddVertex(new Point(1, 1));

        Assert.AreEqual(1, polygon.VertexCount);

        // assert that the empty polygon was not modified
        Assert.AreEqual(0, Polygon.Empty.VertexCount);
    }

    [TestMethod]
    public void PointCount_ShouldBe0_GivenEmptyPolygon()
    {
        Assert.AreEqual(0, Polygon.Empty.VertexCount);
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Polygon.Empty.GetHashCode();
        Assert.AreEqual(hashCode, Polygon.Empty.GetHashCode());
    }

    internal static Polygon CreateHexagon()
    {
        var hexagon = new Polygon();
        hexagon.AddVertex(new Point(0, 0));
        hexagon.AddVertex(new Point(1, 0));
        hexagon.AddVertex(new Point(1, 1));
        hexagon.AddVertex(new Point(0, 1));
        hexagon.AddVertex(new Point(-1, 1));
        hexagon.AddVertex(new Point(-1, 0));
        return hexagon;
    }

    internal static PolygonF CreateHexagonF()
    {
        var hexagon = new PolygonF();
        hexagon.AddVertex(new PointF(0, 0));
        hexagon.AddVertex(new PointF(1, 0));
        hexagon.AddVertex(new PointF(1, 1));
        hexagon.AddVertex(new PointF(0, 1));
        hexagon.AddVertex(new PointF(-1, 1));
        hexagon.AddVertex(new PointF(-1, 0));
        return hexagon;
    }

    internal static Polygon CreateConcavePolygon()
    {
        var hexagon = new Polygon();
        hexagon.AddVertex(new Point(0, 0));
        hexagon.AddVertex(new Point(2, 0));
        hexagon.AddVertex(new Point(1, 1));
        hexagon.AddVertex(new Point(2, 1));
        hexagon.AddVertex(new Point(0, 1));
        return hexagon;
    }
}
