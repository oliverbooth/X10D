using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestClass]
public class Vector3Tests
{
    [TestMethod]
    public void WithX_ShouldReturnVectorWithNewX_GivenVector()
    {
        Assert.AreEqual(new Vector3(0, 1, 1), Vector3.One.WithX(0));
        Assert.AreEqual(Vector3.Zero, Vector3.Zero.WithX(0));
        Assert.AreEqual(Vector3.Zero, Vector3.UnitX.WithX(0));
        Assert.AreEqual(Vector3.UnitY, Vector3.UnitY.WithX(0));
        Assert.AreEqual(Vector3.UnitZ, Vector3.UnitZ.WithX(0));

        Assert.AreEqual(Vector3.One, Vector3.One.WithX(1));
        Assert.AreEqual(Vector3.UnitX, Vector3.Zero.WithX(1));
        Assert.AreEqual(Vector3.UnitX, Vector3.UnitX.WithX(1));
        Assert.AreEqual(new Vector3(1, 1, 0), Vector3.UnitY.WithX(1));
        Assert.AreEqual(new Vector3(1, 0, 1), Vector3.UnitZ.WithX(1));
    }

    [TestMethod]
    public void WithY_ShouldReturnVectorWithNewY_GivenVector()
    {
        Assert.AreEqual(new Vector3(1, 0, 1), Vector3.One.WithY(0));
        Assert.AreEqual(Vector3.Zero, Vector3.Zero.WithY(0));
        Assert.AreEqual(Vector3.UnitX, Vector3.UnitX.WithY(0));
        Assert.AreEqual(Vector3.Zero, Vector3.UnitY.WithY(0));
        Assert.AreEqual(Vector3.UnitZ, Vector3.UnitZ.WithY(0));

        Assert.AreEqual(Vector3.One, Vector3.One.WithY(1));
        Assert.AreEqual(Vector3.UnitY, Vector3.Zero.WithY(1));
        Assert.AreEqual(new Vector3(1, 1, 0), Vector3.UnitX.WithY(1));
        Assert.AreEqual(Vector3.UnitY, Vector3.UnitY.WithY(1));
        Assert.AreEqual(new Vector3(0, 1, 1), Vector3.UnitZ.WithY(1));
    }

    [TestMethod]
    public void WithZ_ShouldReturnVectorWithNewZ_GivenVector()
    {
        Assert.AreEqual(new Vector3(1, 1, 0), Vector3.One.WithZ(0));
        Assert.AreEqual(Vector3.Zero, Vector3.Zero.WithZ(0));
        Assert.AreEqual(Vector3.UnitX, Vector3.UnitX.WithZ(0));
        Assert.AreEqual(Vector3.UnitY, Vector3.UnitY.WithZ(0));
        Assert.AreEqual(Vector3.Zero, Vector3.UnitZ.WithZ(0));

        Assert.AreEqual(Vector3.One, Vector3.One.WithZ(1));
        Assert.AreEqual(Vector3.UnitZ, Vector3.Zero.WithZ(1));
        Assert.AreEqual(new Vector3(1, 0, 1), Vector3.UnitX.WithZ(1));
        Assert.AreEqual(new Vector3(0, 1, 1), Vector3.UnitY.WithZ(1));
        Assert.AreEqual(Vector3.UnitZ, Vector3.UnitZ.WithZ(1));
    }
}
