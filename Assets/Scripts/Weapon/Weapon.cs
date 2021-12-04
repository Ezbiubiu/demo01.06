using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon", menuName ="Weapon")]
public class Weapon : ScriptableObject
{

    public Sprite currentWeaponSpr;

    public GameObject bulletPrefab;

    public float fireRate = 1;

    public float damage = 20;


    void Update()
    {
       damage += GlobalControl.Instance.level;
    }
    public void Shoot()
    {
        Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position,Quaternion.identity);
    }
    // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
}
