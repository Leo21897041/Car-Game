using UnityEngine;

public class SpawnerF1Sides : MonoBehaviour
{
    public GameObject trackSidePrefab;
    public int trackSideAmount;
    public float trackSideSpawnOffset;
    public Vector3 spawnStartPosition;

    public float ySpawnTop;
    public float ySpawnBottom;

    void Start()
    {
        spawnStartPosition = transform.position;

        for (int i = 0; i < trackSideAmount; i++)
        {
            Vector3 spawnPositionTop = spawnStartPosition + new Vector3(trackSideSpawnOffset * i, ySpawnTop, 0);
            Instantiate(trackSidePrefab, spawnPositionTop, transform.rotation);

            Vector3 spawnPositionBottom = spawnStartPosition + new Vector3(trackSideSpawnOffset * i, ySpawnBottom, 0);
            Instantiate(trackSidePrefab, spawnPositionBottom, transform.rotation);
        }
    }

    void Update()
    {

    }
}
