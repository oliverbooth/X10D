using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X10D.Tests.Core
{
    /// <summary>
    ///     Tests for <see cref="CharExtensions" />.
    /// </summary>
    [TestClass]
    public class CharTests
    {
        /// <summary>
        ///     Tests for <see cref="CharExtensions.Repeat" />.
        /// </summary>
        [TestMethod]
        public void Random()
        {
            var set = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            var random = set.Random(20);

            Assert.IsTrue(random.All(c => Array.IndexOf(set, c) >= 0));
            Assert.IsFalse(random.Any(c => Array.IndexOf(set, c) < -1));
        }

        /// <summary>
        ///     Tests for <see cref="CharExtensions.Repeat" />.
        /// </summary>
        [TestMethod]
        public void Repeat()
        {
            Assert.AreEqual("aaaaaaaaaa", 'a'.Repeat(10));
        }
    }
}
