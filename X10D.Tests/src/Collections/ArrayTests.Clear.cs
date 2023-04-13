using NUnit.Framework;
using X10D.Collections;

namespace X10D.Tests.Collections;

public partial class ArrayTests
{
    [TestFixture]
    public class ClearTests
    {
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
        public void Clear_ShouldThrowArgumentNullException_WhenArrayIsNull()
        {
            int[] array = null!;
            Assert.Throws<ArgumentNullException>(() => array.Clear(..1));
        }
    }
}
