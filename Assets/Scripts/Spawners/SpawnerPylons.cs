using UnityEngine;

public class SpawnerPylons : MonoBehaviour
{
    public Vector2 pylonSpawnPosition;

    public float newPylonDistance;
    public float offset;

    public Transform player;

    public GameObject pylonPrefab;
    private GameObject spawnedPylon;

    void Start()
    {
        spawnedPylon = Instantiate(pylonPrefab, pylonSpawnPosition, Quaternion.identity);        
    }
    
    void Update()
    {
        Vector2 screenPositionPylon = Camera.main.WorldToScreenPoint(transform.position);

        float distanceToNextPylon = Vector2.Distance(transform.position, spawnedPylon.transform.position);

        if (distanceToNextPylon > newPylonDistance)
        {
            Vector3 spawnPosition = spawnedPylon.transform.position + player.up * offset;
            spawnedPylon = Instantiate(pylonPrefab, pylonSpawnPosition, Quaternion.identity);
        }
    }
}
