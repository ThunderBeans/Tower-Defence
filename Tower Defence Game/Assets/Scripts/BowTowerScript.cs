using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BowTowerScript : MonoBehaviour
{
    public Transform target;
    public Transform DeafaultTargetPosition;
    public float fireRate;
    public bool EnemySeen;
    public bool EnemyDead;
    public List<GameObject> enemy;
    public EnemyPrototype EP;
    public Transform FirePoint;
    public float currentTime;
    private void Start()
    {
        EnemyDead = false;

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {

            EnemySeen = true;
            target = collider.gameObject.transform;
            enemy.Add(collider.gameObject);
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            EnemySeen = false;
            enemy.Remove(collider.gameObject);
        }

    }


    void Update()
    {
        if(enemy.Count <= 0)
        {
            EnemySeen=false;
        }
        if (enemy.Count > 0 && enemy[0] == null)
        {
            enemy.RemoveAt(0);
            EnemySeen = false;
        }

        if (enemy.Count > 0)
        {
            EP = enemy[0].GetComponent<EnemyPrototype>();
        }
        else
        {
            EP = null;
        }

        if (EnemyDead == true && enemy.Count >= 0)
        {
            Destroy(enemy[0]);
            enemy.RemoveAt(0);
            EnemySeen = false;
            EP.Dead = true;
        }

        if (EnemySeen == true)
        {
            transform.LookAt(enemy[0].transform);

            if (Time.time >= currentTime)
            {
                currentTime = Time.time + fireRate;
                if (EP != null)
                {
                    EP.health -= 25;
                }
            }
        }

        else
        {
            transform.LookAt(transform);
        }

        if (enemy.Count > 0)
        {
            EnemySeen = true;
        }

        if (EP != null && EP.Dead == true)
        {
            enemy.RemoveAt(0);
        }

    }
}

