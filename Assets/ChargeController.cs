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

    
    public float timeScaleSpeed = 1f;
    public float timeFreezeScale = 0.01f;
    
   

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
        var force=Vector3.Cross(rb.velocity, field)*forceMultiplier;

        var hor = Input.GetAxis("Horizontal");
        var ver = Input.GetAxis("Vertical");

        var userForce = transform.forward * ver + transform.right * hor;
        userForce *= userSpeed*Time.unscaledDeltaTime;

        rb.AddForce(force+userForce);

        forceVector.setVector( force,true);
        velocityVector.setVector(rb.velocity,true);
        

        if(Input.GetKey(KeyCode.Space) && Time.timeScale > timeFreezeScale)
        {
             var timeScale = Mathf.Clamp(Time.timeScale - timeScaleSpeed * Time.unscaledDeltaTime, timeFreezeScale, 1);
             Time.timeScale = timeScale;
             
        }else if (Time.timeScale < 1)
        {
            var timeScale = Mathf.Clamp(Time.timeScale + timeScaleSpeed * Time.unscaledDeltaTime, timeFreezeScale, 1);
            Time.timeScale = timeScale;
        }

        print(Time.timeScale);
    }



}
