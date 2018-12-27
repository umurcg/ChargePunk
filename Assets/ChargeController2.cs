using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeController2 : MonoBehaviour
{

    Rigidbody rb;
    public float forceMultiplier = 1;
    public float initialVelocity = 1f;

    public GameObject vectorPrefab;
    VectorController velocityVector;
    VectorController forceVector;

    public Color forceVectorColor = Color.blue;
    public Color velocityVectorColor = Color.red;


    public float timeLerpSpeed = 1f;
    public float timeFreezeVelocity = 0.01f;

    Vector3 realVelocity;



    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
      

        forceVector = Instantiate<GameObject>(vectorPrefab).GetComponent<VectorController>();
        velocityVector = Instantiate<GameObject>(vectorPrefab).GetComponent<VectorController>();

        forceVector.transform.SetParent(transform);
        velocityVector.transform.SetParent(transform);

        forceVector.transform.localPosition = Vector3.zero;
        velocityVector.transform.localPosition = Vector3.zero;


        forceVector.setVectorColor(forceVectorColor);
        velocityVector.setVectorColor(velocityVectorColor);
    }

    private void Start()
    {
        rb.velocity=(initialVelocity * Vector3.forward);
        realVelocity = rb.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        

        var field = MagnetSource.getMagneticTotalMagneticField(transform.position);
        var force = Vector3.Cross(field, realVelocity) * forceMultiplier;

        
        if (Input.GetKey(KeyCode.Space))
        {
            
            rb.velocity = Vector3.Lerp(rb.velocity, realVelocity * timeFreezeVelocity, Time.deltaTime * timeLerpSpeed);

        }
        else
        {
            realVelocity += (force / rb.mass) * Time.deltaTime;
            rb.velocity = Vector3.Lerp(rb.velocity, realVelocity, Time.deltaTime * timeLerpSpeed);

        }


        forceVector.setVector(force, true);
        velocityVector.setVector(realVelocity, true);
    }
}
