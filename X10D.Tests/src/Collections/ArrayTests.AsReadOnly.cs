using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;

namespace X10D.Tests.Collections;

public partial class ArrayTests
{
    [TestClass]
    public class AsReadOnlyTests
    {
        [TestMethod]
        public void AsReadOnly_ShouldReturnReadOnlyCollection_WhenArrayIsNotNull()
        {
            int[] array = {1, 2, 3};
            IReadOnlyCollection<int> result = array.AsReadOnly();
            Assert.IsInstanceOfType(result, typeof(IReadOnlyCollection<int>));
        }

        [TestMethod]
        public void AsReadOnly_ShouldThrowArgumentNullException_WhenArrayIsNull()
        {
            int[]? array = null;
            Assert.ThrowsException<ArgumentNullException>(() => array!.AsReadOnly());
        }

        [TestMethod]
        public void AsReadOnly_ShouldReturnCorrectCount_WhenArrayIsNotEmpty()
        {
            int[] array = {1, 2, 3};
            IReadOnlyCollection<int> result = array.AsReadOnly();
            Assert.AreEqual(array.Length, result.Count);
        }

        [TestMethod]
        public void AsReadOnly_ShouldReturnEmptyCollection_WhenArrayIsEmpty()
        {
            int[] array = Array.Empty<int>();
            IReadOnlyCollection<int> result = array.AsReadOnly();
            Assert.AreEqual(0, result.Count);
        }
    }
}
