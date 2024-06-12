using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

internal partial class DecimalTests
{
    [TestFixture]
    public class WrapTests
    {
        [Test]
        public void Wrap_ShouldReturnLow_WhenValueIsEqualToLow()
        {
            const decimal value = 10;
            const decimal low = 10;
            const decimal high = 20;

            decimal result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnHigh_WhenValueIsEqualToHigh()
        {
            const decimal value = 20;
            const decimal low = 10;
            const decimal high = 20;

            decimal result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanHigh()
        {
            const decimal value = 30;
            const decimal low = 10;
            const decimal high = 20;

            decimal result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsLessThanLow()
        {
            const decimal value = 5;
            const decimal low = 10;
            const decimal high = 20;

            decimal result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(15.0m));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsInBetweenLowAndHigh()
        {
            const decimal value = 15;
            const decimal low = 10;
            const decimal high = 20;

            decimal result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Wrap_ShouldReturnZero_WhenValueIsEqualToLength()
        {
            const decimal value = 10;
            const decimal length = 10;

            decimal result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(0.0m));
        }

        [Test]
        public void Wrap_ShouldReturnValue_WhenValueIsLessThanLength()
        {
            const decimal value = 5;
            const decimal length = 10;

            decimal result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanLength()
        {
            const decimal value = 15;
            const decimal length = 10;

            decimal result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(5.0m));
        }
    }
}
