using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreezer : MonoBehaviour
{
    public float freezeTimePowerPerSecond = 1;
    float freezeTimePower = 100;
    bool freezeTime = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && freezeTimePower > 0)
            freezeTime = true;



        if (Input.GetKeyUp(KeyCode.Space) && freezeTime)
            freezeTime = false;


        if (freezeTime)
        {
            freezeTimePower -= freezeTimePowerPerSecond * Time.deltaTime;

            freezeTimePower = Mathf.Clamp(freezeTimePower, 0, 100);

            UIController.controller.setFreezePower((int)freezeTimePower);

            if (freezeTimePower <= 0)
                freezeTime = false;
        }



    }

    public void increzeFreezeTimePower(float value)
    {
        freezeTimePower += value;
        freezeTimePower = Mathf.Clamp(freezeTimePower, 0, 100);
        UIController.controller.setFreezePower((int)freezeTimePower);
    }

    public bool isTimeFrozen()
    {
        return freezeTime;
    }
}
