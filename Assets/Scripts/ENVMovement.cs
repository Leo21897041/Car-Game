using UnityEngine;

public class ENVMovement : MonoBehaviour
{
    private Player playerScript;

    public float currentSpeedENV;
    public float moveSpeedENV;
    public float playerSpeed;

    public int xMin;
    public int xMax;
    void Start()
    {
        playerScript = FindFirstObjectByType<Player>();
    }
    
    void Update()
    {
        currentSpeedENV = Time.deltaTime * moveSpeedENV;

        if (playerScript.currentSpeed < 0)
        {
            playerSpeed = 0;
        }

        transform.position -= (Time.deltaTime * playerScript.currentSpeed * transform.right) * playerSpeed + currentSpeedENV * transform.right;

        //Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (transform.position.x < 0 - xMin || transform.position.x > Screen.width + xMax)
        {
            Destroy(gameObject);
        }
    }
}
