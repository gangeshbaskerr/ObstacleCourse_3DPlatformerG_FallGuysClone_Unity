using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTimeScript : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        DisplayScoreAndTime();
    }

    void DisplayScoreAndTime()
    {
        // Retrieve score and time from PlayerPrefs
        int score = PlayerPrefs.GetInt("Score", 0);
        float time = PlayerPrefs.GetFloat("Time", 0f);

        // Display score and time in the UI
        scoreText.text = "Score: " + score;
        timeText.text = "Time: " + FormatTime(time);
    }

    private string FormatTime(float timeInSeconds)
    {
        System.TimeSpan time = System.TimeSpan.FromSeconds(timeInSeconds);
        return string.Format("{0:D2}:{1:D2}", time.Minutes, time.Seconds);
    }
}
