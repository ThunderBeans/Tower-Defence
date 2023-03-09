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
    NavMeshAgent nmAgent;
    Vector3 navDestination = new(570, 264, -689); //change this to the vector3 of the end of the path



    private void Awake()
    {
        nmAgent = GetComponent<NavMeshAgent>();

        nmAgent.speed = walkSpeed;
        nmAgent.angularSpeed = turnSpeed;
        nmAgent.acceleration = accel;
        nmAgent.stoppingDistance = distanceUntillStop;
    }
    void Start()
    {
        nmAgent.destination = navDestination;
    }
}
