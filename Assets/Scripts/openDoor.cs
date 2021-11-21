using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public GameObject Door1;
    public GameObject Door2;
    public GameObject Door3;
    public GameObject Door4;
    public GameObject needs;
    public int num;

    void Update()
    {
        num = GameObject.Find("Player").GetComponent<PlayerReward>().goldkey;
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (num >= 1)
            {
                Door1.SetActive(false);
                Door2.SetActive(false);
                Door3.SetActive(false);
                Door4.SetActive(false);
                num -= 1; 
            }
            else
            {
                gameObject.SetActive(false);
                needs.SetActive(true);
            }
                    
        }

    }
}
