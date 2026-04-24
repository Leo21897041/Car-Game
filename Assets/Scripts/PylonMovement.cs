using UnityEngine;

public class PylonMovement : MonoBehaviour
{
    public float speed;    
    public float xMin;    
    void Start()
    {
        
    }

    void Update()
    {
        transform.position -= Time.deltaTime * speed * transform.right;

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0 - xMin)
        {
            Destroy(gameObject);
        }
    }
}
