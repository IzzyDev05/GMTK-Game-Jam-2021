using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public static bool playerWentOffscreen = false;

    [SerializeField] float timeAfterDeath = 1f;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject playerEffects;

    private void Update() {
        if (playerWentOffscreen) {
            ThemeSong.isDead = true;
        }
        else {
            ThemeSong.isDead = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("OffScreen")) {
            FindObjectOfType<AudioManager>().Play("OffscreenDeath");
            Instantiate(playerEffects, transform.position, Quaternion.identity);
            playerWentOffscreen = true;
            KillPlayer();
        }
    }

    public void KillPlayer() {
         StartCoroutine(ActivateGameOver());
    }

    private IEnumerator ActivateGameOver() {
        yield return new WaitForSeconds(timeAfterDeath);
        gameOverPanel.SetActive(true);
    }
}