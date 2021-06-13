using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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