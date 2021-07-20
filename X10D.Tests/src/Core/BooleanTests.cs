using System;
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

        /// <summary>
        ///     Tests <see cref="BooleanExtensions.ToByte" />.
        /// </summary>
        [TestMethod]
        public void ToByte()
        {
            const bool trueValue = true;
            const bool falseValue = false;

            const byte trueByte = 1;
            const byte falseByte = 0;

            var trueResult = trueValue.ToByte();
            var falseResult = falseValue.ToByte();

            Assert.AreEqual(trueByte, trueResult);
            Assert.AreEqual(falseByte, falseResult);
        }

        /// <summary>
        ///     Tests <see cref="BooleanExtensions.ToDecimal" />.
        /// </summary>
        [TestMethod]
        public void ToDecimal()
        {
            const bool trueValue = true;
            const bool falseValue = false;

            const decimal trueDecimal = 1.0m;
            const decimal falseDecimal = 0.0m;

            var trueResult = trueValue.ToDecimal();
            var falseResult = falseValue.ToDecimal();

            Assert.AreEqual(trueDecimal, trueResult);
            Assert.AreEqual(falseDecimal, falseResult);
        }

        /// <summary>
        ///     Tests <see cref="BooleanExtensions.ToDouble" />.
        /// </summary>
        [TestMethod]
        public void ToDouble()
        {
            const bool trueValue = true;
            const bool falseValue = false;

            const double trueDouble = 1.0;
            const double falseDouble = 0.0;

            var trueResult = trueValue.ToDouble();
            var falseResult = falseValue.ToDouble();

            Assert.AreEqual(trueDouble, trueResult);
            Assert.AreEqual(falseDouble, falseResult);
        }

        /// <summary>
        ///     Tests <see cref="BooleanExtensions.ToInt16" />.
        /// </summary>
        [TestMethod]
        public void ToInt16()
        {
            const bool trueValue = true;
            const bool falseValue = false;

            const short trueInt16 = 1;
            const short falseInt16 = 0;

            var trueResult = trueValue.ToInt16();
            var falseResult = falseValue.ToInt16();

            Assert.AreEqual(trueInt16, trueResult);
            Assert.AreEqual(falseInt16, falseResult);
        }

        /// <summary>
        ///     Tests <see cref="BooleanExtensions.ToInt32" />.
        /// </summary>
        [TestMethod]
        public void ToInt32()
        {
            const bool trueValue = true;
            const bool falseValue = false;

            const int trueInt32 = 1;
            const int falseInt32 = 0;

            var trueResult = trueValue.ToInt32();
            var falseResult = falseValue.ToInt32();

            Assert.AreEqual(trueInt32, trueResult);
            Assert.AreEqual(falseInt32, falseResult);
        }

        /// <summary>
        ///     Tests <see cref="BooleanExtensions.ToInt64" />.
        /// </summary>
        [TestMethod]
        public void ToInt64()
        {
            const bool trueValue = true;
            const bool falseValue = false;

            const long trueInt64 = 1L;
            const long falseInt64 = 0L;

            var trueResult = trueValue.ToInt64();
            var falseResult = falseValue.ToInt64();

            Assert.AreEqual(trueInt64, trueResult);
            Assert.AreEqual(falseInt64, falseResult);
        }

        /// <summary>
        ///     Tests <see cref="BooleanExtensions.ToSByte" />.
        /// </summary>
        [TestMethod]
        public void ToSByte()
        {
            const bool trueValue = true;
            const bool falseValue = false;

            const sbyte trueByte = 1;
            const sbyte falseByte = 0;

            var trueResult = trueValue.ToSByte();
            var falseResult = falseValue.ToSByte();

            Assert.AreEqual(trueByte, trueResult);
            Assert.AreEqual(falseByte, falseResult);
        }

        /// <summary>
        ///     Tests <see cref="BooleanExtensions.ToSingle" />.
        /// </summary>
        [TestMethod]
        public void ToSingle()
        {
            const bool trueValue = true;
            const bool falseValue = false;

            const float trueSingle = 1.0f;
            const float falseSingle = 0.0f;

            var trueResult = trueValue.ToSingle();
            var falseResult = falseValue.ToSingle();

            Assert.AreEqual(trueSingle, trueResult);
            Assert.AreEqual(falseSingle, falseResult);
        }

        /// <summary>
        ///     Tests <see cref="BooleanExtensions.ToUInt16" />.
        /// </summary>
        [CLSCompliant(false)]
        [TestMethod]
        public void ToUInt16()
        {
            const bool trueValue = true;
            const bool falseValue = false;

            const ushort trueUInt16 = 1;
            const ushort falseUInt16 = 0;

            var trueResult = trueValue.ToUInt16();
            var falseResult = falseValue.ToUInt16();

            Assert.AreEqual(trueUInt16, trueResult);
            Assert.AreEqual(falseUInt16, falseResult);
        }

        /// <summary>
        ///     Tests <see cref="BooleanExtensions.ToUInt32" />.
        /// </summary>
        [CLSCompliant(false)]
        [TestMethod]
        public void ToUInt32()
        {
            const bool trueValue = true;
            const bool falseValue = false;

            const uint trueUInt32 = 1U;
            const uint falseUInt32 = 0U;

            var trueResult = trueValue.ToUInt32();
            var falseResult = falseValue.ToUInt32();

            Assert.AreEqual(trueUInt32, trueResult);
            Assert.AreEqual(falseUInt32, falseResult);
        }

        /// <summary>
        ///     Tests <see cref="BooleanExtensions.ToUInt64" />.
        /// </summary>
        [CLSCompliant(false)]
        [TestMethod]
        public void ToUInt64()
        {
            const bool trueValue = true;
            const bool falseValue = false;

            const ulong trueUInt64 = 1UL;
            const ulong falseUInt64 = 0UL;

            var trueResult = trueValue.ToUInt64();
            var falseResult = falseValue.ToUInt64();

            Assert.AreEqual(trueUInt64, trueResult);
            Assert.AreEqual(falseUInt64, falseResult);
        }
    }
}
