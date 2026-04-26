using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float score;

    public Player playerScript;

    public bool isStartButton;
    public GameObject startButton;

    public float scoreSpeed;

    public void OnStartButton()
    {
        isStartButton = true;
        startButton.SetActive(false);
    }

    void Update()
    {
        if (isStartButton)
        {
            if (playerScript.isGameOver == true)
            {
                return;
            }

            score += playerScript.currentSpeed / scoreSpeed;

            scoreText.text = "Score: " + Mathf.FloorToInt(score);
        }
    }
}
