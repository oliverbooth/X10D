using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X10D.Tests.Core
{
    /// <summary>
    ///     Tests for <see cref="ByteExtensions" />
    /// </summary>
    [TestClass]
    public class ByteTests
    {
        /// <summary>
        ///     Tests <see cref="ByteExtensions.GetBytes" />.
        /// </summary>
        [TestMethod]
        public void GetBytes()
        {
            const byte byteMinValue = byte.MinValue;
            const byte byteMaxValue = byte.MaxValue;

            var minValueBytes = new[] { byteMinValue };
            var maxValueBytes = new[] { byteMaxValue };

            var minValueResult = byteMinValue.GetBytes();
            var maxValueResult = byteMaxValue.GetBytes();

            CollectionAssert.AreEqual(minValueBytes, minValueResult);
            CollectionAssert.AreEqual(maxValueBytes, maxValueResult);
        }

        /// <summary>
        ///     Tests <see cref="ByteExtensions.IsEven" />.
        /// </summary>
        [TestMethod]
        public void IsEven()
        {
            const byte one = 1;
            const byte two = 2;

            var oneEven = one.IsEven();
            var twoEven = two.IsEven();

            Assert.IsFalse(oneEven);
            Assert.IsTrue(twoEven);
        }

        /// <summary>
        ///     Tests <see cref="ByteExtensions.IsOdd" />.
        /// </summary>
        [TestMethod]
        public void IsOdd()
        {
            const byte one = 1;
            const byte two = 2;

            var oneOdd = one.IsOdd();
            var twoOdd = two.IsOdd();

            Assert.IsTrue(oneOdd);
            Assert.IsFalse(twoOdd);
        }
    }
}
