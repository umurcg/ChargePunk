using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController controller;
    public Text freezeTimeText;
       

    private void Awake()
    {
        if (controller != null)
        {
            Destroy(gameObject);
            return;
        }

        controller = this;
    }


    public void setFreezePower(int value)
    {
        freezeTimeText.text = value + "%";
    }



}
