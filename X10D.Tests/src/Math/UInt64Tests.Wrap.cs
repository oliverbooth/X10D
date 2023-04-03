using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

public partial class UInt64Tests
{
    [TestClass]
    public class WrapTests
    {
        [TestMethod]
        public void Wrap_ShouldReturnLow_WhenValueIsEqualToLow()
        {
            const ulong value = 10;
            const ulong low = 10;
            const ulong high = 20;

            ulong result = value.Wrap(low, high);

            Assert.AreEqual(low, result);
        }

        [TestMethod]
        public void Wrap_ShouldReturnHigh_WhenValueIsEqualToHigh()
        {
            const ulong value = 20;
            const ulong low = 10;
            const ulong high = 20;

            ulong result = value.Wrap(low, high);

            Assert.AreEqual(low, result);
        }

        [TestMethod]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanHigh()
        {
            const ulong value = 30;
            const ulong low = 10;
            const ulong high = 20;

            ulong result = value.Wrap(low, high);

            Assert.AreEqual(low, result);
        }

        [TestMethod]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsLessThanLow()
        {
            const ulong value = 5;
            const ulong low = 10;
            const ulong high = 20;

            ulong result = value.Wrap(low, high);

            Assert.AreEqual(11UL, result);
        }

        [TestMethod]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsInBetweenLowAndHigh()
        {
            const ulong value = 15;
            const ulong low = 10;
            const ulong high = 20;

            ulong result = value.Wrap(low, high);

            Assert.AreEqual(value, result);
        }

        [TestMethod]
        public void Wrap_ShouldReturnZero_WhenValueIsEqualToLength()
        {
            const ulong value = 10;
            const ulong length = 10;

            ulong result = value.Wrap(length);

            Assert.AreEqual(0UL, result);
        }

        [TestMethod]
        public void Wrap_ShouldReturnValue_WhenValueIsLessThanLength()
        {
            const ulong value = 5;
            const ulong length = 10;

            ulong result = value.Wrap(length);

            Assert.AreEqual(value, result);
        }

        [TestMethod]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanLength()
        {
            const ulong value = 15;
            const ulong length = 10;

            ulong result = value.Wrap(length);

            Assert.AreEqual(5UL, result);
        }
    }
}
