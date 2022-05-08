#nullable enable

using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using X10D.Unity.Drawing;
using Random = System.Random;

namespace X10D.Unity.Tests.Drawing
{
    public class RandomTests
    {
        [UnityTest]
        public IEnumerator NextColorArgb_ShouldReturn331515e5_GivenSeed1234()
        {
            var random = new Random(1234);
            var color = random.NextColorArgb();
            Assert.AreEqual(0.373868465f, color.r, 1e-6f);
            Assert.AreEqual(0.391597569f, color.g, 1e-6f);
            Assert.AreEqual(0.675019085f, color.b, 1e-6f);
            Assert.AreEqual(0.234300315f, color.a, 1e-6f);
            yield break;
        }

        [UnityTest]
        public IEnumerator NextColorArgb_ShouldThrow_GivenNull()
        {
            Random? random = null;
            Assert.Throws<ArgumentNullException>(() => random!.NextColorArgb());
            yield break;
        }

        [UnityTest]
        public IEnumerator NextColor32Argb_ShouldReturn331515e5_GivenSeed1234()
        {
            var random = new Random(1234);
            Assert.AreEqual(new Color32(21, 21, 229, 51), random.NextColor32Argb());
            yield break;
        }

        [UnityTest]
        public IEnumerator NextColor32Argb_ShouldThrow_GivenNull()
        {
            Random? random = null;
            Assert.Throws<ArgumentNullException>(() => random!.NextColor32Argb());
            yield break;
        }

        [UnityTest]
        public IEnumerator NextColorRgb_ShouldReturn1515e5_GivenSeed1234()
        {
            var random = new Random(1234);
            var color = random.NextColorRgb();
            Assert.AreEqual(0.234300315f, color.r, 1e-6f);
            Assert.AreEqual(0.373868465f, color.g, 1e-6f);
            Assert.AreEqual(0.391597569f, color.b, 1e-6f);
            Assert.AreEqual(1, color.a, 1e-6f);
            yield break;
        }

        [UnityTest]
        public IEnumerator NextColorRgb_ShouldThrow_GivenNull()
        {
            Random? random = null;
            Assert.Throws<ArgumentNullException>(() => random!.NextColorRgb());
            yield break;
        }

        [UnityTest]
        public IEnumerator NextColor32Rgb_ShouldReturn1515e5_GivenSeed1234()
        {
            var random = new Random(1234);
            Assert.AreEqual(new Color32(21, 21, 229, 255), random.NextColor32Rgb());
            yield break;
        }

        [UnityTest]
        public IEnumerator NextColor32Rgb_ShouldThrow_GivenNull()
        {
            Random? random = null;
            Assert.Throws<ArgumentNullException>(() => random!.NextColor32Rgb());
            yield break;
        }
    }
}
