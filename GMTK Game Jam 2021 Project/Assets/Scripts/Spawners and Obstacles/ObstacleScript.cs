using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] float speed = 1.5f;

    [SerializeField] GameObject obstalceEffect;
    [SerializeField] GameObject playerEffects;

    private float currentTime;
    private CameraShake camShake;
    private Player player;

    private void Update() {
        camShake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CameraShake>();
        player = FindObjectOfType<Player>();
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        HandlePlayerDeath();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Player") {
            other.collider.GetComponent<Player>().health -= damage;
            PlayerScore.playerScore--;
            Instantiate(obstalceEffect, transform.position, Quaternion.identity);

            ManageSound();
            MiscActivities();
        }
    }

    private void HandlePlayerDeath() {
        if (player.health <= 0 || PlayerDeath.playerWentOffscreen) {
            ThemeSong.isDead = true;
        }
        else {
            ThemeSong.isDead = false;
        }
    }

   private void ManageSound() {
        if (player.health <= 0) {
            FindObjectOfType<AudioManager>().Play("OffscreenDeath");
            Instantiate(playerEffects, player.transform.position, Quaternion.identity);
        }
        else {
            FindObjectOfType<AudioManager>().Play("PlayerHurt");
        }
    }

    private void MiscActivities() {
        camShake.CamShake();
        Destroy(gameObject);
    }
}