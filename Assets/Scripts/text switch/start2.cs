using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start2 : MonoBehaviour
{
    // public GameObject nextTalk;
  void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {      
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        
        }

    }
}
