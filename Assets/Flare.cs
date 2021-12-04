using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flare : MonoBehaviour
{

    public float damage = 5;


//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // health -= GameObject.Find("Player").GetComponent<PlayerMovement>().currentWeapon.damage;
            GlobalControl.Instance.HP -= damage;
            Destroy(gameObject);
        }
    }

}
