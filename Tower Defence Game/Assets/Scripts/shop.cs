using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public GameObject shopPrefab;
    private bool isActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isActive = !isActive; // Toggle the isActive flag
            shopPrefab.SetActive(isActive);
        }
    }
}
