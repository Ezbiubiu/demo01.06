using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReward : MonoBehaviour
{
    [SerializeField] 
    public int key;
    public Text KeyNum;
    private PlayerHealth playerHealth;
    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        // key = GlobalControl.Instance.reward;

    }
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.tag == "health")
        {
            Destroy(collision.gameObject);
            playerHealth.health += 5;
            GlobalControl.Instance.HP = playerHealth.health;
            //hp += 1;
            //healthNum.text = hp.ToString();
            //GlobalControl.Instance.reward = hp;
        }
        if (collision.tag == "Collection")
        {
            Destroy(collision.gameObject);
            key += 1;
            KeyNum.text = key.ToString();
            // GlobalControl.Instance.reward = key;
        }

        if (collision.tag == "BossPortal")
        {
            //boss room portal !!!
            Destroy(collision.gameObject);

        }
    }

    void Update()
    {
        KeyNum.text = key.ToString(); // Object reference not set to an instance of an object！！！！！！！！！！！！！！！！
        
    }

   
}
