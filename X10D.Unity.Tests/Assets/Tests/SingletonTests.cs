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
            Assert.That(instance, Is.Not.Null);
            Assert.That(instance.Flag);
        }

        [Test]
        public void Singleton_ShouldReturnSameInstance_WhenAccessedTwice()
        {
            TestBehaviour instance = Singleton<TestBehaviour>.Instance;
            Assert.That(instance, Is.Not.Null);
            Assert.That(Singleton<TestBehaviour>.Instance, Is.EqualTo(instance));
        }

        [UnityTest]
        public IEnumerator Singleton_ShouldReturnNewInstance_WhenDestroyed()
        {
            TestBehaviour instance = Singleton<TestBehaviour>.Instance;
            Assert.That(instance, Is.Not.Null);
            Object.Destroy(instance);

            yield return null;

            Assert.IsFalse(instance);

            // ReSharper disable once HeuristicUnreachableCode
            instance = Singleton<TestBehaviour>.Instance;
            Assert.That(instance, Is.Not.Null);
            Assert.IsTrue(instance.Flag);
        }
    }
}
