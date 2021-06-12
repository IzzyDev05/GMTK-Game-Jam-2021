using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePatterns;
    [SerializeField] float startTimeBetweenSpawn;
    [SerializeField] float decreaseTime;
    [SerializeField] float minTime = 0.65f;

    private GameObject obstacleHolder;
    private float timeBetweenSpawn;

    private void Start() {
        obstacleHolder = GameObject.FindGameObjectWithTag("Holder");
    }

    private void Update() {
        if (timeBetweenSpawn <= 0) {
            int rand = Random.Range(0, obstaclePatterns.Length);

            var obstacle = Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
            obstacle.transform.parent = obstacleHolder.transform;

            timeBetweenSpawn = startTimeBetweenSpawn;
            if (startTimeBetweenSpawn > minTime) {
                startTimeBetweenSpawn -= decreaseTime;
            }
        }
        else {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }
}