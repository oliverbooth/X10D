#nullable enable

using System;
using NUnit.Framework;
using UnityEngine;
using X10D.Unity.Drawing;
using Random = System.Random;

namespace X10D.Unity.Tests.Drawing
{
    public class RandomTests
    {
        [Test]
        public void NextColorArgb_ShouldReturn331515e5_GivenSeed1234()
        {
            var random = new Random(1234);
            var color = random.NextColorArgb();
            Assert.AreEqual(0.373868465f, color.r, 1e-6f);
            Assert.AreEqual(0.391597569f, color.g, 1e-6f);
            Assert.AreEqual(0.675019085f, color.b, 1e-6f);
            Assert.AreEqual(0.234300315f, color.a, 1e-6f);
        }

        [Test]
        public void NextColorArgb_ShouldThrow_GivenNull()
        {
            Random random = null!;
            Assert.Throws<ArgumentNullException>(() => random.NextColorArgb());
        }

        [Test]
        public void NextColor32Argb_ShouldReturn331515e5_GivenSeed1234()
        {
            var random = new Random(1234);
            Assert.AreEqual(new Color32(21, 21, 229, 51), random.NextColor32Argb());
        }

        [Test]
        public void NextColor32Argb_ShouldThrow_GivenNull()
        {
            Random random = null!;
            Assert.Throws<ArgumentNullException>(() => random.NextColor32Argb());
        }

        [Test]
        public void NextColorRgb_ShouldReturn1515e5_GivenSeed1234()
        {
            var random = new Random(1234);
            var color = random.NextColorRgb();
            Assert.AreEqual(0.234300315f, color.r, 1e-6f);
            Assert.AreEqual(0.373868465f, color.g, 1e-6f);
            Assert.AreEqual(0.391597569f, color.b, 1e-6f);
            Assert.AreEqual(1, color.a, 1e-6f);
        }

        [Test]
        public void NextColorRgb_ShouldThrow_GivenNull()
        {
            Random random = null!;
            Assert.Throws<ArgumentNullException>(() => random.NextColorRgb());
        }

        [Test]
        public void NextColor32Rgb_ShouldReturn1515e5_GivenSeed1234()
        {
            var random = new Random(1234);
            Assert.AreEqual(new Color32(21, 21, 229, 255), random.NextColor32Rgb());
        }

        [Test]
        public void NextColor32Rgb_ShouldThrow_GivenNull()
        {
            Random random = null!;
            Assert.Throws<ArgumentNullException>(() => random.NextColor32Rgb());
        }
    }
}
