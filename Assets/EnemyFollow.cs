using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public float speed;

    private Transform playerPos;




    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;      
        
    }


    void Update() // enemy follow range
    {
        if (Vector2.Distance(transform.position, playerPos.position) < 10f) // enemy will stay if distance longer than 10f
        {
            if(Vector2.Distance(transform.position,playerPos.position)>0.3f) // enemy will not be inside your body
                transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime); 
        }

    }

}
