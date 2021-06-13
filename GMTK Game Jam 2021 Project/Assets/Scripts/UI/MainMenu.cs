using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Toggle postToggle;

    private void Start() {
        ThemeSong.isDead = false;
        PlayerDeath.playerWentOffscreen = false;

        if (PlayerPrefs.GetInt("PostProcessing") == 1) {
            postToggle.isOn = true;
        }
        else {
            postToggle.isOn = false;
        }

        PauseMenu.gameIsPaused = false;
    }

    public void PlayGame() {
        SceneManager.LoadScene(1);
    }

    public void OpenNotes() {
        SceneManager.LoadScene(2);
    }

    public void OpenCredits() {
        SceneManager.LoadScene(3);
    }

    public void QuitGame() {
        Application.Quit();
    }
}