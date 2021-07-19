using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X10D.Tests.Core
{
    /// <summary>
    ///     Tests for <see cref="ByteExtensions" />.
    /// </summary>
    [TestClass]
    public class ByteTests
    {
        /// <summary>
        ///     Tests for <see cref="ByteExtensions.AsString" />.
        /// </summary>
        [TestMethod]
        public void AsString()
        {
            byte[] a = { 0x00, 0x73, 0xc6, 0xff };
            Assert.AreEqual("00-73-C6-FF", a.AsString());
        }

        /// <summary>
        ///     Tests for <see cref="ByteExtensions.GetInt16" />.
        /// </summary>
        [TestMethod]
        public void GetInt16()
        {
            byte[] a = { 0xF3, 0x3F };
            Assert.AreEqual(16371, a.GetInt16());
        }

        /// <summary>
        ///     Tests for <see cref="ByteExtensions.GetInt32" />.
        /// </summary>
        [TestMethod]
        public void GetInt32()
        {
            byte[] a = { 0xB0, 0x0B, 0x13, 0x5F };
            Assert.AreEqual(1595083696, a.GetInt32());
        }

        /// <summary>
        ///     Tests for <see cref="ByteExtensions.GetInt64" />.
        /// </summary>
        [TestMethod]
        public void GetInt64()
        {
            byte[] a = { 0xB0, 0x0B, 0x13, 0x50, 0x05, 0x31, 0xB0, 0x0B };
            Assert.AreEqual(842227029206305712L, a.GetInt64());
        }

        /// <summary>
        ///     Tests for <see cref="ByteExtensions.GetString(IEnumerable{byte})" />.
        /// </summary>
        [TestMethod]
        public void GetString()
        {
            byte[] a = { 0x48, 0xc3, 0xa9, 0x6c, 0x6c, 0x6f, 0x20, 0x57, 0x6f, 0x72, 0x6c, 0x64 };
            Assert.AreEqual("H\u00e9llo World", a.GetString());
        }

        /// <summary>
        ///     Tests for <see cref="ByteExtensions.GetString(IEnumerable{byte}, Encoding)" />.
        /// </summary>
        [TestMethod]
        public void GetStringAscii()
        {
            byte[] a = { 0x48, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x57, 0x6f, 0x72, 0x6c, 0x64 };
            Assert.AreEqual("Hello World", a.GetString(Encoding.ASCII));
        }

        /// <summary>
        ///     Tests for <see cref="ByteExtensions.GetUInt16" />.
        /// </summary>
        [TestMethod]
        public void GetUInt16()
        {
            byte[] a = { 0xF3, 0x3F };
            Assert.AreEqual(16371, a.GetUInt16());
        }

        /// <summary>
        ///     Tests for <see cref="ByteExtensions.GetUInt32" />.
        /// </summary>
        [TestMethod]
        public void GetUInt32()
        {
            byte[] a = { 0xB0, 0x0B, 0x13, 0x5F };
            Assert.AreEqual(1595083696U, a.GetUInt32());
        }

        /// <summary>
        ///     Tests for <see cref="ByteExtensions.GetUInt64" />.
        /// </summary>
        [TestMethod]
        public void GetUInt64()
        {
            byte[] a = { 0xB0, 0x0B, 0x13, 0x50, 0x05, 0x31, 0xB0, 0x0B };
            Assert.AreEqual(842227029206305712UL, a.GetUInt64());
        }
    }
}
