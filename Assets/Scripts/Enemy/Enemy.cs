using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float health;

    public float MaxHealth;


    //*********** animators *****************

    public Animator animator;


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
    
    
    //*********************************
    public GameObject damageCanvas;


///////////////////////////////////
    void Awake()
    {
        health += GlobalControl.Instance.level * 5;
        sp = GetComponent<SpriteRenderer>();
        MaxHealth = health;
        attackDamage +=  GlobalControl.Instance.level *2;

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
                animator.SetInteger("AnimState", 1);
                Vector2 vt = new Vector2(playerPos.position.x - enemyPos.position.x, playerPos.position.y - enemyPos.position.y);
                rb.velocity = vt.normalized * speed;  // playerPos.position - transform.position

                float InputX = playerPos.position.x - enemyPos.position.x;
                if (InputX > 0)
                    transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                else if (InputX < 0)
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

 
        //---------------------------------------------------------

        if (health <= 0)
            {
            //animator.SetTrigger("Death");
            //animator.Play("Death");
            animator.SetInteger("AnimState", 2);
            enemyRBs.Remove(rb);  
            Destroy(gameObject);
            }
        

        // determine flash time
        if (hurtAmount <= 0 )
            sp.material.SetFloat("_FlashAmount", 0);
        else
            hurtAmount -= Time.deltaTime;

        
    }

    // attack player
    private void OnCollisionStay2D(Collision2D other){
        if(other.gameObject.tag == "Player"){
            if(attackSpeed <= canAttack){
                animator.SetTrigger("Attack");
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
            DamageNum damagable = Instantiate(damageCanvas, other.transform.position, Quaternion.identity).GetComponent<DamageNum>();
            damagable.showDamage(Mathf.RoundToInt(GameObject.Find("Player").GetComponent<PlayerMovement>().currentWeapon.damage));

            Vector2 difference = (other.transform.position - transform.position)/(1.5f);  //  repel angel
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + difference.x, 
                gameObject.transform.position.y + difference.y); //repel distance

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
