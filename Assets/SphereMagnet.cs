using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMagnet : MagnetSource
{
    public enum Port { North,South};

    public Port port;

    public float Br = 100;

    public override Vector3 getMagneticField(Vector3 pos)
    {
        var dir = pos - transform.position;
        var dist = Vector3.Distance(pos, transform.position);

        if (port == Port.South)
            dir *= -1;

        return dir * (1 / dist);
    }
}
