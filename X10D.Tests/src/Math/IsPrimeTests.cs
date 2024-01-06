using System.Numerics;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

[TestFixture]
internal class IsPrimeTests
{
    private IReadOnlyList<int> _primeNumbers = ArraySegment<int>.Empty;

    [SetUp]
    public void Initialize()
    {
        _primeNumbers = LoadPrimes();
        Assert.That(_primeNumbers.Count, Is.EqualTo(1000));
    }

    [Test]
    public void First1000Primes()
    {
        for (var index = 0; index < _primeNumbers.Count; index++)
        {
            int value = _primeNumbers[index];

            Assert.That(value.IsPrime());
            Assert.That(((long)value).IsPrime());
            Assert.That(((BigInteger)value).IsPrime());

            if (value is >= byte.MinValue and <= byte.MaxValue)
            {
                Assert.That(((byte)value).IsPrime());
            }

            if (value is >= short.MinValue and <= short.MaxValue)
            {
                Assert.That(((short)value).IsPrime());
            }

            if (value is >= byte.MinValue and <= byte.MaxValue)
            {
                Assert.That(((byte)value).IsPrime());
            }

            if (value is >= ushort.MinValue and <= ushort.MaxValue)
            {
                Assert.That(((ushort)value).IsPrime());
            }

            if (value is >= sbyte.MinValue and <= sbyte.MaxValue)
            {
                Assert.That(((sbyte)value).IsPrime());
            }

            if (value >= 0)
            {
                Assert.That(((uint)value).IsPrime());
                Assert.That(((ulong)value).IsPrime());
            }
        }
    }

    [Test]
    public void Negatives()
    {
        for (var value = short.MinValue; value < 0; value++)
        {
            Assert.That(value.IsPrime(), Is.False);
            Assert.That(((int)value).IsPrime(), Is.False);
            Assert.That(((long)value).IsPrime(), Is.False);
            Assert.That(((BigInteger)value).IsPrime(), Is.False);

            if (value is >= sbyte.MinValue and <= sbyte.MaxValue)
            {
                Assert.That(((sbyte)value).IsPrime(), Is.False);
            }
        }
    }

    [Test]
    public void LessThan2()
    {
        for (var value = 0; value < 2; value++)
        {
            Assert.That(value.IsPrime(), Is.False);
            Assert.That(((byte)value).IsPrime(), Is.False);
            Assert.That(((short)value).IsPrime(), Is.False);
            Assert.That(((long)value).IsPrime(), Is.False);
            Assert.That(((BigInteger)value).IsPrime(), Is.False);

            Assert.That(((sbyte)value).IsPrime(), Is.False);
            Assert.That(((ushort)value).IsPrime(), Is.False);
            Assert.That(((uint)value).IsPrime(), Is.False);
            Assert.That(((ulong)value).IsPrime(), Is.False);
        }
    }

    [Test]
    public void ZeroTo7919()
    {
        for (var value = 0; value < 7920; value++)
        {
            bool expected = _primeNumbers.Contains(value);

            Assert.That(((short)value).IsPrime(), Is.EqualTo(expected));
            Assert.That(value.IsPrime(), Is.EqualTo(expected));
            Assert.That(((long)value).IsPrime(), Is.EqualTo(expected));
            Assert.That(((BigInteger)value).IsPrime(), Is.EqualTo(expected));

            Assert.That(((ushort)value).IsPrime(), Is.EqualTo(expected));
            Assert.That(((uint)value).IsPrime(), Is.EqualTo(expected));
            Assert.That(((ulong)value).IsPrime(), Is.EqualTo(expected));
        }
    }

    [Test]
    public void ZeroToByteMaxValue()
    {
        for (byte value = 0; value < byte.MaxValue; value++)
        {
            bool expected = _primeNumbers.Contains(value);

            Assert.That(value.IsPrime(), Is.EqualTo(expected));
            Assert.That(((short)value).IsPrime(), Is.EqualTo(expected));
            Assert.That(((int)value).IsPrime(), Is.EqualTo(expected));
            Assert.That(((long)value).IsPrime(), Is.EqualTo(expected));
            Assert.That(((BigInteger)value).IsPrime(), Is.EqualTo(expected));

            Assert.That(((ushort)value).IsPrime(), Is.EqualTo(expected));
            Assert.That(((uint)value).IsPrime(), Is.EqualTo(expected));
            Assert.That(((ulong)value).IsPrime(), Is.EqualTo(expected));

            if (value < sbyte.MaxValue)
            {
                Assert.That(((sbyte)value).IsPrime(), Is.EqualTo(expected));
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
