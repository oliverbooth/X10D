namespace X10D.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for <see cref="EnumerableExtensions"/>.
    /// </summary>
    [TestClass]
    public class EnumerableTests
    {
        /// <summary>
        /// Tests for <see cref="EnumerableExtensions.Split{T}"/> using an array of <see cref="byte"/>.
        /// </summary>
        [TestMethod]
        public void SplitByte()
        {
            byte[] foo = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
            IEnumerable<IEnumerable<byte>> chunks = foo.Split(2).ToArray();

            Assert.AreEqual(4, chunks.Count());
            CollectionAssert.AreEqual(new byte[] { 0x01, 0x02 }, chunks.ElementAt(0).ToList());
            CollectionAssert.AreEqual(new byte[] { 0x03, 0x04 }, chunks.ElementAt(1).ToList());
            CollectionAssert.AreEqual(new byte[] { 0x05, 0x06 }, chunks.ElementAt(2).ToList());
            CollectionAssert.AreEqual(new byte[] { 0x07, 0x08 }, chunks.ElementAt(3).ToList());

            // test exceeding chunk size
            chunks = foo.Split(foo.Length + 10).ToArray();
            Assert.AreEqual(1, chunks.Count());
            CollectionAssert.AreEqual(foo, chunks.SelectMany(c => c).ToList());
        }

        /// <summary>
        /// Tests for <see cref="EnumerableExtensions.Split{T}"/> using an array of <see cref="int"/>.
        /// </summary>
        [TestMethod]
        public void SplitInt32()
        {
            int[] foo = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
            IEnumerable<IEnumerable<int>> chunks = foo.Split(2).ToArray();

            Assert.AreEqual(4, chunks.Count());
            CollectionAssert.AreEqual(new[] { 0x01, 0x02 }, chunks.ElementAt(0).ToList());
            CollectionAssert.AreEqual(new[] { 0x03, 0x04 }, chunks.ElementAt(1).ToList());
            CollectionAssert.AreEqual(new[] { 0x05, 0x06 }, chunks.ElementAt(2).ToList());
            CollectionAssert.AreEqual(new[] { 0x07, 0x08 }, chunks.ElementAt(3).ToList());

            // test exceeding chunk size
            chunks = foo.Split(foo.Length + 10).ToArray();
            Assert.AreEqual(1, chunks.Count());
            CollectionAssert.AreEqual(foo, chunks.SelectMany(c => c).ToList());
        }
    }
}
