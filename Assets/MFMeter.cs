using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MFMeter : MonoBehaviour
{
    LineRenderer lineRenderer;
    public GameObject cylinderPrefab;
    public GameObject arrowHeadPrefab;
    public GameObject vectorObject;


    // Update is called once per frame
    void Start()
    {
        var sources = MagnetSource.sources;

        Vector3 totalField = Vector3.zero;
        foreach (var s in sources)
        {
            var field = s.getMagneticField(transform.position);
            totalField += field;
        }

        var createdVectorObject=Instantiate<GameObject>(vectorObject);

        createdVectorObject.transform.position = transform.position;
        createdVectorObject.transform.SetParent(transform);

        createdVectorObject.GetComponent<VectorController>().setVector(totalField);
        

        //var vectorStart = transform.position - totalField / 2;
        //var vectorEnd = transform.position + totalField / 2;

        //var arrowOffset = 10f;

        //createObjectBetweenTwoPoints(vectorStart,vectorEnd, 0.1f,cylinderPrefab);
        //createObjectBetweenTwoPoints(vectorStart, vectorEnd+arrowOffset*totalField.normalized, 10f, arrowHeadPrefab);

        //DrawArrow.ForDebug(transform.position, totalField, Color.red);
    }


    

    void createObjectBetweenTwoPoints(Vector3 start, Vector3 end, float width, GameObject objectPrefab)
    {
        var offset = end - start;
        var scale = new Vector3(width, offset.magnitude / 2, width);
        var position = start + (offset / 2);

        var cylinder = Instantiate(objectPrefab, position, Quaternion.identity);
        cylinder.transform.up = offset;

        cylinder.transform.localScale = scale;

        cylinder.transform.SetParent(transform);

    }

}
