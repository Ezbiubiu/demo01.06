using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropGift : MonoBehaviour
{
    public GameObject[] gos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getGift()
    {
        Vector3 pos = transform.position;
        Instantiate(gos[Random.Range(0, gos.Length)], pos, Quaternion.identity);
        GlobalControl.Instance.level++;
        //Debug.Log("level" + GlobalControl.Instance.level);
        Destroy(gameObject);
    }
}
