using UnityEngine;

public class SpawnerPylonsMiddle : MonoBehaviour
{
    public float newPylonDistance;
    public float offset;

    //public Transform player;

    public GameObject pylonPrefab;
    private GameObject spawnedPylon;

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
            Vector2 screenPositionPylon = Camera.main.WorldToScreenPoint(transform.position);

            float distanceToNextPylon = Vector2.Distance(transform.position, spawnedPylon.transform.position);

            if (distanceToNextPylon > newPylonDistance)
            {
                spawnedPylon = Instantiate(pylonPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
