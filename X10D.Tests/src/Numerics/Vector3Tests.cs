﻿using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestClass]
public class Vector3Tests
{
    [TestMethod]
    public void Deconstruct_ShouldReturnCorrectValues()
    {
        var vector = new Vector3(1, 2, 3);
        (float x, float y, float z) = vector;

        Assert.AreEqual(1, x);
        Assert.AreEqual(2, y);
        Assert.AreEqual(3, z);
    }

    [TestMethod]
    public void Round_ShouldRoundToNearestInteger_GivenNoParameters()
    {
        var vector = new Vector3(1.5f, 2.6f, -5.2f);
        var rounded = vector.Round();

        Assert.AreEqual(2, rounded.X);
        Assert.AreEqual(3, rounded.Y);
        Assert.AreEqual(-5, rounded.Z);
    }

    [TestMethod]
    public void Round_ShouldRoundToNearest10_GivenPrecision10()
    {
        var vector = new Vector3(1.5f, 25.2f, -12.5f);
        var rounded = vector.Round(10);

        Assert.AreEqual(0, rounded.X);
        Assert.AreEqual(30, rounded.Y);
        Assert.AreEqual(-10, rounded.Z);
    }

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