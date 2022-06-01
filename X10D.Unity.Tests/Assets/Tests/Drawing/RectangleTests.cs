using System.Collections;
using System.Drawing;
using NUnit.Framework;
using UnityEngine.TestTools;
using X10D.Unity.Drawing;
using Random = System.Random;

namespace X10D.Unity.Tests.Drawing
{
    public class RectangleTests
    {
        [UnityTest]
        public IEnumerator ToUnityRect_ShouldReturnRect_WithEquivalentMembers()
        {
            var random = new Random();
            var rectangle = new Rectangle(random.Next(), random.Next(), random.Next(), random.Next());
            var rect = rectangle.ToUnityRect();

            Assert.AreEqual(rectangle.X, rect.x);
            Assert.AreEqual(rectangle.Y, rect.y);
            Assert.AreEqual(rectangle.Width, rect.width);
            Assert.AreEqual(rectangle.Height, rect.height);

            yield break;
        }

        [UnityTest]
        public IEnumerator ToUnityRectInt_ShouldReturnRect_WithEquivalentMembers()
        {
            var random = new Random();
            var rectangle = new Rectangle(random.Next(), random.Next(), random.Next(), random.Next());
            var rect = rectangle.ToUnityRectInt();

            Assert.AreEqual(rectangle.X, rect.x);
            Assert.AreEqual(rectangle.Y, rect.y);
            Assert.AreEqual(rectangle.Width, rect.width);
            Assert.AreEqual(rectangle.Height, rect.height);

            yield break;
        }
    }
}
