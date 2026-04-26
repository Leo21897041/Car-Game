using UnityEngine;

public class CarLeft : MonoBehaviour
{
    private Player playerScript;

    public float speed;
    public int xMin;
    public int xMax;

    void Start()
    {
        playerScript = FindFirstObjectByType<Player>();
    }

    void Update()
    {
        float totalSpeed = speed + playerScript.currentSpeed / 2;

        transform.position -= Time.deltaTime * totalSpeed * transform.right;

        Vector3 screenPosition = transform.position;

        if (screenPosition.x < 0 - xMin)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("EnemyCar"))
        {
            Destroy(gameObject);
        }
    }
}
