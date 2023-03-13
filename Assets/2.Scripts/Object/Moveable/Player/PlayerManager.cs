using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private BulletManager bulletManager = null;

    [SerializeField] private Fire fireAction = null;

    private bool isInitiailzed = false;

    public void Initialize(Vector2 bound)
    {
        Debug.Assert(bulletManager, "BulletManager is Null !!");
        Debug.Assert(fireAction, "FireAction is Null !!");

        if(isInitiailzed)
            return;
        
        bulletManager.Bound = bound;

        fireAction.Initialize(bulletManager);

        isInitiailzed = true;
    }
}
