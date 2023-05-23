using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WavesSpawner : MonoBehaviour
{
    public GameObject prefab; 
    public float spawnTime = 2f; 
    private float timer = 0f;
    public float waveTimer;
    public float wave = 1;
    public TextMeshProUGUI waveText;

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
            Instantiate(prefab, spawnPos, Quaternion.identity);
        }
    }
}
