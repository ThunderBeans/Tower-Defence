using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float spawnInterval = 5f;
    public int minClouds = 1;
    public int maxClouds = 3;

    private void Start()
    {
        InvokeRepeating("SpawnClouds", spawnInterval, spawnInterval);
    }

    private void SpawnClouds()
    {
        int numClouds = Random.Range(minClouds, maxClouds + 1);
        for (int i = 0; i < numClouds; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2),
                                           transform.position.y + Random.Range(-transform.localScale.y / 2, transform.localScale.y / 2),
                                           Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2));
            Instantiate(cloudPrefab, spawnPos, Quaternion.identity);
        }
    }
}
