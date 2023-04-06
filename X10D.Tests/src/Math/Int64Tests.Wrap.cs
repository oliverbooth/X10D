using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

public partial class Int64Tests
{
    [TestFixture]
    public class WrapTests
    {
        [Test]
        public void Wrap_ShouldReturnLow_WhenValueIsEqualToLow()
        {
            const long value = 10;
            const long low = 10;
            const long high = 20;

            long result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnHigh_WhenValueIsEqualToHigh()
        {
            const long value = 20;
            const long low = 10;
            const long high = 20;

            long result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanHigh()
        {
            const long value = 30;
            const long low = 10;
            const long high = 20;

            long result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsLessThanLow()
        {
            const long value = 5;
            const long low = 10;
            const long high = 20;

            long result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(15L));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsInBetweenLowAndHigh()
        {
            const long value = 15;
            const long low = 10;
            const long high = 20;

            long result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Wrap_ShouldReturnZero_WhenValueIsEqualToLength()
        {
            const long value = 10;
            const long length = 10;

            long result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(0L));
        }

        [Test]
        public void Wrap_ShouldReturnValue_WhenValueIsLessThanLength()
        {
            const long value = 5;
            const long length = 10;

            long result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanLength()
        {
            const long value = 15;
            const long length = 10;

            long result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(5L));
        }
    }
}
