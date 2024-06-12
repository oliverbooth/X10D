using NUnit.Framework;
using X10D.Collections;

namespace X10D.Tests.Collections;

internal static partial class ArrayTests
{
    [TestFixture]
    public class ClearTests
    {
        [Test]
        public void Clear_ShouldClearTheArray()
        {
            var array = new int?[] {1, 2, 3, null, 4};

            array.Clear();

            Assert.That(array.All(x => x == null));
        }

        [Test]
        public void Clear_ShouldDoNothing_WhenArrayIsEmpty()
        {
            int[] array = Array.Empty<int>();
            array.Clear();
        }

        [Test]
        public void Clear_WithRange_ShouldClearTheSpecifiedRangeOfTheArray()
        {
            var array = new int?[] {1, 2, 3, null, 4};

            array.Clear(1..4);

            Assert.That(array.Length, Is.EqualTo(5));
            Assert.That(array[0], Is.EqualTo(1));
            Assert.That(array[4], Is.EqualTo(4));
            Assert.That(array[1..4].All(x => x == null));
        }

        [Test]
        public void Clear_WithIndexAndLength_ShouldClearTheSpecifiedRangeOfTheArray()
        {
            var array = new int?[] {1, 2, 3, null, 4};

            array.Clear(1, 3);

            Assert.That(array.Length, Is.EqualTo(5));
            Assert.That(array[0], Is.EqualTo(1));
            Assert.That(array[4], Is.EqualTo(4));
            Assert.That(array[1..4].All(x => x == null));
        }

        [Test]
        public void Clear_ShouldThrowArgumentNullException_WhenArrayIsNull()
        {
            int[] array = null!;
            Assert.Throws<ArgumentNullException>(() => array.Clear());
            Assert.Throws<ArgumentNullException>(() => array.Clear(0, 1));
            Assert.Throws<ArgumentNullException>(() => array.Clear(..1));
        }
    }
}
