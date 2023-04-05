using System.Drawing;
using NUnit.Framework;
using X10D.Core;
using X10D.Unity.Drawing;
using Random = System.Random;

namespace X10D.Unity.Tests.Drawing
{
    public class RectangleFTests
    {
        [Test]
        public void ToUnityRect_ShouldReturnRect_WithEquivalentMembers()
        {
            var random = new Random();
            var rectangle = new RectangleF(random.NextSingle(), random.NextSingle(), random.NextSingle(), random.NextSingle());
            var rect = rectangle.ToUnityRect();

            Assert.AreEqual(rectangle.X, rect.x, 1e-6f);
            Assert.AreEqual(rectangle.Y, rect.y, 1e-6f);
            Assert.AreEqual(rectangle.Width, rect.width, 1e-6f);
            Assert.AreEqual(rectangle.Height, rect.height, 1e-6f);
        }
    }
}
