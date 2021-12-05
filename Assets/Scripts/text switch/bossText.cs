using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossText : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0f;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {      
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        
        }

    }
}
