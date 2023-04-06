#nullable enable

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace X10D.Unity.Tests
{
    public class GameObjectTests
    {
        [UnityTest]
        public IEnumerator GetComponentsInChildrenOnly_ShouldIgnoreParent()
        {
            var parent = new GameObject();
            parent.AddComponent<Rigidbody>();

            var child = new GameObject();
            child.transform.SetParent(parent.transform);
            child.AddComponent<Rigidbody>();

            Rigidbody[] components = parent.GetComponentsInChildrenOnly<Rigidbody>();
            Assert.That(components.Length, Is.EqualTo(1));
            Assert.That(child, Is.EqualTo(components[0].gameObject));

            yield break;
        }

        [UnityTest]
        public IEnumerator LookAt_ShouldRotateSameAsTransform()
        {
            var first = new GameObject {transform = {position = Vector3.zero, rotation = Quaternion.identity}};
            var second = new GameObject {transform = {position = Vector3.right, rotation = Quaternion.identity}};
            Transform firstTransform = first.transform;
            Transform secondTransform = second.transform;

            Assert.That(firstTransform.rotation, Is.EqualTo(Quaternion.identity));
            Assert.That(secondTransform.rotation, Is.EqualTo(Quaternion.identity));

            firstTransform.LookAt(secondTransform);
            Quaternion expected = firstTransform.rotation;

            firstTransform.rotation = Quaternion.identity;
            Assert.That(firstTransform.rotation, Is.EqualTo(Quaternion.identity));

            first.LookAt(second);
            Assert.That(firstTransform.rotation, Is.EqualTo(expected));

            firstTransform.rotation = Quaternion.identity;
            Assert.That(firstTransform.rotation, Is.EqualTo(Quaternion.identity));

            first.LookAt(second.transform);
            Assert.That(firstTransform.rotation, Is.EqualTo(expected));

            firstTransform.rotation = Quaternion.identity;
            Assert.That(firstTransform.rotation, Is.EqualTo(Quaternion.identity));

            first.LookAt(Vector3.right);
            Assert.That(firstTransform.rotation, Is.EqualTo(expected));

            yield break;
        }

        [UnityTest]
        public IEnumerator SetLayerRecursively_ShouldSetLayerRecursively()
        {
            var parent = new GameObject();
            var child = new GameObject();
            var grandChild = new GameObject();

            child.transform.SetParent(parent.transform);
            grandChild.transform.SetParent(child.transform);

            int layer = LayerMask.NameToLayer("UI");
            Assert.AreNotEqual(layer, parent.layer);
            Assert.AreNotEqual(layer, child.layer);
            Assert.AreNotEqual(layer, grandChild.layer);

            parent.SetLayerRecursively(layer);

            Assert.That(parent.layer, Is.EqualTo(layer));
            Assert.That(child.layer, Is.EqualTo(layer));
            Assert.That(grandChild.layer, Is.EqualTo(layer));

            yield break;
        }

        [UnityTest]
        public IEnumerator SetParent_ShouldSetParent()
        {
            var first = new GameObject {transform = {position = Vector3.zero, rotation = Quaternion.identity}};
            var second = new GameObject {transform = {position = Vector3.right, rotation = Quaternion.identity}};

            Assert.That(first.transform.parent, Is.EqualTo(null));
            Assert.That(second.transform.parent, Is.EqualTo(null));

            first.SetParent(second);
            Assert.That(first.transform.parent, Is.EqualTo(second.transform));

            first.transform.SetParent(null!);
            Assert.That(first.transform.parent, Is.EqualTo(null));

            second.SetParent(first);
            Assert.That(second.transform.parent, Is.EqualTo(first.transform));

            yield break;
        }
    }
}
