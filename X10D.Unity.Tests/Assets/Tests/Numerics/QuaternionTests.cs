using NUnit.Framework;
using UnityEngine;
using X10D.Core;
using X10D.Unity.Numerics;
using Random = System.Random;

namespace X10D.Unity.Tests.Numerics
{
    public class QuaternionTests
    {
        [Test]
        public void ToSystemQuaternion_ShouldReturnQuaternion_WithEqualComponents()
        {
            var random = new Random();
            float x = random.NextSingle();
            float y = random.NextSingle();
            float z = random.NextSingle();
            float w = random.NextSingle();

            var quaternion = new Quaternion(x, y, z, w);
            var systemQuaternion = quaternion.ToSystemQuaternion();

            Assert.That(systemQuaternion.X, Is.EqualTo(quaternion.x).Within(1e-6f));
            Assert.That(systemQuaternion.Y, Is.EqualTo(quaternion.y).Within(1e-6f));
            Assert.That(systemQuaternion.Z, Is.EqualTo(quaternion.z).Within(1e-6f));
            Assert.That(systemQuaternion.W, Is.EqualTo(quaternion.w).Within(1e-6f));
        }

        [Test]
        public void ToUnityQuaternion_ShouldReturnQuaternion_WithEqualComponents()
        {
            var random = new Random();
            float x = random.NextSingle();
            float y = random.NextSingle();
            float z = random.NextSingle();
            float w = random.NextSingle();

            var quaternion = new System.Numerics.Quaternion(x, y, z, w);
            var unityQuaternion = quaternion.ToUnityQuaternion();

            Assert.That(unityQuaternion.x, Is.EqualTo(quaternion.X).Within(1e-6f));
            Assert.That(unityQuaternion.y, Is.EqualTo(quaternion.Y).Within(1e-6f));
            Assert.That(unityQuaternion.z, Is.EqualTo(quaternion.Z).Within(1e-6f));
            Assert.That(unityQuaternion.w, Is.EqualTo(quaternion.W).Within(1e-6f));
        }
    }
}
