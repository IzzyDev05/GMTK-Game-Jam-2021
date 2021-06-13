using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    private void Start() {
        PauseMenu.gameIsPaused = false;
    }

    public void ToMainMenu() {
        SceneManager.LoadScene(0);
    }
}