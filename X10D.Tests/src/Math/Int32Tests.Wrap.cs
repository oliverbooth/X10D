using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

internal partial class Int32Tests
{
    [TestFixture]
    public class WrapTests
    {
        [Test]
        public void Wrap_ShouldReturnLow_WhenValueIsEqualToLow()
        {
            const int value = 10;
            const int low = 10;
            const int high = 20;

            int result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnHigh_WhenValueIsEqualToHigh()
        {
            const int value = 20;
            const int low = 10;
            const int high = 20;

            int result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanHigh()
        {
            const int value = 30;
            const int low = 10;
            const int high = 20;

            int result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsLessThanLow()
        {
            const int value = 5;
            const int low = 10;
            const int high = 20;

            int result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsInBetweenLowAndHigh()
        {
            const int value = 15;
            const int low = 10;
            const int high = 20;

            int result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Wrap_ShouldReturnZero_WhenValueIsEqualToLength()
        {
            const int value = 10;
            const int length = 10;

            int result = value.Wrap(length);

            Assert.That(result, Is.Zero);
        }

        [Test]
        public void Wrap_ShouldReturnValue_WhenValueIsLessThanLength()
        {
            const int value = 5;
            const int length = 10;

            int result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanLength()
        {
            const int value = 15;
            const int length = 10;

            int result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(5));
        }
    }
}
