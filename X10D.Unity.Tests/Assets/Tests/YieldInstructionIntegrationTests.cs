using System.Collections;
using UnityEngine;

namespace X10D.Unity.Tests
{
    public class YieldInstructionIntegrationTests : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(CO_WaitForAnyKeyDown());
            StartCoroutine(CO_WaitForSpaceKeyDown());
            StartCoroutine(CO_WaitForSpaceKeyUp());
        }

        private IEnumerator CO_WaitForAnyKeyDown()
        {
            Debug.Log("Waiting for any key to be pressed...");
            yield return new WaitForKeyDown();
            Debug.Log("Key was pressed!");
        }

        private IEnumerator CO_WaitForSpaceKeyDown()
        {
            Debug.Log("Waiting for Space key to be pressed...");
            yield return new WaitForKeyDown(KeyCode.Space);
            Debug.Log("Space key was pressed!");
        }

        private IEnumerator CO_WaitForSpaceKeyUp()
        {
            Debug.Log("Waiting for Space key to be released...");
            yield return new WaitForKeyUp(KeyCode.Space);
            Debug.Log("Space key was released!");
        }
    }
}
