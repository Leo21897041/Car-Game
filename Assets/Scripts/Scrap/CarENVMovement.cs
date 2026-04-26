using UnityEngine;

public class CarENVMovement : MonoBehaviour
{
    private Player playerScript;

    public Vector3 startPositionENV;
    public Vector3 currentPositionENV;
    public Vector3 startPositionPlayer;

    private float amountMoved;

    void Start()
    {
        playerScript = FindFirstObjectByType<Player>();

        startPositionENV = transform.position;
        startPositionPlayer = playerScript.transform.position;
    }

    void Update()
    {
        currentPositionENV = transform.position;

        amountMoved = startPositionPlayer.x - playerScript.currentPosition.x;

        if (playerScript.currentSpeed != 0)
        {
            currentPositionENV.x += amountMoved;
        }

        transform.position = currentPositionENV;
    }
}
