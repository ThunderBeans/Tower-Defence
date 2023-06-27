 using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject[] prefab;
    public string groundTag;
    public CameraController controller;
    public int number;
    public CurencyScript currency;


    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && controller.esc == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Default"), QueryTriggerInteraction.Ignore))
            {
                if (hit.collider.gameObject.CompareTag(groundTag) && number == 1 && currency.Money >= 400)
                {
                     currency.Money -= 400;
                    Instantiate(prefab[1], hit.point, Quaternion.identity);
                }
                if (hit.collider.gameObject.CompareTag(groundTag) && number == 2 && currency.Money >= 700)
                {
                     currency.Money -= 700;
                    Instantiate(prefab[2], hit.point, Quaternion.identity);
                }
                if (hit.collider.gameObject.CompareTag(groundTag) && number == 3 && currency.Money >= 1000)
                {
                    currency.Money -= 1000;
                    Instantiate(prefab[3], hit.point, Quaternion.identity);
                }
                if (hit.collider.gameObject.CompareTag(groundTag) && number == 4 && currency.Money >= 700)
                {
                    currency.Money -= 700;
                    Instantiate(prefab[4], hit.point, Quaternion.identity);
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
    public void press4()
    {
        number = 4;
    }
}
