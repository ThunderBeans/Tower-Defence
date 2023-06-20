using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class FreezeTower : MonoBehaviour
{
    EnemyCombat emc;

    // Tower variables
    int damage = 2;
    int cooldownReduction = 0;

    // Kogel
    public GameObject freezeBlast;
    ParticleSystem Particle;
    Transform position;

    // Start is called before the first frame update
    void Start()
    {
        Particle = GameObject.Find("FreezeBlast 1").GetComponent<ParticleSystem>();
       // position = transform.position.ConvertTo();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.CompareTag("Enemy"))
        {
           Shoot();
        }
    }

    private void OnTriggerExit(Collider Other)
    {
        if (Other.gameObject.CompareTag("Enemy"))
        {
         CancelInvoke("Shoot");
        }
    }

    void DestroyDamage()
    {
        Destroy(freezeBlast);
    }
    void Shoot()
    {
        Particle.Play();
        Instantiate(freezeBlast, position);
        Invoke("Shoot", 0.1f);
        Invoke("DestroyDamage", 1f);
        print("Shooting");
    }
    // maak een ander script om de kogel prefab aan te roepen
    // emc.hitPoints -= damage;
}
