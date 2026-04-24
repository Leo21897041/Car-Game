using UnityEngine;

public class CarObstacles : MonoBehaviour
{
    public float speed;
    public float crashDistance;
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
        transform.position += Time.deltaTime * speed * transform.up;

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0 - xMin || screenPosition.x > Screen.width + xMax)
        {
            Destroy(gameObject);
        }

        playerScript.GameOver();
    }
}
