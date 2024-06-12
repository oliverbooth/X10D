using System.Numerics;
using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

internal partial class BigIntegerTests
{
    [TestFixture]
    public class WrapTests
    {
        [Test]
        public void Wrap_ShouldReturnLow_WhenValueIsEqualToLow()
        {
            BigInteger value = 10;
            BigInteger low = 10;
            BigInteger high = 20;

            BigInteger result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnHigh_WhenValueIsEqualToHigh()
        {
            BigInteger value = 20;
            BigInteger low = 10;
            BigInteger high = 20;

            BigInteger result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanHigh()
        {
            BigInteger value = 30;
            BigInteger low = 10;
            BigInteger high = 20;

            BigInteger result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(low));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsLessThanLow()
        {
            BigInteger value = 5;
            BigInteger low = 10;
            BigInteger high = 20;

            BigInteger result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo((BigInteger)15));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsInBetweenLowAndHigh()
        {
            BigInteger value = 15;
            BigInteger low = 10;
            BigInteger high = 20;

            BigInteger result = value.Wrap(low, high);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Wrap_ShouldReturnZero_WhenValueIsEqualToLength()
        {
            BigInteger value = 10;
            BigInteger length = 10;

            BigInteger result = value.Wrap(length);

            Assert.That(result, Is.EqualTo((BigInteger)0));
        }

        [Test]
        public void Wrap_ShouldReturnValue_WhenValueIsLessThanLength()
        {
            BigInteger value = 5;
            BigInteger length = 10;

            BigInteger result = value.Wrap(length);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Wrap_ShouldReturnCorrectResult_WhenValueIsGreaterThanLength()
        {
            BigInteger value = 15;
            BigInteger length = 10;

            BigInteger result = value.Wrap(length);

            Assert.That(result, Is.EqualTo((BigInteger)5));
        }
    }
}
