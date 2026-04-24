using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float forwardSpeed;
    public float reverseSpeed;
    public float currentSpeed;
    public float decelerate;
    public float speedLimitMax;
    public float speedLimitMin;
    public float turnSpeed;

    Vector3 currentPosition;
    public Vector3 startPosition;
    Vector3 currentRotation;
    public Vector3 startRotation;
    
    public Vector2 directionalInput;

    public AnimationCurve stunCurve;
    public float stunSpeed;
    public float progressStun;
    public float durationStun;
    public bool isStunned;

    void Start()
    {
        transform.position = startPosition;
        transform.eulerAngles = startRotation;
    }

    void Update()
    {        
        if (isStunned)
        {
            if (progressStun < durationStun)
            {
                progressStun += Time.deltaTime;                

                transform.Rotate(0, 0, stunCurve.Evaluate(progressStun / durationStun));
            }

            if (progressStun > durationStun)
            {
                isStunned = false;
                progressStun = 0;
            }
        }
        if (directionalInput.y > 0)
        {
            currentSpeed += forwardSpeed * Time.deltaTime;
        }
        if (directionalInput.y < 0)
        { 
            currentSpeed -= reverseSpeed * Time.deltaTime;
        }
        else if (directionalInput.y == 0)
        {
            if (currentSpeed < 0)
            {
                currentSpeed += decelerate * Time.deltaTime;
                
                if (currentSpeed > 0)
                {
                    currentSpeed = 0f;
                }
            }
            if (currentSpeed > 0)
            { 
                currentSpeed -= decelerate * Time.deltaTime;

                if (currentSpeed < 0)
                {
                    currentSpeed = 0f;
                }
            }
        }        

        if (currentSpeed > speedLimitMax)
        {
            currentSpeed = speedLimitMax;
        }
        if (currentSpeed < speedLimitMin)
        {
            currentSpeed = speedLimitMin;
        }

        transform.position += Time.deltaTime * currentSpeed * transform.up;

        if (currentSpeed > 0)
        {
            if (Keyboard.current.leftArrowKey.isPressed)
            {
                transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
            }
            if (Keyboard.current.rightArrowKey.isPressed)
            {
                transform.Rotate(0, 0, -turnSpeed * Time.deltaTime);
            }
        }
        if (currentSpeed < 0)
        {
            if (Keyboard.current.leftArrowKey.isPressed)
            {
                transform.Rotate(0, 0, -turnSpeed * Time.deltaTime);
            }
            if (Keyboard.current.rightArrowKey.isPressed)
            {
                transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
            }
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
    

    public void OnMove(InputAction.CallbackContext context)
    {
        directionalInput = context.ReadValue<Vector2>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyCar"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Pylon"))
        {
            currentSpeed = 0f;

            Destroy(other.gameObject);

            isStunned = true;
        }
    }
}
