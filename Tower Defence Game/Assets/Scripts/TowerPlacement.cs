using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject[] prefab;
    public string groundTag;
    public CameraController controller;
    public int number;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && controller.esc == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Default"), QueryTriggerInteraction.Ignore))
            {
                if (hit.collider.gameObject.CompareTag(groundTag) && number == 1)
                {
                    Instantiate(prefab[1], hit.point, Quaternion.identity);
                }
                if (hit.collider.gameObject.CompareTag(groundTag) && number == 2)
                {
                    Instantiate(prefab[2], hit.point, Quaternion.identity);
                }
                if (hit.collider.gameObject.CompareTag(groundTag) && number == 3)
                {
                    Instantiate(prefab[3], hit.point, Quaternion.identity);
                }
                else
                {
                    Debug.Log("No");
                }
                Debug.Log("Hit object: " + hit.collider.gameObject.name);
            }
        }
    }
    public void press1()
    {
        number = 1;
    }
    public void press2()
    {
        number = 2;
    }
    public void press3()
    {
        number = 3;
    }
}
