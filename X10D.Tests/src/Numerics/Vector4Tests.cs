using System.Numerics;
using NUnit.Framework;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestFixture]
internal class Vector4Tests
{
    [Test]
    public void Deconstruct_ShouldReturnCorrectValues()
    {
        var vector = new Vector4(1, 2, 3, 4);
        (float x, float y, float z, float w) = vector;

        Assert.Multiple(() =>
        {
            Assert.That(x, Is.EqualTo(1));
            Assert.That(y, Is.EqualTo(2));
            Assert.That(z, Is.EqualTo(3));
            Assert.That(w, Is.EqualTo(4));
        });
    }

    [Test]
    public void Round_ShouldRoundToNearestInteger_GivenNoParameters()
    {
        var vector = new Vector4(1.5f, 2.6f, -5.2f, 0.3f);
        var rounded = vector.Round();

        Assert.Multiple(() =>
        {
            Assert.That(rounded.X, Is.EqualTo(2));
            Assert.That(rounded.Y, Is.EqualTo(3));
            Assert.That(rounded.Z, Is.EqualTo(-5));
            Assert.That(rounded.W, Is.Zero);
        });
    }

    [Test]
    public void Round_ShouldRoundToNearest10_GivenPrecision10()
    {
        var vector = new Vector4(1.5f, 25.2f, -12.5f, 101.2f);
        var rounded = vector.Round(10);

        Assert.Multiple(() =>
        {
            Assert.That(rounded.X, Is.Zero);
            Assert.That(rounded.Y, Is.EqualTo(30));
            Assert.That(rounded.Z, Is.EqualTo(-10));
            Assert.That(rounded.W, Is.EqualTo(100));
        });
    }

    [Test]
    public void WithW_ShouldReturnVectorWithNewW_GivenVector()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Vector4.One.WithW(0), Is.EqualTo(new Vector4(1, 1, 1, 0)));
            Assert.That(Vector4.Zero.WithW(0), Is.EqualTo(Vector4.Zero));
            Assert.That(Vector4.UnitW.WithW(0), Is.EqualTo(Vector4.Zero));
            Assert.That(Vector4.UnitX.WithW(0), Is.EqualTo(Vector4.UnitX));
            Assert.That(Vector4.UnitY.WithW(0), Is.EqualTo(Vector4.UnitY));
            Assert.That(Vector4.UnitZ.WithW(0), Is.EqualTo(Vector4.UnitZ));

            Assert.That(Vector4.One.WithW(1), Is.EqualTo(Vector4.One));
            Assert.That(Vector4.Zero.WithW(1), Is.EqualTo(Vector4.UnitW));
            Assert.That(Vector4.UnitW.WithW(1), Is.EqualTo(Vector4.UnitW));
            Assert.That(Vector4.UnitX.WithW(1), Is.EqualTo(new Vector4(1, 0, 0, 1)));
            Assert.That(Vector4.UnitY.WithW(1), Is.EqualTo(new Vector4(0, 1, 0, 1)));
            Assert.That(Vector4.UnitZ.WithW(1), Is.EqualTo(new Vector4(0, 0, 1, 1)));
        });
    }

    [Test]
    public void WithX_ShouldReturnVectorWithNewX_GivenVector()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Vector4.One.WithX(0), Is.EqualTo(new Vector4(0, 1, 1, 1)));
            Assert.That(Vector4.Zero.WithX(0), Is.EqualTo(Vector4.Zero));
            Assert.That(Vector4.UnitW.WithX(0), Is.EqualTo(Vector4.UnitW));
            Assert.That(Vector4.UnitX.WithX(0), Is.EqualTo(Vector4.Zero));
            Assert.That(Vector4.UnitY.WithX(0), Is.EqualTo(Vector4.UnitY));
            Assert.That(Vector4.UnitZ.WithX(0), Is.EqualTo(Vector4.UnitZ));

            Assert.That(Vector4.One.WithX(1), Is.EqualTo(Vector4.One));
            Assert.That(Vector4.Zero.WithX(1), Is.EqualTo(Vector4.UnitX));
            Assert.That(Vector4.UnitW.WithX(1), Is.EqualTo(new Vector4(1, 0, 0, 1)));
            Assert.That(Vector4.UnitX.WithX(1), Is.EqualTo(Vector4.UnitX));
            Assert.That(Vector4.UnitY.WithX(1), Is.EqualTo(new Vector4(1, 1, 0, 0)));
            Assert.That(Vector4.UnitZ.WithX(1), Is.EqualTo(new Vector4(1, 0, 1, 0)));
        });
    }

    [Test]
    public void WithY_ShouldReturnVectorWithNewY_GivenVector()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Vector4.One.WithY(0), Is.EqualTo(new Vector4(1, 0, 1, 1)));
            Assert.That(Vector4.Zero.WithY(0), Is.EqualTo(Vector4.Zero));
            Assert.That(Vector4.UnitW.WithY(0), Is.EqualTo(Vector4.UnitW));
            Assert.That(Vector4.UnitX.WithY(0), Is.EqualTo(Vector4.UnitX));
            Assert.That(Vector4.UnitY.WithY(0), Is.EqualTo(Vector4.Zero));
            Assert.That(Vector4.UnitZ.WithY(0), Is.EqualTo(Vector4.UnitZ));

            Assert.That(Vector4.One.WithY(1), Is.EqualTo(Vector4.One));
            Assert.That(Vector4.Zero.WithY(1), Is.EqualTo(Vector4.UnitY));
            Assert.That(Vector4.UnitW.WithY(1), Is.EqualTo(new Vector4(0, 1, 0, 1)));
            Assert.That(Vector4.UnitX.WithY(1), Is.EqualTo(new Vector4(1, 1, 0, 0)));
            Assert.That(Vector4.UnitY.WithY(1), Is.EqualTo(Vector4.UnitY));
            Assert.That(Vector4.UnitZ.WithY(1), Is.EqualTo(new Vector4(0, 1, 1, 0)));
        });
    }

    [Test]
    public void WithZ_ShouldReturnVectorWithNewZ_GivenVector()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Vector4.One.WithZ(0), Is.EqualTo(new Vector4(1, 1, 0, 1)));
            Assert.That(Vector4.Zero.WithZ(0), Is.EqualTo(Vector4.Zero));
            Assert.That(Vector4.UnitW.WithZ(0), Is.EqualTo(Vector4.UnitW));
            Assert.That(Vector4.UnitX.WithZ(0), Is.EqualTo(Vector4.UnitX));
            Assert.That(Vector4.UnitY.WithZ(0), Is.EqualTo(Vector4.UnitY));
            Assert.That(Vector4.UnitZ.WithZ(0), Is.EqualTo(Vector4.Zero));

            Assert.That(Vector4.One.WithZ(1), Is.EqualTo(Vector4.One));
            Assert.That(Vector4.Zero.WithZ(1), Is.EqualTo(Vector4.UnitZ));
            Assert.That(Vector4.UnitW.WithZ(1), Is.EqualTo(new Vector4(0, 0, 1, 1)));
            Assert.That(Vector4.UnitX.WithZ(1), Is.EqualTo(new Vector4(1, 0, 1, 0)));
            Assert.That(Vector4.UnitY.WithZ(1), Is.EqualTo(new Vector4(0, 1, 1, 0)));
            Assert.That(Vector4.UnitZ.WithZ(1), Is.EqualTo(Vector4.UnitZ));
        });
    }
}
