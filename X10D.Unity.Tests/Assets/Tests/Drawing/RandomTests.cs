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
            Assert.That(color.r, Is.EqualTo(0.373868465f).Within(1e-6f));
            Assert.That(color.g, Is.EqualTo(0.391597569f).Within(1e-6f));
            Assert.That(color.b, Is.EqualTo(0.675019085f).Within(1e-6f));
            Assert.That(color.a, Is.EqualTo(0.234300315f).Within(1e-6f));
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
            Assert.That(random.NextColor32Argb(), Is.EqualTo(new Color32(21, 21, 229, 51)));
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
            Assert.That(color.r, Is.EqualTo(0.234300315f).Within(1e-6f));
            Assert.That(color.g, Is.EqualTo(0.373868465f).Within(1e-6f));
            Assert.That(color.b, Is.EqualTo(0.391597569f).Within(1e-6f));
            Assert.That(color.a, Is.EqualTo(1).Within(1e-6f));
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
            Assert.That(random.NextColor32Rgb(), Is.EqualTo(new Color32(21, 21, 229, 255)));
        }

        [Test]
        public void NextColor32Rgb_ShouldThrow_GivenNull()
        {
            Random random = null!;
            Assert.Throws<ArgumentNullException>(() => random.NextColor32Rgb());
        }
    }
}
