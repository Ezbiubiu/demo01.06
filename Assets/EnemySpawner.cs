using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 3, time = .5f;

    public GameObject[] enemies;


    // Start is called before the first frame update
    public void Start()
    {
        for (int n = enemies.Length; n <= 1; n ++)
            StartCoroutine(SpawnAnEnemy());
        
    }

    

    IEnumerator SpawnAnEnemy()
    {
        Vector2 spawnPos = GameObject.Find("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        yield return new WaitForSeconds(time);
        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);

        StartCoroutine(SpawnAnEnemy());

    }
}
