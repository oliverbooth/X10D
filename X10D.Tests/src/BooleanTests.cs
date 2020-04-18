namespace X10D.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for <see cref="BooleanExtensions"/>.
    /// </summary>
    [TestClass]
    public class BooleanTests
    {
        /// <summary>
        /// Tests for <see cref="BooleanExtensions.ToInt32"/>.
        /// </summary>
        [TestMethod]
        public void ToInt32()
        {
            const bool a = true;
            const bool b = false;

            Assert.IsTrue(a);
            Assert.IsFalse(b);
            Assert.AreEqual(1, a.ToInt32());
            Assert.AreEqual(0, b.ToInt32());
        }
    }
}
