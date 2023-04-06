using NUnit.Framework;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestFixture]
public class RandomTests
{
    [Test]
    public void NextUnitVector2_ShouldReturnVector_WithMagnitude1()
    {
        var random = new Random();
        var vector = random.NextUnitVector2();
        Assert.That(vector.Length(), Is.EqualTo(1).Within(1e-6));
    }

    [Test]
    public void NextUnitVector2_ShouldThrow_GivenNullRandom()
    {
        Random random = null!;
        Assert.Throws<ArgumentNullException>(() => random.NextUnitVector2());
    }

    [Test]
    public void NextUnitVector3_ShouldReturnVector_WithMagnitude1()
    {
        var random = new Random();
        var vector = random.NextUnitVector3();
        Assert.That(vector.Length(), Is.EqualTo(1).Within(1e-6));
    }

    [Test]
    public void NextUnitVector3_ShouldThrow_GivenNullRandom()
    {
        Random random = null!;
        Assert.Throws<ArgumentNullException>(() => random.NextUnitVector3());
    }

    [Test]
    public void NextRotation_ShouldReturnQuaternion_WithMagnitude1()
    {
        var random = new Random();
        var rotation = random.NextRotation();
        Assert.That(rotation.Length(), Is.EqualTo(1).Within(1e-6));
    }

    [Test]
    public void NextRotation_ShouldThrow_GivenNullRandom()
    {
        Random random = null!;
        Assert.Throws<ArgumentNullException>(() => random.NextRotation());
    }

    [Test]
    public void NextRotationUniform_ShouldReturnQuaternion_WithMagnitude1()
    {
        var random = new Random();
        var rotation = random.NextRotationUniform();
        Assert.That(rotation.Length(), Is.EqualTo(1).Within(1e-6));
    }

    [Test]
    public void NextRotationUniform_ShouldThrow_GivenNullRandom()
    {
        Random random = null!;
        Assert.Throws<ArgumentNullException>(() => random.NextRotationUniform());
    }
}
