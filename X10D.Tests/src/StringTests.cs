namespace X10D.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for <see cref="StringExtensions"/>.
    /// </summary>
    [TestClass]
    public class StringTests
    {
        /// <summary>
        /// Tests for <see cref="StringExtensions.Repeat"/>.
        /// </summary>
        [TestMethod]
        public void Repeat()
        {
            Assert.AreEqual("foofoofoofoofoo", "foo".Repeat(5));
        }

        /// <summary>
        /// Tests for <see cref="StringExtensions.Split"/>.
        /// </summary>
        [TestMethod]
        public void Split()
        {
            const string str = "Hello World";

            // ReSharper disable once SuggestVarOrType_Elsewhere
            var arr = str.Split(2).ToArray();
            CollectionAssert.AreEqual(new[] { "He", "ll", "o ", "Wo", "rl", "d" }, arr);
        }
    }
}
