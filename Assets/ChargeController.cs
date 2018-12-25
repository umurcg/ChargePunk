using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeController : MonoBehaviour
{
    Rigidbody rb;
    public float forceMultiplier = 1;
    //public Vector3 initialVelocity;

    public float userSpeed = 3f;

    public GameObject vectorPrefab;
    VectorController velocityVector;
    VectorController forceVector;

    public Color forceVectorColor=Color.blue;
    public Color velocityVectorColor = Color.red;

    
    public float timeLerpSpeed = 1f;
    public float timeFreezeVelocity =0.01f;

    public Vector3 realVelocity;
    
   

    // Start is called before the first frame update
    void Awake()
    {
       rb = GetComponent<Rigidbody>();
       //rb.velocity = initialVelocity;

       forceVector= Instantiate<GameObject>(vectorPrefab).GetComponent<VectorController>();
       velocityVector = Instantiate<GameObject>(vectorPrefab).GetComponent<VectorController>();

        forceVector.transform.SetParent(transform);
        velocityVector.transform.SetParent(transform);

        forceVector.transform.localPosition = Vector3.zero;
        velocityVector.transform.localPosition = Vector3.zero;


        forceVector.setVectorColor(forceVectorColor);
        velocityVector.setVectorColor(velocityVectorColor);
    }

    // Update is called once per frame
    void Update()
    {
        var field=MagnetSource.getMagneticTotalMagneticField(transform.position);
        var force=Vector3.Cross(field, realVelocity) *forceMultiplier;

        var hor = Input.GetAxis("Horizontal");
        var ver = Input.GetAxis("Vertical");
        var up = Input.GetAxis("Up");

        var userForce = new Vector3(hor, up, ver);
        userForce *= userSpeed*Time.unscaledDeltaTime;

        //rb.AddForce(force+userForce);

        
        
        

        


        if(Input.GetKey(KeyCode.Space))
        {
            realVelocity += ((userForce) / rb.mass) * Time.deltaTime;
            rb.velocity = Vector3.Lerp(rb.velocity, realVelocity * timeFreezeVelocity,Time.deltaTime* timeLerpSpeed);
             
             
        }else
        {
            realVelocity += ((force + userForce) / rb.mass) * Time.deltaTime;
            rb.velocity = Vector3.Lerp(rb.velocity, realVelocity , Time.deltaTime * timeLerpSpeed);

        }


        forceVector.setVector(force, true);
        velocityVector.setVector(realVelocity, true);
    }



}
