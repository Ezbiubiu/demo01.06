using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public float speed;

    private Transform playerPos;
    // private Vector2 moveTo;

    private Rigidbody2D rb;


    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;  
        rb = GetComponent<Rigidbody2D>();    
        
    }


    void Update() // enemy follow range
    {
        if (Vector2.Distance(transform.position, playerPos.position) < 10f) // enemy will stay if distance longer than 10f
        {
            if(Vector2.Distance(transform.position,playerPos.position)>0.3f) // enemy will not be inside your body
                // transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime); 
                rb.velocity = new Vector2(playerPos.position);  // playerPos.position - transform.position
        }

    }

    private void Flip() // enemy pic will flip follow mouse's position
    {
        //mouse is on the right side of the zombie
        if(transform.position.x < Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
            transform.eulerAngles = new Vector3(0, 180, 0);

        //Mouse is on the left side of the zombie
        if(transform.position.x > Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
            transform.eulerAngles = new Vector3(0, 0, 0);
               
    }

}
