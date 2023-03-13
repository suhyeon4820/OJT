using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [SerializeField] private Transform moveObject = null;

    public void OnMove(InputAction.CallbackContext context )
    {
        Vector2 input = context.ReadValue<Vector2>();

        if(input == Vector2.zero)
            return;
        
        Vector3 direction  = new Vector3(input.x, 0f, input.y).normalized;

        moveObject.rotation = Quaternion.LookRotation(direction);
        moveObject.Translate(Vector3.forward * Time.deltaTime * 5.0f);
    }
}
