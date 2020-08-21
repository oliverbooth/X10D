namespace X10D.Tests.Core
{
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
    }
}
