using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private int _rotationSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h_input = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * (_rotationSpeed * h_input * Time.deltaTime));
    }
}
