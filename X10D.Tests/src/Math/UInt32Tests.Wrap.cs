using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

internal partial class UInt32Tests
{
    [TestFixture]
    public class WrapTests
    {
        [Test]
        public void Wrap_ShouldReturnLow_WhenValueIsEqualToLow()
        {
            const uint value = 10;
            const uint low = 10;
            const uint high = 20;

            uint result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnHigh_WhenValueIsEqualToHigh()
        {
            const uint value = 20;
            const uint low = 10;
            const uint high = 20;

            uint result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanHigh()
        {
            const uint value = 30;
            const uint low = 10;
            const uint high = 20;

            uint result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsLessThanLow()
        {
            const uint value = 5;
            const uint low = 10;
            const uint high = 20;

            uint result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(11U));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsInBetweenLowAndHigh()
        {
            const uint value = 15;
            const uint low = 10;
            const uint high = 20;

            uint result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Wrap_ShouldReturnZero_WhenValueIsEqualToLength()
        {
            const uint value = 10;
            const uint length = 10;

            uint result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(0U));
        }

        [Test]
        public void Wrap_ShouldReturnValue_WhenValueIsLessThanLength()
        {
            const uint value = 5;
            const uint length = 10;

            uint result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanLength()
        {
            const uint value = 15;
            const uint length = 10;

            uint result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(5U));
        }
    }
}
