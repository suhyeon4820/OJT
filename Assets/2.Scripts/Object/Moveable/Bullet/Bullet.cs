using System;
using System.Collections;
using UnityEngine;

public class Bullet : RecycleObject
{
    public Action<Bullet> Destroyed = null;
    private Vector2 bound = Vector2.zero;

    public void Fire(Vector2 bound)
    {
        this.bound = bound * 0.5f;
        gameObject.SetActive(true);
        StartCoroutine(Move());
    }

    public IEnumerator Move()
    {
        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

        while( !OutBound())
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 5.0f);
            yield return waitForFixedUpdate;
        }

        Destroyed?.Invoke(this);
    }

    private bool OutBound()
    {
        if(transform.position.x > bound.x || transform.position.x < -bound.x)
            return true;

        if(transform.position.z > bound.y || transform.position.z < -bound.y)
            return true;

        return false;
    }
}
