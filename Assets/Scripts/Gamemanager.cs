using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public int score = 0;
    public int highScore = 0; // Added high score variable



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        // Load the high score from PlayerPrefs when the GameManager initializes

        highScore = PlayerPrefs.GetInt("HighScore", 0);

    }

    public void AddScore(int points)
    {
        score += points;

        // Check if the current score is higher than the high score
        if (score > highScore)
        {
            highScore = score;

            // Save the new high score to PlayerPrefs
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save(); // Make sure to save PlayerPrefs changes
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
