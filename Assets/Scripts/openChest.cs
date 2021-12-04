using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openChest : MonoBehaviour
{
    public GameObject chest1;
    public GameObject chest2;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.O))
        {
            chest1.SetActive(false);
            chest2.SetActive(true); 
        
        }


    }
}
