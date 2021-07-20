using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X10D.Tests.Core
{
    /// <summary>
    ///     Tests for <see cref="Int32Extensions.IsPrime(int)"/>.
    /// </summary>
    /// <remarks>
    ///     Tests for this extension method are delegated to their own test class because of the non-trivial requirements for
    ///     loading testing prime numbers.
    /// </remarks>
    /// <seealso cref="Int32Extensions.IsPrime(int)" />
    [TestClass]
    public class IsPrimeTests
    {
        private IReadOnlyList<int> _primeNumbers = ArraySegment<int>.Empty;

        [TestInitialize]
        public void Initialize()
        {
            _primeNumbers = LoadPrimes();
            Assert.AreEqual(1000, _primeNumbers.Count);
        }

        /// <summary>
        ///     Asserts the primality of the first 1000 known prime numbers. 
        /// </summary>
        [TestMethod]
        public void First1000Primes()
        {
            for (var index = 0; index < _primeNumbers.Count; index++)
            {
                var value = _primeNumbers[index];
                var result = value.IsPrime();
                Assert.IsTrue(result, value.ToString("N0", CultureInfo.InvariantCulture));
            }
        }

        /// <summary>
        ///     Asserts that all negative numbers are not prime.
        /// </summary>
        [TestMethod]
        public void Negatives()
        {
            for (var value = short.MinValue; value < 0; value++)
            {
                var result = value.IsPrime();
                Assert.IsFalse(result, value.ToString("N0", CultureInfo.InvariantCulture));
            }
        }

        /// <summary>
        ///     Asserts that all negative numbers are not prime.
        /// </summary>
        [TestMethod]
        public void LessThan2()
        {
            for (var value = 0; value < 2; value++)
            {
                var result = value.IsPrime();
                Assert.IsFalse(result, value.ToString("N0", CultureInfo.InvariantCulture));
            }
        }

        /// <summary>
        ///     Tests the primality of the numbers 0 - 7919.
        /// </summary>
        [TestMethod]
        public void ZeroTo7919()
        {
            for (var value = 0; value < 7920; value++)
            {
                var expected = _primeNumbers.Contains(value);
                var actual = value.IsPrime();

                Assert.AreEqual(expected, actual, value.ToString("N0", CultureInfo.InvariantCulture));
            }
        }

        /// <summary>
        ///     Tests the primality of the numbers 0 - <see cref="byte.MaxValue" />.
        /// </summary>
        [TestMethod]
        public void ZeroToByteMaxValue()
        {
            for (byte value = 0; value < byte.MaxValue; value++)
            {
                var expected = _primeNumbers.Contains(value);
                var actual = value.IsPrime();

                Assert.AreEqual(expected, actual, value.ToString("N0", CultureInfo.InvariantCulture));
            }
        }

        private static IReadOnlyList<int> LoadPrimes()
        {
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("X10D.Tests.1000primes.txt");
            Assert.IsNotNull(stream);

            using var reader = new StreamReader(stream, Encoding.UTF8);
            var primes = new List<int>();

            while (reader.ReadLine() is { } line)
            {
                if (int.TryParse(line, out var prime))
                {
                    primes.Add(prime);
                }
            }

            return primes.AsReadOnly();
        }
    }
}
