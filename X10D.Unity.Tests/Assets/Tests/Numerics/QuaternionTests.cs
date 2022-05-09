using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using X10D.Core;
using X10D.Unity.Numerics;
using Random = System.Random;

namespace X10D.Unity.Tests.Numerics
{
    public class QuaternionTests
    {
        [UnityTest]
        public IEnumerator ToSystemQuaternion_ShouldReturnQuaternion_WithEqualComponents()
        {
            var random = new Random();
            float x = random.NextSingle();
            float y = random.NextSingle();
            float z = random.NextSingle();
            float w = random.NextSingle();

            var quaternion = new Quaternion(x, y, z, w);
            var systemQuaternion = quaternion.ToSystemQuaternion();

            Assert.AreEqual(quaternion.x, systemQuaternion.X, 1e-6f);
            Assert.AreEqual(quaternion.y, systemQuaternion.Y, 1e-6f);
            Assert.AreEqual(quaternion.z, systemQuaternion.Z, 1e-6f);
            Assert.AreEqual(quaternion.w, systemQuaternion.W, 1e-6f);

            yield break;
        }

        [UnityTest]
        public IEnumerator ToUnityQuaternion_ShouldReturnQuaternion_WithEqualComponents()
        {
            var random = new Random();
            float x = random.NextSingle();
            float y = random.NextSingle();
            float z = random.NextSingle();
            float w = random.NextSingle();

            var quaternion = new System.Numerics.Quaternion(x, y, z, w);
            var unityQuaternion = quaternion.ToUnityQuaternion();

            Assert.AreEqual(quaternion.X, unityQuaternion.x, 1e-6f);
            Assert.AreEqual(quaternion.Y, unityQuaternion.y, 1e-6f);
            Assert.AreEqual(quaternion.Z, unityQuaternion.z, 1e-6f);
            Assert.AreEqual(quaternion.W, unityQuaternion.w, 1e-6f);

            yield break;
        }
    }
}
