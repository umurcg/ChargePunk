﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            GameController.controller.die();
        }

    }
}
