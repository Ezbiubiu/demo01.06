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

//******************* boss attack ****************
    [SerializeField] float attackDamage = 10f;
    [SerializeField] float attackSpeed = 1f;
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
            GetComponent<DropGift>().getGift();
            Destroy(gameObject);
        }

        if (Vector2.Distance(transform.position, playerPos.position) > 0.1f)
        {
            animator.SetFloat("Walk", speed);
            rb.velocity = new Vector2(playerPos.position.x - enemyPos.position.x, playerPos.position.y - enemyPos.position.y).normalized * speed;  // playerPos.position - transform.position
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
                animator.Play("Attack");
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
