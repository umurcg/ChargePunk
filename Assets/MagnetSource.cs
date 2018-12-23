using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MagnetSource : MonoBehaviour
{

    public static List<MagnetSource> sources;

    // Start is called before the first frame update
    void Awake()
    {
        if (sources == null)
            sources = new List<MagnetSource>();

        sources.Add(this);

    }

    private void OnDestroy()
    {
        sources.Remove(this);
    }

    public abstract Vector3 getMagneticField(Vector3 pos);

    public static Vector3 getMagneticTotalMagneticField(Vector3 pos)
    {
        var sources = MagnetSource.sources;

        Vector3 totalField = Vector3.zero;
        foreach (var s in sources)
        {
            var field = s.getMagneticField(pos);
            totalField += field;
        }

        return totalField;

    }

}
