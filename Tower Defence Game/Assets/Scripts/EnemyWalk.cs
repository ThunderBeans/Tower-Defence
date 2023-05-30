using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalk : MonoBehaviour
{
    //-- Stats
    float distanceUntillStop = 0.5f;
    float walkSpeed = 5;
    float turnSpeed = 120;
    float accel = 8;

    //-- Misc
    public bool inCombat = false;
    NavMeshAgent nmAgent;
    GameObject kasteel;
    Kasteel kasteelcode;

    private void Awake()
    {
        nmAgent = GetComponent<NavMeshAgent>();
        kasteelcode = GameObject.FindGameObjectWithTag("kasteel").GetComponent<Kasteel>();
        nmAgent.speed = walkSpeed;
        nmAgent.angularSpeed = turnSpeed;
        nmAgent.acceleration = accel;
        nmAgent.stoppingDistance = distanceUntillStop;

        kasteel = GameObject.FindGameObjectWithTag("kasteel");
    }

    void Start()
    {
        nmAgent.destination = kasteel.transform.position;
    }

    private void Update()
    {
        if (inCombat)
        {
            nmAgent.destination = gameObject.transform.position;
        }
        else if (!inCombat)
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
    }
}
