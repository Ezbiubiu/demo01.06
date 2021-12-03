using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    // Start is called before the first frame update
    public static GlobalControl Instance;
    public float HP;
    public int level;
    //public int reward;

    void Awake()
    {
        Debug.Log("GC awake");
        HP = 100;
        level = 0;
        //reward = 0;


        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
        
    }
    
        
   
}
   
