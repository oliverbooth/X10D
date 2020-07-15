namespace X10D.Tests.Unity
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using UnityEngine;
    using X10D.Unity;

    /// <summary>
    ///     Tests for <see cref="Vector3Extensions" />.
    /// </summary>
    [TestClass]
    public class Vector3Tests
    {
        /// <summary>
        ///     Tests for <see cref="Vector3Extensions.Round" /> by rounding to the nearest 0.5.
        /// </summary>
        [TestMethod]
        public void TestRoundHalf()
        {
            var vector = new Vector3(1.8f, 2.1f, 3.37f);
            Assert.AreEqual(new Vector3(2, 2, 3.5f), vector.Round(0.5f));
        }

        /// <summary>
        ///     Tests for <see cref="Vector3Extensions.Round" /> by rounding to the nearest integer.
        /// </summary>
        [TestMethod]
        public void TestRoundInteger()
        {
            var vector = new Vector3(1.8f, 2.1f, 3.37f);
            Assert.AreEqual(new Vector3(2, 2, 3), vector.Round());
        }

        /// <summary>
        ///     Tests for <see cref="Vector3Extensions.WithX" />.
        /// </summary>
        [TestMethod]
        public void TestWithX()
        {
            var vector = new Vector3(1, 2, 3);
            Assert.AreEqual(new Vector3(4, 2, 3), vector.WithX(4));
        }

        /// <summary>
        ///     Tests for <see cref="Vector3Extensions.WithXY" />.
        /// </summary>
        [TestMethod]
        public void TestWithXY()
        {
            var vector = new Vector3(1, 2, 3);
            Assert.AreEqual(new Vector3(8, 10, 3), vector.WithXY(8, 10));
        }

        /// <summary>
        ///     Tests for <see cref="Vector3Extensions.WithXZ" />.
        /// </summary>
        [TestMethod]
        public void TestWithXZ()
        {
            var vector = new Vector3(1, 2, 3);
            Assert.AreEqual(new Vector3(8, 2, 10), vector.WithXZ(8, 10));
        }

        /// <summary>
        ///     Tests for <see cref="Vector3Extensions.WithY" />.
        /// </summary>
        [TestMethod]
        public void TestWithY()
        {
            var vector = new Vector3(1, 2, 3);
            Assert.AreEqual(new Vector3(1, 4, 3), vector.WithY(4));
        }

        /// <summary>
        ///     Tests for <see cref="Vector3Extensions.WithYZ" />.
        /// </summary>
        [TestMethod]
        public void TestWithYZ()
        {
            var vector = new Vector3(1, 2, 3);
            Assert.AreEqual(new Vector3(1, 8, 10), vector.WithYZ(8, 10));
        }

        /// <summary>
        ///     Tests for <see cref="Vector3Extensions.WithZ" />.
        /// </summary>
        [TestMethod]
        public void TestWithZ()
        {
            var vector = new Vector3(1, 2, 3);
            Assert.AreEqual(new Vector3(1, 2, 4), vector.WithZ(4));
        }
    }
}
