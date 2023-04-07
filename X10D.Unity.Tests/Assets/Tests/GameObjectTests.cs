#nullable enable

using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

namespace X10D.Unity.Tests
{
    public class GameObjectTests
    {
        [UnityTest]
        public IEnumerator CopyComponent_ShouldCopyComponent_GivenComponent()
        {
            var source = new GameObject();
            var sourceComponent = source.AddComponent<Rigidbody>();
            sourceComponent.mass = 10.0f;
            sourceComponent.useGravity = false;

            var target = new GameObject();
            source.CopyComponent<Rigidbody>(target);

            Assert.That(target.TryGetComponent(out Rigidbody targetComponent));
            Assert.That(targetComponent.mass, Is.EqualTo(10.0f));
            Assert.That(targetComponent.useGravity, Is.False);

            Object.Destroy(source);
            Object.Destroy(target);
            yield break;
        }

        [UnityTest]
        public IEnumerator CopyComponent_ShouldThrowArgumentNullException_GivenNullComponentType()
        {
            var source = new GameObject();
            var target = new GameObject();
            Type componentType = null!;

            Assert.Throws<ArgumentNullException>(() => source.CopyComponent(componentType, target));

            Object.Destroy(source);
            Object.Destroy(target);
            yield break;
        }

        [UnityTest]
        public IEnumerator CopyComponent_ShouldThrowArgumentNullException_GivenNullGameObject()
        {
            var target = new GameObject();
            GameObject source = null!;

            Assert.Throws<ArgumentNullException>(() => source.CopyComponent<Rigidbody>(target));
            Assert.Throws<ArgumentNullException>(() => source.CopyComponent(typeof(Rigidbody), target));

            Object.Destroy(target);
            yield break;
        }

        [UnityTest]
        public IEnumerator CopyComponent_ShouldThrowArgumentNullException_GivenNullTarget()
        {
            var source = new GameObject();
            GameObject target = null!;

            Assert.Throws<ArgumentNullException>(() => source.CopyComponent<Rigidbody>(target));
            Assert.Throws<ArgumentNullException>(() => source.CopyComponent(typeof(Rigidbody), target));

            Object.Destroy(source);
            yield break;
        }

        [UnityTest]
        public IEnumerator CopyComponent_ShouldThrowInvalidOperationException_GivenInvalidComponent()
        {
            var source = new GameObject();
            var target = new GameObject();

            Assert.Throws<InvalidOperationException>(() => source.CopyComponent<Rigidbody>(target));
            Assert.Throws<InvalidOperationException>(() => source.CopyComponent(typeof(Rigidbody), target));

            Object.Destroy(source);
            Object.Destroy(target);
            yield break;
        }

        [UnityTest]
        public IEnumerator CopyComponent_ShouldThrowInvalidOperationException_GivenDuplicate()
        {
            var source = new GameObject();
            source.AddComponent<Rigidbody>();

            var target = new GameObject();
            target.AddComponent<Rigidbody>();

            Assert.Throws<InvalidOperationException>(() => source.CopyComponent<Rigidbody>(target));
            Assert.Throws<InvalidOperationException>(() => source.CopyComponent(typeof(Rigidbody), target));

            Object.Destroy(source);
            Object.Destroy(target);
            yield break;
        }

        [UnityTest]
        public IEnumerator GetComponentsInChildrenOnly_ShouldIgnoreParent()
        {
            var parent = new GameObject();
            parent.AddComponent<Rigidbody>();

            var child = new GameObject();
            child.transform.SetParent(parent.transform);
            child.AddComponent<Rigidbody>();

            Rigidbody[] components = parent.GetComponentsInChildrenOnly<Rigidbody>();
            Assert.That(components, Has.Length.EqualTo(1));
            Assert.That(child, Is.EqualTo(components[0].gameObject));

            Object.Destroy(parent);
            Object.Destroy(child);
            yield break;
        }

        [UnityTest]
        [SuppressMessage("ReSharper", "Unity.InefficientPropertyAccess", Justification = "False positive.")]
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

            Object.Destroy(first);
            Object.Destroy(second);
            yield break;
        }

        [UnityTest]
        public IEnumerator MoveComponent_ShouldCopyComponent_GivenComponent()
        {
            var source = new GameObject();
            var sourceComponent = source.AddComponent<Rigidbody>();
            sourceComponent.mass = 10.0f;
            sourceComponent.useGravity = false;

            var target = new GameObject();
            source.MoveComponent<Rigidbody>(target);

            // effects of Destroy only take place at end of frame
            yield return null;

            Assert.That(sourceComponent == null);
            Assert.That(source.TryGetComponent(out Rigidbody _), Is.False);
            Assert.That(target.TryGetComponent(out Rigidbody targetComponent));
            Assert.That(targetComponent.mass, Is.EqualTo(10.0f));
            Assert.That(targetComponent.useGravity, Is.False);

            Object.Destroy(source);
            Object.Destroy(target);
        }

        [UnityTest]
        public IEnumerator MoveComponent_ShouldThrowArgumentNullException_GivenNullComponentType()
        {
            var source = new GameObject();
            var target = new GameObject();
            Type componentType = null!;

            Assert.Throws<ArgumentNullException>(() => source.MoveComponent(componentType, target));

            Object.Destroy(source);
            Object.Destroy(target);
            yield break;
        }

        [UnityTest]
        public IEnumerator MoveComponent_ShouldThrowArgumentNullException_GivenNullGameObject()
        {
            var target = new GameObject();
            GameObject source = null!;

            Assert.Throws<ArgumentNullException>(() => source.MoveComponent<Rigidbody>(target));
            Assert.Throws<ArgumentNullException>(() => source.MoveComponent(typeof(Rigidbody), target));

            Object.Destroy(target);
            yield break;
        }

        [UnityTest]
        public IEnumerator MoveComponent_ShouldThrowArgumentNullException_GivenNullTarget()
        {
            var source = new GameObject();
            GameObject target = null!;

            Assert.Throws<ArgumentNullException>(() => source.MoveComponent<Rigidbody>(target));
            Assert.Throws<ArgumentNullException>(() => source.MoveComponent(typeof(Rigidbody), target));

            Object.Destroy(source);
            yield break;
        }

        [UnityTest]
        public IEnumerator MoveComponent_ShouldThrowInvalidOperationException_GivenInvalidComponent()
        {
            var source = new GameObject();
            var target = new GameObject();

            Assert.Throws<InvalidOperationException>(() => source.MoveComponent<Rigidbody>(target));
            Assert.Throws<InvalidOperationException>(() => source.MoveComponent(typeof(Rigidbody), target));

            Object.Destroy(source);
            Object.Destroy(target);
            yield break;
        }

        [UnityTest]
        public IEnumerator MoveComponent_ShouldThrowInvalidOperationException_GivenDuplicate()
        {
            var source = new GameObject();
            source.AddComponent<Rigidbody>();

            var target = new GameObject();
            target.AddComponent<Rigidbody>();

            Assert.Throws<InvalidOperationException>(() => source.MoveComponent<Rigidbody>(target));
            Assert.Throws<InvalidOperationException>(() => source.MoveComponent(typeof(Rigidbody), target));

            Object.Destroy(source);
            Object.Destroy(target);
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

            Object.Destroy(parent);
            Object.Destroy(child);
            Object.Destroy(grandChild);
            yield break;
        }

        [UnityTest]
        [SuppressMessage("ReSharper", "Unity.InefficientPropertyAccess", Justification = "False positive.")]
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

            Object.Destroy(first);
            Object.Destroy(second);
            yield break;
        }
    }
}
