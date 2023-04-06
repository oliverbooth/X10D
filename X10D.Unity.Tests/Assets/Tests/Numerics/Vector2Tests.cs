using NUnit.Framework;
using UnityEngine;
using X10D.Core;
using X10D.Unity.Numerics;
using Random = System.Random;

namespace X10D.Unity.Tests.Numerics
{
    public class Vector2Tests
    {
        [Test]
        public void Deconstruct_ShouldReturnCorrectValues()
        {
            var vector = new Vector2(1, 2);
            (float x, float y) = vector;

            Assert.That(x, Is.EqualTo(1));
            Assert.That(y, Is.EqualTo(2));
        }

        [Test]
        public void Round_ShouldRoundToNearestInteger_GivenNoParameters()
        {
            var vector = new Vector2(1.5f, 2.6f);
            var rounded = vector.Round();

            Assert.That(rounded.x, Is.EqualTo(2));
            Assert.That(rounded.y, Is.EqualTo(3));
        }

        [Test]
        public void Round_ShouldRoundToNearest10_GivenPrecision10()
        {
            var vector = new Vector2(1.5f, 25.2f);
            var rounded = vector.Round(10);

            Assert.That(rounded.x, Is.EqualTo(0));
            Assert.That(rounded.y, Is.EqualTo(30));
        }

        [Test]
        public void ToSystemPointF_ShouldReturnPoint_WithEquivalentMembers()
        {
            var random = new Random();
            float x = random.NextSingle();
            float y = random.NextSingle();

            var vector = new Vector2(x, y);
            var point = vector.ToSystemPointF();

            Assert.That(point.X, Is.EqualTo(vector.x).Within(1e-6f));
            Assert.That(point.Y, Is.EqualTo(vector.y).Within(1e-6f));
        }

        [Test]
        public void ToSystemSizeF_ShouldReturnSize_WithEquivalentMembers()
        {
            var random = new Random();
            float x = random.NextSingle();
            float y = random.NextSingle();

            var vector = new Vector2(x, y);
            var point = vector.ToSystemSizeF();

            Assert.That(point.Width, Is.EqualTo(vector.x).Within(1e-6f));
            Assert.That(point.Height, Is.EqualTo(vector.y).Within(1e-6f));
        }

        [Test]
        public void ToSystemVector_ShouldReturnVector_WithEqualComponents()
        {
            var random = new Random();
            float x = random.NextSingle();
            float y = random.NextSingle();

            var vector = new Vector2(x, y);
            var systemVector = vector.ToSystemVector();

            Assert.That(systemVector.Length(), Is.EqualTo(vector.magnitude).Within(1e-6f));
            Assert.That(systemVector.X, Is.EqualTo(vector.x).Within(1e-6f));
            Assert.That(systemVector.Y, Is.EqualTo(vector.y).Within(1e-6f));
        }

        [Test]
        public void ToUnityVector_ShouldReturnVector_WithEqualComponents()
        {
            var random = new Random();
            float x = random.NextSingle();
            float y = random.NextSingle();

            var vector = new System.Numerics.Vector2(x, y);
            var unityVector = vector.ToUnityVector();

            Assert.That(unityVector.magnitude, Is.EqualTo(vector.Length()).Within(1e-6f));
            Assert.That(unityVector.x, Is.EqualTo(vector.X).Within(1e-6f));
            Assert.That(unityVector.y, Is.EqualTo(vector.Y).Within(1e-6f));
        }

        [Test]
        public void WithX_ShouldReturnVectorWithNewX_GivenVector()
        {
            Assert.That(Vector2.one.WithX(0), Is.EqualTo(Vector2.up));
            Assert.That(Vector2.zero.WithX(0), Is.EqualTo(Vector2.zero));
            Assert.That(Vector2.right.WithX(0), Is.EqualTo(Vector2.zero));
            Assert.That(Vector2.up.WithX(0), Is.EqualTo(Vector2.up));

            Assert.That(Vector2.one.WithX(1), Is.EqualTo(Vector2.one));
            Assert.That(Vector2.zero.WithX(1), Is.EqualTo(Vector2.right));
            Assert.That(Vector2.right.WithX(1), Is.EqualTo(Vector2.right));
            Assert.That(Vector2.up.WithX(1), Is.EqualTo(Vector2.one));
        }

        [Test]
        public void WithY_ShouldReturnVectorWithNewY_GivenVector()
        {
            Assert.That(Vector2.one.WithY(0), Is.EqualTo(Vector2.right));
            Assert.That(Vector2.zero.WithY(0), Is.EqualTo(Vector2.zero));
            Assert.That(Vector2.right.WithY(0), Is.EqualTo(Vector2.right));
            Assert.That(Vector2.up.WithY(0), Is.EqualTo(Vector2.zero));

            Assert.That(Vector2.one.WithY(1), Is.EqualTo(Vector2.one));
            Assert.That(Vector2.zero.WithY(1), Is.EqualTo(Vector2.up));
            Assert.That(Vector2.right.WithY(1), Is.EqualTo(Vector2.one));
            Assert.That(Vector2.up.WithY(1), Is.EqualTo(Vector2.up));
        }
    }
}
