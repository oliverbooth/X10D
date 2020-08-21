namespace X10D.Tests.Core
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///     Tests for <see cref="ComparableExtensions" />.
    /// </summary>
    [TestClass]
    public class ComparableTests
    {
        /// <summary>
        ///     Tests for <see cref="ComparableExtensions.Between{T}" />.
        /// </summary>
        [TestMethod]
        public void Between()
        {
            Assert.IsFalse(1.Between(2, 4));
            Assert.IsTrue(3.Between(2, 4));
            Assert.IsFalse(5.Between(2, 4));
        }

        /// <summary>
        ///     Tests for <see cref="ComparableExtensions.Outside{T}" />.
        /// </summary>
        [TestMethod]
        public void Outside()
        {
            Assert.IsTrue(1.Outside(2, 4));
            Assert.IsFalse(3.Outside(2, 4));
            Assert.IsTrue(5.Outside(2, 4));
        }
    }
}
