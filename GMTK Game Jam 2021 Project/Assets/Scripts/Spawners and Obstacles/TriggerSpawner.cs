using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawner : MonoBehaviour
{
    [SerializeField] float speed = 2.5f;
    [SerializeField] GameObject leftCap;
    [SerializeField] GameObject rightCap;
    [SerializeField] GameObject triggerHolder;

    private GameObject spawnedObject;

    private void Start() {
        float distance = Vector3.Distance(leftCap.transform.position, rightCap.transform.position);
        float spawnpointX = leftCap.transform.position.x + (distance / 2);
        float spawnpointY = leftCap.transform.position.y;

        CreateTriggger(distance, spawnpointX, spawnpointY);
    }

    private void Update() {
        spawnedObject.transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void CreateTriggger(float distance, float spawnPointX, float spawnpointY) {
        spawnedObject = new GameObject("Spawned Trigger");

        spawnedObject.AddComponent<BoxCollider2D>();
        spawnedObject.AddComponent<Rigidbody2D>();

        spawnedObject.GetComponent<Transform>().localPosition = new Vector3(spawnPointX, spawnpointY, transform.localPosition.z); ;
        spawnedObject.GetComponent<BoxCollider2D>().size = new Vector2(distance, 0.1f);
        spawnedObject.GetComponent<Rigidbody2D>().gravityScale = 0;

        spawnedObject.GetComponent<BoxCollider2D>().isTrigger = true;
        spawnedObject.tag = "ScoreTrigger";

        spawnedObject.transform.parent = triggerHolder.transform;
    }
}