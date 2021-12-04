using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health;

    private float MaxHealth;
//************************************************
// enemy colliders List

    private Rigidbody2D rb;
    // private float repelRange = 2f;
    private List<Rigidbody2D> enemyRBs;


//************************************************
    [Header("Hurt")]
    private SpriteRenderer sp;
    public float hurtLength; //flash hold time
    private float hurtAmount; // counter 

    public Animator animator;


    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        MaxHealth = health;


        if (enemyRBs == null)
            enemyRBs = new List<Rigidbody2D>();
        enemyRBs.Add(rb); 
    }
    

  
    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("walking", health);
        // 判断闪光时间 determine flash time
        if (hurtAmount <= 0 )
            sp.material.SetFloat("_FlashAmount", 0);
        else
            hurtAmount -= Time.deltaTime;

        if (health < 1)
        {
            animator.SetTrigger("Death");
            GetComponent<DropGift>().getGift();
            enemyRBs.Remove(rb);
            Destroy(gameObject);
        }

 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet") 
        {
            Vector2 difference = other.transform.position - transform.position;  // 击退角度 repel angel
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + difference.x, 
                gameObject.transform.position.y + difference.y); //击退距离 repel distance

            health -= GameObject.Find("Player").GetComponent<PlayerMovement>().currentWeapon.damage;
            HurtShader();
            Destroy(other.gameObject);
        }
        
    }

    private void HurtShader() //受伤闪光 object flash after hurted
    {
        sp.material.SetFloat("_FlashAmount", 1); 
        hurtAmount = hurtLength; //可调节闪光时间 control flash time length by control "hurtLength"
    }

}
