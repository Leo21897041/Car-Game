using UnityEngine;

public class SpawnerF1Tracks : MonoBehaviour
{
    public GameObject f1TrackPrefab;
    public Vector3 spawnStartingPosition;
    public int spawnAmountLanes;
    public float spawnOffsetLanes;

    void Start()
    {
        spawnStartingPosition = transform.position;
        
        for (int i = 0; i < spawnAmountLanes; i++)
        { 
            Vector3 spawnPosition = spawnStartingPosition + new Vector3(0, spawnOffsetLanes * i, 0);
            GameObject f1Tracks = Instantiate(f1TrackPrefab, spawnPosition, transform.rotation);
        }       
    }
    
    void Update()
    {
        
    }
}
