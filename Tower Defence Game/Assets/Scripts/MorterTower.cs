using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorterTower : MonoBehaviour
{
    public GameObject prefabToSpawn;    // The prefab to spawn
    public float spawnInterval = 1.0f;  // Time interval between spawns
    public GameObject spawnPoint;
    private float spawnTimer = 0.0f;    // Timer to track spawn interval

    private void FindNearestEnemyOnXAxis()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float nearestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Mathf.Abs(transform.position.x - enemy.transform.position.x);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            Vector3 direction = nearestEnemy.transform.position - transform.position;
            direction.y = 0f;  // Ignore the y-axis
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
        }
    }


    // Update is called once per frame
    void Update()
    {

        FindNearestEnemyOnXAxis();
        // Increment the spawn timer
        spawnTimer += Time.deltaTime;

        // Check if it's time to spawn the prefab
        if (spawnTimer >= spawnInterval)
        {
            SpawnPrefab();
            spawnTimer = 0.0f;  // Reset the spawn timer
        }
    }

    void SpawnPrefab()
    {
        Quaternion rotation = transform.rotation;  // Get the rotation of the MorterTower gameObject
        Instantiate(prefabToSpawn, spawnPoint.transform.position, rotation);
    }
}
