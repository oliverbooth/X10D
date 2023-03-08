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
}
