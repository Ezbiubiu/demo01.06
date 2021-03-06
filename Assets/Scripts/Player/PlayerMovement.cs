using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Weapon currentWeapon;

    private float nextTimeOfFire = 0;

    private Rigidbody2D rb;

    public float speed;

    private Vector2 moveVelocity;

    public Animator animator;

    public GameObject bullet;

    //[SerializeField]
    //private int health;

    //private bool hit = true;



    [Header("Hurt")]
    private SpriteRenderer sp;
    public float hurtLength; //flash hold time
    private float hurtAmount; // counter 
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = currentWeapon.currentWeaponSpr;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();

        animator.SetFloat("Horizontal", moveVelocity.x);
        animator.SetFloat("Vertical", moveVelocity.y);
        animator.SetFloat("Speed", moveVelocity.sqrMagnitude);

    }

    private void Update()
    {
        if (hurtAmount <= 0 )
            sp.material.SetFloat("_FlashAmount", 0);

        if (Input.GetMouseButton(0)) 
        {
            if (Time.time >= nextTimeOfFire)
            {
                currentWeapon.Shoot();
                nextTimeOfFire = Time.time + 1 / currentWeapon.fireRate;
            }
        }
        //Shoot 
        //if (Input.GetMouseButtonDown(0))
        //    Instantiate(bullet, transform.position, Quaternion.identity);

    }

    void Movement() 
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

    }

    // IEnumerator HitBoxoff() 
    // {
    //     hit = false;
    //     yield return new WaitForSeconds(1.5f);
    //     hit = true;
    // }

    // private void OnTriggerEnter2D (Collider2D target)
    // {
    //     if (target.tag == "Enemy")
    //     {
    //         //???????????? repel effect
    //         Vector2 difference = target.transform.position - transform.position;  // ???????????? repel angel
    //         gameObject.transform.position = new Vector2(gameObject.transform.position.x + difference.x, gameObject.transform.position.y + difference.y); //???????????? repel distance
    //         if (hit)
    //         {
                
    //             if(health >= 1)
    //             {
    //                 StartCoroutine(HitBoxoff());
    //                 health--;
    //                 HurtShader(); // BUG: will become "COLOR:PINK" for all the time after get hit by once!!!
    //             }else{
    //                 Destroy(gameObject); //Player has been killed
    //             }
    //         }
    //     }
    // }

    // private void HurtShader() //???????????? object flash after hurted
    // {
    //     sp.material.SetFloat("_FlashAmount", 1); 
    //     hurtAmount = hurtLength; //????????????????????? control flash time length by control "hurtLength"
    // }


}
