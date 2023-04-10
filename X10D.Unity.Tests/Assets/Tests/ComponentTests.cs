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
        [Test]
        public void GetComponentsInChildrenOnly_ShouldIgnoreParent()
        {
            var parent = new GameObject();
            var rigidbody = parent.AddComponent<Rigidbody>();

            var child = new GameObject();
            child.AddComponent<Rigidbody>();

            Rigidbody[] components = rigidbody.GetComponentsInChildrenOnly<Rigidbody>();
            Assert.That(components, Has.Length.EqualTo(1));
            Assert.That(child, Is.EqualTo(components[0].gameObject));

            Object.Destroy(parent);
            Object.Destroy(child);
        }
    }
}
