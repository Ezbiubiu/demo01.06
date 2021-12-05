using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{

    public GameObject nextTalk;

    void Start()
    {
        Time.timeScale = 0f;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {      
            gameObject.SetActive(false);
            nextTalk.SetActive(true);
        
        }

    }

}
