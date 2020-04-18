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

        /// <summary>
        /// Tests for <see cref="BooleanExtensions.ToByte"/>.
        /// </summary>
        [TestMethod]
        public void ToByte()
        {
            const bool a = true;
            const bool b = false;
            const byte c = 1;
            const byte d = 0;

            Assert.IsTrue(a);
            Assert.IsFalse(b);
            Assert.AreEqual(c, a.ToByte());
            Assert.AreEqual(d, b.ToByte());
        }

        /// <summary>
        /// Tests for <see cref="BooleanExtensions.Not"/>.
        /// </summary>
        [TestMethod]
        public void Not()
        {
            bool a = true;
            bool b = false;

            Assert.IsTrue(a);
            Assert.IsFalse(b);
            Assert.IsFalse(a.Not());
            Assert.IsTrue(b.Not());
        }

        /// <summary>
        /// Tests for <see cref="BooleanExtensions.And"/>.
        /// </summary>
        [TestMethod]
        public void And()
        {
            const bool a = true;
            const bool b = true;
            const bool c = false;
            const bool d = false;

            Assert.IsTrue(a);
            Assert.IsTrue(b);
            Assert.IsFalse(c);
            Assert.IsFalse(d);

            Assert.IsTrue(a.And(b));
            Assert.IsFalse(b.And(c));
            Assert.IsFalse(c.And(d));
        }

        /// <summary>
        /// Tests for <see cref="BooleanExtensions.Or"/>.
        /// </summary>
        [TestMethod]
        public void Or()
        {
            const bool a = true;
            const bool b = true;
            const bool c = false;
            const bool d = false;

            Assert.IsTrue(a);
            Assert.IsTrue(b);
            Assert.IsFalse(c);
            Assert.IsFalse(d);

            Assert.IsTrue(a.Or(b));
            Assert.IsTrue(b.Or(c));
            Assert.IsFalse(c.Or(d));
        }

        /// <summary>
        /// Tests for <see cref="BooleanExtensions.Xor"/>.
        /// </summary>
        [TestMethod]
        public void Xor()
        {
            const bool a = true;
            const bool b = true;
            const bool c = false;
            const bool d = false;

            Assert.IsTrue(a);
            Assert.IsTrue(b);
            Assert.IsFalse(c);
            Assert.IsFalse(d);

            Assert.IsFalse(a.XOr(b));
            Assert.IsTrue(b.XOr(c));
            Assert.IsFalse(c.XOr(d));
        }

        /// <summary>
        /// Tests for <see cref="BooleanExtensions.NAnd"/>.
        /// </summary>
        [TestMethod]
        public void NAnd()
        {
            const bool a = true;
            const bool b = true;
            const bool c = false;
            const bool d = false;

            Assert.IsTrue(a);
            Assert.IsTrue(b);
            Assert.IsFalse(c);
            Assert.IsFalse(d);

            Assert.IsFalse(a.NAnd(b));
            Assert.IsTrue(b.NAnd(c));
            Assert.IsTrue(c.NAnd(d));
        }

        /// <summary>
        /// Tests for <see cref="BooleanExtensions.NOr"/>.
        /// </summary>
        [TestMethod]
        public void NOr()
        {
            const bool a = true;
            const bool b = true;
            const bool c = false;
            const bool d = false;

            Assert.IsTrue(a);
            Assert.IsTrue(b);
            Assert.IsFalse(c);
            Assert.IsFalse(d);

            Assert.IsFalse(a.NOr(b));
            Assert.IsFalse(b.NOr(c));
            Assert.IsTrue(c.NOr(d));
        }

        /// <summary>
        /// Tests for <see cref="BooleanExtensions.NOr"/>.
        /// </summary>
        [TestMethod]
        public void XNOr()
        {
            const bool a = true;
            const bool b = true;
            const bool c = false;
            const bool d = false;

            Assert.IsTrue(a);
            Assert.IsTrue(b);
            Assert.IsFalse(c);
            Assert.IsFalse(d);

            Assert.IsTrue(a.XNOr(b));
            Assert.IsFalse(b.XNOr(c));
            Assert.IsTrue(c.XNOr(d));
        }
    }
}
