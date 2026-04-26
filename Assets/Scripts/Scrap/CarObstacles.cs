using TMPro;
using UnityEngine;

public class CarObstacles : MonoBehaviour
{    
    public float speed;
    public int xMin;
    public int xMax;

    private Player playerScript;
    void Start()
    {
        playerScript = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * speed * transform.right;

        Vector3 screenPosition = transform.position;

        if (screenPosition.x < 0 - xMin || screenPosition.x > Screen.width + xMax)
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
    }
}
