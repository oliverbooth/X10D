using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestClass]
public class Vector4Tests
{
    [TestMethod]
    public void WithW_ShouldReturnVectorWithNewW_GivenVector()
    {
        Assert.AreEqual(new Vector4(1, 1, 1, 0), Vector4.One.WithW(0));
        Assert.AreEqual(Vector4.Zero, Vector4.Zero.WithW(0));
        Assert.AreEqual(Vector4.Zero, Vector4.UnitW.WithW(0));
        Assert.AreEqual(Vector4.UnitX, Vector4.UnitX.WithW(0));
        Assert.AreEqual(Vector4.UnitY, Vector4.UnitY.WithW(0));
        Assert.AreEqual(Vector4.UnitZ, Vector4.UnitZ.WithW(0));

        Assert.AreEqual(Vector4.One, Vector4.One.WithW(1));
        Assert.AreEqual(Vector4.UnitW, Vector4.Zero.WithW(1));
        Assert.AreEqual(Vector4.UnitW, Vector4.UnitW.WithW(1));
        Assert.AreEqual(new Vector4(1, 0, 0, 1), Vector4.UnitX.WithW(1));
        Assert.AreEqual(new Vector4(0, 1, 0, 1), Vector4.UnitY.WithW(1));
        Assert.AreEqual(new Vector4(0, 0, 1, 1), Vector4.UnitZ.WithW(1));
    }

    [TestMethod]
    public void WithX_ShouldReturnVectorWithNewX_GivenVector()
    {
        Assert.AreEqual(new Vector4(0, 1, 1, 1), Vector4.One.WithX(0));
        Assert.AreEqual(Vector4.Zero, Vector4.Zero.WithX(0));
        Assert.AreEqual(Vector4.UnitW, Vector4.UnitW.WithX(0));
        Assert.AreEqual(Vector4.Zero, Vector4.UnitX.WithX(0));
        Assert.AreEqual(Vector4.UnitY, Vector4.UnitY.WithX(0));
        Assert.AreEqual(Vector4.UnitZ, Vector4.UnitZ.WithX(0));

        Assert.AreEqual(Vector4.One, Vector4.One.WithX(1));
        Assert.AreEqual(Vector4.UnitX, Vector4.Zero.WithX(1));
        Assert.AreEqual(new Vector4(1, 0, 0, 1), Vector4.UnitW.WithX(1));
        Assert.AreEqual(Vector4.UnitX, Vector4.UnitX.WithX(1));
        Assert.AreEqual(new Vector4(1, 1, 0, 0), Vector4.UnitY.WithX(1));
        Assert.AreEqual(new Vector4(1, 0, 1, 0), Vector4.UnitZ.WithX(1));
    }

    [TestMethod]
    public void WithY_ShouldReturnVectorWithNewY_GivenVector()
    {
        Assert.AreEqual(new Vector4(1, 0, 1, 1), Vector4.One.WithY(0));
        Assert.AreEqual(Vector4.Zero, Vector4.Zero.WithY(0));
        Assert.AreEqual(Vector4.UnitW, Vector4.UnitW.WithY(0));
        Assert.AreEqual(Vector4.UnitX, Vector4.UnitX.WithY(0));
        Assert.AreEqual(Vector4.Zero, Vector4.UnitY.WithY(0));
        Assert.AreEqual(Vector4.UnitZ, Vector4.UnitZ.WithY(0));

        Assert.AreEqual(Vector4.One, Vector4.One.WithY(1));
        Assert.AreEqual(Vector4.UnitY, Vector4.Zero.WithY(1));
        Assert.AreEqual(new Vector4(0, 1, 0, 1), Vector4.UnitW.WithY(1));
        Assert.AreEqual(new Vector4(1, 1, 0, 0), Vector4.UnitX.WithY(1));
        Assert.AreEqual(Vector4.UnitY, Vector4.UnitY.WithY(1));
        Assert.AreEqual(new Vector4(0, 1, 1, 0), Vector4.UnitZ.WithY(1));
    }

    [TestMethod]
    public void WithZ_ShouldReturnVectorWithNewZ_GivenVector()
    {
        Assert.AreEqual(new Vector4(1, 1, 0, 1), Vector4.One.WithZ(0));
        Assert.AreEqual(Vector4.Zero, Vector4.Zero.WithZ(0));
        Assert.AreEqual(Vector4.UnitW, Vector4.UnitW.WithZ(0));
        Assert.AreEqual(Vector4.UnitX, Vector4.UnitX.WithZ(0));
        Assert.AreEqual(Vector4.UnitY, Vector4.UnitY.WithZ(0));
        Assert.AreEqual(Vector4.Zero, Vector4.UnitZ.WithZ(0));

        Assert.AreEqual(Vector4.One, Vector4.One.WithZ(1));
        Assert.AreEqual(Vector4.UnitZ, Vector4.Zero.WithZ(1));
        Assert.AreEqual(new Vector4(0, 0, 1, 1), Vector4.UnitW.WithZ(1));
        Assert.AreEqual(new Vector4(1, 0, 1, 0), Vector4.UnitX.WithZ(1));
        Assert.AreEqual(new Vector4(0, 1, 1, 0), Vector4.UnitY.WithZ(1));
        Assert.AreEqual(Vector4.UnitZ, Vector4.UnitZ.WithZ(1));
    }
}
