using UnityEngine;

public class CarLeft : MonoBehaviour
{
    private Player playerScript;

    public float speed;
    public int xMin;
    public int xMax;

    private float totalSpeed;

    void Start()
    {
        playerScript = FindFirstObjectByType<Player>();
    }

    void Update()
    {
        float directionalCheck = Vector3.Dot(-transform.right, playerScript.transform.up);

        if (directionalCheck > 0)
        {
            totalSpeed = speed - playerScript.currentSpeed;
        }
        else
        {
            totalSpeed = speed + playerScript.currentSpeed;
        }

        totalSpeed = Mathf.Max(0f, totalSpeed);

        transform.position -= Time.deltaTime * totalSpeed * transform.right;

        Vector3 screenPosition = transform.position;

        if (screenPosition.x < 0 - xMin)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyCar"))
        {
            Destroy(gameObject);
        }
    }
}
