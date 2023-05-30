using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float forceMagnitude;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;

    private Rigidbody rb;

    private float timeToLive = 120f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(-transform.right * forceMagnitude, ForceMode.Impulse);

        float size = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(size, size, size);

        float yRotation = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }
    private void Update()
    {
        if (timeToLive < 0)
        {
            Destroy(gameObject);
        }
        timeToLive -= 1 * Time.deltaTime;
    }
}

