using System.Globalization;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

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

    [TestMethod]
    public void Negatives()
    {
        for (var value = short.MinValue; value < 0; value++)
        {
            bool result = value.IsPrime();
            Assert.IsFalse(result, value.ToString("N0", CultureInfo.InvariantCulture));
        }
    }

    [TestMethod]
    public void LessThan2()
    {
        for (var value = 0; value < 2; value++)
        {
            bool result = value.IsPrime();
            Assert.IsFalse(result, value.ToString("N0", CultureInfo.InvariantCulture));
        }
    }

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
