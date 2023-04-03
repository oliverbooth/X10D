using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

public partial class UInt32Tests
{
    [TestClass]
    public class WrapTests
    {
        [TestMethod]
        public void Wrap_ShouldReturnLow_WhenValueIsEqualToLow()
        {
            const uint value = 10;
            const uint low = 10;
            const uint high = 20;

            uint result = value.Wrap(low, high);

            Assert.AreEqual(low, result);
        }

        [TestMethod]
        public void Wrap_ShouldReturnHigh_WhenValueIsEqualToHigh()
        {
            const uint value = 20;
            const uint low = 10;
            const uint high = 20;

            uint result = value.Wrap(low, high);

            Assert.AreEqual(low, result);
        }

        [TestMethod]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanHigh()
        {
            const uint value = 30;
            const uint low = 10;
            const uint high = 20;

            uint result = value.Wrap(low, high);

            Assert.AreEqual(low, result);
        }

        [TestMethod]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsLessThanLow()
        {
            const uint value = 5;
            const uint low = 10;
            const uint high = 20;

            uint result = value.Wrap(low, high);

            Assert.AreEqual(11U, result);
        }

        [TestMethod]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsInBetweenLowAndHigh()
        {
            const uint value = 15;
            const uint low = 10;
            const uint high = 20;

            uint result = value.Wrap(low, high);

            Assert.AreEqual(value, result);
        }

        [TestMethod]
        public void Wrap_ShouldReturnZero_WhenValueIsEqualToLength()
        {
            const uint value = 10;
            const uint length = 10;

            uint result = value.Wrap(length);

            Assert.AreEqual(0U, result);
        }

        [TestMethod]
        public void Wrap_ShouldReturnValue_WhenValueIsLessThanLength()
        {
            const uint value = 5;
            const uint length = 10;

            uint result = value.Wrap(length);

            Assert.AreEqual(value, result);
        }

        [TestMethod]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanLength()
        {
            const uint value = 15;
            const uint length = 10;

            uint result = value.Wrap(length);

            Assert.AreEqual(5U, result);
        }
    }
}
