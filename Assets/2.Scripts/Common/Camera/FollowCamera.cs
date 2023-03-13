using System.Collections;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private float distance = 10.0f;
    [SerializeField] private float height = 5.0f;
    [SerializeField] private float smoothRate = 5.0f;

    private Transform target = null;
    private Coroutine followCorutine = null;

    private bool isPause = false;

    public void StartFollow(Transform target)
    {
        Debug.Assert(target, "Target is Null !!");

        this.target = target;
        followCorutine = StartCoroutine(FollowLoop());
    }
    
    public void StopFollow()
    {
        StopCoroutine(followCorutine);
    }

    public void PauseFollow()
    {
        isPause = true;
    }

    public void ResumeFollow()
    {
        isPause = false;
    }

    private IEnumerator FollowLoop()
    {
        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

        while(true)
        {
            if(isPause)
                yield return null;
            else
            {
                transform.position = target.position - (Vector3.forward * distance) + (Vector3.up * height);
                transform.LookAt(target);

                yield return waitForFixedUpdate;
            }
        }
    } 
}
