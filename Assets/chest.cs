using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chest : MonoBehaviour // prepare for opened chest!
{
    // Start is called before the first frame update

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.tag == "Player")
        {
            // Instantiate(BoxAnimator, collision.transform.position, Quaternion.identity);
            // chestCLOSE.SetActive(false);
            // chestOPEN.SetActive(true);

            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
            //boss room portal !!!
            Destroy(collision.gameObject);

        }
    }
}
