using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject endGamePanel;
    [SerializeField] GameObject countdownPanel;

    private void Start() {
        gameIsPaused = false;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }

        CheckForPause();
    }

    public void Resume() {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    private void Pause() {
        pausePanel.SetActive(true);
        gameIsPaused = true;
    }

    public void MainMenu() {
        Time.timeScale = 1;
        gameIsPaused = false;
        SceneManager.LoadScene(0);
    }

    public void StopTime() {
        Time.timeScale = 0;
    }

    private void CheckForPause() {
        if (gameIsPaused) {
            gameOverPanel.SetActive(false);
            endGamePanel.SetActive(false);
            countdownPanel.SetActive(false);
        }
    }
}