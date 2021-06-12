using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    private void Start() {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Player") {
            var playerScore = other.gameObject.GetComponent<PlayerScore>();
            playerScore.playerScore++;
        }
    }
}
