using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FriendlyCombat : MonoBehaviour
{
    //-- Friendly Stats
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
    private float coolDownBackup;
    EnemyCombat EnemyCombatScript;

    private void Awake()
    {
        coolDownBackup = attackCoolDown;
    }
    private void Start()
    {
        enemyDead = false;

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {

            enemySeen = true;
            target = collider.gameObject.transform;
            enemies.Add(collider.gameObject);
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            enemySeen = false;
            enemies.Remove(collider.gameObject);
        }
    }

    
    void Update()
    {
        if (enemies.Count > 0 && enemies[0] == null)
        {
            enemies.RemoveAt(0);
            enemySeen = false;
        }

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
        else
        {
            transform.LookAt(transform);
        }


        if (enemies.Count > 0)
        {
            enemySeen = true;
        }

        attackCoolDown -= 1 * Time.deltaTime;

        if (attackCoolDown <= 0.1 && enemySeen)
        {
            attackCoolDown = coolDownBackup;
            attack();
        }
    }

    void attack()
    {
        if (UnityEngine.Random.Range(1, critChance) == 1)
        {
            criticalHit = true;
        }

        EnemyCombatScript = enemies[0].GetComponent<EnemyCombat>();

        if(criticalHit)
        {
            print("!!CRIT!!");
            EnemyCombatScript.hitPoints -= (damage * critDmgMultiplier);
            criticalHit = false;
        }else
        {
            EnemyCombatScript.hitPoints -= damage;
        }

        if (EnemyCombatScript.hitPoints <= 0)
        {
            enemyDead = true;
        }
    }
}