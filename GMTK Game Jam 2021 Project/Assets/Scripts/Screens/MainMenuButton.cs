using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void ToMainMenu() {
        SceneManager.LoadScene(0);
    }
}