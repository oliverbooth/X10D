using System.Globalization;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X10D.Tests.Core;

/// <summary>
///     Tests for <see cref="Int32Extensions.IsPrime(int)"/>.
/// </summary>
/// <remarks>
///     Tests for this extension method are delegated to their own test class because of the non-trivial requirements for
///     loading testing prime numbers.
/// </remarks>
/// <seealso cref="Int16Extensions.IsPrime(short)" />
/// <seealso cref="Int32Extensions.IsPrime(int)" />
/// <seealso cref="Int64Extensions.IsPrime(long)" />
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
            int value = _primeNumbers[index];
            bool result = value.IsPrime();
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
            bool result = value.IsPrime();
            Assert.IsFalse(result, value.ToString("N0", CultureInfo.InvariantCulture));
        }
    }

    /// <summary>
    ///     Asserts that values 0 and 1 are not prime.
    /// </summary>
    [TestMethod]
    public void LessThan2()
    {
        for (var value = 0; value < 2; value++)
        {
            bool result = value.IsPrime();
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
            bool expected = _primeNumbers.Contains(value);
            bool actual = value.IsPrime();

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
            bool expected = _primeNumbers.Contains(value);
            bool actual = value.IsPrime();

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
            if (int.TryParse(line, out int prime))
            {
                primes.Add(prime);
            }
        }

        return primes.AsReadOnly();
    }
}