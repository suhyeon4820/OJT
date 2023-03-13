using UnityEngine;
using UnityEngine.InputSystem;


public class Rotation : MonoBehaviour
{
    [SerializeField] private Transform rotationObject = null;

    public void OnRotation(InputAction.CallbackContext context )
    {
        Vector2 input = context.ReadValue<Vector2>();

        if(input == Vector2.zero)
            return;
        
        Vector3 direction  = new Vector3(input.x, 0f, input.y).normalized;
        rotationObject.rotation = Quaternion.LookRotation(direction);
    }
}
