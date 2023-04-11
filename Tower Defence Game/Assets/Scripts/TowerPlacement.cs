using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject prefab;
    public LayerMask groundLayer; 

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer))
            {
                Instantiate(prefab, hit.point, Quaternion.identity);
            }
            else
            {
                Debug.Log("No");
            }
        }
    }
}
