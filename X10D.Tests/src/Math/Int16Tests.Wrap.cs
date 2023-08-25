using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

internal partial class Int16Tests
{
    [TestFixture]
    public class WrapTests
    {
        [Test]
        public void Wrap_ShouldReturnLow_WhenValueIsEqualToLow()
        {
            const short value = 10;
            const short low = 10;
            const short high = 20;

            short result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnHigh_WhenValueIsEqualToHigh()
        {
            const short value = 20;
            const short low = 10;
            const short high = 20;

            short result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanHigh()
        {
            const short value = 30;
            const short low = 10;
            const short high = 20;

            short result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsLessThanLow()
        {
            const short value = 5;
            const short low = 10;
            const short high = 20;

            short result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsInBetweenLowAndHigh()
        {
            const short value = 15;
            const short low = 10;
            const short high = 20;

            short result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Wrap_ShouldReturnZero_WhenValueIsEqualToLength()
        {
            const short value = 10;
            const short length = 10;

            short result = value.Wrap(length);

            Assert.That(result, Is.Zero);
        }

        [Test]
        public void Wrap_ShouldReturnValue_WhenValueIsLessThanLength()
        {
            const short value = 5;
            const short length = 10;

            short result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanLength()
        {
            const short value = 15;
            const short length = 10;

            short result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(5));
        }
    }
}
