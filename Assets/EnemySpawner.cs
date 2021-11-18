using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 20, time = 1.5f;

    public GameObject[] enemies;


    // Start is called before the first frame update
    void Start()
    {
        for (int n = enemies.Length; n <= 5; n ++)
            StartCoroutine(SpawnAnEnemy());
        
    }

    

    IEnumerator SpawnAnEnemy()
    {
        Vector2 spawnPos = GameObject.Find("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        // StartCoroutine(SpawnAnEnemy());

    }
}
