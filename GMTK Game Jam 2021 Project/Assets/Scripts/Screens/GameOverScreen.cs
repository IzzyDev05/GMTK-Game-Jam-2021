﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void StopTime() {
        Time.timeScale = 0;
    }

    public void RestartLevel() {
        ThemeSong.isDead = false;
        PlayerDeath.playerWentOffscreen = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame() {
        Application.Quit();
    }

    private void OnDisable() {
        Time.timeScale = 1;
    }
}