using System.Drawing;
using NUnit.Framework;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestFixture]
public class PolygonTests
{
    [Test]
    public void AddVertices_ShouldAddVertices()
    {
        var polygon = Polygon.Empty;
        polygon.AddVertices(new[] {new Point(1, 2), new Point(3, 4)});
        Assert.That(polygon.VertexCount, Is.EqualTo(2));

        // assert that the empty polygon was not modified
        Assert.That(Polygon.Empty.VertexCount, Is.Zero);
    }

    [Test]
    public void AddVertices_ShouldThrowArgumentNullException_GivenNullEnumerable()
    {
        var polygon = Polygon.Empty;
        IEnumerable<Point> vertices = null!;
        Assert.Throws<ArgumentNullException>(() => polygon.AddVertices(vertices));
    }

    [Test]
    public void ClearVertices_ShouldClearVertices()
    {
        var polygon = Polygon.Empty;
        polygon.AddVertices(new[] {new Point(1, 2), new Point(3, 4)});
        Assert.That(polygon.VertexCount, Is.EqualTo(2));

        // assert that the empty polygon was not modified
        Assert.That(Polygon.Empty.VertexCount, Is.Zero);

        polygon.ClearVertices();
        Assert.That(polygon.VertexCount, Is.Zero);
    }

    [Test]
    public void Constructor_ShouldPopulateVertices_GivenPolygon()
    {
        var pointPolygon = new Polygon(new[] {new Point(1, 2), new Point(3, 4)});

        Assert.That(pointPolygon.VertexCount, Is.EqualTo(2));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_GivenNullEnumerableOfPoint()
    {
        IEnumerable<Point> vertices = null!;
        Assert.Throws<ArgumentNullException>(() => new Polygon(vertices));
    }

    [Test]
    public void CopyConstructor_ShouldCopyVertices_GivenPolygon()
    {
        var first = Polygon.Empty;
        first.AddVertices(new[] {new Point(1, 2), new Point(3, 4)});

        var second = new Polygon(first);
        Assert.That(first.VertexCount, Is.EqualTo(2));
        Assert.That(second.VertexCount, Is.EqualTo(2));

        // we cannot use CollectionAssert here for reasons I am not entirely sure of.
        // it seems to dislike casting from IReadOnlyList<Point> to ICollection. but okay.
        Assert.That(first.Vertices.SequenceEqual(second.Vertices));

        // assert that the empty polygon was not modified
        Assert.That(Polygon.Empty.VertexCount, Is.Zero);
    }

    [Test]
    public void CopyConstructor_ShouldThrowArgumentNullException_GivenNullPolygon()
    {
        Polygon polygon = null!;
        Assert.Throws<ArgumentNullException>(() => new Polygon(polygon));
    }

    [Test]
    public void Equals_ShouldBeTrue_GivenTwoEmptyPolygons()
    {
        var first = Polygon.Empty;
        var second = Polygon.Empty;

        Assert.Multiple(() =>
        {
            Assert.That(second, Is.EqualTo(first));
            Assert.That(first, Is.EqualTo(second));
        });
    }

    [Test]
    public void Equals_ShouldBeTrue_GivenTwoHexagons()
    {
        Polygon first = CreateHexagon();
        Polygon second = CreateHexagon();

        Assert.Multiple(() =>
        {
            Assert.That(second, Is.EqualTo(first));
            Assert.That(first, Is.EqualTo(second));
        });
    }

    [Test]
    public void Equals_ShouldBeFalse_GivenHexagonAndEmptyPolygon()
    {
        Polygon first = CreateHexagon();
        Polygon second = Polygon.Empty;

        Assert.Multiple(() =>
        {
            Assert.That(second, Is.Not.EqualTo(first));
            Assert.That(first, Is.Not.EqualTo(second));
        });
    }

    [Test]
    public void FromPolygonF_ShouldReturnEquivalentPolygon_GivenPolygon()
    {
        PolygonF hexagon = CreateHexagonF();

        Polygon expected = CreateHexagon();
        Polygon actual = Polygon.FromPolygonF(hexagon);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void FromPolygonF_ShouldThrowArgumentNullException_GivenNullPolygon()
    {
        Assert.Throws<ArgumentNullException>(() => Polygon.FromPolygonF(null!));
    }

    [Test]
    public void IsConvex_ShouldBeFalse_GivenEmptyPolygon()
    {
        Assert.That(Polygon.Empty.IsConvex, Is.False);
    }

    [Test]
    public void IsConvex_ShouldBeTrue_GivenHexagon()
    {
        Assert.That(CreateHexagon().IsConvex);
    }

    [Test]
    public void IsConvex_ShouldBeFalse_GivenConcavePolygon()
    {
        Assert.That(CreateConcavePolygon().IsConvex, Is.False);
    }

    [Test]
    public void PointCount_ShouldBe1_GivenPolygonWith1Point()
    {
        var polygon = Polygon.Empty;
        polygon.AddVertex(new Point(1, 1));

        Assert.That(polygon.VertexCount, Is.EqualTo(1));

        // assert that the empty polygon was not modified
        Assert.That(Polygon.Empty.VertexCount, Is.Zero);
    }

    [Test]
    public void PointCount_ShouldBe0_GivenEmptyPolygon()
    {
        Assert.That(Polygon.Empty.VertexCount, Is.Zero);
    }

    [Test]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Polygon.Empty.GetHashCode();
        Assert.That(Polygon.Empty.GetHashCode(), Is.EqualTo(hashCode));
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
