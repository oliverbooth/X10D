#nullable enable

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

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
            child.AddComponent<Rigidbody>();

            yield return null;

            Rigidbody[] components = rigidbody.GetComponentsInChildrenOnly<Rigidbody>();
            Assert.That(components, Has.Length.EqualTo(1));
            Assert.That(child, Is.EqualTo(components[0].gameObject));

            Object.Destroy(parent);
            Object.Destroy(child);
        }
    }
}
