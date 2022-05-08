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
            Assert.AreEqual(1, components.Length);
            Assert.AreEqual(components[0].gameObject, child);

            yield break;
        }

        [UnityTest]
        public IEnumerator LookAt_ShouldRotateSameAsTransform()
        {
            var first = new GameObject {transform = {position = Vector3.zero, rotation = Quaternion.identity}};
            var second = new GameObject {transform = {position = Vector3.right, rotation = Quaternion.identity}};
            Transform firstTransform = first.transform;
            Transform secondTransform = second.transform;

            Assert.AreEqual(Quaternion.identity, firstTransform.rotation);
            Assert.AreEqual(Quaternion.identity, secondTransform.rotation);

            firstTransform.LookAt(secondTransform);
            Quaternion expected = firstTransform.rotation;

            firstTransform.rotation = Quaternion.identity;
            Assert.AreEqual(Quaternion.identity, firstTransform.rotation);

            first.LookAt(second);
            Assert.AreEqual(expected, firstTransform.rotation);

            firstTransform.rotation = Quaternion.identity;
            Assert.AreEqual(Quaternion.identity, firstTransform.rotation);

            first.LookAt(second.transform);
            Assert.AreEqual(expected, firstTransform.rotation);

            firstTransform.rotation = Quaternion.identity;
            Assert.AreEqual(Quaternion.identity, firstTransform.rotation);

            first.LookAt(Vector3.right);
            Assert.AreEqual(expected, firstTransform.rotation);

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

            Assert.AreEqual(layer, parent.layer);
            Assert.AreEqual(layer, child.layer);
            Assert.AreEqual(layer, grandChild.layer);

            yield break;
        }

        [UnityTest]
        public IEnumerator SetParent_ShouldSetParent()
        {
            var first = new GameObject {transform = {position = Vector3.zero, rotation = Quaternion.identity}};
            var second = new GameObject {transform = {position = Vector3.right, rotation = Quaternion.identity}};

            Assert.AreEqual(null, first.transform.parent);
            Assert.AreEqual(null, second.transform.parent);

            first.SetParent(second);
            Assert.AreEqual(second.transform, first.transform.parent);

            first.transform.SetParent(null!);
            Assert.AreEqual(null, first.transform.parent);

            second.SetParent(first);
            Assert.AreEqual(first.transform, second.transform.parent);

            yield break;
        }
    }
}
