using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] GameObject towerToPlace;

    private bool isClicked = false;
    private void OnMouseDown()
    {
        print("was clicked");
        isClicked = true;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (isClicked)
            {
                isClicked = false;
                GameObject b = Instantiate(towerToPlace, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation);
            }
        }
    }
}
