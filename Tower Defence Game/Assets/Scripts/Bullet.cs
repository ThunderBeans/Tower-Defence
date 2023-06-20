using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float launchForce = 10f;           // Force applied to launch the bullet
    public float arcHeight = 2f;              // Height of the arc
    public float moveSpeed = 5f;              // Speed at which the bullet moves towards the target
    public float strenght = .1f;
    public float delayBeforeTracking = 2f;    // Delay before the bullet starts tracking

    public GameObject Explosion;
    private Rigidbody rb;
    private bool isTracking = false;
    private GameObject nearestEnemy;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        LaunchBullet();
    }

    private void Update()
    {
        if (isTracking && nearestEnemy != null)
        {
            LookAtNearestEnemy();
        }

        ApplyConstantForce();
    }

    private void ApplyConstantForce()
    {
        Vector3 forwardForce = transform.forward * strenght;
        rb.AddForce(forwardForce);
    }

    private void LaunchBullet()
    {
        // Apply an initial upward force to create an arcing motion
        rb.AddForce(Vector3.up * launchForce, ForceMode.Impulse);

        // Calculate the forward force to maintain the desired arc
        Vector3 forwardForce = transform.forward * launchForce;

        // Apply the forward force with an upward component for the arc
        rb.AddForce(forwardForce + Vector3.up * arcHeight, ForceMode.Impulse);

        // Start tracking after a delay
        StartCoroutine(StartTrackingDelay());
    }

    private void LookAtNearestEnemy()
    {
        // Make the bullet face towards the nearest enemy
        transform.LookAt(nearestEnemy.transform);
    }

    private IEnumerator StartTrackingDelay()
    {
        yield return new WaitForSeconds(delayBeforeTracking);
        isTracking = true;
        FindNearestEnemy();
    }

    private void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float nearestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        this.nearestEnemy = nearestEnemy;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(Explosion, collision.contacts[0].point, Quaternion.identity);
        Destroy(gameObject);
    }
}
