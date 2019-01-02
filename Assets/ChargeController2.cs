using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeController2 : MonoBehaviour
{

    
    public float forceMultiplier = 1;
    public float initialVelocity = 1f;

    public GameObject vectorPrefab;
    VectorController velocityVector;
    VectorController forceVector;

    public Color forceVectorColor = Color.blue;
    public Color velocityVectorColor = Color.red;

    public float timeLerpSpeed = 1f;
    public float timeFreezeVelocity = 0.01f;

    Vector3 currentVelocity;
    Vector3 currentForce;

    Rigidbody rb;

    TimeFreezer timeFreezer;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        timeFreezer = GetComponent<TimeFreezer>();

        createVectorObjects();        

    }

    void createVectorObjects()
    {
        forceVector = Instantiate<GameObject>(vectorPrefab).GetComponent<VectorController>();
        velocityVector = Instantiate<GameObject>(vectorPrefab).GetComponent<VectorController>();

        forceVector.transform.SetParent(transform);
        velocityVector.transform.SetParent(transform);

        forceVector.transform.localPosition = Vector3.zero;
        velocityVector.transform.localPosition = Vector3.zero;

        forceVector.setVectorColor(forceVectorColor);
        velocityVector.setVectorColor(velocityVectorColor);

    }
    

    void updateVectorObjects()
    {
        forceVector.setVector(currentForce, true);
        velocityVector.setVector(currentVelocity, true);
    }

    private void Start()
    {
        rb.velocity=(initialVelocity * Vector3.forward);
        currentVelocity = rb.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
        var field = MagnetSource.getMagneticTotalMagneticField(transform.position);
        currentForce = Vector3.Cross(field, currentVelocity) * forceMultiplier;

        
        if (timeFreezer.isTimeFrozen())
        {            
            rb.velocity = Vector3.Lerp(rb.velocity, currentVelocity * timeFreezeVelocity, Time.deltaTime * timeLerpSpeed);
        }
        else
        {
            currentVelocity += (currentForce / rb.mass) * Time.deltaTime;
            rb.velocity = Vector3.Lerp(rb.velocity, currentVelocity, Time.deltaTime * timeLerpSpeed);

        }

        updateVectorObjects();


    }
}
