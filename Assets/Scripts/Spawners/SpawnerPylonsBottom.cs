using UnityEngine;

public class SpawnerPylonsBottom : MonoBehaviour
{
    public Vector2 pylonSpawnPosition;

    public float newPylonDistance;
    public float offset;

    public Transform player;

    public GameObject pylonPrefab;
    private GameObject spawnedPylon;

    void Start()
    {
        spawnedPylon = Instantiate(pylonPrefab, transform.position, Quaternion.identity);
    }

    void Update()
    {
        Vector2 screenPositionPylon = Camera.main.WorldToScreenPoint(transform.position);

        float distanceToNextPylon = Vector2.Distance(transform.position, spawnedPylon.transform.position);

        if (distanceToNextPylon > newPylonDistance)
        {
            spawnedPylon = Instantiate(pylonPrefab, transform.position, Quaternion.identity);
        }
    }
}
