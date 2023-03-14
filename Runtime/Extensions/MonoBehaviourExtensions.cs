using System;
using System.Collections;
using UnityEngine;

namespace Sacristan.Utils
{
    public static class MonoBehaviourExtensions
    {
        public static Coroutine StartCoroutineIfActive(this MonoBehaviour behaviour, IEnumerator routine)
        {
            if (behaviour == null)
            {
                Debug.Log("MonoBehaviourExtensions.StartCoroutineIfActive received GameObject is null");
            }
            else
            {
                if (behaviour.enabled && behaviour.gameObject.activeSelf) return behaviour?.StartCoroutine(routine);
            }

            return null;
        }

        public static void InvokeSafe(this MonoBehaviour behaviour, System.Action method, float delayInSeconds)
        {
            behaviour.StartCoroutine(InvokeSafeRoutine(method, delayInSeconds));
        }

        public static void InvokeRepeatingSafe(this MonoBehaviour behaviour, System.Action method, float delayInSeconds, float repeatRateInSeconds)
        {
            behaviour.StartCoroutine(InvokeSafeRepeatingRoutine(method, delayInSeconds, repeatRateInSeconds));
        }

        private static IEnumerator InvokeSafeRepeatingRoutine(System.Action method, float delayInSeconds, float repeatRateInSeconds)
        {
            yield return new WaitForSeconds(delayInSeconds);

            while (true)
            {
                if (method != null) method.Invoke();
                yield return new WaitForSeconds(repeatRateInSeconds);
            }
        }

        private static IEnumerator InvokeSafeRoutine(System.Action method, float delayInSeconds)
        {
            yield return new WaitForSeconds(delayInSeconds);
            if (method != null) method.Invoke();
        }
    }
}
