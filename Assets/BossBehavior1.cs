using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior1 : MonoBehaviour
{
    [SerializeField]
    private float health;
    private float MaxHealth;

    public float speed;
    private Transform playerPos;
    private Transform enemyPos;
    private Rigidbody2D rb;


    [SerializeField]
    private float attackDamage = 10f;
    [SerializeField]
    private float attackSpeed = 1f;
    private float canAttack;
    
    public Animator animator;
    

    private void Awake()
    {

        MaxHealth = health;

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        enemyPos = gameObject.transform;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (health < 1)
        {
            Destroy(gameObject);
        }

        if (Vector2.Distance(transform.position, playerPos.position) > 1.2f)
        {
            animator.SetFloat("walking", speed);
            rb.velocity = new Vector2(playerPos.position.x - enemyPos.position.x, playerPos.position.y - enemyPos.position.y).normalized * speed;  // playerPos.position - transform.position
        }

        if (Vector2.Distance(transform.position, playerPos.position) < 1f)
        {
            animator.Play("Attack");
        }




    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {

            health -= GameObject.Find("Player").GetComponent<PlayerMovement>().currentWeapon.damage;
            
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                //animator.Play("Attack");
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }
}
