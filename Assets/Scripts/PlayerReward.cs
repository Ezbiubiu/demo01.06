using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReward : MonoBehaviour
{
    [SerializeField] public int hp;
    public Text healthNum;
    private void Start()
    {
        hp = GlobalControl.Instance.reward;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.tag == "health")
        {
            Destroy(collision.gameObject);
            hp += 1;
            healthNum.text = hp.ToString();
            GlobalControl.Instance.reward = hp;
        }
    }

    void Update()
    {
        healthNum.text = hp.ToString(); // Object reference not set to an instance of an object
        
    }

   
}
