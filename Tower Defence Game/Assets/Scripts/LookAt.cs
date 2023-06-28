using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private GameObject mainCamera;

    private void Start()
    {
        // Find the camera with the "MainCamera" tag
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        // Ensure the camera exists
        if (mainCamera == null)
        {
            Debug.LogError("Camera with the 'MainCamera' tag not found in the scene!");
        }
    }

    private void Update()
    {
        // Rotate the object to look at the camera
        transform.LookAt(mainCamera.transform);
    }
}
