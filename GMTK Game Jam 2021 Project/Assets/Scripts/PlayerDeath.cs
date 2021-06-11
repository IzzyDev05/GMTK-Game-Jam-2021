using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("OffScreen")) {
            KillPlayer("Went offscreen!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Obstacles") {
            KillPlayer("Hit obstacle!");
        }
    }

    public void KillPlayer(string reason) {
        Debug.Log("PLAYER HAS DIED! BIG OOF! CAUSE: " + reason);
    }
}
