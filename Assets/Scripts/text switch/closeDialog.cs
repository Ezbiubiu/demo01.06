using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDialog : MonoBehaviour
{
    public GameObject restart;
    public GameObject restart1;
    public GameObject restart2;


    void Start()
    {
        Time.timeScale = 0f;
    }

  void Update()
    {
        Time.timeScale = 0f;
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {      
            gameObject.SetActive(false);
            if (GlobalControl.Instance.level == 1)
            {
                    restart.SetActive(true);
                    
            }else if (GlobalControl.Instance.level == 2 )
            {
                    restart1.SetActive(true);

            }else if (GlobalControl.Instance.level == 3 )
            {
                    restart2.SetActive(true);

        }

        
        }

    }
}