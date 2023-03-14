using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] GameObject towerToPlace;
    [SerializeField] GameObject PlacerToPlace;
    Camera cam;
    public LayerMask mask;
    public LayerMask mask2;
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // Draw Ray
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position,
        Color.blue);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, mask, QueryTriggerInteraction.Ignore))
            {
                Debug.Log(hit.transform.name);
                _ = Instantiate(towerToPlace, hit.transform.gameObject.GetComponent<Transform>().position, hit.transform.gameObject.GetComponent<Transform>().rotation);
                Destroy(hit.transform.gameObject);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, mask2, QueryTriggerInteraction.Ignore))
            {
                Debug.Log(hit.transform.name);
                _ = Instantiate(PlacerToPlace, hit.transform.gameObject.GetComponent<Transform>().position, PlacerToPlace.transform.rotation);
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
