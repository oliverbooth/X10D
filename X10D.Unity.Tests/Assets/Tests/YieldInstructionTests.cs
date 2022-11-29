using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UTime = UnityEngine.Time;

namespace X10D.Unity.Tests
{
    public class YieldInstructionTests : MonoBehaviour
    {
        [UnityTest]
        public IEnumerator WaitForFrames_ShouldYieldCorrectNumberOfFrames()
        {
            int frameCount = UTime.frameCount;
            yield return new WaitForFrames(10);
            Assert.AreEqual(frameCount + 10, UTime.frameCount, $"{frameCount + 10} == {UTime.frameCount}");
        }

        [UnityTest]
        public IEnumerator WaitForSecondsNoAlloc_ShouldYieldForCorrectTime()
        {
            float time = UTime.time;
            yield return new WaitForSecondsNoAlloc(2);
            Assert.AreEqual(time + 2, UTime.time, 1e-2, $"{time + 2} == {UTime.time}");
        }

        [UnityTest]
        public IEnumerator WaitForSecondsRealtimeNoAlloc_ShouldYieldForCorrectTime()
        {
            float time = UTime.time;
            yield return new WaitForSecondsRealtimeNoAlloc(2);
            Assert.AreEqual(time + 2, UTime.time, 1e-2, $"{time + 2} == {UTime.time}");
        }

        [UnityTest]
        public IEnumerator WaitForTimeSpan_ShouldYieldForCorrectTime()
        {
            float time = UTime.time;
            yield return new WaitForTimeSpan(TimeSpan.FromSeconds(2));
            Assert.AreEqual(time + 2, UTime.time, 1e-2, $"{time + 2} == {UTime.time}");
        }

        [UnityTest]
        public IEnumerator WaitForTimeSpanRealtime_ShouldYieldForCorrectTime()
        {
            float time = UTime.time;
            yield return new WaitForTimeSpanRealtime(TimeSpan.FromSeconds(2));
            Assert.AreEqual(time + 2, UTime.time, 1e-2, $"{time + 2} == {UTime.time}");
        }
    }
}
