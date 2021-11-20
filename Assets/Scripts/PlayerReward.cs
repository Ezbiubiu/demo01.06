using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReward : MonoBehaviour
{
    [SerializeField] public int hp = 0;
    public Text healthNum;

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.tag == "health")
        {
            Destroy(collision.gameObject);
            hp += 1;
            healthNum.text = hp.ToString();
        }
    }

    void Update()
    {
        healthNum.text = hp.ToString(); // Object reference not set to an instance of an object
        
    }

   
}
