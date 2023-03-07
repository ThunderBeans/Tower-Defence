using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FriendlyCombat : MonoBehaviour
{
    //-- Enemy Stats
    public float hitPoints = 20;
    public float damage = 10;
    public float attackCoolDown = 1f; // how many seconds between attacks
    public float critChance = 10f; // 1 in ...
    public float critDmgMultiplier = 1.5f;

    //-- Misc
    public Transform target;
    public Transform DeafaultTargetPosition;
    public bool enemySeen;
    public bool enemyDead;
    public List<GameObject> enemies;
    private bool criticalHit = false;
    FriendlyCombat friendlyCombatScript;


    private void Start()
    {
        enemyDead = false;

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Friendly"))
        {

            enemySeen = true;
            target = collider.gameObject.transform;
            enemies.Add(collider.gameObject);
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Friendly"))
        {
            enemySeen = false;
            enemies.Remove(collider.gameObject);
        }
    }


    void Update()
    {
        if (enemyDead == true && enemies.Count >= 0)
        {
            Destroy(enemies[0]);
            enemies.RemoveAt(0);
            enemySeen = false;
            enemyDead = false;
        }

        if (enemySeen == true)
        {
            transform.LookAt(enemies[0].transform);
        }


        if (enemies.Count > 0)
        {
            enemySeen = true;
        }

    }

    void attack()
    {
        if (UnityEngine.Random.Range(1, critChance) == 1)
        {
            criticalHit = true;
        }

        friendlyCombatScript = enemies[0].GetComponent<FriendlyCombat>();

        if(criticalHit)
        {
            friendlyCombatScript.hitPoints -= (damage * critDmgMultiplier);
        }else
        {

        }
    }
}