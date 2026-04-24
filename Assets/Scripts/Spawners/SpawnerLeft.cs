using UnityEngine;

public class SpawnerLeft : MonoBehaviour
{
    public Vector2 laneOne;
    public Vector2 laneTwo;    

    public int randomLane;
    public float spawningProgress;
    public float spawningDuration;
    public float minTimer;
    public float maxTimer;

    public GameObject carPrefab;
    public Vector3 carSpawnPosition;

    public bool isStartButton;
    public GameObject startButton;
    void Start()
    {

    }

    public void OnStartButton()
    {
        isStartButton = true;
        startButton.SetActive(false);
    }
    
    void Update()
    {
        if (isStartButton)
        {
            if (spawningProgress < spawningDuration)
            {
                spawningProgress += Time.deltaTime;
            }

            if (spawningProgress > spawningDuration)
            {
                randomLane = Random.Range(1, 3);
                spawningProgress = 0f;
                spawningDuration = Random.Range(minTimer, maxTimer);

                if (randomLane == 1)
                {
                    carSpawnPosition = laneOne;
                }
                if (randomLane == 2)
                {
                    carSpawnPosition = laneTwo;
                }

                GameObject spawnedCar = Instantiate(carPrefab, carSpawnPosition, transform.rotation);

                Debug.Log(randomLane);
                Debug.Log(carSpawnPosition);
            }
        }
    }
}
