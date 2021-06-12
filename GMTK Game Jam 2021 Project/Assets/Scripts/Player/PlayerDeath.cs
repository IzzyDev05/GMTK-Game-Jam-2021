using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] float timeAfterDeath = 1f;
    [SerializeField] GameObject gameOverPanel;

    private GameObject player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("OffScreen")) {
            FindObjectOfType<AudioManager>().Play("OffscreenDeath");
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