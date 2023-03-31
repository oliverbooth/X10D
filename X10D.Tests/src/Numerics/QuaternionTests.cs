using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestClass]
public class QuaternionTests
{
    [TestMethod]
    public void ToAxisAngle_ShouldGiveAngle180VectorZero_GivenQuaternion()
    {
        Vector3 axis = Vector3.UnitY;
        const float angle = MathF.PI;
        var quaternion = Quaternion.CreateFromAxisAngle(axis, angle);

        (Vector3 Axis, float Angle) axisAngle = quaternion.ToAxisAngle();
        Assert.AreEqual(axis, axisAngle.Axis);
        Assert.AreEqual(angle, axisAngle.Angle);
    }

    [TestMethod]
    public void ToVector3_ShouldReturnZeroVector_GivenIdentityQuaternion()
    {
        Assert.AreEqual(Vector3.Zero, Quaternion.Identity.ToVector3());
    }

    [TestMethod]
    public void ToVector3_ShouldReturnVector_0_PI_0_GivenQuaternionCreatedFrom_PI_0_0()
    {
        Quaternion quaternion = Quaternion.CreateFromYawPitchRoll(MathF.PI, 0, 0);
        var expected = new Vector3(0, MathF.PI, 0);
        var actual = quaternion.ToVector3();
        
        Assert.AreEqual(expected.X, actual.X, 1e-5f);
        Assert.AreEqual(expected.Y, actual.Y, 1e-5f);
        Assert.AreEqual(expected.Z, actual.Z, 1e-5f);
    }
}
