using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X10D.Tests.Core
{
    /// <summary>
    ///     Tests for <see cref="CharExtensions" />.
    /// </summary>
    [TestClass]
    public class CharTests
    {
        [TestMethod]
        public void Repeat()
        {
            const char character = 'a';
            const int repeatCount = 10;

            const string repeated = "aaaaaaaaaa";
            string result = character.Repeat(repeatCount);

            Assert.AreEqual(repeated, result);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => character.Repeat(-1));
        }
    }
}
