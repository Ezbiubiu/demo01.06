using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart : MonoBehaviour
{

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {      
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        
        }

    }
}
