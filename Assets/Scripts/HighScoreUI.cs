using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreUI : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
        scoreText.text = "Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }
}
