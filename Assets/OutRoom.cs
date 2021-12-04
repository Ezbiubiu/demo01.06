using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutRoom : MonoBehaviour

{
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {   
            GlobalControl.Instance.level ++;
            GlobalControl.Instance.MaxHP += 10f;
            GlobalControl.Instance.HP = GlobalControl.Instance.MaxHP;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
            
        }
    }
}
