using System.Numerics;
using NUnit.Framework;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestFixture]
public class PolyhedronTests
{
    [Test]
    public void AddVertices_ShouldAddVertices()
    {
        var polyhedron = Polyhedron.Empty;
        polyhedron.AddVertices(new[] {new Vector3(1, 2, 3), new Vector3(4, 5, 6)});

        Assert.Multiple(() =>
        {
            Assert.That(polyhedron.VertexCount, Is.EqualTo(2));

            // assert that the empty polyhedron was not modified
            Assert.That(Polyhedron.Empty.VertexCount, Is.Zero);
        });
    }

    [Test]
    public void AddVertices_ShouldThrowArgumentNullException_GivenNullEnumerableOfVector3()
    {
        var polygon = Polyhedron.Empty;
        IEnumerable<Vector3> vertices = null!;
        Assert.Throws<ArgumentNullException>(() => polygon.AddVertices(vertices));
    }

    [Test]
    public void ClearVertices_ShouldClearVertices()
    {
        var polyhedron = Polyhedron.Empty;
        polyhedron.AddVertices(new[] {new Vector3(1, 2, 3), new Vector3(4, 5, 6)});
        Assert.Multiple(() =>
        {
            Assert.That(polyhedron.VertexCount, Is.EqualTo(2));

            // assert that the empty polyhedron was not modified
            Assert.That(Polyhedron.Empty.VertexCount, Is.Zero);
        });

        polyhedron.ClearVertices();
        Assert.That(polyhedron.VertexCount, Is.Zero);
    }

    [Test]
    public void Constructor_ShouldPopulateVertices_GivenPolyhedron()
    {
        var polyhedron = new Polyhedron(new[] {new Vector3(1, 2, 3), new Vector3(4, 5, 6)});
        Assert.That(polyhedron.VertexCount, Is.EqualTo(2));
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_GivenNullEnumerableOfVector3()
    {
        IEnumerable<Vector3> vertices = null!;
        Assert.Throws<ArgumentNullException>(() => _ = new Polyhedron(vertices));
    }

    [Test]
    public void CopyConstructor_ShouldCopyVertices_GivenPolyhedron()
    {
        var first = Polyhedron.Empty;
        first.AddVertices(new[] {new Vector3(1, 2, 3), new Vector3(4, 5, 6)});

        var second = new Polyhedron(first);
        Assert.Multiple(() =>
        {
            Assert.That(first.VertexCount, Is.EqualTo(2));
            Assert.That(second.VertexCount, Is.EqualTo(2));

            // we cannot use CollectionAssert here for reasons I am not entirely sure of.
            // it seems to dislike casting from IReadOnlyList<Point> to ICollection. but okay.
            CollectionAssert.AreEqual(first.Vertices, second.Vertices);

            // assert that the empty polyhedron was not modified
            Assert.That(Polyhedron.Empty.VertexCount, Is.Zero);
        });
    }

    [Test]
    public void Equals_ShouldBeTrue_GivenTwoEmptyPolyhedrons()
    {
        var first = Polyhedron.Empty;
        var second = Polyhedron.Empty;

        Assert.Multiple(() =>
        {
            Assert.That(second, Is.EqualTo(first));
            Assert.That(first, Is.EqualTo(second));
        });
    }

    [Test]
    public void Equals_ShouldBeTrue_GivenTwoHexagons()
    {
        Polyhedron first = CreateHexagonPolyhedron();
        Polyhedron second = CreateHexagonPolyhedron();

        Assert.Multiple(() =>
        {
            Assert.That(second, Is.EqualTo(first));
            Assert.That(first, Is.EqualTo(second));
        });
    }

    [Test]
    public void Equals_ShouldBeFalse_GivenHexagonAndEmptyPolyhedron()
    {
        Polyhedron first = CreateHexagonPolyhedron();
        Polyhedron second = Polyhedron.Empty;

        Assert.Multiple(() =>
        {
            Assert.That(second, Is.Not.EqualTo(first));
            Assert.That(first, Is.Not.EqualTo(second));
        });
    }

    [Test]
    public void FromPolygon_ShouldThrowArgumentNullException_GivenNullPolygonF()
    {
        Assert.Throws<ArgumentNullException>(() => Polyhedron.FromPolygon(null!));
    }

    [Test]
    public void FromPolygonF_ShouldThrowArgumentNullException_GivenNullPolygonF()
    {
        Assert.Throws<ArgumentNullException>(() => Polyhedron.FromPolygonF(null!));
    }

    [Test]
    public void op_Implicit_ShouldReturnEquivalentPolyhedron_GivenPolyhedron()
    {
        Polygon polygon = PolygonTests.CreateHexagon();
        Polyhedron converted = polygon;

        Assert.Multiple(() =>
        {
            Assert.That(converted, Is.EqualTo((Polyhedron)polygon));
            Assert.That(converted.VertexCount, Is.EqualTo(polygon.VertexCount));

            CollectionAssert.AreEqual(converted.Vertices, polygon.Vertices.Select(p =>
            {
                var point = p.ToVector2();
                return new Vector3(point.X, point.Y, 0);
            }));
        });
    }

    [Test]
    public void op_Implicit_ShouldReturnEquivalentPolyhedron_GivenPolyhedronF()
    {
        PolygonF polygon = CreateHexagonPolygon();
        Polyhedron converted = polygon;

        Assert.Multiple(() =>
        {
            Assert.That(converted, Is.EqualTo((Polyhedron)polygon));
            Assert.That(converted.VertexCount, Is.EqualTo(polygon.VertexCount));
            CollectionAssert.AreEqual(converted.Vertices, polygon.Vertices.Select(p =>
            {
                var point = p.ToVector2();
                return new Vector3(point.X, point.Y, 0);
            }));
        });
    }

    [Test]
    public void PointCount_ShouldBe1_GivenPolyhedronWith1Point()
    {
        var polyhedron = new Polyhedron();
        polyhedron.AddVertex(Vector3.One);

        Assert.Multiple(() =>
        {
            Assert.That(polyhedron.VertexCount, Is.EqualTo(1));

            // assert that the empty polyhedron was not modified
            Assert.That(Polyhedron.Empty.VertexCount, Is.Zero);
        });
    }

    [Test]
    public void PointCount_ShouldBe0_GivenEmptyPolyhedron()
    {
        Assert.That(Polyhedron.Empty.VertexCount, Is.Zero);
    }

    [Test]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Polyhedron.Empty.GetHashCode();
        Assert.That(Polyhedron.Empty.GetHashCode(), Is.EqualTo(hashCode));
    }

    private static PolygonF CreateHexagonPolygon()
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

    private static Polyhedron CreateHexagonPolyhedron()
    {
        var hexagon = new Polyhedron();
        hexagon.AddVertex(new Vector3(0, 0, 0));
        hexagon.AddVertex(new Vector3(1, 0, 0));
        hexagon.AddVertex(new Vector3(1, 1, 0));
        hexagon.AddVertex(new Vector3(0, 1, 0));
        hexagon.AddVertex(new Vector3(-1, 1, 0));
        hexagon.AddVertex(new Vector3(-1, 0, 0));
        return hexagon;
    }

    private static Polyhedron CreateConcavePolyhedron()
    {
        var hexagon = new Polyhedron();
        hexagon.AddVertex(new Vector3(0, 0, 0));
        hexagon.AddVertex(new Vector3(2, 0, 0));
        hexagon.AddVertex(new Vector3(2, 1, 0));
        hexagon.AddVertex(new Vector3(2, 1, 0));
        hexagon.AddVertex(new Vector3(0, 1, 0));
        return hexagon;
    }
}
