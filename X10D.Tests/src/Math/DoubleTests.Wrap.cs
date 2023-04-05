using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

public partial class DoubleTests
{
    [TestFixture]
    public class WrapTests
    {
        [Test]
        public void Wrap_ShouldReturnLow_WhenValueIsEqualToLow()
        {
            const double value = 10;
            const double low = 10;
            const double high = 20;

            double result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnHigh_WhenValueIsEqualToHigh()
        {
            const double value = 20;
            const double low = 10;
            const double high = 20;

            double result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanHigh()
        {
            const double value = 30;
            const double low = 10;
            const double high = 20;

            double result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsLessThanLow()
        {
            const double value = 5;
            const double low = 10;
            const double high = 20;

            double result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(15.0));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsInBetweenLowAndHigh()
        {
            const double value = 15;
            const double low = 10;
            const double high = 20;

            double result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Wrap_ShouldReturnZero_WhenValueIsEqualToLength()
        {
            const double value = 10;
            const double length = 10;

            double result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(0.0));
        }

        [Test]
        public void Wrap_ShouldReturnValue_WhenValueIsLessThanLength()
        {
            const double value = 5;
            const double length = 10;

            double result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanLength()
        {
            const double value = 15;
            const double length = 10;

            double result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(5.0));
        }
    }
}
