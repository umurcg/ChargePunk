using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMagnetSource : MagnetSource
{

    public float size = 10f;
    Vector3 direction = Vector3.forward;

    public float rotateSpeed = 10f;
    public GameObject mainCam;

    public override Vector3 getMagneticField(Vector3 pos)
    {
        return direction * size;
    }

    // Update is called once per frame
    void Update()
    {
        var ver = Input.GetAxis("Vertical");
        var hor = Input.GetAxis("Horizontal");

        

        direction = Quaternion.Euler(-direction.z * ver * rotateSpeed, hor * rotateSpeed, direction.x*ver*rotateSpeed)*direction;

        

        if(hor!=0 || ver != 0)
        {
            foreach(var m in MFMeter.mFMeters)
            {
                m.updateMeter();
            }
        }



    }
}
