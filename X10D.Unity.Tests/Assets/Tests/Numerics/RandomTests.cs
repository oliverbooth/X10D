#nullable enable

using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using X10D.Unity.Numerics;

namespace Tests.Numerics
{
    public class RandomTests
    {
        [UnityTest]
        public IEnumerator NextUnitVector2_ShouldReturnVector_WithMagnitude1()
        {
            var random = new Random();
            var vector = random.NextUnitVector2();
            Assert.AreEqual(1, vector.magnitude, 1e-6);
            yield break;
        }

        [UnityTest]
        public IEnumerator NextUnitVector2_ShouldThrow_GivenNullRandom()
        {
            Random? random = null;
            Assert.Throws<ArgumentNullException>(() => random!.NextUnitVector2());
            yield break;
        }

        [UnityTest]
        public IEnumerator NextUnitVector3_ShouldReturnVector_WithMagnitude1()
        {
            var random = new Random();
            var vector = random.NextUnitVector3();
            Assert.AreEqual(1, vector.magnitude, 1e-6);
            yield break;
        }

        [UnityTest]
        public IEnumerator NextUnitVector3_ShouldThrow_GivenNullRandom()
        {
            Random? random = null;
            Assert.Throws<ArgumentNullException>(() => random!.NextUnitVector3());
            yield break;
        }

        [UnityTest]
        public IEnumerator NextRotation_ShouldThrow_GivenNullRandom()
        {
            Random random = null;
            Assert.Throws<ArgumentNullException>(() => random!.NextRotation());
            yield break;
        }

        [UnityTest]
        public IEnumerator NextRotationUniform_ShouldThrow_GivenNullRandom()
        {
            Random? random = null;
            Assert.Throws<ArgumentNullException>(() => random!.NextRotationUniform());
            yield break;
        }
    }
}
