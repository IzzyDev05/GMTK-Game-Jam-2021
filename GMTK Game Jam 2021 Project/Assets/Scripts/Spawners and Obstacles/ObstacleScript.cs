using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] float speed = 5;
    [SerializeField] GameObject obstalceEffect;

    private CameraShake camShake;

    private void Update() {
        camShake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CameraShake>();
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Player") {
            other.collider.GetComponent<Player>().health -= damage;
            Instantiate(obstalceEffect, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("PlayerHurt");
            camShake.CamShake();
            Destroy(gameObject);
        }
    }
}