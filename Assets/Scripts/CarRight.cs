using UnityEngine;

public class CarRight : MonoBehaviour
{
    public Player playerScript;

    public float speed;
    public int xMin;
    public int xMax;

    public bool sameDirectionAsPlayer;

    private float totalSpeed;

    public ParticleSystem crashParticles;

    void Start()
    {
        playerScript = FindFirstObjectByType<Player>();
    }

    void Update()
    {
        float directionalCheck = Vector3.Dot(transform.right, playerScript.transform.up);

        if (directionalCheck > 0)
        {
            totalSpeed = speed - playerScript.currentSpeed;            
        }
        else
        {
            totalSpeed = speed + playerScript.currentSpeed;            
        }

        totalSpeed = Mathf.Max(0f, totalSpeed);

        transform.position += Time.deltaTime * totalSpeed * transform.right;

        Vector3 screenPosition = transform.position;

        if (screenPosition.x > Screen.width + xMax)
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
