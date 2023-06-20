using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalk : MonoBehaviour
{
    // Stats
    float distanceUntilStop = 0.5f;
    float walkSpeed = 5;
    float turnSpeed = 120;
    float accel = 8;

    // Misc
    public bool inCombat = false;
    NavMeshAgent nmAgent;
    GameObject kasteel;
    Kasteel kasteelCode;
    EnemyCombat ec;

    private void Awake()
    {
        ec= GetComponent<EnemyCombat>();
        nmAgent = GetComponent<NavMeshAgent>();
        kasteelCode = GameObject.FindGameObjectWithTag("kasteel").GetComponent<Kasteel>();
        nmAgent.speed = walkSpeed;
        nmAgent.angularSpeed = turnSpeed;
        nmAgent.acceleration = accel;
        nmAgent.stoppingDistance = distanceUntilStop;

        kasteel = GameObject.FindGameObjectWithTag("kasteel");
    }

    void Start()
    {
        Invoke("Journy", 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("kasteel"))
        {
            if (kasteelCode.attacked == false)
            {
                kasteelCode.attacked = true;
                kasteelCode.Invoke("Damage", 2);
                Destroy(gameObject);
            }
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            ec.Hit();
        }
    }
    private void Journy()
    {
        nmAgent.SetDestination(kasteel.transform.position);
    }
}
