using System;
using UnityEngine;
using System.Collections;
using TMPro;

public class StopWatch : MonoBehaviour
{
    [SerializeField] TMP_Text timeAlive;
    [SerializeField] TMP_Text maxTimeAlive;

    private bool stopWatchActive = false;
    private float currentTime;

    private int minutes;
    private int seconds;
    private int milliseconds;

    private void Start() {
        currentTime = 0;
    }

    private void Update() {
        CheckIfPlayerAlive();
        UpdateTime();
    }

    private void CheckIfPlayerAlive() {
        if (!ThemeSong.isDead) {
            stopWatchActive = true;
        }
        else {
            stopWatchActive = false;
        }
    }

    private void UpdateTime() {
        if (stopWatchActive) {
            currentTime += Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timeAlive.text = time.ToString(@"mm\:ss\:fff");

        HighestTime(time);

        var highestTime = PlayerPrefs.GetInt("Minutes") + ":" + PlayerPrefs.GetInt("Seconds") + ":" + PlayerPrefs.GetInt("Milliseconds");
        maxTimeAlive.text = highestTime; 
    }

    private void HighestTime(TimeSpan time) {
        minutes = time.Minutes;
        seconds = time.Seconds;
        milliseconds = time.Milliseconds;

        PlayerPrefs.SetInt("Minutes", minutes);
        PlayerPrefs.SetInt("Seconds", seconds);
        PlayerPrefs.SetInt("Milliseconds", milliseconds);

        CheckIfHighest();
    }

    private void CheckIfHighest() {
        int highScoreMinutes = PlayerPrefs.GetInt("Minutes");
        int highScoreSeconds = PlayerPrefs.GetInt("Seconds");
        int highScoreMilliseconds = PlayerPrefs.GetInt("Milliseconds");

        if (minutes > highScoreMinutes) {
            SetNewHighScore();
        }
        else if (minutes == highScoreMinutes) {
            if (seconds > highScoreMinutes) {
                SetNewHighScore();
            }
            if (seconds == highScoreSeconds) {
                if (milliseconds > highScoreMilliseconds) {
                    SetNewHighScore();
                }
                else {
                    //do nothing
                }
            }
        }
    }

    private void SetNewHighScore() {
        PlayerPrefs.SetInt("Minutes", minutes);
        PlayerPrefs.SetInt("Seconds", seconds);
        PlayerPrefs.SetInt("Milliseconds", milliseconds);
    }
}