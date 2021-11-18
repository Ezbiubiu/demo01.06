using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_walk : MonoBehaviour
{

    [SerializeField]public float speed;
    [SerializeField]private float health;

    private Transform playPos;
    private Rigidbody2D rb;
    private float repelRange = 2f;


    private List<Rigidbody2D> enemyRBs;



    // Start is called before the first frame update
    void Awake()
    {
        playPos = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        if (enemyRBs == null)
            enemyRBs = new List<Rigidbody2D>();
        enemyRBs.Add(rb);
    }

    private void beKilled()
    {
        enemyRBs.Remove(rb);
    }

    // Update is called once per frame
    void Update()
    {
        if(playPos != null)
        {
            if (Vector2.Distance(transform.position, playPos.position) > 0.24f)
                transform.position = Vector2.MoveTowards(transform.position, playPos.position, speed * Time.deltaTime);
        }
    }

void FixedUpdate()
{
    Vector2 repelForce = Vector2.zero;
    foreach(Rigidbody2D enemy in enemyRBs)
    {
        if(enemy == rb)
            continue;
        if(Vector2.Distance(enemy.position, rb.position) <= repelRange )
        {
            Vector2 repelDir = (rb.position - enemy.position).normalized;
            repelForce += repelDir;
        }
    }
}

}
