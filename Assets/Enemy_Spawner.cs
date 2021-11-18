using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{

    [SerializeField]private float spawnRadius = 5, time = 2f;

    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnAnEnemy());
    }

    IEnumerator spawnAnEnemy()
    {
        Vector2 spawnPos = GameObject.Find("Player").transform .position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(spawnAnEnemy());
    }
}
