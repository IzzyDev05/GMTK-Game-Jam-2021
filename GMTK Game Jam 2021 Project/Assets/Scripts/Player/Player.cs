using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 5;
    [SerializeField] float movementSpeed = 10.0f;

    private float horizontal;
    private float vertical;
    private Rigidbody2D rb;
    private PlayerDeath death;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        death = GetComponent<PlayerDeath>();
    }

    private void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (health <= 0) {
            death.KillPlayer();
        }
    }

    private void FixedUpdate() {
        float horizontalSpeed = horizontal * movementSpeed * Time.deltaTime;
        float verticalSpeed = vertical * movementSpeed * Time.deltaTime;

        rb.velocity = new Vector2(horizontalSpeed, verticalSpeed);
    }
}