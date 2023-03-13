using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBillboard : MonoBehaviour
{
    private Transform mainCameraTransform = null;

    private void Awake()
    {
        mainCameraTransform = Camera.main.transform;
    }

    private void Start()
    {
        StartCoroutine(Billboard());
    }

    private IEnumerator Billboard()
    {
        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
        while(true)
        {
            transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward, mainCameraTransform.rotation * Vector3.up);
            yield return waitForFixedUpdate;
        }
    }
}
