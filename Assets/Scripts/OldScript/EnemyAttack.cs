using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField]
    private float attackDamage = 10f;
    [SerializeField]
    private float attackSpeed = 1f;
    private float canAttack;

    private Animator  animator;

    private void OnCollisionStay2D(Collision2D other){
        if(other.gameObject.tag == "Player"){
            if(attackSpeed <= canAttack){
                animator.SetTrigger("Attack");
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }else{
                canAttack += Time.deltaTime;
            }
        }
    }
}
