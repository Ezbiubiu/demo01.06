using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDialog : MonoBehaviour
{
  void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {      
            gameObject.SetActive(false);
        
        }

    }
}