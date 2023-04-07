#nullable enable

using System;
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
        public IEnumerator CopyTo_ShouldCopyComponent_GivenComponent()
        {
            var source = new GameObject();
            var sourceComponent = source.AddComponent<Rigidbody>();
            sourceComponent.mass = 10.0f;
            sourceComponent.useGravity = false;

            var target = new GameObject();
            sourceComponent.CopyTo(target);

            Assert.That(target.TryGetComponent(out Rigidbody targetComponent));
            Assert.That(targetComponent.mass, Is.EqualTo(10.0f));
            Assert.That(targetComponent.useGravity, Is.False);

            Object.Destroy(source);
            Object.Destroy(target);
            yield break;
        }

        [UnityTest]
        public IEnumerator CopyTo_ShouldThrowArgumentNullException_GivenNullComponent()
        {
            var target = new GameObject();
            Rigidbody rigidbody = null!;

            Assert.Throws<ArgumentNullException>(() => rigidbody.CopyTo(target));

            Object.Destroy(target);
            yield break;
        }

        [UnityTest]
        public IEnumerator CopyTo_ShouldThrowArgumentNullException_GivenNullTarget()
        {
            var source = new GameObject();
            var rigidbody = source.AddComponent<Rigidbody>();
            GameObject target = null!;

            Assert.Throws<ArgumentNullException>(() => rigidbody.CopyTo(target));

            Object.Destroy(source);
            yield break;
        }

        [UnityTest]
        public IEnumerator CopyTo_ShouldThrowInvalidOperationException_GivenDuplicate()
        {
            var source = new GameObject();
            var rigidbody = source.AddComponent<Rigidbody>();

            var target = new GameObject();
            target.AddComponent<Rigidbody>();

            Assert.Throws<InvalidOperationException>(() => rigidbody.CopyTo(target));

            Object.Destroy(source);
            Object.Destroy(target);
            yield break;
        }

        [UnityTest]
        public IEnumerator GetComponentsInChildrenOnly_ShouldIgnoreParent()
        {
            var parent = new GameObject();
            var rigidbody = parent.AddComponent<Rigidbody>();

            var child = new GameObject();
            child.AddComponent<Rigidbody>();

            yield return null;

            Rigidbody[] components = rigidbody.GetComponentsInChildrenOnly<Rigidbody>();
            Assert.That(components.Length, Is.EqualTo(1));
            Assert.That(child, Is.EqualTo(components[0].gameObject));

            Object.Destroy(parent);
            Object.Destroy(child);
        }

        [UnityTest]
        public IEnumerator MoveTo_ShouldCopyComponent_GivenComponent()
        {
            var source = new GameObject();
            var sourceComponent = source.AddComponent<Rigidbody>();
            sourceComponent.mass = 10f;
            sourceComponent.useGravity = false;

            var target = new GameObject();
            sourceComponent.MoveTo(target);

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
        public IEnumerator MoveTo_ShouldThrowArgumentNullException_GivenNullComponent()
        {
            var target = new GameObject();
            Rigidbody rigidbody = null!;

            Assert.Throws<ArgumentNullException>(() => rigidbody.MoveTo(target));

            Object.Destroy(target);
            yield break;
        }

        [UnityTest]
        public IEnumerator MoveTo_ShouldThrowArgumentNullException_GivenNullTarget()
        {
            var source = new GameObject();
            var rigidbody = source.AddComponent<Rigidbody>();
            GameObject target = null!;

            Assert.Throws<ArgumentNullException>(() => rigidbody.MoveTo(target));

            Object.Destroy(source);
            yield break;
        }

        [UnityTest]
        public IEnumerator MoveTo_ShouldThrowInvalidOperationException_GivenDuplicate()
        {
            var source = new GameObject();
            var rigidbody = source.AddComponent<Rigidbody>();

            var target = new GameObject();
            target.AddComponent<Rigidbody>();

            Assert.Throws<InvalidOperationException>(() => rigidbody.MoveTo(target));

            Object.Destroy(source);
            Object.Destroy(target);
            yield break;
        }
    }
}
