using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private int rotationSpeed;
    [SerializeField] private int moveSpeed;
    private float horizontalInput;
    private 

    void Update()
    {
        if (Input.GetAxis("Right Trigger") > 0)
        {
            transform.Translate(new Vector3(0, 0, 10) * moveSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetAxis("Left Trigger") > 0)
        {
            transform.Translate(new Vector3(0, 0, -10) * moveSpeed * Time.deltaTime, Space.World);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, horizontalInput, 0) * rotationSpeed * Time.deltaTime, Space.World);
    }
}
