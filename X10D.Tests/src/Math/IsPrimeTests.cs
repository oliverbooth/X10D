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

            Assert.IsTrue(value.IsPrime());
            Assert.IsTrue(((long)value).IsPrime());

            if (value is >= byte.MinValue and <= byte.MaxValue)
            {
                Assert.IsTrue(((byte)value).IsPrime());
            }

            if (value is >= short.MinValue and <= short.MaxValue)
            {
                Assert.IsTrue(((short)value).IsPrime());
            }

            if (value is >= byte.MinValue and <= byte.MaxValue)
            {
                Assert.IsTrue(((byte)value).IsPrime());
            }

            if (value is >= ushort.MinValue and <= ushort.MaxValue)
            {
                Assert.IsTrue(((ushort)value).IsPrime());
            }

            if (value is >= sbyte.MinValue and <= sbyte.MaxValue)
            {
                Assert.IsTrue(((sbyte)value).IsPrime());
            }

            if (value >= 0)
            {
                Assert.IsTrue(((uint)value).IsPrime());
                Assert.IsTrue(((ulong)value).IsPrime());
            }
        }
    }

    [TestMethod]
    public void Negatives()
    {
        for (var value = short.MinValue; value < 0; value++)
        {
            Assert.IsFalse(value.IsPrime());
            Assert.IsFalse(((int)value).IsPrime());
            Assert.IsFalse(((long)value).IsPrime());

            if (value is >= sbyte.MinValue and <= sbyte.MaxValue)
            {
                Assert.IsFalse(((sbyte)value).IsPrime());
            }
        }
    }

    [TestMethod]
    public void LessThan2()
    {
        for (var value = 0; value < 2; value++)
        {
            Assert.IsFalse(value.IsPrime());
            Assert.IsFalse(((byte)value).IsPrime());
            Assert.IsFalse(((short)value).IsPrime());
            Assert.IsFalse(((long)value).IsPrime());

            Assert.IsFalse(((sbyte)value).IsPrime());
            Assert.IsFalse(((ushort)value).IsPrime());
            Assert.IsFalse(((uint)value).IsPrime());
            Assert.IsFalse(((ulong)value).IsPrime());
        }
    }

    [TestMethod]
    public void ZeroTo7919()
    {
        for (var value = 0; value < 7920; value++)
        {
            bool expected = _primeNumbers.Contains(value);

            Assert.AreEqual(expected, ((short)value).IsPrime());
            Assert.AreEqual(expected, value.IsPrime());
            Assert.AreEqual(expected, ((long)value).IsPrime());

            Assert.AreEqual(expected, ((ushort)value).IsPrime());
            Assert.AreEqual(expected, ((uint)value).IsPrime());
            Assert.AreEqual(expected, ((ulong)value).IsPrime());
        }
    }

    [TestMethod]
    public void ZeroToByteMaxValue()
    {
        for (byte value = 0; value < byte.MaxValue; value++)
        {
            bool expected = _primeNumbers.Contains(value);

            Assert.AreEqual(expected, value.IsPrime());
            Assert.AreEqual(expected, ((short)value).IsPrime());
            Assert.AreEqual(expected, ((int)value).IsPrime());
            Assert.AreEqual(expected, ((long)value).IsPrime());

            Assert.AreEqual(expected, ((ushort)value).IsPrime());
            Assert.AreEqual(expected, ((uint)value).IsPrime());
            Assert.AreEqual(expected, ((ulong)value).IsPrime());

            if (value < sbyte.MaxValue)
            {
                Assert.AreEqual(expected, ((sbyte)value).IsPrime());
            }
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
