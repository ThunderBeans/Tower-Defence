using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Projectyle : MonoBehaviour
{
    public Rigidbody rb;
    public int speed;
    public Transform target;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Vector3 v3Force = speed * direction * Time.deltaTime;
            rb.AddForce(v3Force);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
       speed = 0;
       Invoke("delete", 4);
    }
    private void delete()
    {
        Destroy(gameObject);
    }
    public void SetTarget(Transform Target)
    {
        target = Target;
        print(target.name);
    }
}
