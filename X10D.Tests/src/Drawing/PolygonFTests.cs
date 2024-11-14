using System.Drawing;
using System.Numerics;
using NUnit.Framework;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestFixture]
internal class PolygonFTests
{
    [Test]
    public void AddVertices_ShouldAddVertices()
    {
        var polygon = PolygonF.Empty;
        polygon.AddVertices([new PointF(1, 2), new PointF(3, 4)]);
        Assert.That(polygon.VertexCount, Is.EqualTo(2));

        // assert that the empty polygon was not modified
        Assert.That(PolygonF.Empty.VertexCount, Is.Zero);
    }

    [Test]
    public void AddVertices_ShouldThrowArgumentNullException_GivenNullEnumerableOfPointF()
    {
        var polygon = PolygonF.Empty;
        IEnumerable<PointF> vertices = null!;
        Assert.Throws<ArgumentNullException>(() => polygon.AddVertices(vertices));
    }

    [Test]
    public void AddVertices_ShouldThrowArgumentNullException_GivenNullEnumerableOfVector2()
    {
        var polygon = PolygonF.Empty;
        IEnumerable<Vector2> vertices = null!;
        Assert.Throws<ArgumentNullException>(() => polygon.AddVertices(vertices));
    }

    [Test]
    public void ClearVertices_ShouldClearVertices()
    {
        var polygon = PolygonF.Empty;
        polygon.AddVertices([new Vector2(1, 2), new Vector2(3, 4)]);
        Assert.That(polygon.VertexCount, Is.EqualTo(2));

        // assert that the empty polygon was not modified
        Assert.That(PolygonF.Empty.VertexCount, Is.Zero);

        polygon.ClearVertices();
        Assert.That(polygon.VertexCount, Is.Zero);
    }

    [Test]
    public void Constructor_ShouldPopulateVertices_GivenPolygon()
    {
        var pointPolygon = new PolygonF([new PointF(1, 2), new PointF(3, 4)]);
        var vectorPolygon = new PolygonF([new Vector2(1, 2), new Vector2(3, 4)]);

        Assert.That(pointPolygon.VertexCount, Is.EqualTo(2));
        Assert.That(vectorPolygon.VertexCount, Is.EqualTo(2));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_GivenNullEnumerableOfPointF()
    {
        IEnumerable<PointF> vertices = null!;
        Assert.Throws<ArgumentNullException>(() => _ = new PolygonF(vertices));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_GivenNullEnumerableOfVector2()
    {
        IEnumerable<Vector2> vertices = null!;
        Assert.Throws<ArgumentNullException>(() => _ = new PolygonF(vertices));
    }

    [Test]
    public void CopyConstructor_ShouldCopyVertices_GivenPolygon()
    {
        var first = PolygonF.Empty;
        first.AddVertices([new PointF(1, 2), new PointF(3, 4)]);

        var second = new PolygonF(first);
        Assert.That(first.VertexCount, Is.EqualTo(2));
        Assert.That(second.VertexCount, Is.EqualTo(2));

        // we cannot use CollectionAssert here for reasons I am not entirely sure of.
        // it seems to dislike casting from IReadOnlyList<Point> to ICollection. but okay.
        Assert.That(second.Vertices, Is.EqualTo(first.Vertices).AsCollection);

        // assert that the empty polygon was not modified
        Assert.That(PolygonF.Empty.VertexCount, Is.Zero);
    }

    [Test]
    public void CopyConstructor_ShouldThrowArgumentNullException_GivenNullPolygonF()
    {
        PolygonF polygon = null!;
        Assert.Throws<ArgumentNullException>(() => _ = new PolygonF(polygon));
    }

    [Test]
    public void Equals_ShouldBeTrue_GivenTwoEmptyPolygons()
    {
        var first = PolygonF.Empty;
        var second = PolygonF.Empty;

        Assert.Multiple(() =>
        {
            Assert.That(second, Is.EqualTo(first));
            Assert.That(first, Is.EqualTo(second));
            Assert.That(second == first);
            Assert.That(first == second);
        });
    }

    [Test]
    public void Equals_ShouldBeTrue_GivenTwoHexagons()
    {
        PolygonF first = CreateHexagon();
        PolygonF second = CreateHexagon();

        Assert.Multiple(() =>
        {
            Assert.That(second, Is.EqualTo(first));
            Assert.That(first, Is.EqualTo(second));
            Assert.That(second == first);
            Assert.That(first == second);
        });
    }

    [Test]
    public void Equals_ShouldBeFalse_GivenHexagonAndEmptyPolygon()
    {
        PolygonF first = CreateHexagon();
        PolygonF second = PolygonF.Empty;

        Assert.Multiple(() =>
        {
            Assert.That(second, Is.Not.EqualTo(first));
            Assert.That(first, Is.Not.EqualTo(second));
            Assert.That(second != first);
            Assert.That(first != second);
        });
    }

    [Test]
    public void FromPolygon_ShouldThrowArgumentNullException_GivenNullPolygonF()
    {
        Assert.Throws<ArgumentNullException>(() => PolygonF.FromPolygon(null!));
    }

    [Test]
    public void IsConvex_ShouldBeFalse_GivenEmptyPolygon()
    {
        Assert.That(PolygonF.Empty.IsConvex, Is.False);
    }

    [Test]
    public void IsConvex_ShouldBeTrue_GivenHexagon()
    {
        Assert.That(CreateHexagon().IsConvex, Is.True);
    }

    [Test]
    public void IsConvex_ShouldBeFalse_GivenConcavePolygon()
    {
        Assert.That(CreateConcavePolygon().IsConvex, Is.False);
    }

    [Test]
    public void op_Explicit_ShouldReturnEquivalentCircle_GivenCircle()
    {
        PolygonF polygon = CreateHexagon();
        Polygon converted = (Polygon)polygon;

        Assert.Multiple(() =>
        {
            Assert.That(converted, Is.EqualTo((Polygon)polygon));
            Assert.That(converted.IsConvex, Is.EqualTo(polygon.IsConvex));
            Assert.That(converted.VertexCount, Is.EqualTo(polygon.VertexCount));
            Assert.That(converted.Vertices.Select(p => (PointF)p), Is.EqualTo(polygon.Vertices).AsCollection);
        });
    }

    [Test]
    public void op_Implicit_ShouldReturnEquivalentCircle_GivenCircle()
    {
        Polygon polygon = PolygonTests.CreateHexagon();
        PolygonF converted = polygon;

        Assert.Multiple(() =>
        {
            Assert.That(converted, Is.EqualTo((PolygonF)polygon));
            Assert.That(converted == polygon);
            Assert.That(converted.IsConvex, Is.EqualTo(polygon.IsConvex));
            Assert.That(converted.VertexCount, Is.EqualTo(polygon.VertexCount));
            Assert.That(polygon.Vertices.Select(p => (PointF)p), Is.EqualTo(converted.Vertices).AsCollection);
        });
    }

    [Test]
    public void PointCount_ShouldBe1_GivenPolygonFWith1Point()
    {
        var polygon = new PolygonF();
        polygon.AddVertex(new Point(1, 1));

        Assert.That(polygon.VertexCount, Is.EqualTo(1));

        // assert that the empty polygon was not modified
        Assert.That(PolygonF.Empty.VertexCount, Is.Zero);
    }

    [Test]
    public void PointCount_ShouldBe0_GivenEmptyPolygon()
    {
        Assert.That(PolygonF.Empty.VertexCount, Is.Zero);
    }

    [Test]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = PolygonF.Empty.GetHashCode();
        Assert.That(PolygonF.Empty.GetHashCode(), Is.EqualTo(hashCode));
    }

    private static PolygonF CreateHexagon()
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

    private static PolygonF CreateConcavePolygon()
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
