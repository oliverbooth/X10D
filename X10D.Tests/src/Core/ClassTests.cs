namespace X10D.Tests.Core
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///     Tests for <see cref="ClassExtensions" />.
    /// </summary>
    [TestClass]
    public class ClassTests
    {
        /// <summary>
        ///     Tests for <see cref="ClassExtensions.PropertiesEquals{T}" />.
        /// </summary>
        [TestMethod]
        public void PropertiesEquals()
        {
            var a = new TempClass
            {
                PropBool = true,
                PropInt = 1,
                InnerClass = new TempClass
                {
                    PropBool = false,
                    PropInt = 0,
                },
            };
            var b = new TempClass
            {
                PropBool = true,
                PropInt = 1,
                InnerClass = new TempClass
                {
                    PropBool = false,
                    PropInt = 0,
                },
            };
            Assert.IsTrue(a.PropertiesEquals(b));
        }

        /// <summary>
        ///     Tests for <see cref="ClassExtensions.FieldsEquals{T}" />.
        /// </summary>
        [TestMethod]
        public void FieldsEquals()
        {
            var a = new TempClass
            {
                FieldBool = false,
                FieldInt = 0,
                InnerClass = new TempClass
                {
                    FieldBool = true,
                    FieldInt = 1,
                },
            };
            var b = new TempClass
            {
                FieldBool = false,
                FieldInt = 0,
                InnerClass = new TempClass
                {
                    FieldBool = true,
                    FieldInt = 1,
                },
            };
            Assert.IsTrue(a.FieldsEquals(b));
        }

        [Serializable]
        private class TempClass
        {
            public int FieldInt;
            public bool FieldBool;

            public int PropInt { get; set; }

            public bool PropBool { get; set; }

            public TempClass InnerClass { get; set; }
        }
    }
}
