using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterSpawner : MonoBehaviour
{

    public GameObject container;

    public float delta = 0.5f;

    public GameObject meterPrefab;
    


    // Start is called before the first frame update
    void Start()
    {
        var bounds = container.GetComponent<Renderer>().bounds;

        var maxX = bounds.max.x;
        var maxY = bounds.max.y;
        var maxZ = bounds.max.z;
        var minX = bounds.min.x;
        var minY = bounds.min.y;
        var minZ = bounds.min.z;

        for(int i = 0; i < (maxX - minX) / delta; i++)
            for (int j = 0; j < (maxY - minY) / delta; j++)
                for (int k = 0; k < (maxZ - minZ) / delta; k++) {

                    var meter = Instantiate<GameObject>(meterPrefab);
                    meter.transform.position = new Vector3(minX + delta * i, minY + delta * j, minZ + delta * k);
                    meter.transform.SetParent(transform);
                }


    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
