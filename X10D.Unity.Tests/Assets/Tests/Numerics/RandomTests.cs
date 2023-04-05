#nullable enable

using System;
using NUnit.Framework;
using X10D.Unity.Numerics;

namespace X10D.Unity.Tests.Numerics
{
    public class RandomTests
    {
        [Test]
        public void NextUnitVector2_ShouldReturnVector_WithMagnitude1()
        {
            var random = new Random();
            var vector = random.NextUnitVector2();
            Assert.AreEqual(1, vector.magnitude, 1e-6);
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
            Assert.AreEqual(1, vector.magnitude, 1e-6);
        }

        [Test]
        public void NextUnitVector3_ShouldThrow_GivenNullRandom()
        {
            Random random = null!;
            Assert.Throws<ArgumentNullException>(() => random.NextUnitVector3());
        }

        [Test]
        public void NextRotation_ShouldThrow_GivenNullRandom()
        {
            Random random = null!;
            Assert.Throws<ArgumentNullException>(() => random.NextRotation());
        }

        [Test]
        public void NextRotationUniform_ShouldThrow_GivenNullRandom()
        {
            Random random = null!;
            Assert.Throws<ArgumentNullException>(() => random.NextRotationUniform());
        }
    }
}
