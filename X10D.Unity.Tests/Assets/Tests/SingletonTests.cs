using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace X10D.Unity.Tests
{
    public class SingletonTests
    {
        [UnityTest]
        public IEnumerator Singleton_ShouldReturnNewInstance_WhenNoInstanceExists()
        {
            TestBehaviour instance = Singleton<TestBehaviour>.Instance;
            Assert.IsTrue(instance);
            Assert.IsTrue(instance.Flag);

            yield break;
        }

        [UnityTest]
        public IEnumerator Singleton_ShouldReturnSameInstance_WhenAccessedTwice()
        {
            TestBehaviour instance = Singleton<TestBehaviour>.Instance;
            Assert.IsTrue(instance);
            Assert.AreEqual(instance, Singleton<TestBehaviour>.Instance);

            yield break;
        }

        [UnityTest]
        public IEnumerator Singleton_ShouldReturnNewInstance_WhenDestroyed()
        {
            TestBehaviour instance = Singleton<TestBehaviour>.Instance;
            Assert.IsTrue(instance);
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
