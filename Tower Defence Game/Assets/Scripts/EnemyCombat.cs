using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyCombat : MonoBehaviour
{
    //-- Enemy Stats
    public float hitPoints = 50;
    public float damage = 10;
    public float attackCoolDown = 1f; // how many seconds between attacks
    public float critChance = 10f; // 1 in ...
    public float critDmgMultiplier = 1.5f;

    //-- Misc
    public Transform target;
    public Transform DeafaultTargetPosition;
    public bool enemySeen;
    public bool enemyDead;
    public bool Dead;
    public List<GameObject> enemies;
    private bool criticalHit = false;
    private float coolDownBackup;
    FriendlyCombat friendlyCombatScript;
    EnemyWalk enemyWalk;
    public CurencyScript curencyScript;

    private void Awake()
    { 
        curencyScript = GameObject.Find("Gui").GetComponent<CurencyScript>();
        enemyWalk = GetComponent<EnemyWalk>();
        coolDownBackup = attackCoolDown;
        enemyDead = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (Dead == false)
        {

            if (collider.CompareTag("Friendly"))
            {

                enemySeen = true;
                target = collider.gameObject.transform;
                enemies.Add(collider.gameObject);
            }
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (Dead == false)
        {

            if (collider.CompareTag("Friendly"))
            {
                enemySeen = false;
                enemyWalk.inCombat = false;
                enemies.Remove(collider.gameObject);
            }
        }
    }


    void Update()
    {
        
        if (hitPoints <= 0)
        {
            curencyScript.addMoney();
            Dead=true;
            Destroy(gameObject);
            
        }
        if (Dead == false)
        {
            if (enemies.Count > 0 && enemies[0] == null)
            {
                enemies.RemoveAt(0);
                enemySeen = false;
                enemyWalk.inCombat = false;
            }

            if (enemyDead == true && enemies.Count >= 0)
            {
                Destroy(enemies[0]);
                enemies.RemoveAt(0);
                enemyWalk.inCombat = false;
                enemySeen = false;
                enemyDead = false;
            }

            if (enemySeen == true)
            {
                enemyWalk.inCombat = true;
                transform.LookAt(enemies[0].transform);
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
    }

    void attack()
    {
        if (UnityEngine.Random.Range(1, critChance) == 1)
        {
            criticalHit = true;
        }

        friendlyCombatScript = enemies[0].GetComponent<FriendlyCombat>();

        if (criticalHit)
        {
            friendlyCombatScript.hitPoints -= (damage * critDmgMultiplier);
            criticalHit = false;
        }
        else
        {
            friendlyCombatScript.hitPoints -= damage;
        }

        if (friendlyCombatScript.hitPoints <= 0)
        {
            enemyDead = true;
        }
    }
}