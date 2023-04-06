using NUnit.Framework;
using UnityEngine;
using X10D.Unity.Numerics;

namespace X10D.Unity.Tests.Numerics
{
    public class Vector3IntTests
    {
        [Test]
        public void Deconstruct_ShouldReturnCorrectValues()
        {
            var vector = new Vector3Int(1, 2, 3);
            (float x, float y, float z) = vector;

            Assert.That(x, Is.EqualTo(1));
            Assert.That(y, Is.EqualTo(2));
            Assert.That(z, Is.EqualTo(3));
        }

        [Test]
        public void WithX_ShouldReturnVectorWithNewX_GivenVector()
        {
            Assert.That(Vector3Int.one.WithX(0), Is.EqualTo(new Vector3Int(0, 1, 1)));
            Assert.That(Vector3Int.zero.WithX(0), Is.EqualTo(Vector3Int.zero));
            Assert.That(Vector3Int.right.WithX(0), Is.EqualTo(Vector3Int.zero));
            Assert.That(Vector3Int.up.WithX(0), Is.EqualTo(Vector3Int.up));
            Assert.That(Vector3Int.forward.WithX(0), Is.EqualTo(Vector3Int.forward));

            Assert.That(Vector3Int.one.WithX(1), Is.EqualTo(Vector3Int.one));
            Assert.That(Vector3Int.zero.WithX(1), Is.EqualTo(Vector3Int.right));
            Assert.That(Vector3Int.right.WithX(1), Is.EqualTo(Vector3Int.right));
            Assert.That(Vector3Int.up.WithX(1), Is.EqualTo(new Vector3Int(1, 1, 0)));
            Assert.That(Vector3Int.forward.WithX(1), Is.EqualTo(new Vector3Int(1, 0, 1)));
        }

        [Test]
        public void WithY_ShouldReturnVectorWithNewY_GivenVector()
        {
            Assert.That(Vector3Int.one.WithY(0), Is.EqualTo(new Vector3Int(1, 0, 1)));
            Assert.That(Vector3Int.zero.WithY(0), Is.EqualTo(Vector3Int.zero));
            Assert.That(Vector3Int.right.WithY(0), Is.EqualTo(Vector3Int.right));
            Assert.That(Vector3Int.up.WithY(0), Is.EqualTo(Vector3Int.zero));
            Assert.That(Vector3Int.forward.WithY(0), Is.EqualTo(Vector3Int.forward));

            Assert.That(Vector3Int.one.WithY(1), Is.EqualTo(Vector3Int.one));
            Assert.That(Vector3Int.zero.WithY(1), Is.EqualTo(Vector3Int.up));
            Assert.That(Vector3Int.right.WithY(1), Is.EqualTo(new Vector3Int(1, 1, 0)));
            Assert.That(Vector3Int.up.WithY(1), Is.EqualTo(Vector3Int.up));
            Assert.That(Vector3Int.forward.WithY(1), Is.EqualTo(new Vector3Int(0, 1, 1)));
            ;
        }

        [Test]
        public void WithZ_ShouldReturnVectorWithNewZ_GivenVector()
        {
            Assert.That(Vector3Int.one.WithZ(0), Is.EqualTo(new Vector3Int(1, 1, 0)));
            Assert.That(Vector3Int.zero.WithZ(0), Is.EqualTo(Vector3Int.zero));
            Assert.That(Vector3Int.right.WithZ(0), Is.EqualTo(Vector3Int.right));
            Assert.That(Vector3Int.up.WithZ(0), Is.EqualTo(Vector3Int.up));
            Assert.That(Vector3Int.forward.WithZ(0), Is.EqualTo(Vector3Int.zero));

            Assert.That(Vector3Int.one.WithZ(1), Is.EqualTo(Vector3Int.one));
            Assert.That(Vector3Int.zero.WithZ(1), Is.EqualTo(Vector3Int.forward));
            Assert.That(Vector3Int.right.WithZ(1), Is.EqualTo(new Vector3Int(1, 0, 1)));
            Assert.That(Vector3Int.up.WithZ(1), Is.EqualTo(new Vector3Int(0, 1, 1)));
            Assert.That(Vector3Int.forward.WithZ(1), Is.EqualTo(Vector3Int.forward));
        }
    }
}
