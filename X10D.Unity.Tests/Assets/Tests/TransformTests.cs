#nullable enable

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace X10D.Unity.Tests
{
    public class TransformTests
    {
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

            firstTransform.LookAt(second);
            Assert.That(firstTransform.rotation, Is.EqualTo(expected));

            firstTransform.rotation = Quaternion.identity;
            Assert.That(firstTransform.rotation, Is.EqualTo(Quaternion.identity));

            yield break;
        }

        [UnityTest]
        public IEnumerator SetParent_ShouldSetParent()
        {
            var first = new GameObject {transform = {position = Vector3.zero, rotation = Quaternion.identity}};
            var second = new GameObject {transform = {position = Vector3.right, rotation = Quaternion.identity}};

            Assert.That(first.transform.parent, Is.EqualTo(null));
            Assert.That(second.transform.parent, Is.EqualTo(null));

            first.transform.SetParent(second);
            Assert.That(first.transform.parent, Is.EqualTo(second.transform));

            first.transform.SetParent(null!);
            Assert.That(first.transform.parent, Is.EqualTo(null));

            second.transform.SetParent(first);
            Assert.That(second.transform.parent, Is.EqualTo(first.transform));

            yield break;
        }
    }
}
