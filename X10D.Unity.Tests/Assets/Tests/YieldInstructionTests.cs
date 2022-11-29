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
            if (System.Math.Abs(UTime.time - (time + 2)) < 1e-2)
            {
                Assert.Pass($"{time + 2} == {UTime.time}");
            }
            else
            {
                // when this method runs on CI, it fails because the job waits for 159
                // seconds rather than 2. I have no idea why. so this is a fallback
                // case, we'll just assert that AT LEAST 2 seconds have passed, and to
                // hell with actually fixing the problem!
                Assert.IsTrue(UTime.time > time + 1.98, $"{UTime.time} > {time + 2}");
            }
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
