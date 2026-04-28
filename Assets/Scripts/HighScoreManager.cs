using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class HighScoreManager : MonoBehaviour
{
    public Score scoreScript;
    public Player playerScript;

    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI newHighScoreText;

    public GameObject highScoreUI;
    public GameObject newHighScoreUI;

    private int highScore;
    private bool hasCheckedHighScore;
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "HighScore: " + highScore;

        highScoreUI.SetActive(true);
        newHighScoreUI.SetActive(false);
    }

    public void StartButton()
    {
        highScoreUI.SetActive(false);
        newHighScoreUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.isGameOver && hasCheckedHighScore == false)
        {
            int finalScore = Mathf.FloorToInt(scoreScript.score);

            if (finalScore > highScore)
            {
                highScore = finalScore;

                PlayerPrefs.SetInt("HighScore", highScore);
                PlayerPrefs.Save();

                highScoreText.text = "HighScore: " + highScore;

                newHighScoreUI.SetActive(true);              
            }
            
            highScoreUI.SetActive(true);

            hasCheckedHighScore = true;
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            ResetHighScore();
        }
    }
    void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");

        highScore = 0;
        highScoreText.text = "HighScore: 0";

        if (newHighScoreText != null)
        {
            newHighScoreText.gameObject.SetActive(false);
        }
    }
}
