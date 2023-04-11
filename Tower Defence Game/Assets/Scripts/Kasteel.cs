using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kasteel : MonoBehaviour
{
    public int health= 500;

    private void Update()
    {
        if(health <= 0)
        {
            Debug.Log("Dead");
            Destroy(gameObject);
        }
    }
}
