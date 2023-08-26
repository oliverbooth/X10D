using System.Numerics;
using NUnit.Framework;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestFixture]
internal class Vector3Tests
{
    [Test]
    public void Deconstruct_ShouldReturnCorrectValues()
    {
        var vector = new Vector3(1, 2, 3);
        (float x, float y, float z) = vector;

        Assert.Multiple(() =>
        {
            Assert.That(x, Is.EqualTo(1));
            Assert.That(y, Is.EqualTo(2));
            Assert.That(z, Is.EqualTo(3));
        });
    }

    [Test]
    public void Round_ShouldRoundToNearestInteger_GivenNoParameters()
    {
        var vector = new Vector3(1.5f, 2.6f, -5.2f);
        var rounded = vector.Round();

        Assert.Multiple(() =>
        {
            Assert.That(rounded.X, Is.EqualTo(2));
            Assert.That(rounded.Y, Is.EqualTo(3));
            Assert.That(rounded.Z, Is.EqualTo(-5));
        });
    }

    [Test]
    public void Round_ShouldRoundToNearest10_GivenPrecision10()
    {
        var vector = new Vector3(1.5f, 25.2f, -12.5f);
        var rounded = vector.Round(10);

        Assert.Multiple(() =>
        {
            Assert.That(rounded.X, Is.Zero);
            Assert.That(rounded.Y, Is.EqualTo(30));
            Assert.That(rounded.Z, Is.EqualTo(-10));
        });
    }

    [Test]
    public void WithX_ShouldReturnVectorWithNewX_GivenVector()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Vector3.One.WithX(0), Is.EqualTo(new Vector3(0, 1, 1)));
            Assert.That(Vector3.Zero.WithX(0), Is.EqualTo(Vector3.Zero));
            Assert.That(Vector3.UnitX.WithX(0), Is.EqualTo(Vector3.Zero));
            Assert.That(Vector3.UnitY.WithX(0), Is.EqualTo(Vector3.UnitY));
            Assert.That(Vector3.UnitZ.WithX(0), Is.EqualTo(Vector3.UnitZ));

            Assert.That(Vector3.One.WithX(1), Is.EqualTo(Vector3.One));
            Assert.That(Vector3.Zero.WithX(1), Is.EqualTo(Vector3.UnitX));
            Assert.That(Vector3.UnitX.WithX(1), Is.EqualTo(Vector3.UnitX));
            Assert.That(Vector3.UnitY.WithX(1), Is.EqualTo(new Vector3(1, 1, 0)));
            Assert.That(Vector3.UnitZ.WithX(1), Is.EqualTo(new Vector3(1, 0, 1)));
        });
    }

    [Test]
    public void WithY_ShouldReturnVectorWithNewY_GivenVector()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Vector3.One.WithY(0), Is.EqualTo(new Vector3(1, 0, 1)));
            Assert.That(Vector3.Zero.WithY(0), Is.EqualTo(Vector3.Zero));
            Assert.That(Vector3.UnitX.WithY(0), Is.EqualTo(Vector3.UnitX));
            Assert.That(Vector3.UnitY.WithY(0), Is.EqualTo(Vector3.Zero));
            Assert.That(Vector3.UnitZ.WithY(0), Is.EqualTo(Vector3.UnitZ));

            Assert.That(Vector3.One.WithY(1), Is.EqualTo(Vector3.One));
            Assert.That(Vector3.Zero.WithY(1), Is.EqualTo(Vector3.UnitY));
            Assert.That(Vector3.UnitX.WithY(1), Is.EqualTo(new Vector3(1, 1, 0)));
            Assert.That(Vector3.UnitY.WithY(1), Is.EqualTo(Vector3.UnitY));
            Assert.That(Vector3.UnitZ.WithY(1), Is.EqualTo(new Vector3(0, 1, 1)));
        });
    }

    [Test]
    public void WithZ_ShouldReturnVectorWithNewZ_GivenVector()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Vector3.One.WithZ(0), Is.EqualTo(new Vector3(1, 1, 0)));
            Assert.That(Vector3.Zero.WithZ(0), Is.EqualTo(Vector3.Zero));
            Assert.That(Vector3.UnitX.WithZ(0), Is.EqualTo(Vector3.UnitX));
            Assert.That(Vector3.UnitY.WithZ(0), Is.EqualTo(Vector3.UnitY));
            Assert.That(Vector3.UnitZ.WithZ(0), Is.EqualTo(Vector3.Zero));

            Assert.That(Vector3.One.WithZ(1), Is.EqualTo(Vector3.One));
            Assert.That(Vector3.Zero.WithZ(1), Is.EqualTo(Vector3.UnitZ));
            Assert.That(Vector3.UnitX.WithZ(1), Is.EqualTo(new Vector3(1, 0, 1)));
            Assert.That(Vector3.UnitY.WithZ(1), Is.EqualTo(new Vector3(0, 1, 1)));
            Assert.That(Vector3.UnitZ.WithZ(1), Is.EqualTo(Vector3.UnitZ));
        });
    }
}
