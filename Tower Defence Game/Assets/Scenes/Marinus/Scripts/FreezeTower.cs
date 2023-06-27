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
    public static ParticleSystem freeze;


    EnemyCombat emc;
    EnemyWalk emw;

    private float fireCountdown = 0f;
    private void Start()
    {
    freeze = freezeRay.GetComponent<ParticleSystem>();
    }
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
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetTag);
        GameObject nearestEnemy = null;
        float shortestDistance = range + 1f; // Initialize with a value greater than the range

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy <= shortestDistance) // Check if distance is less than or equal
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
                    print("Shoot");
                    emc = nearestEnemy.GetComponent<EnemyCombat>();
                    emw = nearestEnemy.GetComponent<EnemyWalk>();

                    freeze.Play();

                    emc.hitPoints -= damage;

                    FreezeEnemy(freezePower);
                }

                Debug.Log("Hit Object: " + hit.collider.gameObject.name);
            }
        }
    }



    public void FreezeEnemy(float _freezePower)
    {
        if(emc.tag == "Enemy")
        { 
        emw.walkSpeed = Mathf.MoveTowards(emw.walkSpeed, 0, (1 / _freezePower) * Time.deltaTime);
        }
        
        if (emw.walkSpeed <= 0)
        {
            emc.Man.GetComponent<Renderer>().material.color = emc.FrozenMat.color;
            emc.tag = "Untagged";
        }
       
        else if (emw.walkSpeed >= 0)
        { 
            emc.Man.GetComponent<Renderer>().material.color = emc.NormalMat.color;
            
        }
    }

}