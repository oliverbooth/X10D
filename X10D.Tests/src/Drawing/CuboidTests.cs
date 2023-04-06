using System.Numerics;
using NUnit.Framework;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestFixture]
public class CuboidTests
{
    [Test]
    public void Corners_ShouldBeCorrect_GivenCubeOfSize1()
    {
        Cuboid cube = Cuboid.Cube;

        Assert.That(cube.FrontTopRight, Is.EqualTo(new Vector3(0.5f, 0.5f, -0.5f)));
        Assert.That(cube.FrontTopLeft, Is.EqualTo(new Vector3(-0.5f, 0.5f, -0.5f)));
        Assert.That(cube.FrontBottomRight, Is.EqualTo(new Vector3(0.5f, -0.5f, -0.5f)));
        Assert.That(cube.FrontBottomLeft, Is.EqualTo(new Vector3(-0.5f, -0.5f, -0.5f)));
        Assert.That(cube.BackTopRight, Is.EqualTo(new Vector3(0.5f, 0.5f, 0.5f)));
        Assert.That(cube.BackTopLeft, Is.EqualTo(new Vector3(-0.5f, 0.5f, 0.5f)));
        Assert.That(cube.BackBottomRight, Is.EqualTo(new Vector3(0.5f, -0.5f, 0.5f)));
        Assert.That(cube.BackBottomLeft, Is.EqualTo(new Vector3(-0.5f, -0.5f, 0.5f)));
    }

    [Test]
    public void Equals_ShouldBeTrue_GivenTwoCubesOfSize1()
    {
        var cube1 = Cuboid.Cube;
        var cube2 = Cuboid.Cube;
        Assert.That(cube1, Is.EqualTo(cube2));
        Assert.That(cube2, Is.EqualTo(cube1));
        Assert.That(cube1 == cube2);
        Assert.That(cube2 == cube1);
    }

    [Test]
    public void Equals_ShouldBeFalse_GivenDifferentCubes()
    {
        Assert.That(Cuboid.Empty, Is.Not.EqualTo(Cuboid.Cube));
        Assert.That(Cuboid.Empty != Cuboid.Cube);
    }

    [Test]
    public void Equals_ShouldBeFalse_GivenDifferentObjects()
    {
        Assert.That(Cuboid.Cube.Equals(null), Is.False);
    }

    [Test]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Cuboid.Empty.GetHashCode();
        Assert.That(Cuboid.Empty.GetHashCode(), Is.EqualTo(hashCode));
    }

    [Test]
    public void GetHashCode_ShouldBeCorrect_GivenCubeOfSize1()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Cuboid.Cube.GetHashCode();
        Assert.That(Cuboid.Cube.GetHashCode(), Is.EqualTo(hashCode));
    }

    [Test]
    public void Size_ShouldBeOne_GivenCubeOfSize1()
    {
        Assert.That(Cuboid.Cube.Size, Is.EqualTo(Vector3.One));
    }

    [Test]
    public void Size_ShouldBeOne_GivenRotatedCube()
    {
        Assert.That(new Cuboid(0, 0, 0, 1, 1, 1, 90, 0, 0).Size, Is.EqualTo(Vector3.One));
    }

    [Test]
    public void Volume_ShouldBe1_GivenCubeOfSize1()
    {
        Assert.That(Cuboid.Cube.Volume, Is.EqualTo(1.0f).Within(1e-6f));
    }
}
