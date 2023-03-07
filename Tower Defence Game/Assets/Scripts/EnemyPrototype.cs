using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrototype : MonoBehaviour
{
    public Rigidbody body;
    public int speed;
    public int health = 50;
    public BowTowerScript bowTowerScript;
   
    void Update()
    {
        body= GetComponent<Rigidbody>();
        Vector3 v3Force = speed * transform.forward * Time.deltaTime;
        body.AddForce(v3Force);
        if (health <= 0)
        {
            Debug.Log("dadw");
            bowTowerScript.EnemyDead = true;
        }
    }

}
