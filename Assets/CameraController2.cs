using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour
{

    public GameObject focusObject;
    public float rotateSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        transform.RotateAround(focusObject.transform.position, Vector3.up, mouseX * rotateSpeed);
        transform.RotateAround(focusObject.transform.position, transform.right, mouseY * rotateSpeed);
    }
}
