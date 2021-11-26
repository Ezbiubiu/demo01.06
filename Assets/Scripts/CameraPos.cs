using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    public static CameraPos instance;
    public float speed;
    public Transform target;

    // public GameObject enemySpawnPrefab;

    private void Awake()
    {
        instance = this;
        // enemySpawnPrefab = EnemySpawner.s
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position,new Vector3(target.position.x,target.position.y,transform.position.z),speed*Time.deltaTime);

        }
        
    }
    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
    }

}
