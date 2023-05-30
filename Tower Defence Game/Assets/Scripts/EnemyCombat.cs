using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    //-- Unit Stats
    public float hitPoints = 50;
    public float damage = 10;
    public float attackCoolDown = 1f; // how many seconds between attacks
    public float critChance = 10f; // 1 in ...
    public float critDmgMultiplier = 1.5f;

    //-- Misc 
    public Transform targetTransform;
    public bool enemySeen;
    public bool castleSeen;
    public bool isDead;
    public List<GameObject> targets;
    private bool criticalHit = false;
    private float coolDownBackup;
    FriendlyCombat otherCombattant;
    private string enemyTag = "Friendly";
    EnemyWalk enemyWalk;

    public GameObject Man;
    public GameObject Poef;

    private void Awake()
    {
        enemyWalk = GetComponent<EnemyWalk>();
        coolDownBackup = attackCoolDown;
        isDead = false;
        castleSeen = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isDead)
        {
            if (other.gameObject.CompareTag(enemyTag))
            {
                enemySeen = true;
                targetTransform = other.gameObject.transform;
                targets.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isDead)
        {
            if (other.gameObject.CompareTag(enemyTag))
            {
                targets.Remove(other.gameObject);
                enemySeen = false;
            }
        }
    }
    void Dead()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        if (hitPoints <= 0)
        {
            isDead = true;
            targets.Clear();
            enemyWalk.inCombat = true;
            enemyWalk.enabled = false;
            Man.SetActive(false);
            Poef.SetActive(true);
            Invoke("Dead", 1);
        }

        attackCoolDown -= 1 * Time.deltaTime;


        if (targets.Count > 0)
        {
            if (targets[0].GetComponent<FriendlyCombat>().isDead)
            {
                targets.RemoveAt(0);
            }
        }else
        {
            enemySeen = false;
        }

        if (attackCoolDown <= 0.1 && enemySeen && !isDead)
        {
            attackCoolDown = coolDownBackup;
            attack();
        }

        if (enemySeen)
        {
            enemyWalk.inCombat = true;
            transform.LookAt(targetTransform);
        }else
        {
            enemyWalk.inCombat = false;
            transform.LookAt(transform);
        }
    }

    void attack()
    {
        if (targets.Count == 0) return;

        if (UnityEngine.Random.Range(1, critChance) == 1)
        {
            criticalHit = true;
        }  

        otherCombattant = targets[0].GetComponent<FriendlyCombat>();

        if (criticalHit)
        {
            otherCombattant.hitPoints -= (damage * critDmgMultiplier);
            criticalHit = false;
            print("!!CRIT!!");
        }else
        {
            otherCombattant.hitPoints -= damage;
        }
    }
}