using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] float destroyObstacleAfter = 5f;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject obstacleHolder;

    private void Start() {
        var obstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        obstacle.transform.parent = obstacleHolder.transform;

        Destroy(obstacle, destroyObstacleAfter);
    }
}