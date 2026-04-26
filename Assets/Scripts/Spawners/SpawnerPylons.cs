using UnityEngine;

public class SpawnerPylons : MonoBehaviour
{
    public GameObject pylonPrefab;
    public int pylonAmountX;
    public int pylonAmountY;
    public Vector3 startingSpawnPosition;
    public float offsetPylonX;
    public float offsetPylonY;

    public float respawnProgress;
    public float respawnDuration;
    void Start()
    {
        for (int i = 0; i < pylonAmountX; i++)
        { 
            for (int j = 0; j < pylonAmountY; j++)
            { 
                Vector3 spawnPosition = startingSpawnPosition + new Vector3(offsetPylonX * i, -offsetPylonY * j, 0);
                GameObject spawnedPylon = Instantiate(pylonPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
    
    void Update()
    {

    }
}
