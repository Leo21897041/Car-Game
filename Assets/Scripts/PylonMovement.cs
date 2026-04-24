using UnityEngine;
using UnityEngine.InputSystem;

public class PylonMovement : MonoBehaviour
{
    Vector3 currentPylonPosition;

    public float speed;
    public float speedLimit;
    public float accelerate;
    public float xMin;    
    void Start()
    {
        
    }

    void Update()
    {     
        if (Keyboard.current.upArrowKey.isPressed)
        {
            accelerate += Time.deltaTime * speed;
            currentPylonPosition = transform.position;
            currentPylonPosition -= accelerate * transform.right;
            transform.position = currentPylonPosition;

            if (accelerate > speedLimit)
            {
                accelerate = speedLimit;
            }
        }
        else
        {
            accelerate -= Time.deltaTime * speed;
            currentPylonPosition = transform.position;
            currentPylonPosition -= accelerate * transform.right;
            transform.position = currentPylonPosition;

            if (accelerate <= 0)
            {
                accelerate = 0f;
            }
        }

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0 - xMin)
        {
            Destroy(gameObject);
        }
    }
}
