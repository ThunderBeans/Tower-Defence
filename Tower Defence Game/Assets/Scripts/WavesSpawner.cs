using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WavesSpawner : MonoBehaviour
{
    public GameObject Man;
    public GameObject Slime;
    public GameObject Paddenstoel;
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
            PickEnemy(spawnPos);
            
          
        }
    }

         //EnemyPicked pakt een index en EnemySpawned geeft het nummer terug op deze index
         private void PickEnemy(Vector3 _spawnPos)
         {
           List<int> EnemyOdds = new List<int>() {0,0,0,0,0,0,0,0,0,1};
           if (wave < 5) 
           { 
            EnemyOdds = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1 }; 
           }

           if (wave < 10) 
           {
            EnemyOdds = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 1, 1, 2 }; 
           }

           if (wave < 20)
           {
            EnemyOdds = new List<int>() { 0, 0, 0, 0, 0, 1, 1, 1, 2, 2 };
           }   

        int EnemyPicked = Random.Range(0, EnemyOdds.Count);
            int EnemySpawned = EnemyOdds[EnemyPicked];
            switch (EnemySpawned) 
             { 
                    case 0:
                Instantiate(Man, _spawnPos, Quaternion.identity);
                //print(EnemySpawned);
                break;

                    case 1:
                Instantiate(Slime, _spawnPos, Quaternion.identity);
                //print(EnemySpawned);
                break;

                    case 2:
                Instantiate(Paddenstoel, _spawnPos, Quaternion.identity);
                //print(EnemySpawned);
                break;
            }
             
         }
}
