using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

public partial class SingleTests
{
    [TestClass]
    public class WrapTests
    {
        [TestMethod]
        public void Wrap_ShouldReturnLow_WhenValueIsEqualToLow()
        {
            const float value = 10;
            const float low = 10;
            const float high = 20;

            float result = value.Wrap(low, high);

            Assert.AreEqual(low, result);
        }

        [TestMethod]
        public void Wrap_ShouldReturnHigh_WhenValueIsEqualToHigh()
        {
            const float value = 20;
            const float low = 10;
            const float high = 20;

            float result = value.Wrap(low, high);

            Assert.AreEqual(low, result);
        }

        [TestMethod]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanHigh()
        {
            const float value = 30;
            const float low = 10;
            const float high = 20;

            float result = value.Wrap(low, high);

            Assert.AreEqual(low, result);
        }

        [TestMethod]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsLessThanLow()
        {
            const float value = 5;
            const float low = 10;
            const float high = 20;

            float result = value.Wrap(low, high);

            Assert.AreEqual(15.0f, result);
        }

        [TestMethod]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsInBetweenLowAndHigh()
        {
            const float value = 15;
            const float low = 10;
            const float high = 20;

            float result = value.Wrap(low, high);

            Assert.AreEqual(value, result);
        }

        [TestMethod]
        public void Wrap_ShouldReturnZero_WhenValueIsEqualToLength()
        {
            const float value = 10;
            const float length = 10;

            float result = value.Wrap(length);

            Assert.AreEqual(0.0f, result);
        }

        [TestMethod]
        public void Wrap_ShouldReturnValue_WhenValueIsLessThanLength()
        {
            const float value = 5;
            const float length = 10;

            float result = value.Wrap(length);

            Assert.AreEqual(value, result);
        }

        [TestMethod]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanLength()
        {
            const float value = 15;
            const float length = 10;

            float result = value.Wrap(length);

            Assert.AreEqual(5.0f, result);
        }
    }
}
