using UnityEngine;

public class CarObstacles : MonoBehaviour
{
    public float speed;
    public int xMin;
    public int xMax;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        transform.position += Time.deltaTime * speed * transform.up;

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0 - xMin || screenPosition.x > Screen.width + xMax)
        {
            Destroy(gameObject);
        }        
    }
}
