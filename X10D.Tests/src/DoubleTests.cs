namespace X10D.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for <see cref="DoubleExtensions"/>.
    /// </summary>
    [TestClass]
    public class DoubleTests
    {
        /// <summary>
        /// Tests for <see cref="DoubleExtensions.Clamp"/>.
        /// </summary>
        [TestMethod]
        public void Clamp()
        {
            Assert.AreEqual(2.0, 3.0.Clamp(1.0, 2.0));
            Assert.AreEqual(1.0, (-3.0).Clamp(1.0, 2.0));
        }

        /// <summary>
        /// Tests for <see cref="DoubleExtensions.DegreesToRadians"/>.
        /// </summary>
        [TestMethod]
        public void DegreesToRadians()
        {
            Assert.AreEqual(Math.PI, 180.0.DegreesToRadians());
            Assert.AreEqual(Math.PI * 1.5, 270.0.DegreesToRadians());
        }

        /// <summary>
        /// Tests for <see cref="DoubleExtensions.GetBytes"/>.
        /// </summary>
        [TestMethod]
        public void GetBytes()
        {
            CollectionAssert.AreEqual(
                new byte[] { 0x18, 0x2D, 0x44, 0x54, 0xFB, 0x21, 0x09, 0x40 },
                Math.PI.GetBytes());
        }

        /// <summary>
        /// Tests for <see cref="DoubleExtensions.IsEven"/>.
        /// </summary>
        [TestMethod]
        public void IsEven()
        {
            Assert.IsTrue(2.0.IsEven());
            Assert.IsFalse(1.0.IsEven());
        }

        /// <summary>
        /// Tests for <see cref="DoubleExtensions.IsOdd"/>.
        /// </summary>
        [TestMethod]
        public void IsOdd()
        {
            Assert.IsFalse(2.0.IsOdd());
            Assert.IsTrue(1.0.IsOdd());
        }

        /// <summary>
        /// Tests for <see cref="DoubleExtensions.RadiansToDegrees"/>.
        /// </summary>
        [TestMethod]
        public void RadiansToDegrees()
        {
            Assert.AreEqual(180.0, Math.PI.RadiansToDegrees());
            Assert.AreEqual(360.0, (2.0 * Math.PI).RadiansToDegrees());
        }

        /// <summary>
        /// Tests for <see cref="DoubleExtensions.Round"/>.
        /// </summary>
        [TestMethod]
        public void Round()
        {
            Assert.AreEqual(5.0, 3.5.Round(5));
            Assert.AreEqual(5.0, 7.0.Round(5));
            Assert.AreEqual(10.0, 7.5.Round(5));
        }
    }
}
