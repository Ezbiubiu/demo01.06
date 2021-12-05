using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start1 : MonoBehaviour
{
    public GameObject nextTalk;
  void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {      
            gameObject.SetActive(false);
            nextTalk.SetActive(true);
        
        }

    }
}
