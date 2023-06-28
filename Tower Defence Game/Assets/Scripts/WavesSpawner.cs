using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WavesSpawner : MonoBehaviour
{
    public GameObject Man;
    public GameObject Slime;
    public GameObject Paddenstoel;
    public GameObject NewEnemy;
    public float spawnTime = 2f;
    private float timer = 0f;
    public float waveTimer;
    public float wave = 1;
    public TextMeshProUGUI waveText;

    private float paddenstoelSpawnChance = 0.05f; // 10% chance of Paddenstoel spawning
    private float newEnemySpawnChance = 0.08f; // 10% chance of NewEnemy spawning

    void Update()
    {
        timer += Time.deltaTime;
        waveTimer += Time.deltaTime;

        if (waveTimer >= 20f)
        {
            waveTimer = 0f;
            wave++;
            spawnTime *= 0.9f;
            waveText.text = "Wave: " + wave.ToString();
        }

        if (timer >= spawnTime)
        {
            timer = 0f;

            Vector3 spawnPos = transform.position;
            Vector3 hitboxSize = GetComponent<Collider>().bounds.size;
            spawnPos.x += Random.Range(-hitboxSize.x / 2f, hitboxSize.x / 2f);
            spawnPos.y += Random.Range(-hitboxSize.y / 2f, hitboxSize.y / 2f);
            spawnPos.z += Random.Range(-hitboxSize.z / 2f, hitboxSize.z / 2f);
            PickEnemy(spawnPos);
        }
    }

    private void PickEnemy(Vector3 _spawnPos)
    {
        if (wave > 0)
        {
            Instantiate(Man, _spawnPos, Quaternion.identity);
        }

        if (wave > 4)
        {
            Instantiate(Slime, _spawnPos, Quaternion.identity);
        }

        if (wave > 6 && Random.value <= newEnemySpawnChance)
        {
            Instantiate(NewEnemy, _spawnPos, Quaternion.identity);
        }

        if (wave > 9 && Random.value <= paddenstoelSpawnChance)
        {
            Instantiate(Paddenstoel, _spawnPos, Quaternion.identity);
        }
    }
}
