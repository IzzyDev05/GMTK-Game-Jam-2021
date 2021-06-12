using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 5;
    [SerializeField] float movementSpeed = 10.0f;
    [SerializeField] GameObject gameOverPanel;

    private float horizontal;
    private float vertical;

    private BoxCollider2D boxColl;
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    private PlayerDeath death;

    private void Awake() {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void Start() {
        boxColl = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        death = GetComponent<PlayerDeath>();
    }

    private void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (health <= 0) {
            boxColl.enabled = false;
            sr.enabled = false;
            death.KillPlayer();
        }
    }

    private void FixedUpdate() {
        float horizontalSpeed = horizontal * movementSpeed * Time.deltaTime;
        float verticalSpeed = vertical * movementSpeed * Time.deltaTime;

        rb.velocity = new Vector2(horizontalSpeed, verticalSpeed);
    }
}