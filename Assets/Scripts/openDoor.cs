using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public GameObject Door;
   
    
    public GameObject needs;
    public int num;

    void Update()
    {
        num = GameObject.Find("Player").GetComponent<PlayerReward>().key;
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (num >= 5)
            {
                Door.SetActive(true);  
                gameObject.SetActive(false);  
            }
            else
            {
                gameObject.SetActive(false);
                needs.SetActive(true);
            }
                    
        }

    }
}
