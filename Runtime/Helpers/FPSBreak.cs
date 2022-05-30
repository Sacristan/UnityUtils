using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSBreak : MonoBehaviour
{
#if DEBUG_FPS_BREAK
    private uint minSatisfactoryFPS = 30;
    private float initializationTime = 2f;

    bool trackingEnabled = false;

    void Start()
    {
        Debug.Log("FPSBreak Initialized");
        ResetTracking();
    }

    void Update()
    {
        if (!trackingEnabled) return;

        float fps = 1f / Time.deltaTime;

        if (fps < minSatisfactoryFPS)
        {
            Debug.LogFormat("FPSBreak unsatisfatory FPS:{0} min:{1} ", fps.ToString("n1"), minSatisfactoryFPS);
            Debug.Break();
            ResetTracking();
        }
    }

    private void ResetTracking()
    {
        trackingEnabled = false;
        StartCoroutine(ResetTrackingRoutine());
    }

    private IEnumerator ResetTrackingRoutine()
    {
        yield return new WaitForSeconds(initializationTime);
        trackingEnabled = true;
    }
#else
    void Awake()
    {
        Destroy(this);
    }
#endif

}
