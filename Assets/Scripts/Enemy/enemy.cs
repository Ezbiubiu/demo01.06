using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{


    [SerializeField] private float attackDamage;
    [SerializeField] private float moveSpeed;

    private Transform target;

    [SerializeField] private float maxHP;

    private float health;

    private Transform playPos;
    private Rigidbody2D rb;
    private float repelRange = 2f;

    [Header("Hurt")]
    private SpriteRenderer sp;
    public float hurtLength; //flash hold time
    private float hurtAmount; // counter 




    private List<Rigidbody2D> enemyRBs;

    // Start is called before the first frame update
    private void Awake()
    {
        health = maxHP;
        target = GameObject.Find("Player").GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();

        if (enemyRBs == null)
            enemyRBs = new List<Rigidbody2D>();
        enemyRBs.Add(rb);
    }

    // Update is called once per frame
    private void Update()
    {
        FollowPlayer();
        if (hurtAmount <= 0 )
            sp.material.SetFloat("_FlashAmount", 0);
        else
            hurtAmount -= Time.deltaTime;

    }

    private void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    public void takenDamage(float _amount)
    {
        health -= _amount;
        HurtShader();
        if(health <= 0)
            Destroy(gameObject);
            enemyRBs.Remove(rb);
    }

    private void HurtShader() //受伤闪光 object flash after hurted
    {
        sp.material.SetFloat("_FlashAmount", 1); 
        hurtAmount = hurtLength; //可调节闪光时间 control flash time length by control "hurtLength"
    }

    private void onTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<enemy>().takenDamage(attackDamage); //攻击掉血 lose blood after got hurt
            // 击退效果 repel effect
            // Vector2 difference = other.transform.position - transform.position;  // 击退角度 repel angel
            // other.transform.position = new Vector2(other.transform.position.x + difference.x, other.transform.position.y + difference.y); //击退距离 repel distance
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
