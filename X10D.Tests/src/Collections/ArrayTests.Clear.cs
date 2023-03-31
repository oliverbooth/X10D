using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;

namespace X10D.Tests.Collections;

public partial class ArrayTests
{
    [TestClass]
    public class ClearTests
    {
        [TestMethod]
        public void Clear_ShouldClearTheArray()
        {
            var array = new int?[] {1, 2, 3, null, 4};

            array.Clear();

            Assert.IsTrue(array.All(x => x == null));
        }

        [TestMethod]
        public void Clear_ShouldDoNothing_WhenArrayIsEmpty()
        {
            int[] array = Array.Empty<int>();
            array.Clear();
        }

        [TestMethod]
        public void Clear_WithRange_ShouldClearTheSpecifiedRangeOfTheArray()
        {
            var array = new int?[] {1, 2, 3, null, 4};

            array.Clear(1..4);

            Assert.AreEqual(5, array.Length);
            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(4, array[4]);
            Assert.IsTrue(array[1..4].All(x => x == null));
        }

        [TestMethod]
        public void Clear_WithIndexAndLength_ShouldClearTheSpecifiedRangeOfTheArray()
        {
            var array = new int?[] {1, 2, 3, null, 4};

            array.Clear(1, 3);

            Assert.AreEqual(5, array.Length);
            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(4, array[4]);
            Assert.IsTrue(array[1..4].All(x => x == null));
        }

        [TestMethod]
        public void Clear_ShouldThrowArgumentNullException_WhenArrayIsNull()
        {
            int[]? array = null;
            Assert.ThrowsException<ArgumentNullException>(array!.Clear);
        }
    }
}
