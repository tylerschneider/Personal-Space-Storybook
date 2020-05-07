using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARSessionEnabler : MonoBehaviour
{
    [SerializeField] ARSession m_Session;

    IEnumerator Start()
    {
        if (ARSession.state == ARSessionState.None || ARSession.state == ARSessionState.CheckingAvailability)
        {
            yield return ARSession.CheckAvailability();
        }

        if (ARSession.state == ARSessionState.Unsupported)
        {
            Debug.LogError("This device does not support ARFoundation");
        }
        else
        {
            m_Session.enabled = true;
        }
    }
}