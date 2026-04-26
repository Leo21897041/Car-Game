using UnityEngine;

public class CarRight : MonoBehaviour
{
    private Player playerScript;

    public float speed;
    public int xMin;
    public int xMax;

    public bool sameDirectionAsPlayer;

    public float totalSpeed;

    public ParticleSystem crashParticles;

    void Start()
    {
        playerScript = FindFirstObjectByType<Player>();
    }

    void Update()
    {
        if (playerScript.isGameOver)
        {
            totalSpeed = playerScript.finalSpeedRight;
        }
        else
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

            Vector3 screenPosition = transform.position;

            if (screenPosition.x > Screen.width + xMax)
            {
                Destroy(gameObject);
            }
        }

        transform.position += Time.deltaTime * totalSpeed * transform.right;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            crashParticles.Play();

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
