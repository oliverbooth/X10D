using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

internal partial class UInt16Tests
{
    [TestFixture]
    public class WrapTests
    {
        [Test]
        public void Wrap_ShouldReturnLow_WhenValueIsEqualToLow()
        {
            const ushort value = 10;
            const ushort low = 10;
            const ushort high = 20;

            ushort result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnHigh_WhenValueIsEqualToHigh()
        {
            const ushort value = 20;
            const ushort low = 10;
            const ushort high = 20;

            ushort result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanHigh()
        {
            const ushort value = 30;
            const ushort low = 10;
            const ushort high = 20;

            ushort result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsLessThanLow()
        {
            const ushort value = 5;
            const ushort low = 10;
            const ushort high = 20;

            ushort result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(11U));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsInBetweenLowAndHigh()
        {
            const ushort value = 15;
            const ushort low = 10;
            const ushort high = 20;

            ushort result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Wrap_ShouldReturnZero_WhenValueIsEqualToLength()
        {
            const ushort value = 10;
            const ushort length = 10;

            ushort result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(0U));
        }

        [Test]
        public void Wrap_ShouldReturnValue_WhenValueIsLessThanLength()
        {
            const ushort value = 5;
            const ushort length = 10;

            ushort result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanLength()
        {
            const ushort value = 15;
            const ushort length = 10;

            ushort result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(5U));
        }
    }
}
