using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	private Rigidbody2D RB;
	private float moveH, moveV;


	private Vector2 moveVelocity;
	public Animator animator;


	private float health;
	[SerializeField]private float moveSpeed;
	[SerializeField] private float maxHP;


	[Header("Hurt")]
    private SpriteRenderer sp;
    public float hurtLength; //flash hold time
    private float hurtAmount; // counter 

	private void Start()
	{
		health = maxHP;
		RB = GetComponent<Rigidbody2D>();
		sp = GetComponent<SpriteRenderer>();
	}

	 void Update()
	{
		// if (Input.GetMouseButtonDown(0))
        // 	Instantiate(bullet, transform.position, Quaternion.identity);
		if (hurtAmount <= 0 )
            sp.material.SetFloat("_FlashAmount", 0);
        else
            hurtAmount -= Time.deltaTime;
	}



//flip character and flip animator  
	void FixedUpdate()
	{
		Movement();

		animator.SetFloat("Horizontal", moveVelocity.x);
        animator.SetFloat("Vertical", moveVelocity.y);
        animator.SetFloat("Speed", moveVelocity.sqrMagnitude);
	}



//character movement and 
	void Movement() 
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * moveSpeed;
        RB.MovePosition(RB.position + moveVelocity * Time.fixedDeltaTime);

    }

    void Rotation()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
    }


	
    public void takenDamage(float _amount)
    {
        health -= _amount;
        HurtShader();
        if(health <= 0)
            Destroy(gameObject);
    }

	
    private void HurtShader() //受伤闪光 object flash after hurted
    {
        sp.material.SetFloat("_FlashAmount", 1); 
        hurtAmount = hurtLength; //可调节闪光时间 control flash time length by control "hurtLength"
    }
	





}

