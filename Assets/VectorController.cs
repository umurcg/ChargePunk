using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorController : MonoBehaviour
{

    public GameObject cylinderPrefab;
    public GameObject arrowPrefab;

    GameObject vectorLine;
    GameObject arrowObject;

    public Vector3 vector;
    public float vectorWidth = 0.03f;
    public float arrowSize = 5;
    public float arrowOffset = 0.005f;

    public Color color=Color.white;

    // Start is called before the first frame update
    void Awake()
    {
        vectorLine = Instantiate<GameObject>(cylinderPrefab);
        arrowObject = Instantiate<GameObject>(arrowPrefab);

        vectorLine.transform.SetParent(transform);
        vectorLine.transform.position = transform.position;

        arrowObject.transform.SetParent(transform);


        setVectorColor(color);
    
        
    }

    public void setVectorColor(Color col)
    {
        //print(vectorLine);
        vectorLine.GetComponent<Renderer>();
        var vectorMat = vectorLine.GetComponent<Renderer>().material;
        vectorMat.color = col;
        color = col;
    }

    // Update is called once per frame
    void Update()
    {
        //setVector(vector);
    }

    public void setVector(Vector3 vector, bool startFromCenter=false)
    {
        this.vector = vector;

        var offset = vector;
        var scale = new Vector3(vectorWidth, offset.magnitude / 2, vectorWidth);

        vectorLine.transform.up = offset;
        vectorLine.transform.localScale = scale;

        arrowObject.transform.up = offset;
        arrowObject.transform.position =transform.position+offset/2+arrowOffset*arrowSize*arrowObject.transform.up;
        arrowObject.transform.localScale = new Vector3(arrowSize,arrowSize,arrowSize); ;

        if (startFromCenter)
        {
            
            vectorLine.transform.position=transform.position+ offset / 2;
            arrowObject.transform.position += offset /2;
            
        }
        
    }



}
