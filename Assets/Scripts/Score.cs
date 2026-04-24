using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float score;

    public Player playerScript;

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
            if (playerScript == null)
            {
                return;
            }

            score += Time.deltaTime;

            scoreText.text = "Score: " + Mathf.FloorToInt(score);
        }
    }
}
