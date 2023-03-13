using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBillboard : MonoBehaviour
{
    [SerializeField] private Transform tartget = null;

    private void Awake()
    {
        Debug.Assert(tartget, "Target is Null !!");
    }

    private void Start()
    {
        StartCoroutine(Billboard());
    }

    private IEnumerator Billboard()
    {
        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
        Vector3 tartgetPosition = Vector3.zero;
        while(true)
        {
            tartgetPosition = new Vector3(tartget.position.x, transform.position.y, tartget.position.z);
            transform.LookAt(tartgetPosition);
            yield return waitForFixedUpdate;
        }
    }
}
