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
            Assert.IsTrue(5.Between(2, 7));
            Assert.IsTrue(10.Between(9, 11));
            Assert.IsFalse(100.Between(80, 99));
        }
    }
}
