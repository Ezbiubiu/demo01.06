using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    public float health;
    [SerializeField]
    public float maxHealth;

    public static bool gameOver;

    public GameObject gameoverPanle;

    private void Start(){
        health = GlobalControl.Instance.HP;
    }

    public void UpdateHealth(float mod){
        health += mod;

        if(health > maxHealth){
            health = maxHealth;
        }else if(health <= 0f){
            health = 0f;
            gameOver = true;
            gameoverPanle.SetActive(true); 
            health = 100f;
            Debug.Log("Player Respawn");
        }
        Debug.Log("Player saved");
        GlobalControl.Instance.HP = health;
    }    
  
}
