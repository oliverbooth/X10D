using NUnit.Framework;
using X10D.Collections;

namespace X10D.Tests.Collections;

public partial class ArrayTests
{
    [TestFixture]
    public class AsReadOnlyTests
    {
        [Test]
        public void AsReadOnly_ShouldReturnReadOnlyCollection_WhenArrayIsNotNull()
        {
            int[] array = {1, 2, 3};
            IReadOnlyCollection<int> result = array.AsReadOnly();
            Assert.That(result, Is.InstanceOf<IReadOnlyCollection<int>>());
        }

        [Test]
        public void AsReadOnly_ShouldThrowArgumentNullException_WhenArrayIsNull()
        {
            int[] array = null!;
            Assert.Throws<ArgumentNullException>(() => _ = array.AsReadOnly());
        }

        [Test]
        public void AsReadOnly_ShouldReturnCorrectCount_WhenArrayIsNotEmpty()
        {
            int[] array = {1, 2, 3};
            IReadOnlyCollection<int> result = array.AsReadOnly();
            Assert.That(result, Has.Count.EqualTo(array.Length));
        }

        [Test]
        public void AsReadOnly_ShouldReturnEmptyCollection_WhenArrayIsEmpty()
        {
            int[] array = Array.Empty<int>();
            IReadOnlyCollection<int> result = array.AsReadOnly();
            Assert.That(result, Is.Empty);
        }
    }
}
