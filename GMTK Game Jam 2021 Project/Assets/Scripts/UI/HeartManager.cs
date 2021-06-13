using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    [SerializeField] GameObject[] filledHearts;
    [SerializeField] GameObject[] emptyHearts;

    private Player player;
    private int playerHealth;

    private void Start() {
        player = FindObjectOfType<Player>();
    }

    private void Update() {
        playerHealth = player.health;

        UpdateHearts();
    }

    private void UpdateHearts() {
        if (playerHealth == 5) {
            foreach (GameObject heart in filledHearts) {
                heart.SetActive(true);
            }
            foreach (GameObject heart in emptyHearts) {
                heart.SetActive(false);
            }
        }
        else if (playerHealth == 4) {
            filledHearts[0].SetActive(false);
            emptyHearts[0].SetActive(true);
        }
        else if (playerHealth == 3) {
            filledHearts[1].SetActive(false);
            emptyHearts[1].SetActive(true);
        }
        else if (playerHealth == 2) {
            filledHearts[2].SetActive(false);
            emptyHearts[2].SetActive(true);
        }
        else if (playerHealth == 1) {
            filledHearts[3].SetActive(false);
            emptyHearts[3].SetActive(true);
        }
        else {
            foreach (GameObject heart in filledHearts) {
                heart.SetActive(false);
            }
            foreach (GameObject heart in emptyHearts) {
                heart.SetActive(true);
            }
        }
    }
}