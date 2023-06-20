using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyWalk : MonoBehaviour
{
    //-- Stats
    float distanceUntillStop = 0.5f;
    public float walkSpeed = 5;
    float turnSpeed = 120;
    float accel = 8;
    public float baseSpeed;
    public float unFreezeSpeed = 1;

    //-- Misc
    public bool inCombat = false;
    NavMeshAgent nmAgent;
    GameObject kasteel;
    EnemyCombat ec;
    Kasteel kasteelcode;

    private void Awake()
    {
        ec = GetComponent<EnemyCombat>();
        kasteelcode = GameObject.FindGameObjectWithTag("kasteel").GetComponent<Kasteel>();
        nmAgent = GetComponent<NavMeshAgent>();
        baseSpeed = walkSpeed;
        nmAgent.speed = walkSpeed;
        nmAgent.angularSpeed = turnSpeed;
        nmAgent.acceleration = accel;
        nmAgent.stoppingDistance = distanceUntillStop;

        kasteel = GameObject.FindGameObjectWithTag("kasteel");
    }

    void Start()
    {
        Invoke("Journey", 0.6f);
    }

    private void Update()
    {

       nmAgent.speed = walkSpeed;
        if (walkSpeed <= baseSpeed)
        {
            walkSpeed = Mathf.MoveTowards(walkSpeed, baseSpeed, (1 / unFreezeSpeed) * Time.deltaTime);
        }

        if (walkSpeed <= 0)
        {
            walkSpeed = 0;
        }

        if (inCombat)
        {
            nmAgent.destination = gameObject.transform.position;
        }
        else if (!inCombat && nmAgent.isOnNavMesh)
        {
            nmAgent.destination = kasteel.transform.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("kasteel"))
        {
            if(kasteelcode.attacked == false)
            { 
                kasteelcode.attacked = true;
                kasteelcode.Invoke("Damage",2);
                Destroy(gameObject);
            }  
        }
    if (other.gameObject.CompareTag("Bullet"))
        {
        ec.Hit();
        }
    }

    IEnumerator walkSpeedUp(float start, float doel, float lengte)
    {
        for (float t = 0f; t < lengte; t += Time.deltaTime)
        {
            walkSpeed = Mathf.Lerp(start, doel, t /lengte);
            yield return null;
        }
        walkSpeed = doel;
    }

    private void Journey()
    {
        if (nmAgent.isOnNavMesh)
        { 
        nmAgent.SetDestination(kasteel.transform.position);
        }
    }
}
