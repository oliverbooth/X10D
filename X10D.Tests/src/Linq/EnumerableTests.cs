using NUnit.Framework;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestFixture]
public class EnumerableTests
{
    [Test]
    public void ConcatOne_ShouldReturnConcatenatedSequence_GivenValidSequenceAndValue()
    {
        IEnumerable<string> source = new[] {"Hello"};
        string[] expected = {"Hello", "World"};

        string[] actual = source.ConcatOne("World").ToArray();

        Assert.That(actual, Has.Length.EqualTo(2));
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void ConcatOne_ShouldReturnSingletonSequence_GivenEmptySequenceAndValidValue()
    {
        IEnumerable<string> source = Enumerable.Empty<string>();
        string[] expected = {"Foobar"};

        string[] actual = source.ConcatOne("Foobar").ToArray();

        Assert.That(actual, Has.Length.EqualTo(1));
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void ConcatOne_ShouldThrowArgumentNullException_GivenNullSource()
    {
        IEnumerable<string>? source = null;
        Assert.Throws<ArgumentNullException>(() => source!.ConcatOne("Foobar").ToArray());
    }

    [Test]
    public void Except_ShouldFilterElements_GivenMatchingElements()
    {
        int[] source = Enumerable.Range(1, 10).ToArray();
        int[] result = source.Except(5).ToArray();

        Assert.That(result, Is.EquivalentTo(new[] {1, 2, 3, 4, 6, 7, 8, 9, 10}));
    }

    [Test]
    public void Except_ShouldReturnSameElements_GivenNoMatchingElements()
    {
        int[] source = Enumerable.Range(1, 10).ToArray();
        int[] result = source.Except(11).ToArray();

        Assert.That(result, Is.EquivalentTo(source));
    }

    [Test]
    public void Except_ShouldThrowArgumentNullException_GivenNullSource()
    {
        IEnumerable<int> source = null!;
        Assert.Throws<ArgumentNullException>(() => source.Except(42));
    }

    [Test]
    public void MinMax_ShouldReturnCorrectValues_UsingDefaultComparer()
    {
        IEnumerable<int> source = Enumerable.Range(1, 10);
        (int minimum, int maximum) = source.MinMax();
        Assert.Multiple(() =>
        {
            Assert.That(minimum, Is.EqualTo(1));
            Assert.That(maximum, Is.EqualTo(10));
        });

        source = Enumerable.Range(1, 10).ToArray();
        (minimum, maximum) = source.MinMax();
        Assert.Multiple(() =>
        {
            Assert.That(minimum, Is.EqualTo(1));
            Assert.That(maximum, Is.EqualTo(10));
        });
    }

    [Test]
    public void MinMax_ShouldReturnCorrectSelectedValues_UsingDefaultComparer()
    {
        IEnumerable<Person> source = Enumerable.Range(1, 10).Select(i => new Person {Age = i});
        (int minimum, int maximum) = source.MinMax(p => p.Age);
        Assert.Multiple(() =>
        {
            Assert.That(minimum, Is.EqualTo(1));
            Assert.That(maximum, Is.EqualTo(10));
        });

        source = Enumerable.Range(1, 10).Select(i => new Person {Age = i}).ToArray();
        (minimum, maximum) = source.MinMax(p => p.Age);
        Assert.Multiple(() =>
        {
            Assert.That(minimum, Is.EqualTo(1));
            Assert.That(maximum, Is.EqualTo(10));
        });
    }

    [Test]
    public void MinMax_ShouldReturnOppositeSelectedValues_UsingInverseComparer()
    {
        IEnumerable<Person> source = Enumerable.Range(1, 10).Select(i => new Person {Age = i});
        (int minimum, int maximum) = source.MinMax(p => p.Age, new InverseComparer<int>());
        Assert.Multiple(() =>
        {
            Assert.That(minimum, Is.EqualTo(10));
            Assert.That(maximum, Is.EqualTo(1));
        });

        source = Enumerable.Range(1, 10).Select(i => new Person {Age = i}).ToArray();
        (minimum, maximum) = source.MinMax(p => p.Age, new InverseComparer<int>());
        Assert.Multiple(() =>
        {
            Assert.That(minimum, Is.EqualTo(10));
            Assert.That(maximum, Is.EqualTo(1));
        });
    }

    [Test]
    public void MinMax_ShouldReturnOppositeValues_UsingInverseComparer()
    {
        (int minimum, int maximum) = Enumerable.Range(1, 10).MinMax(new InverseComparer<int>());
        Assert.Multiple(() =>
        {
            Assert.That(minimum, Is.EqualTo(10));
            Assert.That(maximum, Is.EqualTo(1));
        });

        (minimum, maximum) = Enumerable.Range(1, 10).ToArray().MinMax(new InverseComparer<int>());
        Assert.Multiple(() =>
        {
            Assert.That(minimum, Is.EqualTo(10));
            Assert.That(maximum, Is.EqualTo(1));
        });
    }

    [Test]
    public void MinMax_ShouldThrowArgumentNullException_GivenNullSelector()
    {
        IEnumerable<int> source = Enumerable.Empty<int>();
        Assert.Throws<ArgumentNullException>(() => source.MinMax((Func<int, int>)(null!)));
        Assert.Throws<ArgumentNullException>(() => source.MinMax((Func<int, int>)(null!), null));
    }

    [Test]
    public void MinMax_ShouldThrowArgumentNullException_GivenNullSource()
    {
        IEnumerable<int>? source = null;
        Assert.Throws<ArgumentNullException>(() => source!.MinMax());
        Assert.Throws<ArgumentNullException>(() => source!.MinMax(v => v));
        Assert.Throws<ArgumentNullException>(() => source!.MinMax(null));
        Assert.Throws<ArgumentNullException>(() => source!.MinMax(v => v, null));
    }

    [Test]
    public void MinMax_ShouldThrowInvalidOperationException_GivenEmptySource()
    {
        Assert.Throws<InvalidOperationException>(() => Enumerable.Empty<int>().MinMax());
        Assert.Throws<InvalidOperationException>(() => Array.Empty<int>().MinMax());
        Assert.Throws<InvalidOperationException>(() => new List<int>().MinMax());

        Assert.Throws<InvalidOperationException>(() => Enumerable.Empty<int>().MinMax(i => i * 2));
        Assert.Throws<InvalidOperationException>(() => Array.Empty<int>().MinMax(i => i * 2));
        Assert.Throws<InvalidOperationException>(() => new List<int>().MinMax(i => i * 2));
    }

    [Test]
    public void MinMaxBy_ShouldReturnCorrectSelectedValues_UsingDefaultComparer()
    {
        IEnumerable<Person> source = Enumerable.Range(1, 10).Select(i => new Person {Age = i});
        (Person minimum, Person maximum) = source.MinMaxBy(p => p.Age);
        Assert.Multiple(() =>
        {
            Assert.That(minimum.Age, Is.EqualTo(1));
            Assert.That(maximum.Age, Is.EqualTo(10));
        });

        source = Enumerable.Range(1, 10).Select(i => new Person {Age = i}).ToArray();
        (minimum, maximum) = source.MinMaxBy(p => p.Age);
        Assert.Multiple(() =>
        {
            Assert.That(minimum.Age, Is.EqualTo(1));
            Assert.That(maximum.Age, Is.EqualTo(10));
        });
    }

    [Test]
    public void MinMaxBy_ShouldReturnOppositeSelectedValues_UsingInverseComparer()
    {
        IEnumerable<Person> source = Enumerable.Range(1, 10).Select(i => new Person {Age = i});
        (Person minimum, Person maximum) = source.MinMaxBy(p => p.Age, new InverseComparer<int>());
        Assert.Multiple(() =>
        {
            Assert.That(minimum.Age, Is.EqualTo(10));
            Assert.That(maximum.Age, Is.EqualTo(1));
        });

        source = Enumerable.Range(1, 10).Select(i => new Person {Age = i}).ToArray();
        (minimum, maximum) = source.MinMaxBy(p => p.Age, new InverseComparer<int>());
        Assert.Multiple(() =>
        {
            Assert.That(minimum.Age, Is.EqualTo(10));
            Assert.That(maximum.Age, Is.EqualTo(1));
        });
    }

    [Test]
    public void MinMaxBy_ShouldThrowArgumentNullException_GivenNullSelector()
    {
        Person[] source = Enumerable.Range(1, 10).Select(i => new Person {Age = i}).ToArray();

        Assert.Throws<ArgumentNullException>(() => source.MinMaxBy((Func<Person, int>)null!));
        Assert.Throws<ArgumentNullException>(() => source.MinMaxBy((Func<Person, int>)null!, null));
    }

    [Test]
    public void MinMaxBy_ShouldThrowArgumentNullException_GivenNullSource()
    {
        IEnumerable<Person>? source = null;
        Assert.Throws<ArgumentNullException>(() => source!.MinMaxBy(p => p.Age));
        Assert.Throws<ArgumentNullException>(() => source!.MinMaxBy(p => p.Age, null));
    }

    [Test]
    public void MinMaxBy_ShouldThrowInvalidOperationException_GivenEmptySource()
    {
        Assert.Throws<InvalidOperationException>(() =>
        {
            IEnumerable<Person> source = Enumerable.Empty<Person>();
            _ = source.MinMaxBy(p => p.Age);
        });

        Assert.Throws<InvalidOperationException>(() =>
        {
            Person[] source = Array.Empty<Person>();
            _ = source.MinMaxBy(p => p.Age);
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
                : throw new ArgumentException(ExceptionMessages.ObjectIsNotAValidType);
        }
    }
}
