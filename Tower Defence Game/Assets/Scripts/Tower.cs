using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 5f;
    public float damage = 10f;
    public string targetTag = "Enemy";
    public Transform gun;
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
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            gun.LookAt(nearestEnemy.transform);
            
            RaycastHit hit;
            if (Physics.Raycast(gun.position, gun.forward, out hit, range))
            {
                Debug.Log("2");
                if (hit.collider.gameObject.CompareTag(targetTag))
                {
                    emc = nearestEnemy.GetComponent<EnemyCombat>();
                    emc.hitPoints -= damage;
                    Debug.Log("Blalal");
                }
            }
        }
    }
}
