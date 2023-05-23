using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Kasteel : MonoBehaviour
{
    public int health= 500;
    public bool attacked;

 
    public void Damage()
    {
        Debug.Log("ow");
        attacked = false;
        health -= 10;
        if (health <= 0)
        {
            Debug.Log("dood");
        }
    }
}
