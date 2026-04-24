using UnityEngine;

public class SpawnerPylons : MonoBehaviour
{
    public float pylonProgress;
    public float pylonDuration;
    public Vector2 pylonSpawnPosition;

    public GameObject pylonPrefab;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (pylonProgress < pylonDuration)
        {
            pylonProgress += Time.deltaTime;
        }

        if (pylonProgress > pylonDuration)
        {
            pylonProgress = 0;

            GameObject spawnedPylon = Instantiate(pylonPrefab, pylonSpawnPosition, Quaternion.identity);
        }
    }
}
