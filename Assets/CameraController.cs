using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotateSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            var mouseX = Input.GetAxis("Mouse X");
            var mouseY = Input.GetAxis("Mouse Y");

            transform.RotateAround(transform.parent.position, Vector3.up, mouseX * rotateSpeed);
            transform.RotateAround(transform.parent.position, transform.right, mouseY * rotateSpeed);
        }
    }
}
