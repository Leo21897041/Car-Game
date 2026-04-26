using UnityEngine;

public class SpawnerCars : MonoBehaviour
{
    public GameObject carPrefabTop;
    public GameObject carPrefabBottom;
    public GameObject startButton;
    public bool isStarted;

    public Vector3 startSpawnPositionTop;

    public float spawnProgressTop;
    public float spawnDurationTop;
    public float randomDurationMinTop;
    public float randomDurationMaxTop;

    public int spawnAmountCarsTop;
    public int spawnOffsetYTop;
    public int randomLaneTop;
    public int randomLaneTopMin;
    public int randomLaneTopMax;
    
    public int laneOne;
    public int laneTwo;

    public Vector3 startSpawnPositionBottom;

    public float spawnProgressBottom;
    public float spawnDurationBottom;
    public float randomDurationMinBottom;
    public float randomDurationMaxBottom;

    public int spawnAmountCarsBottom;
    public int spawnOffsetYBottom;
    public int randomLaneBottom;
    public int randomLaneBottomMin;
    public int randomLaneBottomMax;

    public int laneThree;
    public int laneFour;


    void Start()
    {
        
    }

    public void OnStartButton()
    {
        startButton.SetActive(false);

        isStarted = true;

        randomLaneTop = Random.Range(randomLaneTopMin, randomLaneTopMax);
        randomLaneBottom = Random.Range(randomLaneBottomMin, randomLaneBottomMax);
        
        if (randomLaneTop == 1)
        {
            spawnOffsetYTop = laneOne;
        }
        if (randomLaneTop == 2)
        {
            spawnOffsetYTop = laneTwo;
        }

        if (randomLaneBottom == 1)
        {
            spawnOffsetYBottom = laneThree;
        }
        if (randomLaneBottom == 2)
        {
            spawnOffsetYBottom = laneFour;
        }

        
    }

    void Update()
    {
        if (isStarted)
        {
            spawnProgressTop += Time.deltaTime;
            spawnProgressBottom += Time.deltaTime;
           
            Vector3 spawnPositionBottom = startSpawnPositionBottom - new Vector3(0, spawnOffsetYBottom, 0);
            Vector3 spawnPositionTop = startSpawnPositionTop - new Vector3 (0, spawnOffsetYTop, 0);

            if (spawnProgressTop > spawnDurationTop)
            {
                Instantiate(carPrefabTop, spawnPositionTop, transform.rotation);

                spawnProgressTop = 0;
                spawnDurationTop = Random.Range(randomDurationMinTop, randomDurationMaxTop);

                randomLaneTop = Random.Range(randomLaneTopMin, randomLaneTopMax);

                if (randomLaneTop == 1)
                {
                    spawnOffsetYTop = laneOne;
                }
                if (randomLaneTop == 2)
                {
                    spawnOffsetYTop = laneTwo;
                }
            }

            if (spawnProgressBottom > spawnDurationBottom)
            {
                Instantiate(carPrefabBottom, spawnPositionBottom, transform.rotation);

                spawnProgressBottom = 0;
                spawnDurationBottom = Random.Range(randomDurationMinTop, randomDurationMaxTop);

                randomLaneBottom = Random.Range(randomLaneBottomMin, randomLaneBottomMax);

                if (randomLaneBottom == 1)
                {
                    spawnOffsetYBottom = laneThree;
                }
                if (randomLaneBottom == 2)
                {
                    spawnOffsetYTop = laneFour;
                }
            }
        }
    }
}
