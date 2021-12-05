using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerReward : MonoBehaviour
{
    [SerializeField] 
    public int key;
    public Text KeyNum;
    private PlayerHealth playerHealth;
    public int level;
    public Text levelNum;

    //************* text shown **************************
    public GameObject congrats;
    public GameObject startDialog;

    public GameObject bossText;
    
    
    

// //********************************************
//     public GameObject chestCLOSE;
//     public GameObject chestOPEN;

//     bool openBox = false;


    // public GameObject textTransfer;

    
    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        // key = GlobalControl.Instance.reward;
        level = GlobalControl.Instance.level;

        if(SceneManager.GetActiveScene().buildIndex == 1){
            if (GlobalControl.Instance.level == 0){
                startDialog.SetActive(true);
            }
            else if (GlobalControl.Instance.level >=1 ){
                congrats.SetActive(true);
                
            }

        }else if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            if(GlobalControl.Instance.level == 0)
                bossText.SetActive(true);
        }

    }
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.tag == "health")
        {
            Destroy(collision.gameObject);
            playerHealth.health += 5;
            playerHealth.healthNum.text = playerHealth.health.ToString();
            
            GlobalControl.Instance.HP = playerHealth.health;
            if (playerHealth.health > playerHealth.maxHealth)
            {
                playerHealth.health = playerHealth.maxHealth;
                GlobalControl.Instance.HP = playerHealth.health;
                playerHealth.healthNum.text = playerHealth.health.ToString();
            }

            //hp += 1;
            //healthNum.text = hp.ToString();
            //GlobalControl.Instance.reward = hp;
        }
        if (collision.tag == "Collection")
        {
            Destroy(collision.gameObject);
            key += 1;
            KeyNum.text = key.ToString();
            // GlobalControl.Instance.reward = key;
        }

        // if (collision.tag == "BossPortal")
        // {
            

            // Instantiate(BoxAnimator, collision.transform.position, Quaternion.identity);
            // chestCLOSE.SetActive(false);
            // chestOPEN.SetActive(true);

            // Destroy(chestCLOSE);
            // chestCLOSE.SetActive(false);
            // boxOpened();


            // if(openBox == true)
            // {
            //     textTransfer.SetActive(true);
            //     // Instantiate(BoxAnimator, collision.transform.position, Quaternion.identity);

            //     if (Input.GetKeyDown(KeyCode.B))
            //     {
            //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
            //         //boss room portal !!!
            //         Destroy(collision.gameObject);

            //     }

                // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
                //boss room portal !!!
        //     }

        // }


        // void boxOpened()
        // {
        //     Vector3 chestPos = chestCLOSE.transform.position;
        //     Instantiate(chestOPEN, chestPos, Quaternion.identity);
        //     openBox = true;
        // }

        // if (collision.tag == "chestOpen")
        // {
        //     textTransfer.SetActive(true);
        //     // Instantiate(BoxAnimator, collision.transform.position, Quaternion.identity);

        //     if (Input.GetKeyDown(KeyCode.I))
        //     {
        //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        //         //boss room portal !!!
        //         Destroy(collision.gameObject);

        //     }

        // }

    }

    void Update()
    {
        KeyNum.text = key.ToString();
        levelNum.text = level.ToString();
        
        
    }
   
}
