using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    public float health;
    [SerializeField]
    public float maxHealth;

    private void Start(){
        health = GlobalControl.Instance.HP;
    }

    public void UpdateHealth(float mod){
        health += mod;

        if(health > maxHealth){
            health = maxHealth;
        }else if(health <= 0f){
            health = 0f;
            GlobalControl.Instance.HP = health;

            if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);
                Destroy(gameObject);
            }
            if(SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
                Destroy(gameObject);
            }
        }
        //Debug.Log("Player saved");


    }
  
}
