using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject prefab;
    public string groundTag;
    public CameraController controller;
    public CurencyScript currency;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && controller.esc == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Default"), QueryTriggerInteraction.Ignore))
            {
                if (hit.collider.gameObject.CompareTag(groundTag) && currency.Money >= 400)
                {
                    Instantiate(prefab, hit.point, Quaternion.identity);
                    currency.Money -= 400;

                }
                else
                {
                    Debug.Log("No");
                }
                Debug.Log("Hit object: " + hit.collider.gameObject.name);
            }
        }
    }
}
