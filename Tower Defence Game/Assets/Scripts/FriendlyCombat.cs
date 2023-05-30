using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FriendlyCombat : MonoBehaviour
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
    public bool isDead;
    public List<GameObject> targets;
    private bool criticalHit = false;
    private float coolDownBackup;
    EnemyCombat otherCombattant;
    private string enemyTag = "Enemy";

    private void Awake()
    {
        coolDownBackup = attackCoolDown;
        isDead = false;
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

                if (targets.Count == 0)
                {
                    enemySeen = false;
                }
            }
        }
    }

    private void Update()
    {
        if (hitPoints <= 0)
        {
            isDead = true;
            targets.Clear();
        }

        attackCoolDown -= 1 * Time.deltaTime;

        if (attackCoolDown <= 0.1 && enemySeen && !isDead)
        {
            attackCoolDown = coolDownBackup;
            attack();
        }
        if (targets.Count > 0)
        {
            if (targets[0].GetComponent<EnemyCombat>().isDead)
            {
                targets.RemoveAt(0);
            }
        }
        else
        {
            enemySeen = false;
        }
    }

    void attack()
    {
        if (UnityEngine.Random.Range(1, critChance) == 1)
        {
            criticalHit = true;
        }

        otherCombattant = targets[0].GetComponent<EnemyCombat>();

        if (criticalHit)
        {
            otherCombattant.hitPoints -= (damage * critDmgMultiplier);
            criticalHit = false;
            print("!!CRIT!!");
        }
        else
        {
            otherCombattant.hitPoints -= damage;
        }
    }
}