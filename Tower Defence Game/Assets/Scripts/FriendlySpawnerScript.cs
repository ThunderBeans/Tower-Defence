using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlySpawnerScript : MonoBehaviour
{
    [SerializeField] int towerLevel = 1;

    [SerializeField] float spawnCooldown = 5;
    int maxSpawnRate = 3;

    [SerializeField] GameObject toSpawn;

    public float cooldown;

    List<GameObject> spawnedUnits = new List<GameObject>();

    void Awake()
    {
        cooldown = spawnCooldown;
    }

    void Update()
    {
        switch (towerLevel)
        {
            case 1:
                maxSpawnRate = 3;
                break;
            case 2:
                maxSpawnRate = 5;
                break;
            case 3:
                maxSpawnRate = 7;
                break;
        }

        if(cooldown < 0)
        {
            if (spawnedUnits.Count < maxSpawnRate)
            { 
            spawnUnit();
            }
            cooldown = spawnCooldown;
        }else
        {
            cooldown -= 1 * Time.deltaTime;
        }

        for (int i = 0; i < spawnedUnits.Count; i++)
        {
            if (spawnedUnits[i] == null)
            {
                spawnedUnits.RemoveAt(i);
            }
        }
    }

    void spawnUnit()
    {
        GameObject unit = Instantiate(toSpawn, gameObject.transform.position, gameObject.transform.rotation);
        spawnedUnits.Add(unit);
    }
}