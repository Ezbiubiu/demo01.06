using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    public float health;
    [SerializeField]
    public float maxHealth;
    public Text healthNum;


    private void Start(){

        //GlobalControl.Instance.HP += GlobalControl.Instance.level * 10;

        //if (maxHealth >= GlobalControl.Instance.HP)
        //    GlobalControl.Instance.HP = maxHealth;
 
        health = GlobalControl.Instance.HP;
        maxHealth = GlobalControl.Instance.MaxHP;
        healthNum.text = health.ToString();
    }

    public void UpdateHealth(float mod){
        health += mod;
        GlobalControl.Instance.HP = health;
        healthNum.text = health.ToString();
        //GlobalControl.Instance.HP += GlobalControl.Instance.level * 10;

        //maxHealth += GlobalControl.Instance.HP;
        //Debug.Log("max health changed");

        if (health > maxHealth){
            health = maxHealth;
            GlobalControl.Instance.HP = health;
        }
        else if(health <= 0f){
            health = 0f;
            GlobalControl.Instance.HP = health;

            if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);
                // Destroy(gameObject);
            }
            if(SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
                // Destroy(gameObject);
            }
        }
        //Debug.Log("Player saved");


    }
  
}
