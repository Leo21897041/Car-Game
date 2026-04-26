using UnityEngine;

public class SpawnerF1Top : MonoBehaviour
{
    public float newPylonDistance;
    public float offset;

    //public Transform player;

    public GameObject f1SidePrefab;
    public GameObject spawnedF1Side;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        Vector2 screenPositionPylon = Camera.main.WorldToScreenPoint(transform.position);

        float distanceToNextPylon = Vector2.Distance(transform.position, spawnedF1Side.transform.position);

        if (distanceToNextPylon > newPylonDistance)
        {
            spawnedF1Side = Instantiate(f1SidePrefab, transform.position, transform.rotation);
        }
    }
}
