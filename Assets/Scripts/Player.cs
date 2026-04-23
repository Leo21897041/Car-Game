using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = speed * Time.deltaTime;    
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 directionalInput = ReadValue<context>();
    }
}
