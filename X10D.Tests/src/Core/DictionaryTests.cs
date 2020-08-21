namespace X10D.Tests.Core
{
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///     Tests for <see cref="DictionaryExtensions" />.
    /// </summary>
    [TestClass]
    public class DictionaryTests
    {
        /// <summary>
        ///     Tests for <see cref="DictionaryExtensions.ToConnectionString{T1,T2}(IEnumerable{KeyValuePair{T1, T2}})" />.
        /// </summary>
        [TestMethod]
        public void ToConnectionString()
        {
            IReadOnlyDictionary<string, object> dictionary = new Dictionary<string, object>
            {
                { "username", "Foo" }, { "password", "Foo Bar" }, { "port", 3306 },
            };

            var connectionString = dictionary.ToConnectionString();
            Assert.AreEqual("username=Foo;password=\"Foo Bar\";port=3306", connectionString);
        }

        /// <summary>
        ///     Tests for <see cref="DictionaryExtensions.ToGetParameters{T1,T2}(IEnumerable{KeyValuePair{T1, T2}})" />.
        /// </summary>
        [TestMethod]
        public void ToGetParameters()
        {
            var dictionary = new Dictionary<string, object>
            {
                { "username", "Foo" }, { "password", "Foo Bar" }, { "port", 3306 },
            };

            var getParameterString = dictionary.ToGetParameters();
            Assert.AreEqual("username=Foo&password=Foo+Bar&port=3306", getParameterString);
        }

        /// <summary>
        ///     Tests for <see cref="DictionaryExtensions.ToGetParameters{T1,T2}(IEnumerable{KeyValuePair{T1, T2}})" />.
        /// </summary>
        [TestMethod]
        public void ToGetParametersSeparator()
        {
            var dictionary = new Dictionary<string, IEnumerable>
            {
                { "username", "Foo" }, { "password", "Foo Bar" }, { "port", new[] { 3, 3, 0, 6 } },
            };

            var getParameterString = dictionary.ToGetParameters(",");
            Assert.AreEqual("username=F%2co%2co&password=F%2co%2co%2c+%2cB%2ca%2cr&port=3%2c3%2c0%2c6", getParameterString);
        }
    }
}
