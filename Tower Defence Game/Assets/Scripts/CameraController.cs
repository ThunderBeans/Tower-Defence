using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float speedV = 40000.0f;
    float speedH = 50000.0f;
    public GameObject Camera;
    Rigidbody rb;
    bool inputDetector = true;
    bool esc = false;
    GameObject Op;
    

    private void Awake()
    {
        Op = GameObject.Find("Main");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // toggle voor de esc bool
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggler();
        }

        // zet menu aan en uit
        if (esc == true)
        {
            Op.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else 
        {
            Op.SetActive(false);
            Time.timeScale = 1.0f;
        }


        float horizon = Input.GetAxisRaw("Horizontal");
        float vertica = Input.GetAxisRaw("Vertical");
        // horizon is de horizontale input en vertica de verticale
        switch (horizon)
        {
            case 1:
                rb.AddForce(Vector3.right * speedH * Time.deltaTime);
                break;
            case -1:
                rb.AddForce(Vector3.left * speedH * Time.deltaTime);
                break;
        }
        switch (vertica)
        {
            case -1:
                rb.AddForce(Vector3.back * speedV * Time.deltaTime);
                break;
            case 1:
                rb.AddForce(Vector3.forward * speedV * Time.deltaTime);
                break;
        }

        if (horizon >= vertica && inputDetector == true)
        {
            rb.velocity = Vector3.zero;
        }
        if (horizon <= vertica && inputDetector == true)
        { 
           rb.velocity = Vector3.zero;
        }

        // als de er geen input is wordt de camera langzaam stil gezet

        //checkt voor input en returned een bool
        if (vertica != 0 || horizon != 0)
        {
            inputDetector = true;
        } 
        else { inputDetector = false;  }


        if (inputDetector == false)
        {
            rb.velocity = rb.velocity / Instellingen.cameraSmoothness;
        }

    }
    public void Toggler()
    {
        esc = !esc;
    }
}