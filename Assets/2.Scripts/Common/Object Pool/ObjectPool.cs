using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private Stack<RecycleObject> pool = new Stack<RecycleObject>();
    private RecycleObject recycleObject = null;
    
    private Transform parent = null;
    private int defaultPoolSize = 10;

    public ObjectPool(RecycleObject recycleObject, int defaultPoolSize = 10, Transform parent = null)
    {
        this.recycleObject = recycleObject;
        this.defaultPoolSize = defaultPoolSize;
        this.parent = parent;

        Debug.Assert(recycleObject, " RecycleObject is null !! ");

        CreatePool();
    }

    private void CreatePool()
    {
        for (int i = 0; i < defaultPoolSize; i++)
        {
            RecycleObject obj =  GameObject.Instantiate<RecycleObject>(recycleObject, parent:parent);
            obj.gameObject.SetActive(false);
            pool.Push(obj);
        }
    }

    public T Get<T>() where T : class
    {
        if(pool.Count == 0)
            return null;

        return pool.Pop() as T;
    }

    public void Restore(RecycleObject recycleObject)
    {
        Debug.Assert(recycleObject, " RecycleObject is null !! ");
        recycleObject.transform.position = Vector3.zero;
        recycleObject.gameObject.SetActive(false);
        pool.Push(recycleObject);
    }
}
