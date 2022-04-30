using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestClass]
public class RandomTests
{
    [TestMethod]
    public void NextUnitVector2_ShouldReturnVector_WithMagnitude1()
    {
        var random = new Random();
        var vector = random.NextUnitVector2();
        Assert.AreEqual(1, vector.Length(), 1e-6);
    }

    [TestMethod]
    public void NextUnitVector2_ShouldThrow_GivenNullRandom()
    {
        Random? random = null;
        Assert.ThrowsException<ArgumentNullException>(() => random!.NextUnitVector2());
    }

    [TestMethod]
    public void NextUnitVector3_ShouldReturnVector_WithMagnitude1()
    {
        var random = new Random();
        var vector = random.NextUnitVector3();
        Assert.AreEqual(1, vector.Length(), 1e-6);
    }

    [TestMethod]
    public void NextUnitVector3_ShouldThrow_GivenNullRandom()
    {
        Random? random = null;
        Assert.ThrowsException<ArgumentNullException>(() => random!.NextUnitVector3());
    }

    [TestMethod]
    public void NextRotation_ShouldReturnQuaternion_WithMagnitude1()
    {
        var random = new Random();
        var rotation = random.NextRotation();
        Assert.AreEqual(1, rotation.Length(), 1e-6);
    }

    [TestMethod]
    public void NextRotation_ShouldThrow_GivenNullRandom()
    {
        Random? random = null;
        Assert.ThrowsException<ArgumentNullException>(() => random!.NextRotation());
    }

    [TestMethod]
    public void NextRotationUniform_ShouldReturnQuaternion_WithMagnitude1()
    {
        var random = new Random();
        var rotation = random.NextRotationUniform();
        Assert.AreEqual(1, rotation.Length(), 1e-6);
    }

    [TestMethod]
    public void NextRotationUniform_ShouldThrow_GivenNullRandom()
    {
        Random? random = null;
        Assert.ThrowsException<ArgumentNullException>(() => random!.NextRotationUniform());
    }
}
