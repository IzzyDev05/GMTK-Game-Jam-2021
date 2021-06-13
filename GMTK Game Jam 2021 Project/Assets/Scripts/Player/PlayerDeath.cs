using System.Collections;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public static bool playerWentOffscreen = false;

    [SerializeField] float timeAfterDeath = 1f;
    [SerializeField] float timeBeforeEnd = 7f;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject quitScreen;
    [SerializeField] GameObject countdownPanel;
    [SerializeField] GameObject playerEffects;

    private void Start() {
        quitScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("OffScreen")) {
            FindObjectOfType<AudioManager>().Play("OffscreenDeath");
            playerWentOffscreen = true;
            Instantiate(playerEffects, transform.position, Quaternion.identity);
            KillPlayer();
        }
    }

    public void KillPlayer() {
        if (LossManager.numberOfLosses < 5) {
            quitScreen.SetActive(false);
            countdownPanel.GetComponent<Animator>().SetTrigger("FadeOut");
            StartCoroutine(ActivateGameOver());
        }
        else {
            gameOverPanel.SetActive(false);
            countdownPanel.GetComponent<Animator>().SetTrigger("FadeOut");
            StartCoroutine(ActivateEndGame());
        }
    }

    private IEnumerator ActivateGameOver() {
        yield return new WaitForSeconds(timeAfterDeath);
        gameOverPanel.SetActive(true);
    }

    private IEnumerator ActivateEndGame() {
        yield return new WaitForSeconds(timeAfterDeath);
        quitScreen.SetActive(true);
        yield return new WaitForSeconds(timeBeforeEnd);
        Debug.Log("Game application has ended");
        Application.Quit();
    }
}