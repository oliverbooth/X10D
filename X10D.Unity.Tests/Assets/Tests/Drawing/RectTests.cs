using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using X10D.Core;
using X10D.Unity.Drawing;
using Random = System.Random;

namespace X10D.Unity.Tests.Drawing
{
    public class RectTests
    {
        [UnityTest]
        public IEnumerator ToSystemRectangleF_ShouldReturnRectangleF_WithEquivalentMembers()
        {
            var random = new Random();
            var rect = new Rect(random.NextSingle(), random.NextSingle(), random.NextSingle(), random.NextSingle());
            var rectangle = rect.ToSystemRectangleF();

            Assert.AreEqual(rect.x, rectangle.X, 1e-6f);
            Assert.AreEqual(rect.y, rectangle.Y, 1e-6f);
            Assert.AreEqual(rect.width, rectangle.Width, 1e-6f);
            Assert.AreEqual(rect.height, rectangle.Height, 1e-6f);

            yield break;
        }
    }
}
