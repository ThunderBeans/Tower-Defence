using UnityEngine;

public class Rotating : MonoBehaviour
{
    public float rotationSpeed = 10f;  // Speed of rotation

    void Update()
    {
        // Rotate the object on the x and y axes
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
