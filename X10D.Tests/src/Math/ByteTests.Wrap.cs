using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

public partial class ByteTests
{
    [TestFixture]
    public class WrapTests
    {
        [Test]
        public void Wrap_ShouldReturnLow_WhenValueIsEqualToLow()
        {
            const byte value = 10;
            const byte low = 10;
            const byte high = 20;

            byte result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnHigh_WhenValueIsEqualToHigh()
        {
            const byte value = 20;
            const byte low = 10;
            const byte high = 20;

            byte result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanHigh()
        {
            const byte value = 30;
            const byte low = 10;
            const byte high = 20;

            byte result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsLessThanLow()
        {
            const byte value = 5;
            const byte low = 10;
            const byte high = 20;

            byte result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(11));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsInBetweenLowAndHigh()
        {
            const byte value = 15;
            const byte low = 10;
            const byte high = 20;

            byte result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Wrap_ShouldReturnZero_WhenValueIsEqualToLength()
        {
            const byte value = 10;
            const byte length = 10;

            byte result = value.Wrap(length);

            Assert.That(result, Is.Zero);
        }

        [Test]
        public void Wrap_ShouldReturnValue_WhenValueIsLessThanLength()
        {
            const byte value = 5;
            const byte length = 10;

            byte result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanLength()
        {
            const byte value = 15;
            const byte length = 10;

            byte result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(5));
        }
    }
}
