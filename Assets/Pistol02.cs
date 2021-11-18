using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol02 : MonoBehaviour
{

    private Vector2 mousePos;

    private float flipY;
    // Start is called before the first frame update


    private Vector2 direction;
    void Start()
    {
        flipY = transform.localScale.y;

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized;
        transform.right = direction;

        // float rotZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        // transform.rotation = Quaternion.Euler(0, 0, rotZ);
        if(mousePos.x < transform.position.x)
            transform.localScale = new Vector3(flipY, -flipY,1);
        else
            transform.localScale = new Vector3(flipY, flipY,1);




    }

    
}
