using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using X10D.Unity.Drawing;

namespace X10D.Unity.Tests.Drawing
{
    public class ColorTests
    {
        [UnityTest]
        public IEnumerator Inverted_ShouldReturnInvertedColor()
        {
            var black = new Color(0, 0, 0);
            var white = new Color(1, 1, 1);
            var red = new Color(1, 0, 0);
            var green = new Color(0, 1, 0);
            var blue = new Color(0, 0, 1);
            var cyan = new Color(0, 1, 1);
            var magenta = new Color(1, 0, 1);
            var yellow = new Color(1, 1, 0);

            Assert.AreEqual(white, black.Inverted());
            Assert.AreEqual(black, white.Inverted());
            Assert.AreEqual(red, cyan.Inverted());
            Assert.AreEqual(cyan, red.Inverted());
            Assert.AreEqual(green, magenta.Inverted());
            Assert.AreEqual(magenta, green.Inverted());
            Assert.AreEqual(yellow, blue.Inverted());
            Assert.AreEqual(blue, yellow.Inverted());

            yield break;
        }

        [UnityTest]
        public IEnumerator Inverted_ShouldIgnoreAlpha()
        {
            var expected = new Color(0, 0, 0, 1);
            var actual = new Color(1, 1, 1, 1).Inverted();

            Assert.AreEqual(expected, actual);

            yield break;
        }
    }
}
