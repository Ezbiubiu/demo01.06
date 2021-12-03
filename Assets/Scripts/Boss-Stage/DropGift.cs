using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropGift : MonoBehaviour
{
    public GameObject[] gos;


    public void getGift()
    {
        Vector3 pos = transform.position;
        Instantiate(gos[Random.Range(0, gos.Length)], pos, Quaternion.identity);
        // GlobalControl.Instance.level++;
        //Debug.Log("level" + GlobalControl.Instance.level);
    }
}
