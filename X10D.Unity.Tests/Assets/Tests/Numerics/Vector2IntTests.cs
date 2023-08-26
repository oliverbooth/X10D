using NUnit.Framework;
using UnityEngine;
using X10D.Unity.Numerics;
using Random = System.Random;

namespace X10D.Unity.Tests.Numerics
{
    public class Vector2IntTests
    {
        [Test]
        public void Deconstruct_ShouldReturnCorrectValues()
        {
            var vector = new Vector2Int(1, 2);
            (int x, int y) = vector;

            Assert.That(x, Is.EqualTo(1));
            Assert.That(y, Is.EqualTo(2));
        }

        [Test]
        public void ToSystemPoint_ShouldReturnPoint_WithEquivalentMembers()
        {
            var random = new Random();
            int x = random.Next();
            int y = random.Next();

            var vector = new Vector2Int(x, y);
            var point = vector.ToSystemPoint();

            Assert.That(point.X, Is.EqualTo(vector.x));
            Assert.That(point.Y, Is.EqualTo(vector.y));
        }

        [Test]
        public void ToSystemSize_ShouldReturnSize_WithEquivalentMembers()
        {
            var random = new Random();
            int x = random.Next();
            int y = random.Next();

            var vector = new Vector2Int(x, y);
            var point = vector.ToSystemSize();

            Assert.That(point.Width, Is.EqualTo(vector.x));
            Assert.That(point.Height, Is.EqualTo(vector.y));
        }

        [Test]
        public void WithX_ShouldReturnVectorWithNewX_GivenVector()
        {
            Assert.That(Vector2Int.one.WithX(0), Is.EqualTo(Vector2Int.up));
            Assert.That(Vector2Int.zero.WithX(0), Is.EqualTo(Vector2Int.zero));
            Assert.That(Vector2Int.right.WithX(0), Is.EqualTo(Vector2Int.zero));
            Assert.That(Vector2Int.up.WithX(0), Is.EqualTo(Vector2Int.up));

            Assert.That(Vector2Int.one.WithX(1), Is.EqualTo(Vector2Int.one));
            Assert.That(Vector2Int.zero.WithX(1), Is.EqualTo(Vector2Int.right));
            Assert.That(Vector2Int.right.WithX(1), Is.EqualTo(Vector2Int.right));
            Assert.That(Vector2Int.up.WithX(1), Is.EqualTo(Vector2Int.one));
        }

        [Test]
        public void WithY_ShouldReturnVectorWithNewY_GivenVector()
        {
            Assert.That(Vector2Int.one.WithY(0), Is.EqualTo(Vector2Int.right));
            Assert.That(Vector2Int.zero.WithY(0), Is.EqualTo(Vector2Int.zero));
            Assert.That(Vector2Int.right.WithY(0), Is.EqualTo(Vector2Int.right));
            Assert.That(Vector2Int.up.WithY(0), Is.EqualTo(Vector2Int.zero));

            Assert.That(Vector2Int.one.WithY(1), Is.EqualTo(Vector2Int.one));
            Assert.That(Vector2Int.zero.WithY(1), Is.EqualTo(Vector2Int.up));
            Assert.That(Vector2Int.right.WithY(1), Is.EqualTo(Vector2Int.one));
            Assert.That(Vector2Int.up.WithY(1), Is.EqualTo(Vector2Int.up));
        }
    }
}
