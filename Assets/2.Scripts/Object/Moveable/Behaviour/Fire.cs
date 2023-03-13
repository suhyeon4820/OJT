using UnityEngine;
using UnityEngine.InputSystem;

public class Fire : MonoBehaviour
{
    private BulletManager bulletManager = null;

    private bool isInitiailzed = false;

    public void Initialize(BulletManager bulletManager)
    {
        if(isInitiailzed)
            return;
        
        this.bulletManager = bulletManager;

        isInitiailzed = true;
    }

    public void OnFire(InputAction.CallbackContext context )
    {
        if( !context.ReadValueAsButton())
            bulletManager.Fire();
    }
}
