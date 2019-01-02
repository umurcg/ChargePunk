using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotateSpeed = 10f;
    public float zoomSpeed = 10f;
    public float minZ = 1;
    public float maxZ = 100;
    float zoom;


    private void Start()
    {        
        zoom = 0.5f;
        updateZoom();
    }


    void updateZoom()
    {
        var forward = transform.forward;
        var pivot = transform.parent.position;
        var minZPos = pivot + forward * minZ;
        var maxZPos = pivot + forward * maxZ;
        transform.position = Vector3.Lerp(minZPos, maxZPos, zoom);
    }
    


    // Update is called once per frame
    void Update()
    {
                
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        //Rotate around Y axis
        transform.RotateAround(transform.parent.position, Vector3.up, mouseX * rotateSpeed);

        //Rotate around X axis
        transform.RotateAround(transform.parent.position, transform.right, mouseY * rotateSpeed);

        
        var scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        zoom += scrollWheel * Time.deltaTime*zoomSpeed;
        zoom=Mathf.Clamp(zoom, 0, 1);
        updateZoom();


        transform.LookAt(transform.parent.transform);

    }
}
