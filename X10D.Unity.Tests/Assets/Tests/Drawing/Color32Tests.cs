using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using X10D.Unity.Drawing;

namespace X10D.Unity.Tests.Drawing
{
    public class Color32Tests
    {
        private static readonly Color32 Black = new(0, 0, 0, 1);
        private static readonly Color32 White = new(255, 255, 255, 1);
        private static readonly Color32 Red = new(255, 0, 0, 1);
        private static readonly Color32 Green = new(0, 255, 0, 1);
        private static readonly Color32 Blue = new(0, 0, 255, 1);
        private static readonly Color32 Cyan = new(0, 255, 255, 1);
        private static readonly Color32 Magenta = new(255, 0, 255, 1);
        private static readonly Color32 Yellow = new(255, 255, 0, 1);

        [UnityTest]
        public IEnumerator Inverted_ShouldReturnInvertedColor()
        {
            Assert.AreEqual(White, Black.Inverted());
            Assert.AreEqual(Black, White.Inverted());
            Assert.AreEqual(Red, Cyan.Inverted());
            Assert.AreEqual(Cyan, Red.Inverted());
            Assert.AreEqual(Green, Magenta.Inverted());
            Assert.AreEqual(Magenta, Green.Inverted());
            Assert.AreEqual(Yellow, Blue.Inverted());
            Assert.AreEqual(Blue, Yellow.Inverted());

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
