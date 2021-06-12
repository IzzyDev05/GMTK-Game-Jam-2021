using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] float speed = 5;
    [SerializeField] GameObject obstalceEffect;

    private CameraShake camShake;
    private Player player;

    private void Update() {
        camShake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CameraShake>();
        player = FindObjectOfType<Player>();
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Player") {
            other.collider.GetComponent<Player>().health -= damage;
            Instantiate(obstalceEffect, transform.position, Quaternion.identity);
            ManageSound();
            camShake.CamShake();
            Destroy(gameObject);
        }
    }

   private void ManageSound() {
        if (player.health <= 0) {
            FindObjectOfType<AudioManager>().Play("OffscreenDeath");
        }
        else {
            FindObjectOfType<AudioManager>().Play("PlayerHurt");
        }
    }
}