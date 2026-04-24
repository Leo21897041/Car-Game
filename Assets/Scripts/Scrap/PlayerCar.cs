using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCar : MonoBehaviour
{
    public float speed;
    public float speedLimit;
    public float accelerate;
    public float turnSpeed;

    Vector3 currentPosition;
    public Vector3 startPosition;
    Vector3 currentRotation;
    public Vector3 startRotation;
    //public Vector2 directionalInput;


    void Start()
    {
        transform.position = startPosition;
        transform.eulerAngles = startRotation;
    }


    void Update()
    {
        if (Keyboard.current.upArrowKey.isPressed)
        {
            accelerate += Time.deltaTime * speed;
            currentPosition = transform.position;
            currentPosition += accelerate * transform.up;
            transform.position = currentPosition;

            if (accelerate > speedLimit)
            {
                accelerate = speedLimit;
            }
        }
        else 
        {
            accelerate -= Time.deltaTime * speed;
            currentPosition = transform.position;
            currentPosition += accelerate * transform.up;
            transform.position = currentPosition;

            if (accelerate <= 0)
            {
                accelerate = 0f;
            }
        }

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            currentRotation = transform.eulerAngles;

            currentRotation.z += Time.deltaTime * turnSpeed;

            transform.eulerAngles = currentRotation;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            currentRotation = transform.eulerAngles;

            currentRotation .z -= Time.deltaTime * turnSpeed;           

            transform.eulerAngles = currentRotation;
        }

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0)
        {
            screenPosition.x = 0;
        }
        if (screenPosition.x > Screen.width)
        {
            screenPosition.x = Screen.width;
        }
        if (screenPosition.y < 0)
        {
            screenPosition.y = 0;
        }
        if (screenPosition.y > Screen.height)
        {
            screenPosition.y = Screen.height;
        }        

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        transform.position = worldPosition;

    }

    //public void OnMove(InputAction.CallbackContext context)
    //{
    //    directionalInput = context.ReadValue<Vector2>();
    //}
}
