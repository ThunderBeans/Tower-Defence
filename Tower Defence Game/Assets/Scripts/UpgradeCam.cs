using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCam : MonoBehaviour
{
    public Camera upgradeCamera; // Reference to the upgrade camera
    public float raycastDistance = 100f; // Maximum distance for the raycast

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Check if right mouse button is pressed
        {
            Ray ray = upgradeCamera.ScreenPointToRay(Input.mousePosition); // Create a ray from the mouse position using the upgrade camera

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("Tower")) // Check if the hit object has the "Tower" tag
                {
                    Debug.Log("Fak");
                    Upgrate upgradeComponent = hit.collider.gameObject.GetComponent<Upgrate>();
                    if (upgradeComponent != null)
                    {
                        Debug.Log("Fak2");
                        upgradeComponent.Upgradeing();
                    }
            }
        }
    }
}


}