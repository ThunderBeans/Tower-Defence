using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRemove : MonoBehaviour
{
    [SerializeField] private GameObject ground;

    private bool isClicked = false;
    private void OnMouseDown()
    {
        print("was clicked");
        isClicked = true;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (isClicked)
            {
                isClicked = false;
                _ = Instantiate(ground, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation);
                Destroy(gameObject);
            }
        }
    }
}
