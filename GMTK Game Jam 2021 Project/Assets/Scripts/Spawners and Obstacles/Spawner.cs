using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float startTimeBetweenSpawn;
    [SerializeField] float decreaseTime;
    [SerializeField] float minTime = 0.65f;
    [SerializeField] GameObject patternHolder;
    [SerializeField] GameObject[] obstaclePatterns;

    private float timeBetweenSpawn;

    private void Update() {
        if (timeBetweenSpawn <= 0) {
            int rand = Random.Range(0, obstaclePatterns.Length);
            Vector3 patternPos = new Vector3(obstaclePatterns[rand].transform.position.x, transform.position.y, 0);
            var obstacle = Instantiate(obstaclePatterns[rand], patternPos, Quaternion.identity);
            obstacle.transform.parent = patternHolder.transform;

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