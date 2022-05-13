using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestClass]
public class Vector2Tests
{
    [TestMethod]
    public void WithX_ShouldReturnVectorWithNewX_GivenVector()
    {
        Assert.AreEqual(Vector2.UnitY, Vector2.One.WithX(0));
        Assert.AreEqual(Vector2.Zero, Vector2.Zero.WithX(0));
        Assert.AreEqual(Vector2.Zero, Vector2.UnitX.WithX(0));
        Assert.AreEqual(Vector2.UnitY, Vector2.UnitY.WithX(0));

        Assert.AreEqual(Vector2.One, Vector2.One.WithX(1));
        Assert.AreEqual(Vector2.UnitX, Vector2.Zero.WithX(1));
        Assert.AreEqual(Vector2.UnitX, Vector2.UnitX.WithX(1));
        Assert.AreEqual(Vector2.One, Vector2.UnitY.WithX(1));
    }

    [TestMethod]
    public void WithY_ShouldReturnVectorWithNewY_GivenVector()
    {
        Assert.AreEqual(Vector2.UnitX, Vector2.One.WithY(0));
        Assert.AreEqual(Vector2.Zero, Vector2.Zero.WithY(0));
        Assert.AreEqual(Vector2.UnitX, Vector2.UnitX.WithY(0));
        Assert.AreEqual(Vector2.Zero, Vector2.UnitY.WithY(0));

        Assert.AreEqual(Vector2.One, Vector2.One.WithY(1));
        Assert.AreEqual(Vector2.UnitY, Vector2.Zero.WithY(1));
        Assert.AreEqual(Vector2.One, Vector2.UnitX.WithY(1));
        Assert.AreEqual(Vector2.UnitY, Vector2.UnitY.WithY(1));
    }
}
