using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FreezeTower : MonoBehaviour
{
    public float range = 5f;
    public float damage = 1f;
    public static string targetTag = "Enemy";
    public Transform[] guns;
    public float fireRate = 8f;
    public float freezePower = 0.3f; // larger is stronger
    public GameObject freezeRay;
    public ParticleSystem freeze;

    private void Start()
    {
        freeze = freezeRay.GetComponent<ParticleSystem>();
        StartCoroutine(ShootRoutine());
    }

    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / fireRate);
            FindTargetAndShoot();
        }
    }

    private void FindTargetAndShoot()
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
            foreach (Transform gun in guns)
            {
                gun.LookAt(nearestEnemy.transform);

                RaycastHit hit;
                if (Physics.Raycast(gun.position, gun.forward, out hit, range))
                {
                    if (hit.collider.gameObject.CompareTag(targetTag))
                    {
                        Debug.Log("Shoot");
                        EnemyCombat emc = nearestEnemy.GetComponent<EnemyCombat>();
                        EnemyWalk emw = nearestEnemy.GetComponent<EnemyWalk>();

                        freeze.Play();

                        emc.hitPoints -= damage;
                        
                        FreezeEnemy(emc, emw, freezePower);
                    }

                    Debug.Log("Hit Object: " + hit.collider.gameObject.name);
                }
            }
        }
    }

    private void FreezeEnemy(EnemyCombat emc, EnemyWalk emw, float _freezePower)
    {
        if (emc != null && emc.tag == "Enemy")
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
