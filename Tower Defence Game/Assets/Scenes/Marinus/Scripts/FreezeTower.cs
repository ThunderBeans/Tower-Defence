using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class FreezeTower : MonoBehaviour
{
    EnemyCombat emc;

    // Tower variables
    int damage = 2;
    int cooldownReduction = 0;

    // Kogel
    public GameObject freezeBlast;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Upgrade.PlayerUpgrade == true)
        //{ 
           
        //}

    }


    private void OnTriggerEnter(Collider Trigger)
    {
        if (Trigger.gameObject.CompareTag("Enemy"))
        {
           Shoot();
        }
    }
    void Shoot()
    {
     Instantiate(freezeBlast);
     InvokeRepeating("Shoot", 0.3f, 3f - cooldownReduction);
    }
    // maak een ander script om de kogel prefab aan te roepen
    // emc.hitPoints -= damage;
}
