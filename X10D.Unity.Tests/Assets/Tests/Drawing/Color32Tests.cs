using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using X10D.Unity.Drawing;

namespace X10D.Unity.Tests.Drawing
{
    public class Color32Tests
    {
        [UnityTest]
        public IEnumerator Inverted_ShouldReturnInvertedColor()
        {
            var black = new Color32(0, 0, 0, 1);
            var white = new Color32(255, 255, 255, 1);
            var red = new Color32(255, 0, 0, 1);
            var green = new Color32(0, 255, 0, 1);
            var blue = new Color32(0, 0, 255, 1);
            var cyan = new Color32(0, 255, 255, 1);
            var magenta = new Color32(255, 0, 255, 1);
            var yellow = new Color32(255, 255, 0, 1);

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
            var expected = new Color32(0, 0, 0, 255);
            var actual = new Color32(255, 255, 255, 255).Inverted();

            Assert.AreEqual(expected, actual);

            yield break;
        }
    }
}
