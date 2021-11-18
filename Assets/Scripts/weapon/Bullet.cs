using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]private float attackDamage; 

    [SerializeField]public float speed;

    // public GameObject explosionPrefab;

    new private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    public void SetSpeed(Vector2 direction)
    {
        rigidbody.velocity = direction * speed;
    }


    private void onTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<enemy>().takenDamage(attackDamage); //攻击掉血 lose blood after got hurt
            // 击退效果 repel effect
            Vector2 difference = other.transform.position - transform.position;  // 击退角度 repel angel
            other.transform.position = new Vector2(other.transform.position.x + difference.x, other.transform.position.y + difference.y); //击退距离 repel distance
        }
        // Instantiate(explosionPrefab,transform.position, Quaternion.identity);
        // Destroy(gameObject);
    }

    // private void OnCollisionEnter2D(Collider2D other) // test for collider is working or not， collider 并未正常工作
    // {
    //     if(other.gameObject.tag == "Enemy")
    //     {
    //         Destroy(gameObject);
    //     }
    // }
}
