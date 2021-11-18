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

    [SerializeField]
    private int health;

    private bool hit = true;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
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

    IEnumerator HitBoxoff() 
    {
        hit = false;
        yield return new WaitForSeconds(1.5f);
        hit = true;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            // 击退效果 repel effect
            // Vector2 difference = target.transform.position - transform.position;  // 击退角度 repel angel
            // target.transform.position = new Vector2(target.transform.position.x + difference.x, target.transform.position.y + difference.y); //击退距离 repel distance
            if (hit)
            {
                StartCoroutine(HitBoxoff());
                health--;
            }
        }
    }


}
