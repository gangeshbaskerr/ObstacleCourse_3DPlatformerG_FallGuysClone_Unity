using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    private float startTime;
    private float endTime;
    private float elapsedTime;
    private int score;

    public static GameManager inst;
    public GameObject gameOverScreen;
    public Text scoreText;
    public Text timeText;

    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        elapsedTime = Time.time - startTime;
        timeText.text = "Time: " + FormatTime(elapsedTime);
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        endTime = Time.time;
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetFloat("Time", endTime - startTime);
        gameOverScreen.SetActive(true);
    }

    private string FormatTime(float timeInSeconds)
    {
        TimeSpan time = TimeSpan.FromSeconds(timeInSeconds);
        return string.Format("{0:D2}:{1:D2}", time.Minutes, time.Seconds);
    }
}
