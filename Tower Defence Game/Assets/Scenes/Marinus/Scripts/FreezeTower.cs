using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTower : MonoBehaviour
{
    public float range = 5f;
    public float damage = 1f;
    public static string targetTag = "Enemy";
    public Transform[] gun;
    public float fireRate = 8f;
    public float freezePower = 0.3f; // lager is sterker
    public GameObject freezeRay;


    EnemyCombat emc;
    EnemyWalk emw;

    private float fireCountdown = 0f;

    void LateUpdate()
    {
        fireCountdown -= Time.deltaTime;
        if (fireCountdown <= 0f)
        {
            FindTargetAndShoot();
            fireCountdown = 1f / fireRate;
        }
    }

    void FindTargetAndShoot()
    {
        // int ignore = 0; ignore = Random.Range(0, 2);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetTag);
        
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) // && ignore == 1)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;

            }
            else if (distanceToEnemy > shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            gun[0].LookAt(nearestEnemy.transform);
            
            RaycastHit hit;
            if (Physics.Raycast(gun[0].position, gun[0].forward, out hit, range))
            {
                if (hit.collider.gameObject.CompareTag(targetTag))
                {
                    emc = nearestEnemy.GetComponent<EnemyCombat>();
                    emw = nearestEnemy.GetComponent<EnemyWalk>();

                    print("Shooting");
                    freezeRay.GetComponent<ParticleSystem>().Play();

                    emc.hitPoints -= damage;
                    FreezeEnemy(freezePower);
                }
            }
        }
    }
    public void FreezeEnemy(float _freezePower)
    {
        emw.walkSpeed = Mathf.MoveTowards(emw.walkSpeed, 0, (1 / _freezePower) * Time.deltaTime);
        if (emw.walkSpeed <= 0)
        {
            emc.Man.GetComponent<Renderer>().material.color = emc.FrozenMat.color;
        }
        else if (emw.walkSpeed >= 0)
        { 
            emc.Man.GetComponent<Renderer>().material.color = emc.NormalMat.color;
        }
    }

}


