using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

internal partial class SByteTests
{
    [TestFixture]
    public class WrapTests
    {
        [Test]
        public void Wrap_ShouldReturnLow_WhenValueIsEqualToLow()
        {
            const sbyte value = 10;
            const sbyte low = 10;
            const sbyte high = 20;

            sbyte result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnHigh_WhenValueIsEqualToHigh()
        {
            const sbyte value = 20;
            const sbyte low = 10;
            const sbyte high = 20;

            sbyte result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanHigh()
        {
            const sbyte value = 30;
            const sbyte low = 10;
            const sbyte high = 20;

            sbyte result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsLessThanLow()
        {
            const sbyte value = 5;
            const sbyte low = 10;
            const sbyte high = 20;

            sbyte result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsInBetweenLowAndHigh()
        {
            const sbyte value = 15;
            const sbyte low = 10;
            const sbyte high = 20;

            sbyte result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Wrap_ShouldReturnZero_WhenValueIsEqualToLength()
        {
            const sbyte value = 10;
            const sbyte length = 10;

            sbyte result = value.Wrap(length);

            Assert.That(result, Is.Zero);
        }

        [Test]
        public void Wrap_ShouldReturnValue_WhenValueIsLessThanLength()
        {
            const sbyte value = 5;
            const sbyte length = 10;

            sbyte result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanLength()
        {
            const sbyte value = 15;
            const sbyte length = 10;

            sbyte result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(5));
        }
    }
}
