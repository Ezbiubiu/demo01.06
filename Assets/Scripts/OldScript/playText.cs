using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playText : MonoBehaviour
{

    public Animator ani;


    // Start is called before the first frame update
    void Start()
    {
        // act = true;
        // if(act == true)
            ani.Play("playButtonAnimation");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
