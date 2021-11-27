using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReward : MonoBehaviour
{
    [SerializeField] public int hp = 3;
    [SerializeField] public int goldkey = 0;
    public Text healthNum;
    public Text KeyNum;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.tag == "health")
        {
            Destroy(collision.gameObject);
            hp += 1;
            healthNum.text = hp.ToString();
        }
         if (collision.tag == "Collection")
        {
            Destroy(collision.gameObject);
            goldkey += 1;
            KeyNum.text = goldkey.ToString();
        }
    }

    void Update()
    {
        healthNum.text = hp.ToString();
        KeyNum.text = goldkey.ToString(); 
        
    }

   
}
