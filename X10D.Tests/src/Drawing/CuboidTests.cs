using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class CuboidTests
{
    [TestMethod]
    public void Corners_ShouldBeCorrect_GivenCubeOfSize1()
    {
        Cuboid cube = Cuboid.Cube;

        Assert.AreEqual(new Vector3(0.5f, 0.5f, -0.5f), cube.FrontTopRight);
        Assert.AreEqual(new Vector3(-0.5f, 0.5f, -0.5f), cube.FrontTopLeft);
        Assert.AreEqual(new Vector3(0.5f, -0.5f, -0.5f), cube.FrontBottomRight);
        Assert.AreEqual(new Vector3(-0.5f, -0.5f, -0.5f), cube.FrontBottomLeft);
        Assert.AreEqual(new Vector3(0.5f, 0.5f, 0.5f), cube.BackTopRight);
        Assert.AreEqual(new Vector3(-0.5f, 0.5f, 0.5f), cube.BackTopLeft);
        Assert.AreEqual(new Vector3(0.5f, -0.5f, 0.5f), cube.BackBottomRight);
        Assert.AreEqual(new Vector3(-0.5f, -0.5f, 0.5f), cube.BackBottomLeft);
    }

    [TestMethod]
    public void Equals_ShouldBeTrue_GivenTwoCubesOfSize1()
    {
        var cube1 = Cuboid.Cube;
        var cube2 = Cuboid.Cube;
        Assert.AreEqual(cube1, cube2);
        Assert.IsTrue(cube1 == cube2);
        Assert.IsFalse(cube1 != cube2);
    }

    [TestMethod]
    public void Equals_ShouldBeFalse_GivenDifferentCubes()
    {
        Assert.AreNotEqual(Cuboid.Cube, Cuboid.Empty);
        Assert.IsFalse(Cuboid.Cube == Cuboid.Empty);
        Assert.IsTrue(Cuboid.Cube != Cuboid.Empty);
    }

    [TestMethod]
    public void Equals_ShouldBeFalse_GivenDifferentObjects()
    {
        Assert.IsFalse(Cuboid.Cube.Equals(null));
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyCircle()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Cuboid.Empty.GetHashCode();
        Assert.AreEqual(hashCode, Cuboid.Empty.GetHashCode());
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenCubeOfSize1()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Cuboid.Cube.GetHashCode();
        Assert.AreEqual(hashCode, Cuboid.Cube.GetHashCode());
    }

    [TestMethod]
    public void Size_ShouldBeOne_GivenCubeOfSize1()
    {
        Assert.AreEqual(Vector3.One, Cuboid.Cube.Size);
    }

    [TestMethod]
    public void Size_ShouldBeOne_GivenRotatedCube()
    {
        Assert.AreEqual(Vector3.One, new Cuboid(0, 0, 0, 1, 1, 1, 90, 0, 0).Size);
    }

    [TestMethod]
    public void Volume_ShouldBe1_GivenCubeOfSize1()
    {
        Assert.AreEqual(1.0f, Cuboid.Cube.Volume, 1e-6f);
    }
}
