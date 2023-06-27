using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 5f;
    public float damage = 10f;
    public static string targetTag = "Enemy";
    public Transform[] gun;
    public float fireRate = 1f;
    EnemyCombat emc;
    private float fireCountdown = 0f;

    void Update()
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
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
                print("HIT");

            }
            if (distanceToEnemy > shortestDistance)
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
                    emc.hitPoints -= damage;
                }
            }
        }
    }
}
