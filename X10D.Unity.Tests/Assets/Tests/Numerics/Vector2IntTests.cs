using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using X10D.Unity.Numerics;
using Random = System.Random;

namespace X10D.Unity.Tests.Numerics
{
    public class Vector2IntTests
    {
        [UnityTest]
        public IEnumerator Deconstruct_ShouldReturnCorrectValues()
        {
            var vector = new Vector2Int(1, 2);
            (int x, int y) = vector;

            Assert.AreEqual(1, x);
            Assert.AreEqual(2, y);

            yield break;
        }

        [UnityTest]
        public IEnumerator ToSystemPoint_ShouldReturnPoint_WithEquivalentMembers()
        {
            var random = new Random();
            int x = random.Next();
            int y = random.Next();

            var vector = new Vector2Int(x, y);
            var point = vector.ToSystemPoint();

            Assert.AreEqual(vector.x, point.X);
            Assert.AreEqual(vector.y, point.Y);

            yield break;
        }

        [UnityTest]
        public IEnumerator ToSystemSize_ShouldReturnSize_WithEquivalentMembers()
        {
            var random = new Random();
            int x = random.Next();
            int y = random.Next();

            var vector = new Vector2Int(x, y);
            var point = vector.ToSystemSize();

            Assert.AreEqual(vector.x, point.Width);
            Assert.AreEqual(vector.y, point.Height);

            yield break;
        }

        [UnityTest]
        public IEnumerator WithX_ShouldReturnVectorWithNewX_GivenVector()
        {
            Assert.AreEqual(Vector2Int.up, Vector2Int.one.WithX(0));
            Assert.AreEqual(Vector2Int.zero, Vector2Int.zero.WithX(0));
            Assert.AreEqual(Vector2Int.zero, Vector2Int.right.WithX(0));
            Assert.AreEqual(Vector2Int.up, Vector2Int.up.WithX(0));

            Assert.AreEqual(Vector2Int.one, Vector2Int.one.WithX(1));
            Assert.AreEqual(Vector2Int.right, Vector2Int.zero.WithX(1));
            Assert.AreEqual(Vector2Int.right, Vector2Int.right.WithX(1));
            Assert.AreEqual(Vector2Int.one, Vector2Int.up.WithX(1));

            yield break;
        }

        [UnityTest]
        public IEnumerator WithY_ShouldReturnVectorWithNewY_GivenVector()
        {
            Assert.AreEqual(Vector2Int.right, Vector2Int.one.WithY(0));
            Assert.AreEqual(Vector2Int.zero, Vector2Int.zero.WithY(0));
            Assert.AreEqual(Vector2Int.right, Vector2Int.right.WithY(0));
            Assert.AreEqual(Vector2Int.zero, Vector2Int.up.WithY(0));

            Assert.AreEqual(Vector2Int.one, Vector2Int.one.WithY(1));
            Assert.AreEqual(Vector2Int.up, Vector2Int.zero.WithY(1));
            Assert.AreEqual(Vector2Int.one, Vector2Int.right.WithY(1));
            Assert.AreEqual(Vector2Int.up, Vector2Int.up.WithY(1));

            yield break;
        }
    }
}
