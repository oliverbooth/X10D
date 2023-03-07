using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class PolyhedronTests
{
    [TestMethod]
    public void AddVertices_ShouldAddVertices()
    {
        var polyhedron = Polyhedron.Empty;
        polyhedron.AddVertices(new[] {new Vector3(1, 2, 3), new Vector3(4, 5, 6)});
        Assert.AreEqual(2, polyhedron.VertexCount);

        // assert that the empty polyhedron was not modified
        Assert.AreEqual(0, Polyhedron.Empty.VertexCount);
    }

    [TestMethod]
    public void ClearVertices_ShouldClearVertices()
    {
        var polyhedron = Polyhedron.Empty;
        polyhedron.AddVertices(new[] {new Vector3(1, 2, 3), new Vector3(4, 5, 6)});
        Assert.AreEqual(2, polyhedron.VertexCount);

        // assert that the empty polyhedron was not modified
        Assert.AreEqual(0, Polyhedron.Empty.VertexCount);

        polyhedron.ClearVertices();
        Assert.AreEqual(0, polyhedron.VertexCount);
    }

    [TestMethod]
    public void Constructor_ShouldPopulateVertices_GivenPolyhedron()
    {
        var polyhedron = new Polyhedron(new[] {new Vector3(1, 2, 3), new Vector3(4, 5, 6)});
        Assert.AreEqual(2, polyhedron.VertexCount);
    }

    [TestMethod]
    public void CopyConstructor_ShouldCopyVertices_GivenPolyhedron()
    {
        var first = Polyhedron.Empty;
        first.AddVertices(new[] {new Vector3(1, 2, 3), new Vector3(4, 5, 6)});

        var second = new Polyhedron(first);
        Assert.AreEqual(2, first.VertexCount);
        Assert.AreEqual(2, second.VertexCount);

        // we cannot use CollectionAssert here for reasons I am not entirely sure of.
        // it seems to dislike casting from IReadOnlyList<Point> to ICollection. but okay.
        Assert.IsTrue(first.Vertices.SequenceEqual(second.Vertices));

        // assert that the empty polyhedron was not modified
        Assert.AreEqual(0, Polyhedron.Empty.VertexCount);
    }

    [TestMethod]
    public void Equals_ShouldBeTrue_GivenTwoEmptyPolyhedrons()
    {
        var first = Polyhedron.Empty;
        var second = Polyhedron.Empty;

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
        Polyhedron first = CreateHexagon();
        Polyhedron second = CreateHexagon();

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
    public void Equals_ShouldBeFalse_GivenHexagonAndEmptyPolyhedron()
    {
        Polyhedron first = CreateHexagon();
        Polyhedron second = Polyhedron.Empty;

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
    public void op_Implicit_ShouldReturnEquivalentPolyhedron_GivenPolyhedron()
    {
        Polygon polygon = PolygonTests.CreateHexagon();
        Polyhedron converted = polygon;

        Assert.AreEqual(polygon, converted);
        Assert.AreEqual(polygon.VertexCount, converted.VertexCount);

        Assert.IsTrue(converted.Vertices.SequenceEqual(polygon.Vertices.Select(p =>
        {
            var point = p.ToVector2();
            return new Vector3(point.X, point.Y, 0);
        })));
    }

    [TestMethod]
    public void op_Implicit_ShouldReturnEquivalentPolyhedron_GivenPolyhedronF()
    {
        PolygonF polygon = PolygonFTests.CreateHexagon();
        Polyhedron converted = polygon;

        Assert.AreEqual(polygon, converted);
        Assert.AreEqual(polygon.VertexCount, converted.VertexCount);

        Assert.IsTrue(converted.Vertices.SequenceEqual(polygon.Vertices.Select(v =>
        {
            var point = v.ToVector2();
            return new Vector3(point.X, point.Y, 0);
        })));
    }

    [TestMethod]
    public void PointCount_ShouldBe1_GivenPolyhedronWith1Point()
    {
        var polyhedron = new Polyhedron();
        polyhedron.AddVertex(Vector3.One);

        Assert.AreEqual(1, polyhedron.VertexCount);

        // assert that the empty polyhedron was not modified
        Assert.AreEqual(0, Polyhedron.Empty.VertexCount);
    }

    [TestMethod]
    public void PointCount_ShouldBe0_GivenEmptyPolyhedron()
    {
        Assert.AreEqual(0, Polyhedron.Empty.VertexCount);
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Polyhedron.Empty.GetHashCode();
        Assert.AreEqual(hashCode, Polyhedron.Empty.GetHashCode());
    }

    internal static Polyhedron CreateHexagon()
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

    internal static Polyhedron CreateConcavePolyhedron()
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
