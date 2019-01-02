using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController controller;

    int currentLevel;
    
    


    private void Awake()
    {
        if (controller != null)
        {
            Destroy(gameObject);
            return;
        }
        
        controller = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    public void die()
    {
        SceneManager.LoadScene(currentLevel);
    }


    

}
