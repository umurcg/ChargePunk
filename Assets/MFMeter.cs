using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MFMeter : MonoBehaviour
{

    public static List<MFMeter> mFMeters;

    LineRenderer lineRenderer;
    public GameObject cylinderPrefab;
    public GameObject arrowHeadPrefab;
    public GameObject vectorObject;


    VectorController createdVector;

    private void Awake()
    {
        if (mFMeters == null)
            mFMeters = new List<MFMeter>();

        mFMeters.Add(this);
    }

    // Update is called once per frame
    void Start()
    {
     
        var createdVectorObject=Instantiate<GameObject>(vectorObject);
        createdVectorObject.transform.position = transform.position;
        createdVectorObject.transform.SetParent(transform);
        createdVector = createdVectorObject.GetComponent<VectorController>();

        updateMeter();
    }

    public void updateMeter()
    {
        var sources = MagnetSource.sources;

        Vector3 totalField = Vector3.zero;
        foreach (var s in sources)
        {
            var field = s.getMagneticField(transform.position);
            totalField += field;
        }
        createdVector.setVector(totalField);
    }
    



}
