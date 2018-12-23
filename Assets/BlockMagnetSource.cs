using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMagnetSource : MagnetSource
{
    float length;
    float depth;
    float width;

    Renderer rend;

    //Remenance field
    public float Br = 2;


    Vector3 northCenter;
    Vector3 southCenter;

    // Start is called before the first frame update
    void Awake()
    {
        rend = GetComponent<Renderer>();
        var bounds=rend.bounds;

        var max = bounds.max;
        var min = bounds.min;
        var center = bounds.center;

        northCenter = new Vector3(center.x, center.y, (max.z+center.z)/2);
        southCenter = new Vector3(center.x, center.y, (min.z+ center.z) / 2);

        depth = Mathf.Abs(max.z - min.z);
        width = Mathf.Abs(max.y - min.y);
        length = Mathf.Abs(max.x - min.x);

        print(northCenter);
        print(southCenter);

    }

    public override Vector3 getMagneticField(Vector3 pos)
    {

        var northToPos = pos - northCenter;
        var southToPos = pos - southCenter;

        var northB = northToPos.normalized * (1 / Mathf.Pow(northToPos.magnitude, 2));
        var southB = -1*southToPos.normalized * (1 / Mathf.Pow(southToPos.magnitude, 2));


        return (northB + southB)*Br ;
    }

    //public Vector3 getMagneticField(Vector3 pos)
    //{
    //    //First project position to symmetri axis
    //    var projectedVector = Vector3.Project(pos, transform.forward);
    

    //    //Center of box
    //    var bounds = rend.bounds;
    //    var center = bounds.center;

    //    var maxZ = bounds.max.z;
    //    var minZ = bounds.min.z;

    //    var northPole = new Vector3(center.x, center.y, maxZ);
    //    var southPole = new Vector3(center.x, center.y, minZ);

    //    //get distance to nearest pole
    //    var posToNorth = Vector3.Distance(projectedVector, northPole);
    //    var posToSouth = Vector3.Distance(projectedVector, southPole);

    //    if (posToNorth < posToSouth)
    //        print("north");
    //    else
    //        print("south");

    //    float distance = 0;
    //    Vector3 dir = Vector3.zero;

        
    //    if ((maxZ - minZ) - (posToNorth + posToSouth)<0.0001f)
    //    {
            
            
    //    }
    //    else
    //    {
    //        distance = (posToNorth < posToSouth) ? posToNorth : posToSouth;
    //        dir = (posToNorth < posToSouth) ? pos - northPole : southPole - pos;
    //        dir = dir.normalized;
    //    }


    //    //I dont know why but i used real formula
    //    var fieldMagnitude = 
    //        (Br / Mathf.PI) * 
    //        (Mathf.Atan(length * width / (2 * distance * Mathf.Sqrt(4 * Mathf.Pow(distance, 2) + Mathf.Pow(length, 2) + Mathf.Pow(width, 2)))) -
    //        Mathf.Atan(length*width/(2*(depth+distance)*(Mathf.Sqrt(4*Mathf.Pow(distance-depth,2)+Mathf.Pow(length,2)+Mathf.Pow(width,2))))));

    //    fieldMagnitude = Mathf.Abs(fieldMagnitude);

    //    //print(fieldMagnitude);

    //    return dir * fieldMagnitude;


    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
