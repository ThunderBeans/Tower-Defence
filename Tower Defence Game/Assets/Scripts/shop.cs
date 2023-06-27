using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public GameObject shopPrefab;
    private bool isActive = false;
    public CameraController controller;

    private void Start()
    {
         shopPrefab.SetActive(isActive);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && controller.esc == false)
        {
            isActive = !isActive; // Toggle the isActive flag
           
        }
        if (controller.esc == true)
        {
            isActive = false;
        }

         shopPrefab.SetActive(isActive);

    }
}
