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

            Assert.That(rect.x, Is.EqualTo(rectangle.X).Within(1e-6f));
            Assert.That(rect.y, Is.EqualTo(rectangle.Y).Within(1e-6f));
            Assert.That(rect.width, Is.EqualTo(rectangle.Width).Within(1e-6f));
            Assert.That(rect.height, Is.EqualTo(rectangle.Height).Within(1e-6f));
        }
    }
}
