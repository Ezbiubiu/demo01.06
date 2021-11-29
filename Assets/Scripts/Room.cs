using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public GameObject doorLeft, doorRight, doorUp, doorDown;
    public bool roomLeft, roomRight, roomUp, roomDown;//check if there is room beside
    public int stepToStart;
    public Text text;
    public int doorNumber;



//****************Enemy Spawner***********************************************
    [SerializeField]
    private float spawnRadius = 4, time = 15.5f;

    public GameObject[] enemies;



    // Start is called before the first frame update
    void Start()
    {
        doorLeft.SetActive(roomLeft);
        doorRight.SetActive(roomRight);
        doorUp.SetActive(roomUp);
        doorDown.SetActive(roomDown);

        
    }

    public void UpdateRoom(float xOffset, float yOffset)
    {
        
        stepToStart = (int)(Mathf.Abs(transform.position.x / xOffset) + Mathf.Abs(transform.position.y / yOffset));

        text.text = stepToStart.ToString();

        if (roomUp)
            doorNumber++;
        if (roomDown)
            doorNumber++;
        if (roomLeft)
            doorNumber++;
        if (roomRight)
            doorNumber++;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            CameraPos.instance.ChangeTarget(transform);
            // GetComponent<EnemySpawner>().Start();
            for (int n = enemies.Length; n <= 3; n ++)
                StartCoroutine(SpawnAnEnemy());
        }

    }


    IEnumerator SpawnAnEnemy()
    {
        Vector2 spawnPos = gameObject.transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        yield return new WaitForSeconds(time);
        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);

        // StartCoroutine(SpawnAnEnemy());

    }

}
