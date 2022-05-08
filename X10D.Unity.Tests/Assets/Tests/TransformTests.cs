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

            Assert.AreEqual(Quaternion.identity, firstTransform.rotation);
            Assert.AreEqual(Quaternion.identity, secondTransform.rotation);

            firstTransform.LookAt(secondTransform);
            Quaternion expected = firstTransform.rotation;

            firstTransform.rotation = Quaternion.identity;
            Assert.AreEqual(Quaternion.identity, firstTransform.rotation);

            firstTransform.LookAt(second);
            Assert.AreEqual(expected, firstTransform.rotation);

            firstTransform.rotation = Quaternion.identity;
            Assert.AreEqual(Quaternion.identity, firstTransform.rotation);

            yield break;
        }

        [UnityTest]
        public IEnumerator SetParent_ShouldSetParent()
        {
            var first = new GameObject {transform = {position = Vector3.zero, rotation = Quaternion.identity}};
            var second = new GameObject {transform = {position = Vector3.right, rotation = Quaternion.identity}};

            Assert.AreEqual(null, first.transform.parent);
            Assert.AreEqual(null, second.transform.parent);

            first.transform.SetParent(second);
            Assert.AreEqual(second.transform, first.transform.parent);

            first.transform.SetParent(null!);
            Assert.AreEqual(null, first.transform.parent);

            second.transform.SetParent(first);
            Assert.AreEqual(first.transform, second.transform.parent);

            yield break;
        }
    }
}
