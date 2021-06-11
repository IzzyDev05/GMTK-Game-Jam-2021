using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    PlayerDeath death;

    private void Start() {
        death = FindObjectOfType<PlayerDeath>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            death.KillPlayer("Hit obstacle!");
        }
    }
}
