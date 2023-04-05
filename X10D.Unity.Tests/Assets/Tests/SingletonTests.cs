using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace X10D.Unity.Tests
{
    public class SingletonTests
    {
        [Test]
        public void Singleton_ShouldReturnNewInstance_WhenNoInstanceExists()
        {
            TestBehaviour instance = Singleton<TestBehaviour>.Instance;
            Assert.IsNotNull(instance);
            Assert.IsTrue(instance.Flag);
        }

        [Test]
        public void Singleton_ShouldReturnSameInstance_WhenAccessedTwice()
        {
            TestBehaviour instance = Singleton<TestBehaviour>.Instance;
            Assert.IsNotNull(instance);
            Assert.AreEqual(instance, Singleton<TestBehaviour>.Instance);
        }

        [UnityTest]
        public IEnumerator Singleton_ShouldReturnNewInstance_WhenDestroyed()
        {
            TestBehaviour instance = Singleton<TestBehaviour>.Instance;
            Assert.IsNotNull(instance);
            Object.Destroy(instance);

            yield return null;

            Assert.IsFalse(instance);

            // ReSharper disable once HeuristicUnreachableCode
            instance = Singleton<TestBehaviour>.Instance;
            Assert.IsNotNull(instance);
            Assert.IsTrue(instance.Flag);
        }
    }
}
