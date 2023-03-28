using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestClass]
public class EnumerableTests
{
    [TestMethod]
    public void MinMax_ShouldReturnCorrectValues_UsingDefaultComparer()
    {
        IEnumerable<int> source = Enumerable.Range(1, 10);
        (int minimum, int maximum) = source.MinMax();
        Assert.AreEqual(1, minimum);
        Assert.AreEqual(10, maximum);

        source = Enumerable.Range(1, 10).ToArray();
        (minimum, maximum) = source.MinMax();
        Assert.AreEqual(1, minimum);
        Assert.AreEqual(10, maximum);
    }

    [TestMethod]
    public void MinMax_ShouldReturnCorrectSelectedValues_UsingDefaultComparer()
    {
        IEnumerable<Person> source = Enumerable.Range(1, 10).Select(i => new Person {Age = i});
        (int minimum, int maximum) = source.MinMax(p => p.Age);
        Assert.AreEqual(1, minimum);
        Assert.AreEqual(10, maximum);

        source = Enumerable.Range(1, 10).Select(i => new Person {Age = i}).ToArray();
        (minimum, maximum) = source.MinMax(p => p.Age);
        Assert.AreEqual(1, minimum);
        Assert.AreEqual(10, maximum);
    }

    [TestMethod]
    public void MinMax_ShouldReturnOppositeSelectedValues_UsingInverseComparer()
    {
        IEnumerable<Person> source = Enumerable.Range(1, 10).Select(i => new Person {Age = i});
        (int minimum, int maximum) = source.MinMax(p => p.Age, new InverseComparer<int>());
        Assert.AreEqual(10, minimum);
        Assert.AreEqual(1, maximum);

        source = Enumerable.Range(1, 10).Select(i => new Person {Age = i}).ToArray();
        (minimum, maximum) = source.MinMax(p => p.Age, new InverseComparer<int>());
        Assert.AreEqual(10, minimum);
        Assert.AreEqual(1, maximum);
    }

    [TestMethod]
    public void MinMax_ShouldReturnOppositeValues_UsingInverseComparer()
    {
        (int minimum, int maximum) = Enumerable.Range(1, 10).MinMax(new InverseComparer<int>());
        Assert.AreEqual(10, minimum);
        Assert.AreEqual(1, maximum);

        (minimum, maximum) = Enumerable.Range(1, 10).ToArray().MinMax(new InverseComparer<int>());
        Assert.AreEqual(10, minimum);
        Assert.AreEqual(1, maximum);
    }

    [TestMethod]
    public void MinMax_ShouldThrowArgumentNullException_GivenNullSelector()
    {
        Assert.ThrowsException<ArgumentNullException>(() => Enumerable.Range(1, 10).MinMax((Func<int, int>?)null!));
        Assert.ThrowsException<ArgumentNullException>(() => Enumerable.Range(1, 10).ToArray().MinMax((Func<int, int>?)null!));
    }

    [TestMethod]
    public void MinMax_ShouldThrowArgumentNullException_GivenNullSource()
    {
        IEnumerable<int>? source = null;
        Assert.ThrowsException<ArgumentNullException>(() => source!.MinMax());
    }

    [TestMethod]
    public void MinMax_ShouldThrowInvalidOperationException_GivenEmptySource()
    {
        Assert.ThrowsException<InvalidOperationException>(() => Enumerable.Empty<int>().MinMax());
        Assert.ThrowsException<InvalidOperationException>(() => Array.Empty<int>().MinMax());
        Assert.ThrowsException<InvalidOperationException>(() => new List<int>().MinMax());

        Assert.ThrowsException<InvalidOperationException>(() => Enumerable.Empty<int>().MinMax(i => i * 2));
        Assert.ThrowsException<InvalidOperationException>(() => Array.Empty<int>().MinMax(i => i * 2));
        Assert.ThrowsException<InvalidOperationException>(() => new List<int>().MinMax(i => i * 2));
    }

    [TestMethod]
    public void MinMaxBy_ShouldReturnCorrectSelectedValues_UsingDefaultComparer()
    {
        IEnumerable<Person> source = Enumerable.Range(1, 10).Select(i => new Person {Age = i});
        (Person minimum, Person maximum) = source.MinMaxBy(p => p.Age);
        Assert.AreEqual(1, minimum.Age);
        Assert.AreEqual(10, maximum.Age);

        source = Enumerable.Range(1, 10).Select(i => new Person {Age = i}).ToArray();
        (minimum, maximum) = source.MinMaxBy(p => p.Age);
        Assert.AreEqual(1, minimum.Age);
        Assert.AreEqual(10, maximum.Age);
    }

    [TestMethod]
    public void MinMaxBy_ShouldReturnOppositeSelectedValues_UsingInverseComparer()
    {
        IEnumerable<Person> source = Enumerable.Range(1, 10).Select(i => new Person {Age = i});
        (Person minimum, Person maximum) = source.MinMaxBy(p => p.Age, new InverseComparer<int>());
        Assert.AreEqual(10, minimum.Age);
        Assert.AreEqual(1, maximum.Age);

        source = Enumerable.Range(1, 10).Select(i => new Person {Age = i}).ToArray();
        (minimum, maximum) = source.MinMaxBy(p => p.Age, new InverseComparer<int>());
        Assert.AreEqual(10, minimum.Age);
        Assert.AreEqual(1, maximum.Age);
    }

    [TestMethod]
    public void MinMaxBy_ShouldThrowArgumentNullException_GivenNullSelector()
    {
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            IEnumerable<Person> source = Enumerable.Range(1, 10).Select(i => new Person {Age = i});
            return source.MinMaxBy((Func<Person, int>?)null!);
        });

        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            Person[] source = Enumerable.Range(1, 10).Select(i => new Person {Age = i}).ToArray();
            return source.MinMaxBy((Func<Person, int>?)null!);
        });
    }

    [TestMethod]
    public void MinMaxBy_ShouldThrowArgumentNullException_GivenNullSource()
    {
        IEnumerable<Person>? source = null;
        Assert.ThrowsException<ArgumentNullException>(() => source!.MinMaxBy(p => p.Age));
    }

    [TestMethod]
    public void MinMaxBy_ShouldThrowInvalidOperationException_GivenEmptySource()
    {
        Assert.ThrowsException<InvalidOperationException>(() =>
        {
            IEnumerable<Person> source = Enumerable.Empty<Person>();
            return source.MinMaxBy(p => p.Age);
        });

        Assert.ThrowsException<InvalidOperationException>(() =>
        {
            Person[] source = Array.Empty<Person>();
            return source.MinMaxBy(p => p.Age);
        });
    }

    private struct InverseComparer<T> : IComparer<T> where T : IComparable<T>
    {
        public int Compare(T? x, T? y)
        {
            if (x is null)
            {
                return y is null ? 0 : 1;
            }

            return y is null ? -1 : y.CompareTo(x);
        }
    }

    private struct Person : IComparable<Person>, IComparable
    {
        public int Age { get; set; }

        public static bool operator <(Person left, Person right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Person left, Person right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Person left, Person right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(Person left, Person right)
        {
            return left.CompareTo(right) >= 0;
        }

        public int CompareTo(Person other)
        {
            return Age.CompareTo(other.Age);
        }

        public int CompareTo(object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return 1;
            }

            return obj is Person other
                ? CompareTo(other)
                : throw new ArgumentException($"Object must be of type {nameof(Person)}");
        }
    }
}
