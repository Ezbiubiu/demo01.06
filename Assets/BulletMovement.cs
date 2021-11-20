using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    private float speed = 7;

    private Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = GameObject.Find("Dir").transform.position;
        transform.position = GameObject.Find("FirePoint").transform.position;
        Destroy(gameObject,3);
        transform.eulerAngles = new Vector3(0,0,GameObject.Find("Player").transform.eulerAngles.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
        
    }
}
