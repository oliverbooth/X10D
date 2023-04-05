#nullable enable

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace X10D.Unity.Tests
{
    public class ComponentTests
    {
        [UnityTest]
        public IEnumerator GetComponentsInChildrenOnly_ShouldIgnoreParent()
        {
            var parent = new GameObject();
            var rigidbody = parent.AddComponent<Rigidbody>();

            var child = new GameObject();
            child.transform.SetParent(parent.transform);
            child.AddComponent<Rigidbody>();

            Rigidbody[] components = rigidbody.GetComponentsInChildrenOnly<Rigidbody>();
            Assert.That(components.Length, Is.EqualTo(1));
            Assert.That(child, Is.EqualTo(components[0].gameObject));

            yield break;
        }
    }
}
