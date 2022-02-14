using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X10D.Tests.Core
{
    /// <summary>
    ///     Tests for <see cref="BooleanExtensions" />.
    /// </summary>
    [TestClass]
    public class BooleanTests
    {
        /// <summary>
        ///     Tests <see cref="BooleanExtensions.GetBytes" />.
        /// </summary>
        [TestMethod]
        public void GetBytes()
        {
            const bool trueValue = true;
            const bool falseValue = false;

            var trueBytes = new byte[] { 0x01 };
            var falseBytes = new byte[] { 0x00 };

            var trueResult = trueValue.GetBytes();
            var falseResult = falseValue.GetBytes();

            CollectionAssert.AreEqual(trueBytes, trueResult);
            CollectionAssert.AreEqual(falseBytes, falseResult);
        }
    }
}
