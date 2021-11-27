using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log("Player Respawn");
        }
        Debug.Log("Player saved");
        GlobalControl.Instance.HP = health;

    }
  
}
