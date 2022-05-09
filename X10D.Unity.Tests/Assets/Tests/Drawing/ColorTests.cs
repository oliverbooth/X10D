using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using X10D.Unity.Drawing;

namespace X10D.Unity.Tests.Drawing
{
    public class ColorTests
    {
        private static readonly Color Black = new(0, 0, 0);
        private static readonly Color White = new(1, 1, 1);
        private static readonly Color Red = new(1, 0, 0);
        private static readonly Color Green = new(0, 1, 0);
        private static readonly Color Blue = new(0, 0, 1);
        private static readonly Color Cyan = new(0, 1, 1);
        private static readonly Color Magenta = new(1, 0, 1);
        private static readonly Color Yellow = new(1, 1, 0);

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
            var expected = new Color(0, 0, 0, 1);
            var actual = new Color(1, 1, 1, 1).Inverted();

            Assert.AreEqual(expected, actual);

            yield break;
        }
    }
}
