using UnityEngine;

public class SpawnerPylons : MonoBehaviour
{
    public Vector2 pylonSpawnPosition;

    public float newPylonDistance;

    public GameObject pylonPrefab;

    void Start()
    {
        GameObject spawnedPylon = Instantiate(pylonPrefab, pylonSpawnPosition, Quaternion.identity);        
    }
    
    void Update()
    {
        Vector2 screenPositionPylon = Camera.main.WorldToScreenPoint(transform.position);

        float distanceToNextPylon = Vector2.Distance(transform.position, pylonPrefab.transform.position);

        if (distanceToNextPylon > newPylonDistance)
        {
            GameObject spawnedPylon = Instantiate(pylonPrefab, pylonSpawnPosition, Quaternion.identity);
        }
    }
}
