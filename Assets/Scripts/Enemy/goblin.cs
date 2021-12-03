using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblin : MonoBehaviour
{
    [SerializeField]
    private float health;

    private float MaxHealth;


//*********** animators *****************

    // [SerializeField] Animator animator;


//************ enemy colliders List **********************

    private Rigidbody2D rb;
    // private float repelRange = 2f;
    private List<Rigidbody2D> enemyRBs;


//************** Flash after hurt ***********************
    [Header("Hurt")]
    private SpriteRenderer sp;
    public float hurtLength; //flash hold time
    private float hurtAmount; // counter 

//***************** attack **********************

    [SerializeField]
    private float attackDamage = 10f;
    [SerializeField]
    private float attackSpeed = 1f;
    private float canAttack;


//**************** follow player & collider work on eachother ****************

    public float speed;

    private Transform playerPos;

    private Transform enemyPos;
    // private Vector2 moveTo;


///////////////////////////////////
    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        MaxHealth = health;

        //follow---------------------------------------------------------
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;  
        enemyPos = gameObject.transform; 
        rb = GetComponent<Rigidbody2D>();    

        //-----------------------------------------------

        if (enemyRBs == null)
            enemyRBs = new List<Rigidbody2D>();
        enemyRBs.Add(rb); 
    }
    

  
    // Update is called once per frame
    void Update()
    {
        //-------------------------------------------------------
        //follow
        if (Vector2.Distance(transform.position, playerPos.position) < 10f  && Vector2.Distance(transform.position,playerPos.position) > 0.1f) // enemy will stay if distance longer than 10f
        {// enemy will not be inside your body
                // transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime); 
                Vector2 vt = new Vector2(playerPos.position.x - enemyPos.position.x, playerPos.position.y - enemyPos.position.y);
                rb.velocity = vt.normalized * speed;  // playerPos.position - transform.position

                float InputX = playerPos.position.x - enemyPos.position.x;
                if (InputX > 0)
                    transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                else if (InputX < 0)
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

 
        //---------------------------------------------------------


        // determine flash time
        if (hurtAmount <= 0 )
            sp.material.SetFloat("_FlashAmount", 0);
        else
            hurtAmount -= Time.deltaTime;

        if (health < 1)
        {
            
            enemyRBs.Remove(rb);
            // deathAnimator.SetInteger("AnimState", 1);             
            Destroy(gameObject);
        }
    }

    // attack player
    private void OnCollisionStay2D(Collision2D other){
        if(other.gameObject.tag == "Player"){
            if(attackSpeed <= canAttack){
                // attackAnimator.Play("Attack");
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }else{
                canAttack += Time.deltaTime;
            }
        }
    }

    // get injured after bullet shooting inside enemy
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet") 
        {
            // Vector2 difference = other.transform.position - transform.position;  //  repel angel
            // gameObject.transform.position = new Vector2(gameObject.transform.position.x + difference.x, 
            //     gameObject.transform.position.y + difference.y); //repel distance

            health -= GameObject.Find("Player").GetComponent<PlayerMovement>().currentWeapon.damage;
            HurtShader();
            Destroy(other.gameObject);
        }
        
    }

    private void HurtShader() //object flash after hurted
    {
        sp.material.SetFloat("_FlashAmount", 1); 
        hurtAmount = hurtLength; //control flash time length by control "hurtLength"
    }

}

