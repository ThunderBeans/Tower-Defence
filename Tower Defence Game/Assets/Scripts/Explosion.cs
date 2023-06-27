using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float time = .2f;
    void Start()
    {
        Invoke("Destroy", time);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
