using System.Numerics;
using NUnit.Framework;
using X10D.Numerics;

namespace X10D.Tests.Numerics;

[TestFixture]
internal class QuaternionTests
{
    [Test]
    public void ToAxisAngle_ShouldGiveAngle180VectorZero_GivenQuaternion()
    {
        Vector3 axis = Vector3.UnitY;
        const float angle = MathF.PI;
        var quaternion = Quaternion.CreateFromAxisAngle(axis, angle);

        (Vector3 Axis, float Angle) axisAngle = quaternion.ToAxisAngle();
        Assert.Multiple(() =>
        {
            Assert.That(axisAngle.Axis, Is.EqualTo(axis));
            Assert.That(axisAngle.Angle, Is.EqualTo(angle));
        });
    }

    [Test]
    public void ToVector3_ShouldReturnZeroVector_GivenIdentityQuaternion()
    {
        Assert.That(Quaternion.Identity.ToVector3(), Is.EqualTo(Vector3.Zero));
    }

    [Test]
    public void ToVector3_ShouldReturnVector_0_PI_0_GivenQuaternionCreatedFrom_PI_0_0()
    {
        Quaternion quaternion = Quaternion.CreateFromYawPitchRoll(MathF.PI, 0, 0);
        var expected = new Vector3(0, MathF.PI, 0);
        var actual = quaternion.ToVector3();

        Assert.Multiple(() =>
        {
            Assert.That(actual.X, Is.EqualTo(expected.X).Within(1e-5f));
            Assert.That(actual.Y, Is.EqualTo(expected.Y).Within(1e-5f));
            Assert.That(actual.Z, Is.EqualTo(expected.Z).Within(1e-5f));
        });
    }
}
